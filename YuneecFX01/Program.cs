using System;
using System.Threading;
using System.Windows.Forms;
using YuneecFX01.system;
using YuneecFX01.tool;
using YuneecFX01.Window;

namespace YuneecFX01
{
    internal static class Program
    {
        public static object OneInstance { get; private set; }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //初始化全局数据模型

            //初始化sqlite数据库
            sysFunction.initApplication();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (instance.IsFirst("YuneecFX01.exe"))
            {
                sysLog.Info("system startup.");
                Application.Run(new formMain());
            }
            else
            {
                MessageBox.Show("软件已经启动！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }           
            
        }
    }
}
