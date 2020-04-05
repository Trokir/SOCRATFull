using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Socrat.Lib.Commands;

namespace Socrat.References
{
    public class ReferenceCommand: IMenuCommand
    {
        private MenuCommandType _commandType;
        private string _title;
        private List<IMenuCommand> _commands;
        private Image _image;
        private Action<object> _Execute;
        private Func<object, bool> _CanExecute;
        private bool _beginGroup = false;

        public ReferenceCommand(MenuCommandType commandType, string title, Action<object> execute, Func<object, bool> canExecute)
        {
            _commandType = commandType;
            _title = title;
            _Execute = execute;
            _CanExecute = canExecute;
            _commands = new List<IMenuCommand>();
        }

        public MenuCommandType CommandType
        {
            get => _commandType;
            set => _commandType = value;
        }

        public void Execute(object parameter)
        {
            _Execute?.Invoke(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return _CanExecute?.Invoke(parameter) ?? true;
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

        public Image Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public bool BeginGroup
        {
            get => _beginGroup;
            set => _beginGroup = value;
        }

        public bool ReadOnly { get; set; }

        public bool IsWriteCommand { get; set; }
    }
}
