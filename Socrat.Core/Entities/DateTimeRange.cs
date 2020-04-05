using System;

namespace Socrat.Core.Entities
{
    public class DateTimeRange : Entity
    {
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                SetField(ref _name, value, () => Name);
            }
        }

        private DateTime? _start;

        public DateTime? Start
        {
            get
            {
                return _start;
            }
            set
            {
                SetField(ref _start, value, () => Start);
            }
        }

        private DateTime? _finish;

        public DateTime? Finish
        {
            get { return _finish; }
            set
            {
                SetField(ref _finish, value, () => Finish);
            }
        }
    }
}
