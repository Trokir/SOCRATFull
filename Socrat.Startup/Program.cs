using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Socrat.Core.DI;
using Socrat.Log;
using Socrat.Log.Enums;
using Socrat.Startup.DI;

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
                //Инициализация механизма внедрения зависимостей
                CompositionRoot.Initialize(new DependencyModule());
                
                //Инициация лога
                Log.Core.SqlHelper.ConnectionString = SocratConnection.CnnStr;
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

                    Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
                    CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("ru-RU");
                    CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("ru-RU");

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
