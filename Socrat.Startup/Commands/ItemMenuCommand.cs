using System;
using System.Collections.Generic;
using Socrat.Lib.Commands;

namespace Socrat.Startup.Commands
{
    /// <summary>
    /// Универсальная команда меню
    /// </summary>
    public class ItemMenuCommand: IMenuCommand
    {
        private string _title;
        private Action ExecuteMethod;
        protected Func<object, bool> CanExecuteMethod;

        public ItemMenuCommand(string title, Action executeMethod, Func<object, bool> canExecuteMethod)
        {
            _title = title;
            ExecuteMethod = executeMethod;
            CanExecuteMethod = canExecuteMethod;
        }

        public ItemMenuCommand(string title, Action executeMethod)
        {
            _title = title;
            ExecuteMethod = executeMethod;
        }

        public MenuCommandType CommandType
        {
            get => MenuCommandType.Item;
        }

        public void Execute(object parameter)
        {
            ExecuteMethod?.Invoke();
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteMethod?.Invoke(parameter) ?? true;
        }

        public string Title
        {
            get => _title;
        }

        public List<IMenuCommand> Commands
        {
            get => null;
        }

        public bool ReadOnly { get; set; }
    }
}