using System.Collections.Generic;
using System.Linq;

namespace Socrat.Module.Order.Processings
{
    public class SingleSideChoiser
    {
        public event SideChoiseChanged SideChoiseChanged;

        public int SidesCount { get; set; }

        public int SelectedSide { get; set; }

        List<SideItem> list = new List<SideItem>();

        private void OnSideChoiseChanged(int[] SideNum)
        {
            SideChoiseChanged?.Invoke(SideNum);
        }

        public List<SideItem> GetSidesDataSource(int sidesCount)
        {
            SidesCount = sidesCount;
            SideItem _item = null;
            list.Clear();
            for (int i = 1; i <= SidesCount; i++)
            {
                _item = new SideItem { Num = i, Name = $"Сторона {i}", State = GetState(i) };
                _item.PropertyChanged += _item_PropertyChanged;
                list.Add(_item);
            }
            return list;
        }

        private bool GetState(int num)
        {
            return num == SelectedSide;
        }

        private void _item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SideItem _sideItem = sender as SideItem;
            if (_sideItem != null)
            {
                if (_sideItem.State)
                {
                    SelectedSide = _sideItem.Num;
                    ResetOther(_sideItem.Num);
                    OnSideChoiseChanged(new int[] { SelectedSide });
                }
                
            }
        }

        private void ResetOther(int sideItemNum)
        {
            foreach (SideItem item in list)
            {
                if (item.Num != sideItemNum)
                    item.State = false;
            }
        }

        public void SetChosenSide(int selectedSide)
        {
            if (selectedSide == 0)
                return;
            SelectedSide = selectedSide;
            ResetOther(SelectedSide);
            list.FirstOrDefault(x => x.Num == SelectedSide).State = true;
            OnSideChoiseChanged(new int[] { SelectedSide });
        }
    }
}