using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Socrat.Core.Helpers
{
    public class SequencedCollectionHelper<T> : IDisposable  
        where T:  Entity, new()
    {
        List<Tuple<int, T>> _listSequences = new  AttachedList<Tuple<int, T>>();
        List<T> _list = new List<T>();
        private bool _onSequenceUpdate = false;
        public SequencedCollectionHelper(AttachedList<T> items)
        {
            Items = items;
            Items.CollectionChanged += Items_CollectionChanged;

            RebildListSequences();
            RefreshSequences();
            SubcribeItems();
        }

        private void RefreshSequences()
        {
            _onSequenceUpdate = true;
            _list.Clear();
            foreach (Tuple<int, T> tuple in _listSequences.OrderBy(x => x.Item1))
                _list.Add(tuple.Item2);               
            for (int i = 0; i < _list.Count; i++)
               SetSequenceValue(_list[i], (short)(i + 1));
            RebildListSequences();
            _onSequenceUpdate = false;
        }

        private void RebildListSequences()
        {
            _onSequenceUpdate = true;
            _listSequences.Clear();
            foreach (T item in Items)
            {
                _listSequences.Add(new Tuple<int, T>(GetSequenceValue(item), item));
            }
            _onSequenceUpdate = false;
        }

        private void SubcribeItems()
        {
            foreach (T item in Items)
            {
                item.PropertyChanged -= ItemOnPropertyChanged;
                item.PropertyChanged += ItemOnPropertyChanged;
            }
        }

        private void ItemOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!_onSequenceUpdate && e.PropertyName == "Sequence")
                ItemSequenceChanged(sender);
        }

        private void ItemSequenceChanged(object item)
        {
            T _item = item as T;
            if (_item != null)
            {
                int _seq = GetSequenceValue(_item);
                _seq = Math.Min(_seq, _list.Count);

                _list.Remove(_item);
                if (_seq - 1 >= _list.Count)
                    _list.Add(_item);
                else
                    _list.Insert(_seq - 1, _item);
                
                _onSequenceUpdate = true;
                for (int i = 0; i < _list.Count; i++)
                    SetSequenceValue(_list[i], (short)(i + 1));
                _onSequenceUpdate = false;
                RebildListSequences();
            }
        }


        private void Items_CollectionChanged(object sender, CollectionChangedEventArgs<T> e)
        {
            if (e.Removed.Count > 0)
            {
                foreach (T x1 in e.Removed)
                {
                    _listSequences.RemoveAll(x => x.Item2.Id == x1.Id);
                }

                RefreshSequences();
                return;
            }

            if (e.Added.Count > 0)
            {
                foreach (T addedItem in e.Added)
                {
                    addedItem.PropertyChanged -= ItemOnPropertyChanged;
                    addedItem.PropertyChanged += ItemOnPropertyChanged;
                    int _seq = GetSequenceValue(addedItem);

                    if (_seq < 0)
                        _seq = 0;

                    if (_seq -1 >= _list.Count)
                        _list.Add(addedItem);
                    else
                        _list.Insert(_seq-1, addedItem);

                    for (int i = 0; i < _list.Count; i++)
                        SetSequenceValue(_list[i], (short)(i + 1));

                    RebildListSequences();
                }
            }
        }

        public AttachedList<T> Items { get; set; }

        private int GetSequenceValue(T item)
        {
            int res = -1;
            var prop = item.GetType().GetProperty("Sequence");
            if (prop != null)
            {
                var tmp = prop.GetValue(item);
                if (tmp != null)
                    int.TryParse(tmp.ToString(), out res);
            }
            return res;
        }

        private void SetSequenceValue(T item, short value)
        {
            var prop = item.GetType().GetProperty("Sequence");
            if (prop != null)
            {
                prop.SetValue(item, value);
            }
        }

        public void Dispose()
        {
            if (Items != null)
            {
                foreach (T item in Items)
                    item.PropertyChanged -= ItemOnPropertyChanged;
                Items.CollectionChanged -= Items_CollectionChanged;
            }
            if (_list != null)
                _list.Clear();
            if (_listSequences != null)
                _listSequences.Clear();
        }
    }
}