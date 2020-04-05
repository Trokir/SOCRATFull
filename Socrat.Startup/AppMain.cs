using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Socrat.Lib;
using Socrat.Lib.Module;
using Socrat.Lib.UI;
using Socrat.Log;
using System.Xml.Linq;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.References.Params;

namespace Socrat.Startup
{
    /// <summary>
    /// Менеджер приложения
    /// </summary>
    public static class AppMain
    {
        /// <summary>
        /// Главная форма
        /// </summary>
        public static FxMain MainForm { get; set; }

        /// <summary>
        /// Функционал в/д с БД
        /// </summary>
        public static SqlHelper SqlHelper { get; set; }
        /// <summary>
        /// Тип отображения
        /// </summary>
        public static MainViewType ViewType { get; set; }

        /// <summary>
        /// Использовать стили для отображения
        /// </summary>
        public static bool UseStyles { get; set; }

        /// <summary>
        /// Текущий пользователь
        /// </summary>
        public static User User { get; set; }

        /// <summary>
        /// Инициация менеджера приложения
        /// </summary>
        public static void Init()
        {
            LoadViewTypeSettings();

            Logger.AddInfo("Начало аунтификации");
            if (!Authentificate())
            {
                Logger.AddError(string.Format("Попытка входа не зарегистривованого пользователя {0}", Environment.UserName));
                XtraMessageBox.Show(string.Format(
                    "Отсутствует учетная запись в программе для пользователя {0}. Обратитесь в службу поддержки Socrat",
                    Environment.UserName));
                return;
            }

            Constants.CurrentUser = User;

            Logger.AddInfo("Загрузка параметров приложения");
            AppParams.Params.Load();
            using (Socrat.Core.IRepository<Division> repo = DataHelper.GetRepository<Division>())
            {
                Guid _id;
                Guid.TryParse(AppParams.Params[ParamAlias.CurrentDivision], out _id);
                Constants.CurrentDivision = repo.GetItem(_id);
            }

            Logger.AddInfo("Построение главной формы");
            MainForm = new FxMain();
            //SqlHelper = new SqlHelper(Properties.Settings.Default.ConnectStr);
            Application.ThreadException += ApplicationOnThreadException;
            Application.ApplicationExit += ApplicationOnApplicationExit;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Logger.AddInfo("Инициация завершена");
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logger.AddErrorMsgEx(((Exception)e.ExceptionObject).Message, (Exception)e.ExceptionObject);
        }

        private static bool Authentificate()
        {
            using (var Repo = DataHelper.GetRepository<User>())
            {
                User = Repo.GetAll().FirstOrDefault(x => x.Login == Environment.UserName);
            }
            SocratEntities.User = User;
            return User != null;
        }

        private static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Logger.AddErrorMsgEx("AppMain.ApplicationOnThreadException", e.Exception);
        }

        private static void ApplicationOnApplicationExit(object sender, EventArgs e)
        {
            SaveAppSettings();
        }

        /// <summary>
        /// Вывести дочернюю форму в качестве вкладки главной формы приложения
        /// </summary>
        /// <param name="form">дочерняя форма</param>
        public static void LoadTab(ITabable form, Guid moduleId)
        {
            if (MainForm != null)
                MainForm.LoadTab(form, moduleId);
            else
                throw new Exception("Не инициирована главная форма");

        }

