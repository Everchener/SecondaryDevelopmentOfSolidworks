using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xarial.XCad.SolidWorks;
using SolidWorks.Interop.swconst;
using System.IO;
using SolidWorks.Interop.sldworks;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Threading;
using System.Threading;
using MLApp;
using MathWorks.MATLAB;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using System.ComponentModel;
using System.Media;

namespace SolidworksProgram {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        private ISwApplication swApp;
        private BackgroundWorker backgroundWorker;

        //连接sw
        private void ConnectToSw(object sender, RoutedEventArgs e) {
            var swProcess = Process.GetProcessesByName("SLDWORKS");
            if (!swProcess.Any()) {
                SystemSounds.Exclamation.Play();
                msgbox.Text = "你还没打开sw";
            } else {
                swApp = SwApplicationFactory.FromProcess(swProcess.First());
                msgbox.Text = "你使用的是版本是：" + swApp.Version.Major.ToString();
            }
        }

        // 遍历特征
        public void TraverseFeatures(Feature thisFeat, bool isTopLevel, armSource source) {
            Feature curFeat = default(Feature);
            curFeat = thisFeat;

            while ((curFeat != null)) {
                Feature nextFeat = default(Feature);
                if (isTopLevel) {
                    nextFeat = (Feature)curFeat.GetNextFeature();
                } else {
                    nextFeat = null;
                }
                //输出特征名称(调试用)
                //Debug.Print(curFeat.Name);
                //输出可编辑尺寸
                ShowDimensionForFeature(curFeat, source);

                Feature subfeat = default(Feature);
                subfeat = (Feature)curFeat.GetFirstSubFeature();

                //遍历特征中的特征
                while ((subfeat != null)) {
                    TraverseFeatures(subfeat, false, source);
                    Feature nextSubFeat = default(Feature);
                    nextSubFeat = (Feature)subfeat.GetNextSubFeature();
                    subfeat = nextSubFeat;
                    nextSubFeat = null;
                }

                subfeat = null;

                //将下个特征转移到curFeat变量中
                curFeat = nextFeat;
                nextFeat = null;
            }
        }

        //armSourse对象
        public class armSource {
            //权限暂且不管，要么全弄成private弄getter setter，要么全是public
            public double armValue;
            public string featureName;
            public string armName;
            public double optArmValue;
            public armSource() { }
            public armSource(double armValue, string featureName, string armName) {
                this.armValue = armValue;
                this.featureName = featureName;
                this.armName = armName;
            }
            public override string ToString() {
                return $"---特征 {featureName} -->" + armName + "尺寸-->" + armValue;
            }
        }

        //已经保存了的数据数量
        int armCount = 0;

        //智能（本质取最大值）获取机械臂该更改的长度并返回到source对象中
        public void ShowDimensionForFeature(Feature feature, armSource source) {
            var thisDisplayDim = (DisplayDimension)feature.GetFirstDisplayDimension();
            while (thisDisplayDim != null) {
                var dimen = (Dimension)thisDisplayDim.GetDimension();
                if (!Regex.IsMatch(dimen.GetNameForSelection(), "Sketch")) {
                    return;
                }
                if (dimen.Value > maxValue) {
                    maxValue = dimen.Value;
                    source.featureName = feature.Name;
                    source.armName = dimen.GetNameForSelection();
                    source.armValue = maxValue;
                    source.optArmValue = maxValue;
                    //保存地址
                    maxDimension = dimen;
                }
                //Debug.Print($"---特征 {feature.Name} 尺寸-->" + dimen.GetNameForSelection() + "-->" + dimen.Value);
                thisDisplayDim = (DisplayDimension)feature.GetNextDisplayDimension(thisDisplayDim);
            }
        }
        
        //创建一个list保存armSourse对象
        public static List<armSource> armSources = new List<armSource>();
        double maxValue = 0;
        Dimension maxDimension = null;
        //建立一个list储存长度对应的地址，方便更改
        List<Dimension> dimenAddr = new List<Dimension>();

