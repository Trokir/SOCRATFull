using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Socrat.Lib;
using Socrat.Lib.Module;
using Socrat.Log;
using Socrat.Model;

namespace Socrat.References
{
    public static class ReferncesUtils
    {
        /// <summary>
        /// Открыть модуль в качестве вкладки главного окна приложения
        /// </summary>
        /// <param name="moduleName">Имя модуля(название сборки без .dll)</param>
        public static ISelectionDialog LoadModuleSelectionDialog(string moduleName)
        {
            ISelectionDialog _dialog = null;

            string _filePath = Application.StartupPath;
            _filePath += @"\" + moduleName + ".dll";
            if (!File.Exists(_filePath))
            {
                Logger.AddErrorMsg(string.Format("Не найдена сборка {0}", moduleName));
                return null;
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
                _dialog = _module.Form as ISelectionDialog;

            return _dialog;
        }
    }
}