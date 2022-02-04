using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace SolidworksProgram {
    /// <summary>
    /// CorrectWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CorrectWindow : Window {
        public CorrectWindow() {
            InitializeComponent();
        }

        public void ComfirmCorrectClick(object sender, RoutedEventArgs e) {
            double optValue;
            try {
                optValue =  double.Parse(CorrectValueBox.Text);
            } catch {
                Thread thread1 = new Thread(new ThreadStart(EmptyTheBox));
                Thread thread2 = new Thread(new ThreadStart(Warning));
                thread1.Start();
                thread2.Start();
                return;
            }
            //Debug.Print(MainWindow.seleID.ToString());
            int seleID = MainWindow.seleID;
            MainWindow.armSources[seleID].optArmValue = optValue;
            Close();
        }

        private void Warning() {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new Action(
                        delegate {
                            CorrectValueBox.Text = "输入的不是数值，请重新输入";
                        }
                    )
                );
        }

        private void EmptyTheBox() {
            Dispatcher.BeginInvoke(DispatcherPriority.Background,
                new Action(
                    delegate {
                        Thread.Sleep(2000);
                        CorrectValueBox.Clear();
                    }
                )
            );
        }

        private void ExitClick(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
