using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DevExpress.LookAndFeel;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DevExpress.Skins;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Socrat.Lib.UI;
using Socrat.Startup;
using Socrat.Log;

namespace Socrat.LookAndFeel
{
    [System.ComponentModel.DesignerCategory("")]
    public class LookAndFeelSettingsHelper : Component
    {

        public LookAndFeelSettingsHelper()
        {
            try
            {
                RestoreSettings();
            }
            catch (Exception ex)
            {
                Logger.AddErrorEx("RestoreSettings", ex);
            }
            Application.ApplicationExit += Application_ApplicationExit;
        }

        // Fields...
        private string _FileName;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string FileName
        {
            get
            {
                return GetFileName(); }
            set
            {
                _FileName = value;
            }
        }

        private string GetFileName()
        {
            if (string.IsNullOrEmpty(_FileName))
                _FileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                    @"\" + "LookAndFeel.cfg";
            return _FileName;
        }



        void Application_ApplicationExit(object sender, EventArgs e)
        {
            SaveSettings();
        }


        private void SaveSettings()
        {
            Save(FileName);
        }

        private void RestoreSettings()
        {
            Load(FileName);
        }
        public static void Save(string fileName)
        {
            if (AppMain.UseStyles)
            {
                FileStream stream;
                LookAndFeelSettings settings;
                BinaryFormatter formatter;

                settings = new LookAndFeelSettings();
                settings.SkinName = UserLookAndFeel.Default.SkinName;
                settings.Style = UserLookAndFeel.Default.Style;
                settings.UseWindowsXPTheme = UserLookAndFeel.Default.UseWindowsXPTheme;

                using (stream = new FileStream(fileName, FileMode.Create))
                {
                    formatter = new BinaryFormatter();
                    formatter.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
                    formatter.Serialize(stream, settings);
                }
            }
        }

        public static void Load(string fileName)
        {
            if (AppMain.UseStyles)
            {
                if (File.Exists(fileName))
                    using (FileStream stream = new FileStream(fileName, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
                        LookAndFeelSettings settings = formatter.Deserialize(stream) as LookAndFeelSettings;
                        if (AppMain.ViewType == MainViewType.MDI)
                            DevExpress.Skins.SkinManager.EnableMdiFormSkins();
                        if (settings != null)
                        {
                            UserLookAndFeel.Default.UseWindowsXPTheme = settings.UseWindowsXPTheme;
                            UserLookAndFeel.Default.Style = settings.Style;
                            UserLookAndFeel.Default.SkinName = settings.SkinName;
                        }
                    }
            }
            else
            {
                SkinManager.DisableFormSkins();
                SkinManager.DisableMdiFormSkins();
                Application.VisualStyleState = VisualStyleState.NoneEnabled;

                UserLookAndFeel.Default.UseWindowsXPTheme = false;
                UserLookAndFeel.Default.Style = LookAndFeelStyle.Style3D;

                WindowsFormsSettings.AnimationMode = AnimationMode.DisableAll;
                WindowsFormsSettings.AllowHoverAnimation = DevExpress.Utils.DefaultBoolean.False;

                BarAndDockingController.Default.PropertiesBar.MenuAnimationType = AnimationType.None;
                BarAndDockingController.Default.PropertiesBar.SubmenuHasShadow = false;
                BarAndDockingController.Default.PropertiesBar.AllowLinkLighting = false;
            }

        }
    }
}
