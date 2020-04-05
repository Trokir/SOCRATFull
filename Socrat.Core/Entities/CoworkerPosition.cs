using System;

namespace Socrat.Core.Entities
{
    public class CoworkerPosition : Entity
    {
        public Guid? DivisionId { get; set; }
        public Guid? WorkPositionId { get; set; }
        public Guid? CoworkerId { get; set; }

        private bool? _default;
        public bool? Default
        {
            get { return _default; }
            set { SetField(ref _default, value, () => Default); }
        }

        private Coworker _coworker;
        public virtual Coworker Coworker
        {
            get { return _coworker; }
            set { SetField(ref _coworker, value, () => Coworker); }
        }

        [ParentItem]
        private Division _division;
        public virtual Division Division
        {
            get { return _division; }
            set { SetField(ref _division, value, () => Division); }
        }

        private WorkPosition _workPosition;
        public virtual WorkPosition WorkPosition
        {
            get { return _workPosition; }
            set { SetField(ref _workPosition, value, () => WorkPosition); }
        }

        /// <summary>
        /// Полное ФИО сртрудника
        /// </summary>
        public string CoworkerFullName
        {
            get => Coworker?.FullName;
        }

        public string CoworkerMobilePhone
        {
            get => Coworker?.MobilePhone;
        }

        public string CoworkerWorkPhone
        {
            get => Coworker?.WorkPhone;
        }

        public string CoworkerInternalPhone
        {
            get => Coworker?.InternalPhone;
        }

        protected override string GetTitle()
        {
            return $"Сотркдник подразделения {Division.AliasName}";
        }
    }
}
