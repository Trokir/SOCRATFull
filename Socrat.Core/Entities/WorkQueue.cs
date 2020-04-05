using Socrat.Core.Added;
using Socrat.Core.Entities.Planing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Socrat.Core.Entities.Pools;
using Socrat.Common;
using Socrat.Core.Helpers;
using Socrat.Common.Interfaces.Planning;
using Socrat.Common.Enums;

namespace Socrat.Core.Entities
{
    [ChangesLogging(true)]
    public class WorkQueue : Entity, IQueue
    {
        public WorkQueue()
        {
            Orders = new AttachedList<Order>(this);
            Orders.CollectionChanged += OrdersOnCollectionChanged;
        }

        #region IQueue implementation
        [NotMapped]
        public int Number { get => Num; }
        [NotMapped]
        public DateTime ProductionDate { get => WorkDate; }
        #endregion

        private void OrdersOnCollectionChanged(object sender, CollectionChangedEventArgs<Order> e)
        {
            Resort();
        }

        private void Resort()
        {
            for (int i = 0; i < Orders.OrderBy(x => x.WorkQueueOrderNum).ToList().Count; i++)
                Orders[i].WorkQueueOrderNum = i + 1;
        }

        public virtual WorkSortType WorkSortType { get; set; }

        private DateTime _WorkDate;
        public DateTime WorkDate
        {
            get { return _WorkDate; }
            set { SetField(ref _WorkDate, value, () => WorkDate); }
        }

        public Guid DivisionId { get; set; }

        private Division _Division;
        public virtual Division Division
        {
            get { return _Division; }
            set { SetField(ref _Division, value, () => Division); }
        }

        public Guid? WorkQueueAssignmentId { get; set; }
        private WorkQueueAssignment _WorkQueueAssignment;
        public virtual WorkQueueAssignment WorkQueueAssignment
        {
            get { return _WorkQueueAssignment; }
            set { SetField(ref _WorkQueueAssignment, value, () => WorkQueueAssignment); }
        }

        public Guid? MachineNomId { get; set; }
        private Guid? _WorkSortTypeId;
        public Guid? WorkSortTypeId
        {
            get { return _WorkSortTypeId; }
            set { SetField(ref _WorkSortTypeId, value, () => WorkSortTypeId); }
        }

        private Machines.MachineNom _MachineNom;
        public virtual Machines.MachineNom MachineNom
        {
            get { return _MachineNom; }
            set { SetField(ref _MachineNom, value, () => MachineNom); }
        }

        public Guid? WorkShiftId { get; set; }

        private Work.WorkShift _WorkShift;
        public virtual Work.WorkShift WorkShift
        {
            get { return _WorkShift; }
            set { SetField(ref _WorkShift, value, () => WorkShift); }
        }


        private short _Num;
        public short Num
        {
            get { return _Num; }
            set { SetField(ref _Num, value, () => Num); }
        }

        private bool _Plan;
        [NotMapped]
        public bool Plan
        {
            get { return _Plan; }
            set { SetField(ref _Plan, value, () => Plan); }
        }

        private bool _PrintPaln;
        [NotMapped]
        public bool PrintPaln
        {
            get { return _PrintPaln; }
            set { SetField(ref _PrintPaln, value, () => PrintPaln); }
        }

        private bool _PrintLabels;
        [NotMapped]
        public bool PrintLabels
        {
            get { return _PrintLabels; }
            set { SetField(ref _PrintLabels, value, () => PrintLabels); }
        }

        private bool _ExportFrame;

        [NotMapped]
        public bool ExportFrame
        {
            get { return _ExportFrame; }
            set { SetField(ref _ExportFrame, value, () => ExportFrame); }
        }
        [NotMapped]
        public string QueueTitle
        {
            get
            {
                if (Num > 0)
                    return $"<b><image={QueueLineIcon.GetName(MachineNom)}>" 
                           + $"<image={OrderStatusIcon.GetName(Status)}> "
                           + $"Очередь № {Num} от {WorkDate.ToString("dd.MM.yyyy")} ({Weight:N2} кг)"
                           + (MachineNom != null ? ", " + MachineNom.AliasName : "")
                           + (WorkShift?.Team != null ? ", " + WorkShift.Team.Name : "")
                           + (Pool != null ? $" {Pool}": String.Empty) + "</b>";
                return
                    "<b><image=ZeroQueue> " +
                    $"Очередь № {Num} от {WorkDate.ToString("dd.MM.yyyy")}</b>";
            }
        }

        [NotMapped]
        public string WorkTitle
        {
            get { return QueueTitle; }
        }
        [NotMapped]
        public double? Weight
        {
            get => Orders.Sum(x => x.Weight);
        }

        public virtual AttachedList<Order> Orders { get; }
        public PiramideType PiramideType { get; set; }

        [NotMapped]
        public List<Order> ZeroOrders { get; set; } = new List<Order>();

        public void AppendOrder(Order order)
        {
            if (Num == 0)
            {
                ZeroOrders.Add(order);
            }
            else
            {
                Orders.Add(order);
                order.WorkQueue = this;
                order.DateWork = WorkDate;
                order.DateCustomer = WorkDate.AddDays(1);
            }
        }
        [NotMapped]
        public List<Order> Items
        {
            get
            {
                if (Num == 0)
                    return ZeroOrders.OrderBy(x => x.Num).ToList();
                else
                    return Orders.OrderBy(x => x.WorkQueueOrderNum).ToList();
            }
        }
        [NotMapped]
        public List<Order> WorkItems
        {
            get
            {
                return Orders;
            }
        }

