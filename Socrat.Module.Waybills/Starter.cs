using Socrat.Common.UI;
using Socrat.Core;
using Socrat.Lib.Module;
using System;

namespace Socrat.Module.Waybills
{
    [ModuleStarter]
    public class Starter : IModule
    {
        public string Name
        {
            get => "Модуль отгрузки";
        }

        public ITabable Form
        {
            get => new Views.FxWaybills();
        }

        public IEntityEditor GetEditor(string editorPath)
        {
            Type _type = Type.GetType(editorPath);
            if (_type != null)
                return Activator.CreateInstance(_type) as IEntityEditor;
            return null;
        }
    }
}
