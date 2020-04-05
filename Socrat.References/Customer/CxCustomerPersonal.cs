using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Log;
using Person = Socrat.Core.Added.Person;

namespace Socrat.References.Customer
{
    /// <summary>
    /// Шаблон табличного списка (справочника)
    /// </summary>
    public partial class CxCustomerPersonal : CxCustomerTableList
    {
        protected override void Init()
        {
            RefreshData();
        }

        #region Реализация

        protected override void RefreshData()
        {
            if (_customer != null)
            {
                gcGrid.DataSource = null;
                gcGrid.DataSource = _customer.Personal;
            }
        }

        protected override void AddItem()
        {
            if (ReadOnly)
                return;
            try
            {
                Person _personal = new Person();

                FxPersonEdit _fx = new FxPersonEdit(Customer, ReadOnly);
                _fx.Person = _personal;
                _fx.ReadOnly = ReadOnly;
                //_fx.Genders = _entities.Genders.ToList();
                _fx.StartPosition = FormStartPosition.CenterParent;
                DialogResult dlgRes = _fx.ShowDialog(this);

                if (dlgRes != DialogResult.Cancel)
                {
                    RefreshData();
                }
            }
            catch (Exception ex)
            {
                Logger.AddErrorMsgEx("CxCustomerPersonal.AddItem", ex);
            }
        }

        protected override void DeleteItem()
        {
            if (gvGrid.GetFocusedRowCellValue("Id") != null)
            {
                Guid _id;
                if (Guid.TryParse(gvGrid.GetFocusedRowCellValue("Id").ToString(), out _id))
                {
                    Person _personal = _customer.Personal.FirstOrDefault(x => x.Id == _id);
                    if (_personal != null)
                    {
                        DialogResult dlgRes = XtraMessageBox.Show(string.Format("Удалить {0} {1} из персонала?",
                            _personal.Surname,
                            _personal.Name), "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dlgRes == DialogResult.Yes)
                        {
                            RefreshData();
                            OnListChanged();
                        }
                    }
                }
            }
        }

        protected override void OpenItem()
        {
            if (gvGrid.GetFocusedRowCellValue("Id") != null)
            {
                Guid _id;
                if (Guid.TryParse(gvGrid.GetFocusedRowCellValue("Id").ToString(), out _id))
                {
                    Person _personal = _customer.Personal.FirstOrDefault(x => x.Id == _id);
                    if (_personal != null)
                    {
                        FxPersonEdit _fx = new FxPersonEdit(Customer, ReadOnly);
                        _fx.Person = _personal;
                        _fx.ReadOnly = ReadOnly;
                        //_fx.Genders = _entities.Genders.ToList();
                        _fx.StartPosition = FormStartPosition.CenterParent;
                        DialogResult dlgRes = _fx.ShowDialog(this);

                        if (dlgRes != DialogResult.Cancel)
                        {
                            OnListChanged();
                        }
                        else
                        {
                        }
                        RefreshData();
                    }
                }
            }
        }
        
        protected override void InitColumns()
        {
            AddColumn("colFio", "ФИО", "DisplayName", 250, 0);
            AddColumn("colGender", "Пол", "Gender", 60, 0);
        }

        #endregion
    }
}
