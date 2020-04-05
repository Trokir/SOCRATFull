using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Log;
using Socrat.Log.Enums;

namespace Socrat.Startup
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //Инициация лога
                Log.Core.SqlHelper.ConnectionString = Properties.Settings.Default.ConnectStr;
                Logger.Ini("Socrat.Startup", LogPlace.Sql);
                Logger.AddStart();

                try
                {
                    DevExpress.UserSkins.BonusSkins.Register();
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                    //Инициация менеджера приложения
                    AppMain.Init();
                    Logger.ShowMessageMethod = AppMain.MainForm.ShowErrorLogMessage;
                    Application.Run(AppMain.MainForm);
                }
                catch (Exception ex)
                {
                    Logger.AddErrorEx("Socrat.Startup", ex);
                }


                Logger.AddFinish();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
