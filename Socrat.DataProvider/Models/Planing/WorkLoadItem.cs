using Socrat.Data.Model.Machines;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Socrat.Data.Model.Planing
{
    public class WorkLoadItem : Entity
    {
        public bool Expired { get; set; }
        public Division Division { get; set; }
        public WorkQueueAssignment WorkQueueAssignment { get; set; }
        public MachineNom MachineNom { get; set; }
        public WorkShift WorkShift { get; set; }

        // TODO сейчас это Нарезка, СПО, СПД . Сделать универсализацию - набор строк заказов по 
        public List<OrderRow> orderRows1 { get; set; }
        public List<OrderRow> orderRows2 { get; set; }
        public List<OrderRow> orderRows3 { get; set; }
    }
}