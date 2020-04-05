using Socrat.Core;

namespace Socrat.Module.Order.Processings
{
    public class SideItem: Entity
    {
        private int _Num;
        public int Num
        {
            get { return _Num; }
            set { SetField(ref _Num, value, () => Num); }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetField(ref _Name, value, () => Name); }
        }

        private bool _State;
        public bool State
        {
            get { return _State; }
            set { SetField(ref _State, value, () => State); }
        } 


    }
}