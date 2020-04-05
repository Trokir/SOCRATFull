using System;
using System.Collections.Generic;
using Socrat.Core;
using Socrat.Lib;
using Socrat.Lib.Commands;

namespace Socrat.Startup.Commands
{
    /// <summary>
    /// Обобщенная команда открывания формы в виде вкладки/окна
    /// </summary>
    /// <typeparam name="T">Класс окна</typeparam>
    public class OpenTabMenuItem<T>: IMenuCommand where T: class, ITabable
    {
        private MenuCommandType _commandType;
        private string _title;
        private List<IMenuCommand> _commands;
        protected Func<object, bool> CanExecuteMethod;

        public OpenTabMenuItem(string title)
        {
            _title = title;
        }

        public MenuCommandType CommandType
        {
            get => MenuCommandType.Item;
        }

        public void Execute(object parameter)
        {
            T _tab = Activator.CreateInstance<T>();
            AppMain.LoadTab(_tab, Guid.NewGuid());
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