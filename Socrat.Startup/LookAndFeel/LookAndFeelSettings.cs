using System;
using System.Collections.Generic;
using DevExpress.LookAndFeel;

namespace Socrat.LookAndFeel
{
    [Serializable]
    public class LookAndFeelSettings
    {
        public string SkinName;
        public LookAndFeelStyle Style;
        public bool UseWindowsXPTheme;

        public LookAndFeelSettings()
        {

        }
    }
}
