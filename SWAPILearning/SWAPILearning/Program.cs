using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xarial.XCad.SolidWorks;
/*
 * 创建应用捕获进程，使用Diagnostics包中的Process对象中的方法捕获进程
 * 通过SwApplicationFactory可以创建进程和获取进程信息
 * 
 * BUG1：无法捕获以管理员权限打开的SW进程
 * 解决：win10环境下需要保持Solidworks 和Visual studio 用同样的权限启动。同时管理员或者同时一般用户
 */

namespace SWAPILearning {
    class Program{
        static void Main(string[] args){
            var swProcess = Process.GetProcessesByName("SLDWORKS");//捕获进程
            if (!swProcess.Any()){
                Console.WriteLine("SW没有被打开");
                Console.ReadKey();
                var swApp = SwApplicationFactory.Create(Xarial.XCad.SolidWorks.Enums.SwVersion_e.Sw2018);//创建对象
                swApp.ShowMessageBox("Hello SolidWorks");
            } else {
                var swApp = SwApplicationFactory.FromProcess(swProcess.First());//获取进程中的对象
                swApp.ShowMessageBox("Hello SolidWorks");
                Console.WriteLine("成功捕获进程");
                Console.ReadKey();
            }
        }
    }
}
