using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using Socrat.Log.Core;
using Socrat.Log.Enums;
using Socrat.Log.Models;

namespace Socrat.Log
{
    /// <summary>
    /// Класс работы с журналом событий
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Внешний метод показа сообщения
        /// </summary>
        public static Action<string> ShowMessageMethod;

        /// <summary>
        /// Внешний метод получения формы вывода лога
        /// </summary>
        public static Func<Form> GetLogFormMethod;
        
        /// <summary>
        /// Добавить ошибку.1
        /// </summary>
        /// <param name="msg">Сообщение с предупреждением.</param>
        public static void AddError(string msg)
        {
            var sf = new StackFrame(1);

            var declaringType = sf.GetMethod().DeclaringType;
            if (declaringType != null)
            {
                var method = Environment.NewLine + Environment.NewLine + "StackFrame" + Environment.NewLine + "[" + declaringType.Name + "] [" + sf.GetMethod().Name + "]";

                var le = new LogItem {LogType = LogType.Error, Message = msg + method};
                Common.WriteLog(le);
            }
        }

        /// <summary>
        /// Добавить ошибку.1
        /// </summary>
        /// <param name="msg">Сообщение с предупреждением.</param>
        /// <param name="ex"></param>
        public static void AddErrorEx(string msg,Exception ex)
        {
            var sf = new StackFrame(1);

            var declaringType = sf.GetMethod().DeclaringType;
            if (declaringType != null)
            {
                var method = Environment.NewLine + Environment.NewLine + "StackFrame" + Environment.NewLine + "[" + declaringType.Name + "] [" + sf.GetMethod().Name + "]";

                var le = new LogItem {LogType = LogType.Error, Message = msg + method, Ex = new MyException(ex)};
                Common.WriteLog(le);
            }
        }

        /// <summary>
        /// Добавить ошибку.1
        /// </summary>
        /// <param name="msg">Сообщение с предупреждением.</param>
        /// <param name="ex"></param>
        public static void AddErrorMsgEx(string msg, Exception ex)
        {
            var sf = new StackFrame(1);

            var declaringType = sf.GetMethod().DeclaringType;
            if (declaringType != null)
            {
                var method = Environment.NewLine + Environment.NewLine + "StackFrame" + Environment.NewLine + "[" + declaringType.Name + "] [" + sf.GetMethod().Name + "]";

                var le = new LogItem { LogType = LogType.Error, Message = msg + method, Ex = new MyException(ex) };
                Common.WriteLog(le);
            }

            if (ShowMessageMethod != null)
                ShowMessageMethod(msg + " " + ex.Message + " " + ex.StackTrace);
        }

        /// <summary>
        /// Добавить ошибку c окном.1
        /// </summary>
        /// <param name="msg">Сообщение с предупреждением.</param>
        public static void AddErrorMsg(string msg)
        {
            var sf = new StackFrame(1);

            var declaringType = sf.GetMethod().DeclaringType;
            if (declaringType != null)
            {
                var method = Environment.NewLine + Environment.NewLine + "StackFrame" + Environment.NewLine + "[" + declaringType.Name + "] [" + sf.GetMethod().Name + "]";

                var le = new LogItem {LogType = LogType.Error, Message = msg + method};
                Common.WriteLog(le);
            }
            if (ShowMessageMethod != null)
                ShowMessageMethod(msg);
        }
        
      
        /// <summary>
        /// Добавить предупреждение.2
        /// </summary>
        /// <param name="msg">Сообщение с предупреждением.</param>
        public static void AddWarning(string msg)
        {
            var sf = new StackFrame(1);

            var declaringType = sf.GetMethod().DeclaringType;
            if (declaringType != null)
            {
                var method = Environment.NewLine + Environment.NewLine + "StackFrame" + Environment.NewLine + "[" + declaringType.Name + "] [" + sf.GetMethod().Name + "]";

                var le = new LogItem {LogType = LogType.Warning, Message = msg + method};
                Common.WriteLog(le);
            }
        }

