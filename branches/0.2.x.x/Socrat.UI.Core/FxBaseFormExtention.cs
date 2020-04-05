using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using System.IO;
using DevExpress.XtraSplashScreen;

namespace Socrat.UI.Core
{
    /// <summary>
    /// Класс расширения базовой формы
    /// </summary>
    public static class FxBaseFormExtention
    {
        /// <summary>
        /// Найти все контролы одного типа на корневом контроле
        /// </summary>
        /// <typeparam name="T">тип контрола</typeparam>
        /// <param name="mainControl">корневой контрол</param>
        /// <param name="getAllChild">искать рекурсивно в дочерних контролах</param>
        /// <returns></returns>
        public static List<T> FindControlByType<T>(Control mainControl, bool getAllChild = false) where T : Control
        {
            List<T> lt = new List<T>();
            for (int i = 0; i < mainControl.Controls.Count; i++)
            {
                if (mainControl.Controls[i] is T) lt.Add((T)mainControl.Controls[i]);
                if (getAllChild) lt.AddRange(FindControlByType<T>(mainControl.Controls[i], getAllChild));
            }
            return lt;
        }

        /// <summary>
        /// Сохранить настройки всех гридов
        /// </summary>
        /// <param name="baseForm"></param>
        public static void SaveGridsSettings(this FxBaseForm baseForm)
        {
            string _fileName = string.Empty;
            string _folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            List<GridControl> _cl = FindControlByType<GridControl>(baseForm, true);
            foreach (GridControl grid in _cl)
            {
                _fileName = _folder + "\\" + baseForm.Name + "_" + grid.Name + ".xml";
                grid.MainView.SaveLayoutToXml(_fileName);
            }
        }

        /// <summary>
        /// Востановить настройки всех гридов
        /// </summary>
        /// <param name="baseForm"></param>
        public static void RestoreGridsSettings(this FxBaseForm baseForm)
        {
            string _fileName = string.Empty;
            string _folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            List<GridControl> _cl = FindControlByType<GridControl>(baseForm, true);
            foreach (GridControl grid in _cl)
            {
                _fileName = _folder + "\\" + baseForm.Name + "_" + grid.Name + ".xml";
                if (File.Exists(_fileName))
                    grid.MainView.RestoreLayoutFromXml(_fileName);
            }
        }

        /// <summary>
        /// Показать сплэш
        /// </summary>
        /// <param name="baseForm"></param>
        public static void ShowSplashScreen(this FxBaseForm baseForm)
        {
            if (!baseForm.SplashScreen)
            {
                SplashScreenManager.ShowForm(typeof(FxLoading));
                baseForm.SplashScreen = true;
            }
        }

        /// <summary>
        /// Убрать сплэш
        /// </summary>
        /// <param name="baseForm"></param>
        public static void HideSplashScreen(this FxBaseForm baseForm)
        {
            if (baseForm.SplashScreen)
            {
                SplashScreenManager.CloseForm();
                baseForm.SplashScreen = false;
            }
        }
    }
}
