using System;
using System.Collections.Generic;
using Socrat.Core;
using Socrat.Lib.Commands;


namespace Socrat.References.Menu
{
    /// <summary>
    /// Комманда добавления материала
    /// </summary>
    public class MaterialAddCommand
    {
        private Action<MaterialEnum> ExecuteMethod;
        protected Func<object, bool> CanExecuteMethod;
        public MaterialEnum MaterialEnum { get; set; }

        public MaterialAddCommand()
        {
        }

        public MaterialAddCommand(string title, Action<MaterialEnum> executeMethod, Func<object, bool> canExecuteMethod)
        {
            Title = title;
            ExecuteMethod = executeMethod;
            CanExecuteMethod = canExecuteMethod;
        }

        public MaterialAddCommand(Action<MaterialEnum> executeMethod, MaterialEnum materialEnum)
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