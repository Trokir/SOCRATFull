using System;
using Socrat.Lib;

namespace Socrat.Model
{
    public class CoworkerPosition: Entity
    {
        [ParentItem]
        private Division _Division;
        public Division Division
        {
            get { return _Division; }
            set { SetField(ref _Division, value, () => Division); }
        }

        public Nullable<Guid> Division_Id
        {
            get { return Division?.Id; }
        }

        private WorkPosition _WorkPosition;
        public WorkPosition WorkPosition
        {
            get { return _WorkPosition; }
            set { SetField(ref _WorkPosition, value, () => WorkPosition); }
        }

        public Nullable<Guid> WorkPosition_Id
        {
            get { return WorkPosition?.Id; }
        }


        private Coworker _Coworker;
        public Coworker Coworker
        {
            get { return _Coworker; }
            set { SetField(ref _Coworker, value, () => Coworker); }
        }


        public Nullable<Guid> Coworker_Id
        {
            get { return Coworker?.Id; }
        }

        private bool _Defuolt;
        public bool Defuolt
        {
            get { return _Defuolt; }
            set { SetField(ref _Defuolt, value, () => Defuolt); }
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
            return $"Сотркдник подразделения {Division.NameAlias}";
        }
    }
}