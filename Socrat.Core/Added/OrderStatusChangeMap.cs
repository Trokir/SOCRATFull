using Socrat.Core.Entities;

namespace Socrat.Core.Added
{
    public class OrderStatusChangeMap
    {
        private OrderStatus _orderStatus;

        public OrderStatusChangeMap(OrderStatus orderStatus)
        {
            _orderStatus = orderStatus;
        }

        public void SetStatusState(OrderStatus toStatus, bool state)
        {
            _orderStatus.ChangeMap = SetBit(_orderStatus.ChangeMap, toStatus.OrderNum, state);
            _orderStatus.Changed = true;
        }

        public bool CanChangeToStatusState(OrderStatus toStatus)
        {
            return (_orderStatus.ChangeMap >> toStatus.OrderNum & 1) == 1;
        }

        ///<summary>
        /// Устанавливает значение определенного бита в байте
        ///</summary>
        ///<param name="val">Входнойбайт</param>
        ///<param name="num">Номербита</param>
        ///<param name="bit">Значениебита: true-битравен 1, false- битравен 0 </param>
        ///<returns>Байт, с измененным значением бита</returns>
        public static int SetBit(int val, int num, bool bit)
        {
            int tmpval = 1;
            tmpval = (int)(tmpval << num);//устанавливаем нужный бит в единицу
            val = (int)(val & (~tmpval));//сбрасываем в 0 нужный бит

            if (bit)// если бит требуется установить в 1
            {
                val = (int)(val | (tmpval));//то устанавливаем нужный бит в 1
            }
            return val;
        }
    }
}