using System.Collections.Generic;

namespace Socrat.Lib.Commands
{
    public interface IMenuCommand
    {
        MenuCommandType CommandType { get; }
        void Execute(object parameter);
        bool CanExecute(object parameter);
        string Title { get; }
        List<IMenuCommand> Commands { get; }
        bool ReadOnly { get; set; }
    }
}