        bool isSeleting = false;
        //获取用户选择
        private void GetSelectionClick(object sender, EventArgs e) {
            msgbox.Text = "正在获取请稍等";
            if (swApp == null) {
                SystemSounds.Exclamation.Play();
                msgbox.Text = "还未连接SW";
                return;
            }
            IModelDoc2 swModel = (IModelDoc2)swApp.Sw.ActiveDoc;
            if (swModel == null) {
                SystemSounds.Exclamation.Play();
                msgbox.Text = "你还未打开文件";
                return;
            }
            //获取选择管理器
            var seleMgr = swModel.ISelectionManager;
            //获取选择的数量
            var seleCount = seleMgr.GetSelectedObjectCount2(-1);
            if (seleCount < 1) {
                SystemSounds.Exclamation.Play();
                msgbox.Text = "当前没有选择任何东西";
                return;
            }
            if (isSeleting == true) {
                SystemSounds.Exclamation.Play();
                msgbox.Text = "正在进行获取选择操作，请不要使用其它功能";
                return;
            }
            Task.Factory.StartNew(() => {
                isSeleting = true;
                if (isPartDoc) {
                    for (int i = 1; i <= seleCount; i++) {
                        if (armCount >= 3) {
                            this.Dispatcher.Invoke(() => {
                                SystemSounds.Exclamation.Play();
                                msgbox.Text = "已录入三组机械臂长度信息,请使用清除重新录入";
                            });
                            Thread.Sleep(1000);
                            return;
                        }
                        var seleMark = seleMgr.GetSelectedObjectMark(i);
                        var seleType = seleMgr.GetSelectedObjectType3(i, seleMark);
                        if (seleType != 20) {
                            this.Dispatcher.Invoke(() => {
                                SystemSounds.Exclamation.Play();
                                msgbox.Text = $"你选择的不是零件，无法获取尺寸：{seleType}";
                            });
                            Thread.Sleep(1000);
                            continue;
                        }
                        armSource source = new armSource();
                        var seleObj = (IComponent2)seleMgr.GetSelectedObjectsComponent4(i, seleMark);
                        var seleObjFeature = seleObj.FirstFeature();
                        //Debug.Print(seleObj.GetID().ToString());
                        TraverseFeatures(seleObjFeature, true, source);
                        dimenAddr.Add(maxDimension);
                        armSources.Add(source);
                        armCount++;
                        this.Dispatcher.Invoke(() => {
                            SelctionBox.Items.Add(source.ToString());
                        });
                        maxValue = 0;
                        maxDimension = null;
                        //Debug.Print(dimenAddr.Count().ToString());
                    }
                } else {
                    for (int i = 1; i <= seleCount; i++) {
                        if (armCount >= 3) {
                            this.Dispatcher.Invoke(() => {
                                SystemSounds.Exclamation.Play();
                                msgbox.Text = "已录入三组机械臂长度信息,请使用清除重新录入";
                            });
                            Thread.Sleep(1000);
                            return;
                        }
                        var seleMark = seleMgr.GetSelectedObjectMark(i);
                        var seleType = seleMgr.GetSelectedObjectType3(i, seleMark);
                        if (seleType != 14) {
                            this.Dispatcher.Invoke(() => {
                                SystemSounds.Exclamation.Play();
                                msgbox.Text = $"你选择的不是尺寸，无法获取数值：{seleType}";
                            });
                            Thread.Sleep(1000);
                            continue;
                        }
                        var seleDisDimen = (DisplayDimension)seleMgr.GetSelectedObject6(i, seleMark);
                        var seleDimen = (Dimension)seleDisDimen.GetDimension();
                        dimenAddr.Add(seleDimen);
                        armSource source = new armSource(seleDimen.Value, seleDimen.GetFeatureOwner().Name, seleDimen.GetNameForSelection());
                        source.optArmValue = seleDimen.Value;
                        armSources.Add(source);
                        armCount++;
                        this.Dispatcher.Invoke(() => {
                            SelctionBox.Items.Add(source.ToString());
                        });
                    }
                }
                this.Dispatcher.Invoke(() => {
                    SystemSounds.Exclamation.Play();
                    isSeleting = false;
                    msgbox.Text = "获取完成";
                });
            });   
        }

        bool isPartDoc;//判断是不是选择零件
        private void ChoosePartDoc(object sender, RoutedEventArgs e) {
            isPartDoc = true;
        }
        private void ChooseDimension(object sender, RoutedEventArgs e) {
            isPartDoc = false;
        }

