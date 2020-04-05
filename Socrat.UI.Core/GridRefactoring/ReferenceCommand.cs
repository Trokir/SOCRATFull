using System;
using Socrat.Lib.Commands;

namespace Socrat.UI.Core
{
    public class ReferenceCommand: BaseReferenceCommand
    {
        public ReferenceCommand():base() { }
        public ReferenceCommand(
            MenuCommandType commandType, 
            string title, 
            Action<object> execute, 
            Func<object, bool> canExecute,
            object executeParam = null, 
            ActionTypes actionType = ActionTypes.Custom) 
            : base(commandType, title, execute, canExecute, executeParam, actionType)
        { }

        public ReferenceCommand(
            Func<object, object> execute,
            MenuCommandType commandType,
            string title,
            ActionTypes actionType = ActionTypes.Custom)
            : base(execute, commandType, title, actionType)
        { }

        public ReferenceCommand(BaseReferenceCommand cmd)
        {
            ActionType = cmd.ActionType;
            CommandType = cmd.CommandType;
            Title = cmd.Title;
            Commands = cmd.Commands;
            Image = cmd.Image;
            _Execute = cmd._Execute;
            _ExecuteF = cmd._ExecuteF;
            _CanExecute = cmd._CanExecute;
            BeginGroup = cmd.BeginGroup;
            _ExecuteParam = cmd._ExecuteParam;
    }

        //private MenuCommandType _commandType;
        //private string _title;
        //private List<IMenuCommand> _commands;
        //private Image _image;
        //private Action<object> _Execute;
        //private Func<object, object> _ExecuteF;
        //private Func<object, bool> _CanExecute;
        //private bool _beginGroup = false;
        //private object _ExecuteParam = null;
        //private ActionTypes _actionType = ActionTypes.Custom;

        //public ReferenceCommand(MenuCommandType commandType, string title, Action<object> execute, Func<object, bool> canExecute,
        //    object executeParam = null, ActionTypes actionType = ActionTypes.Custom)
        //{
        //    _commandType = commandType;
        //    _title = title;
        //    _Execute = execute;
        //    _CanExecute = canExecute;
        //    _commands = new List<IMenuCommand>();
        //    _ExecuteParam = executeParam;
        //    _actionType = actionType;
        //}

        //public ReferenceCommand(Func<object, object> execute, MenuCommandType commandType, string title, ActionTypes actionType = ActionTypes.Custom)
        //{
        //    _commandType = commandType;
        //    _title = title;
        //    _ExecuteF = execute;
        //    _commands = new List<IMenuCommand>();
        //    _actionType = actionType;
        //}

        //public ReferenceCommand(Func<object, object> execute, MenuCommandType commandType, string title, Func<object, bool> canExecute,
        //    object executeParam = null, ActionTypes actionType = ActionTypes.Custom)
        //{
        //    _commandType = commandType;
        //    _title = title;
        //    _ExecuteF = execute;
        //    _CanExecute = canExecute;
        //    _commands = new List<IMenuCommand>();
        //    _ExecuteParam = executeParam;
        //    _actionType = actionType;
        //}

        //public MenuCommandType CommandType
        //{
        //    get => _commandType;
        //    set => _commandType = value;
        //}

        //public void Execute(object parameter)
        //{
        //    //Обесепчение передачи аргумента в обработчик при имплементации команды в Entity посредством CommandMethodAttribute
        //    //НАЧ;
        //    CommandExecutingEventArgs args = new CommandExecutingEventArgs(parameter);
        //    OnExecuting(args);

        //    if (args.Cancel)
        //        return;

        //    if (args.Data != null)
        //        parameter = args.Data;
        //    //КНЦ;

        //    if (parameter != null)
        //    {
        //        _ExecuteF?.Invoke(parameter);
        //        _Execute?.Invoke(parameter);
        //    }
        //    else
        //    {
        //        _ExecuteF?.Invoke(_ExecuteParam);
        //        _Execute?.Invoke(_ExecuteParam);
        //    }

        //    OnExecuted(parameter);

        //}

        //public bool CanExecute(object parameter)
        //{
        //    return _CanExecute?.Invoke(parameter) ?? true;
        //}

        //public Func<object, bool> CanExecuteDelegate
        //{
        //    get => _CanExecute;
        //    set => _CanExecute = value;
        //}

        //public string Title
        //{
        //    get => _title;
        //    set => _title = value;
        //}

        //public List<IMenuCommand> Commands
        //{
        //    get => _commands;
        //    set => _commands = value;
        //}

        //public Image Image
        //{
        //    get { return _image; }
        //    set { _image = value; }
        //}

        //public bool BeginGroup
        //{
        //    get => _beginGroup;
        //    set => _beginGroup = value;
        //}

        //public ActionTypes ActionType
        //{
        //    get => _actionType;
        //    set => _actionType = value;
        //}

        //public object Owner { get; set; }

        //public bool ReadOnly { get; set; }

        //public bool IsWriteCommand { get; set; }

        //public override string ToString()
        //{
        //    return Title;
        //}

        //#region
        ///// <summary>
        ///// Вызывается перед непосредственным вызовом команды
        ///// Нужен, чтобы передать в команду данные
        ///// </summary>
        //public event EventHandler<CommandExecutingEventArgs> Executing;

        ///// <summary>
        ///// Вызывается сразу после выполнения команды
        ///// Объект сождержит тот объект данных, который был послан вместе с командой OnExecuting
        ///// </summary>
        //public event EventHandler<object> Executed;


        ///// <summary>
        ///// Обертка события Executing
        ///// </summary>
        ///// <param name="args">Экземпляр типа CommandExecutingEventArgs</param>
        //protected void OnExecuting(CommandExecutingEventArgs args)
        //{
        //    Executing?.Invoke(this, args);
        //}

        //protected void OnExecuted(object data)
        //{
        //    Executed?.Invoke(this, data);
        //}

        ///// <summary>
        ///// Предоставляет данные для выполнения или отмены команды
        ///// </summary>
        //public class CommandExecutingEventArgs : CancelEventArgs
        //{
        //    /// <summary>
        //    /// Данные, передаваемые в исполнитель команды
        //    /// </summary>
        //    public object Data { get; set; }

        //    public CommandExecutingEventArgs(object data, bool cancel = false)
        //    {
        //        Data = data;
        //        Cancel = cancel;
        //    }
        //}
        //#endregion

        //public enum ActionTypes
        //{
        //    Custom = 0,
        //    Refresh = 1,
        //    ViewOrEdit = 2,
        //    Add = 3,
        //    Delete = 4,
        //    Export = 5,
        //    Print = 6
        //}
    }
}