        /// <summary>
        /// Поиск и создание класса по наименованию
        /// </summary>
        /// <param name="FullyQualifiedNameOfClass"></param>
        /// <returns>экхемпляр класса</returns>
        public static ITabable GetFormInstance(string FullyQualifiedNameOfClass)
        {
            Type type = Type.GetType(FullyQualifiedNameOfClass);
            if (type != null)
                return (ITabable)Activator.CreateInstance(type);
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = asm.GetType(FullyQualifiedNameOfClass);
                if (type != null)
                    return (ITabable)Activator.CreateInstance(type);
            }
            return null;
        }

        /// <summary>
        /// Загрузка формы в качестве вкладки по наименованию класса формы
        /// </summary>
        /// <param name="formTypeName"></param>
        public static void LoadFormTabByName(string formTypeName, Guid moduleId, bool readOnly = false)
        {
            ITabable form = GetFormInstance(formTypeName);
            form.ReadOnly = readOnly;
            form.ModuleId = moduleId;
            if (MainForm != null)
                MainForm.LoadTab(form, moduleId);
            else
                throw new Exception("Не инициорована главная форма");
        }

        /// <summary>
        /// Открыть модуль в качестве вкладки главного окна приложения
        /// </summary>
        /// <param name="moduleName">Имя модуля(название сборки без .dll)</param>
        public static void LoadModuleTab(string moduleName, Guid moduleId, bool readOnly = false)
        {
            string _filePath = Application.StartupPath;
            _filePath += @"\" + moduleName + ".dll";
            if (!File.Exists(_filePath))
            {
                Logger.AddErrorMsg(string.Format("Не найдена сборка {0}", moduleName));
                return;
            }

            IModule _module = null;
            Assembly _assembly = Assembly.LoadFrom(_filePath);
            Type[] _types = _assembly.GetTypes();

            Type _starterType = null;
            foreach (Type _type in _types)
            {
                var _att = _type.GetCustomAttributes<ModuleStarterAttribute>(true).SingleOrDefault();
                if (_att != null)
                {
                    _starterType = _type;
                }
            }

            if (_starterType != null)
            {
                ConstructorInfo ci = _starterType.GetConstructor(new Type[] { });
                _module = ci.Invoke(new object[] { }) as IModule;
            }

            if (_module != null)
            {
                _module.Form.ReadOnly = readOnly;
                LoadTab(_module.Form, moduleId);
            }

            _module = null;
        }

        private static string GetAppUserSettingsFileName()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                   @"\" + Environment.UserName + "_" + "App.settings";
        }

        private static void LoadViewTypeSettings()
        {
            ViewType = MainViewType.MDI;
            UseStyles = true;
            try
            {
                string _fileName = GetAppUserSettingsFileName();

                if (System.IO.File.Exists(_fileName))
                {
                    XDocument _doc = XDocument.Load(_fileName);
                    if (_doc.Root.HasElements)
                    {
                        XElement _typeViewNode = _doc.Root.Element("ViewType");
                        int _tmp = 0;
                        if (_typeViewNode != null && int.TryParse(_typeViewNode.Value, out _tmp))
                            ViewType = (MainViewType) _tmp;

                        XElement _useStylesNode = _doc.Root.Element("UseStyles");
                        bool _useStyles = true;
                        if (_useStylesNode != null && bool.TryParse(_useStylesNode.Value, out _useStyles))
                            UseStyles = _useStyles;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddErrorEx("LoadViewTypeSettings", ex);
            }
        }

        private static void SaveAppSettings()
        {
            try
            {
                string _fileName = GetAppUserSettingsFileName();
                XDocument _doc = null;
                if (System.IO.File.Exists(_fileName))
                    _doc = XDocument.Load(_fileName);
                else
                    _doc = new XDocument();

                if (_doc.Root == null)
                    _doc.Add(new XElement("AppSettings"));

                XElement _typeViewNode = _doc.Root.Element("ViewType");
                if (_typeViewNode == null)
                    _doc.Root.Add(new XElement("ViewType") { Value = ((int)ViewType).ToString() });
                else
                    _typeViewNode.Value = ((int)ViewType).ToString();

                XElement _useStyles = _doc.Root.Element("UseStyles");
                if (_useStyles == null)
                    _doc.Root.Add(new XElement("UseStyles") { Value = UseStyles.ToString() });
                else
                    _useStyles.Value = UseStyles.ToString();

                _doc.Save(_fileName);
            }
            catch (Exception ex)
            {
                Logger.AddErrorEx("SaveAppSettings", ex);
            }
        }
    }
}
