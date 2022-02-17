using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SolidworksProgram {
    /// <summary>
    /// optWaitWin.xaml 的交互逻辑
    /// </summary>
    public partial class optWaitWin : Window {
        public optWaitWin() {
            InitializeComponent();
        }
        CancellationTokenSource cts = new CancellationTokenSource();

        private void timeOpt(object sender, RoutedEventArgs e) {
            var ct = cts.Token;
            Task.Factory.StartNew(() => {
                int theTime = 0;
                for (; ; ) {
                    theTime++;
                    this.Dispatcher.Invoke(() => {
                        TimeBlock.Text = $"{theTime}秒";
                    });
                    Thread.Sleep(1000);
                }
            }, ct);
        }

        private void MiniWinClick(object sender, RoutedEventArgs e) {
            WindowState = WindowState.Minimized;
            this.Owner.WindowState = WindowState.Minimized;
        }

        private void CloseWinClick(object sender, RoutedEventArgs e) {
            optMsg.Text = "你确定要停止优化吗？（当前所花时间：）";
            button1.Content = "确定";
            button2.Content = "取消";
            button1.Click += CloseClick;
            button1.Click -= MiniWinClick;
            button2.Click -= CloseWinClick;
            button2.Click += CancelClick;
        }

        private void CloseClick(object sender, RoutedEventArgs e) {
            try {
                cts.Cancel();
            } catch (Exception) {
                throw;
            } finally {
                Owner.Close();
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e) {
            optMsg.Text = "正在优化，请勿关闭窗口，优化所进行时间为：";
            button1.Content = "最小化窗口";
            button2.Content = "强制关闭窗口";
            button1.Click -= CloseClick;
            button1.Click += MiniWinClick;
            button2.Click += CloseWinClick;
            button2.Click -= CancelClick;
        }
    }
}
