using System;
using System.Data.Entity.ModelConfiguration;

namespace Socrat.Core.Entities.WayBills
{
    /// <summary>
    /// Склад продукции или материалов
    /// </summary>
    [EntityFormConfiguration("Склады", "Склад: {Title}")]
    [PropertyVisualisation("Код", "Code", 20, 0)]
    [PropertyVisualisation("Склад", "Name", 150, 10)]
    [PropertyVisualisation("Произв.площадка", "Division", 100, 20)]
    [PropertyVisualisation("Примечание", "Comments", 500, 30)]
    public class Storage : Entity
    {
        public Storage()
        {
            IncomingProductionMovements = new AttachedList<ProductionMovement>(this);
            OutgoingProductionMovements = new AttachedList<ProductionMovement>(this);
        }

        #region Locals
        private string _code = "01";
        private string _name = "Склад продукции";
        private Division _division;
        private string _comments;
        #endregion

        #region ForeignKeys
        public Guid DivisionId { get; set; }
        #endregion

        #region Properties
        /// <summary>
        /// Код/префикс склада
        /// </summary>
        public string Code
        {
            get => _code;
            set => SetField(ref _code, value, () => Code);
        }

        /// <summary>
        /// Название склада
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetField(ref _name, value, () => Name);
        }

        /// <summary>
        /// Площадка - владелец склада
        /// </summary>
        [ParentItem]
        public virtual Division Division
        {
            get => _division;
            set => SetField(ref _division, value, () => Division);
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
        /// входящие накладные, т.е. склад явл. 'Target' для накладной
        /// </summary>
        public virtual AttachedList<ProductionMovement> IncomingProductionMovements { get; }

        /// <summary>
        /// исходящие накладные, т.е. склад явл. 'Source' для накладной
        /// </summary>
        public virtual AttachedList<ProductionMovement> OutgoingProductionMovements { get; }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return $"{Name} ({Division?.ShortName}/{Code})";
        }

        #endregion
        
    }
}
