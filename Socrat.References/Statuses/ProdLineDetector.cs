using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Entity.Model;
using DevExpress.XtraEditors;
using Socrat.Core.Entities;
using Socrat.Core.Entities.Machines;
using Socrat.DataProvider;

namespace Socrat.References.Statuses
{
    public static class ProdLineDetector
    {
        public static MachineNom[] GetLines(Core.Entities.Division ActualDivision)
        {
            List<MachineNom> _machineNoms = new List<MachineNom>();


            // вариант только с одним предопределенным назначением очередей - 'Сборка' (без промежуточного уровня выбора назначения)
            WorkQueueAssignment _wqa = DataHelper.GetItem<WorkQueueAssignment>(t => t.Division.Id == ActualDivision.Id && (t.Disabled == null || t.Disabled == false) && t.Name == "Сборка");
            if (_wqa == null)
            {
                XtraMessageBox.Show("В системе не заведено назначение очереди 'Сборка'. Формирование очередей не доступно", "Планирование сборки",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return _machineNoms.ToArray();
            }

            DataHelper.GetAll<Core.Entities.Machines.MachineNom>
            (t =>
                t.Division.Id == ActualDivision.Id
                && t.VendorMachineNom.MachineType.WorkQueueAssignment != null
                && t.VendorMachineNom.MachineType.WorkQueueAssignment.Id == _wqa.Id
            );

            return _machineNoms.ToArray();
        }
    }
}