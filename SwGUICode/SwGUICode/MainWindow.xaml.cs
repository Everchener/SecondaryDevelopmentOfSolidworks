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

namespace SwGUICode {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        private ISwApplication swApp;

        private void ConnectToSw(object sender, RoutedEventArgs e) {
            var swProcess = Process.GetProcessesByName("SLDWORKS");
            if (!swProcess.Any()) {
                msgbox.Text = "你还没打开sw";
            } else {
                swApp = SwApplicationFactory.FromProcess(swProcess.First());
                msgbox.Text = "你使用的是版本是：" + swApp.Version.Major.ToString();
            }
        }

        private void ClickForPart(object sender, RoutedEventArgs e) {
            ClickForNew(swUserPreferenceStringValue_e.swDefaultTemplatePart);
        }

        private void ClickForAssembly(object sender, RoutedEventArgs e) {
            ClickForNew(swUserPreferenceStringValue_e.swDefaultTemplateAssembly);
        }

        private void ClickForDrawing(object sender, RoutedEventArgs e) {
            ClickForNew(swUserPreferenceStringValue_e.swDefaultTemplateDrawing);
        }

        private void ClickForNew(swUserPreferenceStringValue_e swDefaultTemplateType) {
            //判断
            if (swApp == null) {
                msgbox.Text = "还未连接SW";
                return;
            }

            var swTemplate = swApp.Sw.GetUserPreferenceStringValue((int)swDefaultTemplateType);
            if (!File.Exists(swTemplate)) {
                msgbox.Text = "无默认模板";
                return;
            }
            var doc = swApp.Sw.INewDocument2(swTemplate, 0, 400, 600);
        }
        //打开文件可以用swApp.Sw.OpenDoc7()方法进行打开，不过想实现打开选定路径文档还是得摸索
        //看看能不能用msgbox接收文件路径如何作为参数传递达成打开特定路径文档

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

        //遍历特征的按钮捆绑事件
        private void TraverseFeatureClick(object sender, EventArgs e) {
            if (swApp == null) {
                msgbox.Text = "还未连接SW";
                return;
            }
            IModelDoc2 swModel = (IModelDoc2)swApp.Sw.ActiveDoc;
            if (swModel == null) {
                msgbox.Text = "你还未打开零件";
                return;
            }
            //第一个特征
            Feature swFeat = (Feature)swModel.FirstFeature();
            //遍历
            TraverseFeatures(swFeat, true);
        }

        // 遍历特征
        public static void TraverseFeatures(Feature thisFeat, bool isTopLevel, bool isShowDimension = false) {
            Feature curFeat = default(Feature);
            curFeat = thisFeat;

            bool isFeature = false;
            while ((curFeat != null)) {
                Feature nextFeat = default(Feature);
                if (isTopLevel) {
                    nextFeat = (Feature)curFeat.GetNextFeature();
                } else {
                    nextFeat = null;
                }

                //把Orgin之前的特征全部除去
                if (curFeat.Name == "Origin") {
                    isFeature = true;
                    curFeat = nextFeat;
                    nextFeat = null;
                    continue;
                }
                if (isFeature == false) {
                    curFeat = nextFeat;
                    nextFeat = null;
                    continue;
                }

                //输出特征名称
                Debug.Print(curFeat.Name);
                
                //输出可编辑尺寸
                if (isShowDimension == true) ShowDimensionForFeature(curFeat);

                Feature subfeat = default(Feature);
                subfeat = (Feature)curFeat.GetFirstSubFeature();

                //遍历特征中的特征
                while ((subfeat != null)) {
                    TraverseFeatures(subfeat, false);
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

        //获取可编辑尺寸
        public static void ShowDimensionForFeature(Feature feature) {
            var thisDisplayDim = (DisplayDimension)feature.GetFirstDisplayDimension();

            while (thisDisplayDim != null) {
                var dimen = (Dimension)thisDisplayDim.GetDimension();

                Debug.Print($"---特征 {feature.Name} 尺寸-->" + dimen.GetNameForSelection() + "-->" + dimen.Value);

                thisDisplayDim = (DisplayDimension)feature.GetNextDisplayDimension(thisDisplayDim);
            }
        }

        //获取用户选择：不知道怎么将其与特征(划掉，应该是草图中去获取尺寸)联系起来
        private void GetSelectionClick(object sender, EventArgs e) {
            if (swApp == null) {
                msgbox.Text = "还未连接SW";
                return;
            }
            IModelDoc2 swModel = (IModelDoc2)swApp.Sw.ActiveDoc;
            if (swModel == null) {
                msgbox.Text = "你还未打开零件";
                return;
            }

            //获取选择管理器
            var seleMgr = swModel.ISelectionManager;
            //获取选择的数量
            var seleCount = seleMgr.GetSelectedObjectCount2(-1);

            if (seleCount < 1) {
                swApp.ShowMessageBox("当前没有选择任何东西");
                return;
            }

            List<string> data = new List<string>(seleCount);

            //遍历获取选择信息并以string类型传递给data
            for (int i = 1; i <= seleCount; i++) {
                var seleMark = seleMgr.GetSelectedObjectMark(i);
                var seleType = seleMgr.GetSelectedObjectType3(i, seleMark);
                var seleObj = (Feature)seleMgr.GetSelectedObject6(i, seleMark);
                var selePosition = seleMgr.GetSelectionPoint2(i, seleMark) as double[];
                //很神奇的一点是这个只能获取点线面而不能获取长度这样的抽象选择
                ShowDimensionForFeature(seleObj);//这样就可以获取特征了
                //var info = $"Index:{i},Mark:{seleMark},Type:{(swSelectType_e)seleType},Position:{selePosition[0]}{selePosition[1]}{selePosition[2]} ";
                //data.Add(info);
            }
            //SelctionBox.ItemsSource = data;
            //msgbox.Text = "选择对象导出成功";
        }
    }
}