        /// <summary>
        /// Добавить предупреждение c окном.2
        /// </summary>
        /// <param name="msg">Сообщение с предупреждением.</param>
        public static void AddWarningMsg(string msg)
        {
            var sf = new StackFrame(1);

            var declaringType = sf.GetMethod().DeclaringType;
            if (declaringType != null)
            {
                var method = Environment.NewLine + Environment.NewLine + " StackFrame" + Environment.NewLine + "[" + declaringType.Name + "] [" + sf.GetMethod().Name + "]";

                var le = new LogItem {LogType = LogType.Warning, Message = msg + method};
                Common.WriteLog(le);
            }

            if (ShowMessageMethod != null)
                ShowMessageMethod(msg);
        }

        /// <summary>
        /// Добавить исключение.3
        /// </summary>
        /// <param name="exc">Exception.</param>
        public static void AddException(Exception exc)
        {
            var sf = new StackFrame(1);

            var declaringType = sf.GetMethod().DeclaringType;
            if (declaringType != null)
            {
                var method = Environment.NewLine + Environment.NewLine + "StackFrame" + Environment.NewLine + "[" + declaringType.Name + "] [" + sf.GetMethod().Name + "]";

                var le = new LogItem
                {
                    LogType = LogType.ErrorException,
                    Message = String.Format(" [EXCEPTION] :{0} Message: {1}{0}Source: {2}{0}HelpLink: {3}{4}",Environment.NewLine,exc.Message,exc.Source,exc.HelpLink,method),
                    Ex = new MyException(exc)
                };
                Common.WriteLog(le);
            }
        }

        /// <summary>
        /// Добавить исключение c окном.3
        /// </summary>
        /// <param name="msg">Сообщение</param>
        /// <param name="exc">Exception.</param>
        public static void AddMsgException(string msg,Exception exc)
        {
            var sf = new StackFrame(1);

            var declaringType = sf.GetMethod().DeclaringType;
            if (declaringType != null)
            {
                var method = Environment.NewLine + Environment.NewLine + "StackFrame" + Environment.NewLine + "[" + declaringType.Name + "] [" + sf.GetMethod().Name + "]";

                var le = new LogItem
                {
                    LogType = LogType.ErrorException,
                    Message =
                        " [EXCEPTION] :" + Environment.NewLine + " Message: " + exc.Message + Environment.NewLine +
                        " Source: " + exc.Source + Environment.NewLine + "HelpLink: " + exc.HelpLink + method,
                    Ex = new MyException(exc)
                };
                Common.WriteLog(le);
            }

            if (ShowMessageMethod != null)
                ShowMessageMethod(msg + Environment.NewLine + exc.Message);
           
        }


        /// <summary>
        /// Добавить информацию.4
        /// </summary>
        /// <param name="msg">Сообщение с информацией.</param>
        public static void AddInfo(string msg)
        {
            var sf = new StackFrame(1);

            var declaringType = sf.GetMethod().DeclaringType;
            if (declaringType != null)
            {
                var method = Environment.NewLine + Environment.NewLine + "StackFrame"+ Environment.NewLine + "[" + declaringType.Name + "] [" + sf.GetMethod().Name + "]";

                var le = new LogItem {LogType = LogType.Information, Message = msg + method};
                Common.WriteLog(le);
            }
        }

        /// <summary>
        /// Добавить информацию c окном.4
        /// </summary>
        /// <param name="msg">Сообщение с информацией.</param>
        public static void AddInfoMsg(string msg)
        {
            var sf = new StackFrame(1);

            var declaringType = sf.GetMethod().DeclaringType;
            if (declaringType != null)
            {
                var method = Environment.NewLine + Environment.NewLine + "StackFrame" + Environment.NewLine + "[" + declaringType.Name + "] [" + sf.GetMethod().Name + "]";
                var le = new LogItem {LogType = LogType.Information, Message = msg + method};
                Common.WriteLog(le);
            }

            if (ShowMessageMethod != null)
                ShowMessageMethod(msg);
        
        }

        /// <summary>
        /// Ошибка входа.5
        /// </summary>
        /// <param name="msg">Сообщение с информацией.</param>
        /// <param name="username">имя пользователя</param> 
        public static void AddFailureAudit(string msg, string username)
        {
            var sf = new StackFrame(1);

            var declaringType = sf.GetMethod().DeclaringType;
            if (declaringType != null)
            {
                var method = Environment.NewLine + Environment.NewLine + "StackFrame" + Environment.NewLine + "[" + declaringType.Name + "] [" + sf.GetMethod().Name + "]";

                var le = new LogItem { LogType = LogType.FailureAudit, Message = msg + Environment.NewLine + " [Failure Audit] for - [" + username + "]:" + Environment.NewLine + Environment.NewLine + method };
                Common.WriteLog(le);
            }
            if (ShowMessageMethod != null)
                ShowMessageMethod(msg);
       
        }

