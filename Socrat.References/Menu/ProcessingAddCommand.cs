using System;
using System.Collections.Generic;
using Socrat.Core.Added;
using Socrat.Lib.Commands;

namespace Socrat.References.Menu
{
    public class ProcessingAddCommand
    {
        private Action<FormulaItemProcessingEnum> ExecuteMethod;
        protected Func<object, bool> CanExecuteMethod;
        public FormulaItemProcessingEnum ProcessingEnum { get; set; }

        public ProcessingAddCommand(string title, Action<FormulaItemProcessingEnum> executeMethod, Func<object, bool> canExecuteMethod)
        {
            Title = title;
            ExecuteMethod = executeMethod;
            CanExecuteMethod = canExecuteMethod;
        }

        public ProcessingAddCommand(Action<FormulaItemProcessingEnum> executeMethod, FormulaItemProcessingEnum processingEnum)
        {
            ProcessingEnum = processingEnum;
            ExecuteMethod = executeMethod;
        }

        public MenuCommandType CommandType
        {
            get => MenuCommandType.Item;
        }

        public void Execute(object param)
        {
            ExecuteMethod?.Invoke(ProcessingEnum);
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