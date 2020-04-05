using System;
using System.Collections.Generic;
using Socrat.Lib.Commands;
using Socrat.Model;
using Socrat.Model.Materials;

namespace Socrat.References.Menu
{
    public class MaterialCommand
    {
        private Action<MaterialEnum> ExecuteMethod;
        protected Func<object, bool> CanExecuteMethod;
        public MaterialEnum MaterialEnum { get; set; }

        public MaterialCommand(string title, Action<MaterialEnum> executeMethod, Func<object, bool> canExecuteMethod)
        {
            Title = title;
            ExecuteMethod = executeMethod;
            CanExecuteMethod = canExecuteMethod;
        }

        public MaterialCommand(Action<MaterialEnum> executeMethod, MaterialEnum materialEnum)
        {
            MaterialEnum = materialEnum;
            ExecuteMethod = executeMethod;
        }

        public MenuCommandType CommandType
        {
            get => MenuCommandType.Item;
        }

        public void Execute(object param)
        {
            ExecuteMethod?.Invoke(MaterialEnum);
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteMethod?.Invoke(parameter) ?? true;
        }

        public string Title { get; set; }

        public List<IMenuCommand> Commands { get; set; }

        public bool ReadOnly { get; set; }
        
    }
}