        /// <summary>
        /// Доступ входа.6
        /// </summary>
        /// <param name="msg">Сообщение с информацией.</param>
        /// <param name="username">имя пользователя</param> 
        public static void AddSuccessAudit(string msg, string username)
        {
            var sf = new StackFrame(1);

            var declaringType = sf.GetMethod().DeclaringType;
            if (declaringType != null)
            {
                var method = Environment.NewLine + Environment.NewLine + "StackFrame" + Environment.NewLine + "[" + declaringType.Name + "] [" + sf.GetMethod().Name + "]";
                var le = new LogItem { LogType = LogType.SuccessAudit, Message = msg + Environment.NewLine + " [Success Audit] for - [" + username + "]:" + Environment.NewLine + Environment.NewLine + method };
                Common.WriteLog(le);
            }
        }

        /// <summary>
        /// Добавить маркер текущего метода.7
        /// </summary>
        public static void AddMark()
        {
            var sf = new StackFrame(1);

            var declaringType = sf.GetMethod().DeclaringType;
            if (declaringType != null)
            {
                var method = "[" + declaringType.Name + "] [" + sf.GetMethod().Name + "]";
                var le = new LogItem { LogType = LogType.Marker, Message = " [MARK] : " + method };
                Common.WriteLog(le);
            }
        }

        /// <summary>
        /// Запуск приложения.9
        /// </summary>
        public static void AddStart()
        {
            var le = new LogItem { LogType = LogType.Start, Message = "Старт приложения" };
            Common.WriteLog(le);
        }

        /// <summary>
        /// Финиш приложения 8
        /// </summary>
        public static void AddFinish()
        {
            var le = new LogItem { LogType = LogType.Finisch, Message = "Финиш приложения" };
            Common.WriteLog(le);
        }

        /// <summary>
        /// Добавить исключение .10
        /// </summary>
        /// <param name="exc">Exception.</param>
        public static void AddEndException(Exception exc)
        {
            var sf = new StackFrame(1);

            var declaringType = sf.GetMethod().DeclaringType;
            if (declaringType != null)
            {
                var method = Environment.NewLine + Environment.NewLine + "StackFrame" + Environment.NewLine + "[" + declaringType.Name + "] [" + sf.GetMethod().Name + "]";
                var le = new LogItem { LogType = LogType.EndException, Message = @"Критическое завершение приложения!" + Environment.NewLine +  method, Ex = new MyException(exc) };

                Common.WriteLog(le);
                if (ShowMessageMethod != null)
                    ShowMessageMethod(@"Критическое завершение приложения!" + Environment.NewLine + @" [EXCEPTION] :" + 
                            Environment.NewLine + @" Message: " + exc.Message + Environment.NewLine + @" Source: " + 
                            exc.Source + Environment.NewLine + @" HelpLink: " + exc.HelpLink + method);
            }
        }


        public static void Ini(string productName)
        {
            Common.ProductName = productName;
            Common.LogPlace = LogPlace.Xml;
            Common.User = Environment.UserName;
            Common.Version = Assembly.GetCallingAssembly().GetName().Version.ToString();
        }
        public static void Ini(string productName,LogPlace logPlace)
        {
            Common.ProductName = productName;
            Common.LogPlace = logPlace;
            Common.User = Environment.UserName;

            Common.Version = Assembly.GetCallingAssembly().GetName().Version.ToString();
        }

        public static void Ini(string productName, LogPlace logPlace,string user)
        {
            Common.ProductName = productName;
            Common.LogPlace = logPlace;
            Common.User = user;
            Common.Version = Assembly.GetCallingAssembly().GetName().Version.ToString();
        }

        public static Form GetForm()
        {
            if (GetLogFormMethod != null)
                return GetLogFormMethod();
            return null;
        }

        public static string ProductName
        {
            get
            {
                return Common.ProductName;}
            set
            {
                Common.ProductName = value;
            }
        }
    }
}
