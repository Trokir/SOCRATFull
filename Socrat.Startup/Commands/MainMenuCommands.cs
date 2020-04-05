using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraBars;
using Socrat.Lib.Commands;
using Socrat.Startup.Commands.Order;

namespace Socrat.Startup.Commands
{
    public class MainMenuCommands: IMenuCommand
    {
        private List<IMenuCommand> _commands;

        public MainMenuCommands()
        {
            _commands = new List<IMenuCommand>();
            _commands.Add(new ReferencesMenuCommand());
            _commands.Add(new OrderMenuCommands());
            _commands.Add(new AdminMenuComands());
        }

        public MenuCommandType CommandType
        {
            get => MenuCommandType.Group;
        }

        public void Execute(object parameter)
        {
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        //private string _title = _"Главное пользовательское меню";
        public string Title
        {
            get { return ""; }
        }

        public List<IMenuCommand> Commands
        {
            get => _commands;
            set => _commands = value;
        }

        public bool ReadOnly { get; set; }
    }
}
