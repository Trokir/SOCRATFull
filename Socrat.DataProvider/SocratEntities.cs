using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
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
            var changedEntries = ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
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
                        msg = "Нарушение условия ссылочной целостности!";
                    if (e.InnerException.InnerException.Message.Contains("UNIQUE KEY"))
                        msg = "Введено повторяющееся значение!";
                    //msg += " СООБЩЕНИЕ ВЫВОДИТСЯ ТОЛЬКО В РЕЖИМЕ ОТЛАДКИ";
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
