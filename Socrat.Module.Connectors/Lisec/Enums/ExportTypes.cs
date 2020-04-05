using System;

namespace Socrat.Module.Connectors.Lisec.Enums
{
    [Flags]
    public enum ExportTypes
    {
        Unknown = 0,
        Packages = 1,
        Glasses = 2,
        Frames = 4
    }
}
