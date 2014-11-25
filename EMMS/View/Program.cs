using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EMMS.View
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new EMMS.View.MainWindow());

            //Sytem.Theading.Mutex对象，该对象用于解决多线程操作中的互斥问题
            bool createNew;
            using (System.Threading.Mutex m = new System.Threading.Mutex(true, Application.ProductName, out createNew))
            {
                if (createNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new EMMS.View.MainWindow());
                }
                else
                {
                    MessageBox.Show("已经启动了一个应用程序！","警告");
                }
            } 
        }
    }
}
