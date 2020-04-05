using System;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.OleDb;
using System.Windows.Forms;
using DevExpress.Xpo.Logger;
using DevExpress.XtraEditors;
using Socrat.Log;

namespace Socrat.DataProvider
{
    /// <summary>
    /// Определенный пользователем код контекста 
    /// </summary>
    public partial class SocratEntities
    {
        public SocratEntities(string cnnStr):base(cnnStr)
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
                if (e.InnerException != null 
                    && e.InnerException.InnerException != null
                    && e.InnerException.InnerException.Message.Contains("FOREIGN KEY"))
                    return res;


                #if DEBUG
                if (!silent)
                    XtraMessageBox.Show(e.InnerException != null 
                        ? e.InnerException.InnerException.Message + " СООБЩЕНИЕ ВЫВОДИТЬСЯ ТОЛЬКО В РЕЖИМЕ ОТЛАДКИ"
                        : e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                #endif
                Logger.AddErrorEx(e.InnerException.InnerException.Message, e);
            }
            return res;
        }
    }
}
