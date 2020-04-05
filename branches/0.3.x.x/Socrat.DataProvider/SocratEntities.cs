using System;
using System.Data.Entity;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Log;

namespace Socrat.DataProvider
{
    /// <summary>
    /// Определенный пользователем код контекста 
    /// </summary>
    public partial class SocratEntities
    {
        /// <summary>
        /// Аунтифицированый пользователь
        /// </summary>
        public static Socrat.Core.Entities.User User { get; set; }

        public SocratEntities(string cnnStr) : base(cnnStr)
        {
        }

        public void DiscardEntityChanges(object entity)
        {
            Entry(entity).CurrentValues.SetValues(Entry(entity).OriginalValues);
            Entry(entity).State = EntityState.Unchanged;
            Entry(entity).Reload();
        }

        public bool SafetySaveChanges(bool silent = false)
        {
            bool res = false;
            try
            {
                SaveChanges();
                res = true;
            }
            catch (Exception e)
            {
                string msg = e.Message;

#if DEBUG

                if (e.InnerException != null && e.InnerException.InnerException != null)
                {
                    msg = e.InnerException.InnerException.Message;
                    if (e.InnerException.InnerException.Message.Contains("PRIMARY KEY"))
                        msg = "Нарушение условия ссылочной целосности!";
                    if (e.InnerException.InnerException.Message.Contains("UNIQUE KEY"))
                        msg = "Введено повторяющееся значение!";
                    //msg += " СООБЩЕНИЕ ВЫВОДИТЬСЯ ТОЛЬКО В РЕЖИМЕ ОТЛАДКИ";
                }
                XtraMessageBox.Show(e.Message, "Сохранение невозможно", MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                if (!silent)
                    XtraMessageBox.Show(msg, "Сохранение невозможно", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif



                Logger.AddErrorEx(msg, e);
            }
            return res;
        }
    }
}
