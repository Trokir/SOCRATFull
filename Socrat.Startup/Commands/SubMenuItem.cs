using System.Collections.Generic;
using Socrat.Lib.Commands;

namespace Socrat.Startup.Commands
{
    public class SubMenuItem: IMenuCommand
    {
        private MenuCommandType _commandType;
        private string _title;
        private List<IMenuCommand> _commands;

        public SubMenuItem()
        {
            _commands = new List<IMenuCommand>();
        }

        public MenuCommandType CommandType
        {
            get =>  MenuCommandType.Group;
        }

        public void Execute(object parameter)
        {
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public List<IMenuCommand> Commands
        {
            get => _commands;
            set => _commands = value;
        }

        public bool ReadOnly { get; set; }
    }
}
