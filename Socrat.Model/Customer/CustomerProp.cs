using System;

namespace Socrat.Model
{
    public class CustomerProp: Entity
    {

        private CustomerPropType _CustomerPropType;
        public CustomerPropType CustomerPropType
        {
            get { return _CustomerPropType; }
            set { SetField(ref _CustomerPropType, value, () => CustomerPropType); }
        }


        private byte[] _Value;
        public byte[] Value
        {
            get { return _Value; }
            set { SetField(ref _Value, value, () => Value); }
        } 

    }
}
