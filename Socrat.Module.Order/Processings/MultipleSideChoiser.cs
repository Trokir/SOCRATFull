using System.Collections.Generic;
using System.Linq;
using Socrat.Core.Entities;

namespace Socrat.Module.Order.Processings
{
    public class MultipleSideChoiser
    {
        public event SideChoiseChanged SideChoiseChanged;

        private void OnSideChoiseChanged(int[] SideNum)
        {
            SideChoiseChanged?.Invoke(SideNum);
        }

        public SideProcessing SideProcessing { get; set; }

        public int SidesCount { get; set; }

        public List<SideItem> list;

        public void SetSide(int sideNum, bool state)
        {
            SideProcessing.SelectedSides = SetBit(SideProcessing.SelectedSides, sideNum, state);
        }

        public bool GetSide(int sideNum)
        {
            return (SideProcessing.SelectedSides >> sideNum & 1) == 1;
        }

        ///<summary>
        /// Устанавливает значение определенного бита в байте
        ///</summary>
        ///<param name="val">Входнойбайт</param>
        ///<param name="num">Номербита</param>
        ///<param name="bit">Значениебита: true-битравен 1, false- битравен 0 </param>
        ///<returns>Байт, с измененным значением бита</returns>
        private int SetBit(int val, int num, bool bit)
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

        public List<SideItem> GetSidesDataSource(int sidesCount)
        {
            SidesCount = sidesCount;
            list = new List<SideItem>();
            SideItem _item = null;
            for (int i = 1; i <= SidesCount; i++)
            {
                _item = new SideItem {Num = i, Name = $"Сторона {i}", State = GetSide(i)};
                _item.PropertyChanged += _item_PropertyChanged;
                list.Add(_item);
            }
            return list;
        }

        public int[] GetChosenSides()
        {
            List<int> _list = new List<int>();
            for (int i = 1; i <= SidesCount; i++)
            {
                if (GetSide(i))
                    _list.Add(i);
            }
            return _list.ToArray();
        }

        private void _item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SideItem _sideItem = sender as SideItem;
            if (_sideItem != null)
            {
                SetSide(_sideItem.Num, _sideItem.State);
                OnSideChoiseChanged(GetChosenSides());
            }
        }

        public void SetChosenSides(int[] selectedSides)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].State = selectedSides.Contains(list[i].Num);
            }
        }
    }
}