        public void SetOrdersWorkDate()
        {
            foreach (Order order in Orders)
            {
                order.DateWork = WorkDate;
                order.DateCustomer = WorkDate.AddDays(1);
            }
        }

        public override ValidationResult Validate(ValidationStage stage, object ownedList)
        {
            if (!(ownedList is List<WorkQueue> list))
                throw new Exception("Предоставленный родительский список пуст или не является типом List<WorkQueue>");

            if (stage == ValidationStage.OnAdd || stage == ValidationStage.OnEdit)
            {

                if (list.Exists(x => x.Id != this.Id && x.Num == this.Num && this.WorkDate.Date.Equals(x.WorkDate.Date)))
                    return new ValidationResult(
                            ValidationState.Failed,
                            ReportType.MessageBox, 
                        $"Добавление отменено. Очередь с номером {this.Num} на дату { this.WorkDate.Date} уже существует");
            }

            return new ValidationResult(ValidationResult.Success);
        }

        protected override string GetTitle()
        {
            return $"Сортировка очереди № {Num} от {WorkDate}";
        }

        public override string ToString(string format, bool throwException = true, string subsituteWhenNotFound = "")
        {
            return $"Очередь";
        }

        public override string ToString()
        {
            return $"№{Num} от {WorkDate.ToString("dd.MM.yyyy")}";
        }

        public DateTime? DateDone
        {
            get => Orders.Exists(x => x.DateDone == null)
                ? null
                : Orders.Max(x => x.DateDone);
        }
        [NotMapped]
        public bool Cutted
        {
            get => Orders.Count > 0 && !Orders.Any(x => x.OrderStatus == null) 
                                    && Orders.Select(x => x.OrderStatus.Enumerator).Min() == OrderStatusEnum.Сutting;
        }
        [NotMapped]
        public bool Planed
        {
            get => Orders.Count > 0 && !Orders.Any(x => x.OrderStatus == null)
                                    && Orders.Select(x => x.OrderStatus.Enumerator).Min() == OrderStatusEnum.Plan;
        }

        public Pool Pool
        {
            get => Orders.FirstOrDefault(x => x.Pool != null)?.Pool;
        }

        public bool CanChange
        {
            get { return Status < OrderStatusEnum.Plan; }
        }

        //public bool Equals(Position x, Position y)
        //{
        //    return x.Glass1Name == y.Glass1Name &&
        //        x.Width == y.Width &&
        //        x.Height == y.Height &&
        //        x.Shape.Number == y.Shape.Number;
        //}

        //public int GetHashCode(Position obj)
        //{
        //    return obj.GetHashCode();
        //}

        //private class PositionComparerByGlass1Name : IComparer<Position>
        //{
        //    public int Compare(Position x, Position y)
        //    {
        //        int a = x.Glass1Name.CompareTo(y.Glass1Name) * 1000000;
        //        int b = (x.Width - y.Width) * 1000;
        //        int c = (x.Height - y.Height);
        //        return a + b + c;
        //    }
        //}
        public bool CanAppend(Order order)
        {
            return Pool == null
                   || order.Pool == null
                   || Pool.Id == order.Pool.Id;
        }

        public void MoveUp(Order ord)
        {
            if (ord.WorkQueueOrderNum - 1 == 0)
                return;

            int currIndex = Orders.IndexOf(ord);
            int toIndex = Math.Max((currIndex - 1), 0);
            Orders.Move(Orders, currIndex, toIndex);

            for (var i = 0; i < Orders.Count; i++)
                Orders[i].WorkQueueOrderNum = i + 1;
            Changed = true;
        }

        public void MoveDown(Order ord)
        {
            if (ord.WorkQueueOrderNum == Orders.Count)
                return;
            int currIndex = Orders.IndexOf(ord);
            int toIndex = Math.Min((currIndex + 1), Orders.Count -1);
            Orders.Move(Orders, currIndex, toIndex);

            for (var i = 0; i < Orders.Count; i++)
                Orders[i].WorkQueueOrderNum = i + 1;
            Changed = true;
        }

        [NotMapped]
        public OrderStatusEnum Status
        {
            get => GetStatus();
        }

        private OrderStatusEnum GetStatus()
        {
            if (Orders.Count < 1)
                return OrderStatusEnum.Template;
            return Orders.Any(x => x.OrderStatus == null)
                ? OrderStatusEnum.Template
                : Orders.Min(x => x.OrderStatus.Enumerator);
        }

        [NotMapped]
        public string Progress
        {
            get => GetProgress();
        }

        private string GetProgress()
        {
            if (Orders.Count < 1)
                return "0/0";
            return $"{GetDoneItems()}/{ GetItemsCount()}";
        }

        public int GetDoneItems()
        {
            return Orders.Sum(x => x.GetDoneItems());
        }

        public int GetItemsCount()
        {
            return Orders.Sum(x => x.GetItemsCount());
        }

        [NotMapped]
        public double ProgressPercent
        {
            get => GetProgressPercent();
        }
        public double GetProgressPercent()
        {
            if (Orders.Count < 1)
                return (double)0;
            return (double)GetDoneItems() / (double)GetItemsCount() * (double)100;
        }
    }
    
}