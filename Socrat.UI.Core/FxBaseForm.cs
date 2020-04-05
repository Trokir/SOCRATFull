using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraLayout;
using Socrat.Core;

namespace Socrat.UI.Core
{
    public partial class FxBaseForm : DevExpress.XtraEditors.XtraForm, ITabable
    {
        public DialogOutputType WindowOutputType { get; set; } = DialogOutputType.Tab;
        public FxBaseForm TabParent { get; set; }
        public Dictionary<string, string> _UserSettings;

        private Guid _ModuleId = Guid.NewGuid();
        public Guid ModuleId
        {
            set => _ModuleId = value;
            get => _ModuleId;
        }

        private EventHandler<WindowOutputEventArgs> _DialogOutput;
        public event EventHandler<WindowOutputEventArgs> DialogOutput
        {
            add
            {
                lock (this)
                {
                    _DialogOutput = delegate { };
                    _DialogOutput += value;
                }
            }
            remove { _DialogOutput -= value; }
        }

        public FxBaseForm()
        {
            InitializeComponent();
        }

        static readonly object Locker = new object();
        private bool _splashScreen;
        private bool _readOnly;

        public bool SplashScreen
        {
            get
            {
                lock (Locker)
                    return _splashScreen;
            }
            set
            {
                lock (Locker)
                    _splashScreen = value;
            }
        }

        private Icon GetAppIcon()
        {
            SvgBitmap _logo = SvgBitmap.FromStream(new MemoryStream(Properties.Resources.logo));
            Bitmap _bmp = new Bitmap(_logo.Render(new Size() { Height = 128, Width = 128 }, null));
            return Icon.FromHandle(_bmp.GetHicon());
        }

        protected override void OnLoad(EventArgs e)
        {
            RestoreUserSettings();
            base.OnLoad(e);
            this.RestoreGridsSettings();
            SubscribeGrids(this.Controls);
            Icon = GetAppIcon();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            SaveUserSettings();
            this.SaveGridsSettings();
            UnsubscribeGrids(this.Controls);
            base.OnClosing(e);
        }

        private void SaveUserSettings()
        {
            UserSettingsSerializer.Save(_UserSettings, GetUserSettingsFile());
        }

        private void RestoreUserSettings()
        {
            _UserSettings = UserSettingsSerializer.Load(GetUserSettingsFile());
        }

        public string GetUserSettingsFile()
        {
            return $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\{Environment.UserName}_{this.Name}.usf";
        }

        /// <summary>
        /// Пробегаем по всем контролам формы
        /// подписываем/отписываем гриды
        /// </summary>
        private void SubscribeChaildGrigs(object subs, Action<Control.ControlCollection> subsMethod)
        {
            PropertyInfo[] _props = subs.GetType().GetProperties();
            for (int i = 0; i < _props.Length; i++)
            {
                if (_props[i].Name == "Controls" && _props[i].PropertyType == typeof(Control.ControlCollection))
                {
                    subsMethod(_props[i].GetValue(subs, null) as Control.ControlCollection);
                }
            }
        }

        /// <summary>
        /// Подписываем все гриды
        /// </summary>
        private void SubscribeGrids(Control.ControlCollection controls)
        {
            GridControl grid = null;
            foreach (var item in controls)
            {
                grid = item as GridControl;
                if (null != grid)
                    grid.KeyDown += gridControl_KeyDown;
                else
                    SubscribeChaildGrigs(item, SubscribeGrids);
            }
        }

        /// <summary>
        /// Отписываем все гриды
        /// </summary>
        private void UnsubscribeGrids(Control.ControlCollection controls)
        {
            GridControl grid = null;
            foreach (var item in controls)
            {
                grid = item as GridControl;
                if (null != grid)
                    grid.KeyDown -= gridControl_KeyDown;
                else
                    SubscribeChaildGrigs(item, UnsubscribeGrids);
            }
        }

        /// <summary>
        /// Копирование в буфер только выделенной ячейки
        /// </summary>
        /// <param name="sender">грид</param>
        /// <param name="e">агрументы</param>
        private void gridControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                GridControl grid = sender as GridControl;
                DevExpress.XtraGrid.Views.Grid.GridView view = grid.FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;
                Clipboard.SetText(view.GetFocusedDisplayText());
                e.Handled = true;
            }
        }

        public void OnDialogOutput(ITabable outForm, DialogOutputType outputType)
        {
            _DialogOutput?.Invoke(this, new WindowOutputEventArgs { NewTab = outForm, OutputType = outputType, Owner = this });
        }

        public void OnDialogOutput(ITabable outForm, DialogOutputType outputType, IWin32Window owner)
        {
            _DialogOutput?.Invoke(this, new WindowOutputEventArgs { NewTab = outForm, OutputType = outputType, Owner = owner ?? this});
        }

        public void OnDialogOutput(WindowOutputEventArgs woa)
        {
            _DialogOutput?.Invoke(this, new WindowOutputEventArgs { NewTab = woa.NewTab, OutputType = woa.OutputType, Owner = woa.Owner ?? this });
        }

        public string Title
        {
            get { return GetFinalTite(); }
        }

        protected virtual string GetTitle()
        {
            return this.Text;
            //throw new Exception($"Не реализован ModuleName {this.Name}");
        }

        private string GetFinalTite()
        {
            return GetTitle() + (ReadOnly && !this.GetTitle().Contains(Lib.UI.Consts.ReadOnlyTitle)
                       ? $" {Lib.UI.Consts.ReadOnlyTitle}"
                       : string.Empty);
        }

        public bool ReadOnly
        {
            get => _readOnly;
            set => SetReadOnly(value);
        }

        protected virtual void SetReadOnly(bool value)
        {
            _readOnly = value;
            Controls.OfType<ITabable>().ForEach(x => x.ReadOnly = value);
            var layOuts = Controls.OfType<LayoutControl>();
            foreach (LayoutControl layoutControl in layOuts)
            {
                layoutControl.Controls.OfType<BaseEdit>().ForEach(x => x.ReadOnly = value);
            }
        }

        protected virtual void ShowObject()
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100; const int WM_SYSKEYDOWN = 0x104;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.Control | Keys.J:
                        ShowObject();
                        break;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public bool LockFockus { get; set; }

        //[DllImport("user32.dll")]
        //private extern static IntPtr SetActiveWindow(IntPtr handle);
        //private const int WM_ACTIVATE = 6;
        //private const int WA_INACTIVE = 0;


        //protected override void WndProc(ref Message m)
        //{
        //    if (LockFockus)
        //    {
        //        System.Diagnostics.Debug.Print($"{Name} {m.Msg}");
        //        SetActiveWindow(IntPtr.Zero);
        //        if (false && m.Msg == WM_ACTIVATE)
        //        {
        //            if (((int)m.WParam & 0xFFFF) != WA_INACTIVE)
        //            {
        //                if (m.LParam != IntPtr.Zero)
        //                {
        //                    SetActiveWindow(m.LParam);
        //                }
        //                else
        //                {
        //                    // Could not find sender, just in-activate it.
        //                    SetActiveWindow(IntPtr.Zero);
        //                }
        //            }
        //        }
        //    }

        //    base.WndProc(ref m);
        //}
    }
}