        double[] comArmLength = new double[3];//获取机械臂长度进行优化
        //确定按钮对应事件
        private void ComfirmClick(object sender, RoutedEventArgs e) {
            if (swApp == null) {
                SystemSounds.Exclamation.Play();
                msgbox.Text = "还未连接SW";
                return;
            }
            if (armCount != 3) {
                SystemSounds.Exclamation.Play();
                msgbox.Text = "你还没选择够三个零件哦";
                return;
            }
            int i = 0;
            //将arm对象中的数值提取到comArmLength数组中
            foreach (armSource arm in armSources) {
                comArmLength[i] = arm.armValue > arm.optArmValue ? arm.armValue: arm.optArmValue;
                i++;
            }
            //msgbox.Text = $"{comArmLength[0]},{comArmLength[1]},{comArmLength[2]}";
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(optFunDowork);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(optFunProcess);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(optFunComplete);
            backgroundWorker.RunWorkerAsync();
        }

        private void optFunComplete(object sender, RunWorkerCompletedEventArgs e) {
            this.Dispatcher.Invoke(new Action(() => {
                SelctionBox.Items.Clear();
                armCount = 0;
                armSources.Clear();
                SystemSounds.Exclamation.Play();
                msgbox.Text = "优化完成，请使用获取选择查看数据";
            }));
        }

        private void optFunProcess(object sender, ProgressChangedEventArgs e) {
            this.Dispatcher.Invoke(new Action(() =>{
                msgbox.Text = e.ProgressPercentage.ToString();
            }));
        }
        optWaitWin optWaitWindow = new optWaitWin();
        private void optFunDowork(object sender, DoWorkEventArgs e) {
            this.Dispatcher.Invoke(() => {
                msgbox.Text = "启动成功，开始优化";
            });
            this.Dispatcher.BeginInvoke(new Action(() => {
                optWaitWindow.Owner = this;
                optWaitWindow.Topmost = true;
                optWaitWindow.ShowDialog();
            }));
            OptimizeFunction();
            this.Dispatcher.Invoke(() => {
                optWaitWindow.Close();
            });
        }

        //清空操作
        private void EmptyClick(object sender, RoutedEventArgs e) {
            if (isSeleting == true) {
                SystemSounds.Exclamation.Play();
                msgbox.Text = "正在进行获取选择操作，请不要使用其它功能";
                return;
            }
            armSources.Clear();
            SelctionBox.Items.Clear();
            armCount = 0;
            msgbox.Text = "清除成功啦";
        }

        public static int seleID;
        //更正操作
        private void CorrectClick(object sender, RoutedEventArgs e) {
            if (swApp == null) {
                SystemSounds.Exclamation.Play();
                msgbox.Text = "还未连接SW";
                return;
            }
            if (SelctionBox.SelectedItem == null) {
                SystemSounds.Exclamation.Play();
                msgbox.Text = "当前没有选择任何数据";
                return;
            }
            //Debug.Print(SelctionBox.SelectedIndex.ToString());
            seleID = SelctionBox.SelectedIndex;
            CorrectWindow win = new CorrectWindow();
            win.Owner = this;
            win.Topmost = true;
            win.ShowDialog();
            //Debug.Print(armSources[seleID].optArmValue.ToString());
            SelctionBox.Items[seleID] =  $"---特征 {armSources[seleID].featureName} -->{armSources[seleID].armName}尺寸-->{armSources[seleID].optArmValue}";
        }

        private void OptimizeFunction() {
            //TestFun.Class1 testfun = new TestFun.Class1();
            //MWArray[] outArgs = testfun.inherFun(3, comArmLength[0], comArmLength[1], comArmLength[2]);
            inherFun.Class1 inherfun = new inherFun.Class1();
            MWArray[] outArgs = inherfun.inherFun(3, comArmLength[0], comArmLength[1], comArmLength[2]);
            MWNumericArray mol1 = outArgs[0] as MWNumericArray;
            MWNumericArray mol2 = outArgs[1] as MWNumericArray;
            MWNumericArray mol3 = outArgs[2] as MWNumericArray;
            double[,] dol1 = (double[,])mol1.ToArray();
            double[,] dol2 = (double[,])mol2.ToArray();
            double[,] dol3 = (double[,])mol3.ToArray();
            double[] afComArmLength = { dol1[0, 0], dol2[0, 0], dol3[0, 0] };
            Debug.Print(afComArmLength[0].ToString() + afComArmLength[1].ToString() + afComArmLength[2].ToString());
            for (int i = 0; i < dimenAddr.Count; i++) {
                dimenAddr[i].Value = armSources[i].armValue + (afComArmLength[i] - armSources[i].optArmValue);
            }
        }
    }
}
