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

namespace SolidworksProgram {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        private ISwApplication swApp;

        //连接sw
        private void ConnectToSw(object sender, RoutedEventArgs e) {
            var swProcess = Process.GetProcessesByName("SLDWORKS");
            if (!swProcess.Any()) {
                msgbox.Text = "你还没打开sw";
            } else {
                swApp = SwApplicationFactory.FromProcess(swProcess.First());
                msgbox.Text = "你使用的是版本是：" + swApp.Version.Major.ToString();
            }
        }

        //打开文件
        private void OpenFile(object sender, RoutedEventArgs e) {
            string path = msgbox.Text;
            if (swApp == null) {
                msgbox.Text = "还未连接SW";
                return;
            }
            if (!File.Exists(path)) {
                swApp.ShowMessageBox("文件不存在");
                return;
            }
            int errors = 0;
            int warnings = 0;
            var OpenDoc = swApp.Sw.OpenDoc6(path, (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref errors, ref warnings);

            if (OpenDoc == null) {
                swApp.ShowMessageBox($" {path} 打开失败啦，错误代码:{errors}");
                return;
            }
            //ISwApplication.Sw中的方法大多都是有关SW的基本方法
            //对于方法的理解还得多翻API帮助文档
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

        public class armSource {
            //权限暂且不管，要么全弄成private弄getter setter，要么全是public
            public double armValue;
            public string featureName;
            public string armName;
            public double optArmValue = 0;
            public armSource() { }
            public armSource(double armValue, string featureName, string armName) {
                this.armValue = armValue;
                this.featureName = featureName;
                this.armName = armName;
            }
            public override string ToString() {
                return $"---特征 {featureName} 尺寸-->" + armName + "-->" + armValue;
            }
        }

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
                    maxDimension = dimen;
                }
                //Debug.Print($"---特征 {feature.Name} 尺寸-->" + dimen.GetNameForSelection() + "-->" + dimen.Value);
                thisDisplayDim = (DisplayDimension)feature.GetNextDisplayDimension(thisDisplayDim);
            }
        }

        List<armSource> armSources = new List<armSource>();
        double maxValue = 0;
        Dimension maxDimension = null;

        List<Dimension> dimenAddr = new List<Dimension>();
        //获取用户选择
        private void GetSelectionClick(object sender, EventArgs e) {
            msgbox.Text = "正在获取请稍等";
            if (swApp == null) {
                msgbox.Text = "还未连接SW";
                return;
            }
            IModelDoc2 swModel = (IModelDoc2)swApp.Sw.ActiveDoc;
            if (swModel == null) {
                msgbox.Text = "你还未打开文件";
                return;
            }

            //获取选择管理器
            var seleMgr = swModel.ISelectionManager;
            //获取选择的数量
            var seleCount = seleMgr.GetSelectedObjectCount2(-1);

            if (seleCount < 1) {
                msgbox.Text = "当前没有选择任何东西";
                return;
            }
            if (isPartDoc) {
                for (int i = 1; i <= seleCount; i++) {
                    if (armCount >= 3) {
                        msgbox.Text = "已录入三组机械臂长度信息,请使用清除重新录入";
                        return;
                    }
                    var seleMark = seleMgr.GetSelectedObjectMark(i);
                    var seleType = seleMgr.GetSelectedObjectType3(i, seleMark);
                    if (seleType != 20) {
                        msgbox.Text = $"你选择的不是零件，无法获取尺寸：{seleType}";
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
                    SelctionBox.Items.Add(source.ToString());
                    maxValue = 0;
                    maxDimension = null;
                    msgbox.Text = "获取成功";
                    //Debug.Print(dimenAddr.Count().ToString());
                }
            } else {
                for (int i = 1; i <= seleCount; i++) {
                    if (armCount >= 3) {
                        msgbox.Text = "已录入三组机械臂长度信息,请使用清除重新录入";
                        return;
                    }
                    var seleMark = seleMgr.GetSelectedObjectMark(i);
                    var seleType = seleMgr.GetSelectedObjectType3(i, seleMark);
                    if (seleType != 14) {
                        msgbox.Text = $"你选择的不是尺寸，无法获取数值：{seleType}";
                        continue;
                    }
                    var seleDisDimen = (DisplayDimension)seleMgr.GetSelectedObject6(i, seleMark);
                    var seleDimen = (Dimension)seleDisDimen.GetDimension();
                    //seleDimen.Value = seleDimen.Value + 2;
                    dimenAddr.Add(seleDimen);
                    armSource source = new armSource(seleDimen.Value, seleDimen.GetFeatureOwner().Name, seleDimen.GetNameForSelection());
                    armSources.Add(source);
                    armCount++;
                    SelctionBox.Items.Add(source.ToString());
                    msgbox.Text = "获取成功";
                }
            }
        }

        bool isPartDoc;
        private void ChoosePartDoc(object sender, RoutedEventArgs e) {
            isPartDoc = true;
        }

        private void ChooseDimension(object sender, RoutedEventArgs e) {
            isPartDoc = false;
        }

        double[] comArmLength = new double[3];
        private void ComfirmClick(object sender, RoutedEventArgs e) {
            if (swApp == null) {
                msgbox.Text = "还未连接SW";
                return;
            }
            if (armCount != 3) {
                msgbox.Text = "你还没选择够三个零件哦";
                return;
            }
            int i = 0;
            foreach (armSource arm in armSources) {
                comArmLength[i] = arm.armValue;
                i++;
            }
            //msgbox.Text = $"{comArmLength[0]},{comArmLength[1]},{comArmLength[2]}";
            OptimizeFunction();
            msgbox.Text = "优化完成";
        }

        private void EmptyClick(object sender, RoutedEventArgs e) {
            armSources.Clear();
            SelctionBox.Items.Clear();
            armCount = 0;
            msgbox.Text = "清除成功啦";
        }

        private void CorrectClick(object sender, RoutedEventArgs e) {

        }

        private void OptimizeFunction() {
            for (int i = 0; i < dimenAddr.Count; i++) {
                dimenAddr[i].Value = armSources[i].armValue + 10;
            }
        }
    }
}



