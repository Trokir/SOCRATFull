using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socrat.Core.Entities.WayBills
{
    public class ProductionMovement : Entity
    {
        public ProductionMovement()
        {
            Rows = new AttachedList<WaybillRow>(this);
        }


        #region Locals
        private DateTime _dated = DateTime.Today;
        private int _number;
        private string _comments;
        private Storage _source;
        private Storage _target;
        private int _movementType;
        #endregion Locals

        #region ForeignKeys
        public Guid? SourceId { get; set; }
        public Guid? TargetId { get; set; }
        #endregion ForeignKeys

        #region Properties

        /// <summary>
        /// Дата отгрузки
        /// </summary>
        public DateTime Dated
        {
            get => _dated;
            set => SetField(ref _dated, value, () => Dated);
        }

        /// <summary>
        /// Номер накладной
        /// </summary>
        public int Number
        {
            get => _number;
            set => SetField(ref _number, value, () => Number);
        }

        /// <summary>
        /// Примечание
        /// </summary>
        public string Comments
        {
            get => _comments;
            set => SetField(ref _comments, value, () => Comments);
        }

        /// <summary>
        /// Отгружаем со склада
        /// </summary>
        public virtual Storage Source
        {
            get => _source;
            set => SetField(ref _source, value, () => Source);
        }

        /// <summary>
        /// перемещение на склад
        /// </summary>
        public virtual Storage Target
        {
            get => _target;
            set => SetField(ref _target, value, () => Target);
        }

        /// <summary>
        /// Тип перемещения: 1 - отгрузка (накладная на вывоз), 2 - перемещение от сборки на отгрузку (вн.накладная на отгрузку), ...
        /// </summary>
        public int MovementType
        {
            get => _movementType;
            set => SetField(ref _movementType, value, () => MovementType);
        }

        public virtual Waybill Waybill { get; set; }
        public virtual InternalTransfer InternalTransfer { get; set; }
        #endregion Properties

        /// <summary>
        /// Список строк накладной
        /// </summary>
        public AttachedList<WaybillRow> Rows { get; private set; }

    }
}
