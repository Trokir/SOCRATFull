using Socrat.Core.Added;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Socrat.Core.Entities
{
    public class OrderRowsList<T> : AttachedList<T> where T : OrderRow, new()
    {
        public event EventHandler<OrderRowChangedEventArgs> PriceRecalculationRequested;

        private Order _order;

        public OrderRowsList(IEnumerable<T> collection, IEntity owner = null) : base(collection, owner)
        {
            collection.ToList()
                .ForEach(item =>
                {
                    item.PriceRecalculationRequested -= OnPriceRecalculationRequested;
                    item.PriceRecalculationRequested += OnPriceRecalculationRequested;
                });

            _order = owner as Order;
        }

        public OrderRowsList(IEntity owner = null) : base(owner)
        {
            _order = owner as Order;
        }

        public new T this[int index]
        {
            get => base[index];
            set
            {
                value.PriceRecalculationRequested -= OnPriceRecalculationRequested;
                value.PriceRecalculationRequested += OnPriceRecalculationRequested;
                base[index] = value;
            }
        }

        public new void Add(T item)
        {
            item.PriceRecalculationRequested += OnPriceRecalculationRequested;
            base.Add(item);
        }

        public new void AddRange(IEnumerable<T> collection)
        {
            collection.ToList()
                .ForEach(item =>
                {
                    item.PriceRecalculationRequested -= OnPriceRecalculationRequested;
                    item.PriceRecalculationRequested += OnPriceRecalculationRequested;
                });
            base.AddRange(collection);
        }

        public new void Insert(int index, T item)
        {
            item.PriceRecalculationRequested -= OnPriceRecalculationRequested;
            item.PriceRecalculationRequested += OnPriceRecalculationRequested;
            base.Insert(index, item);
        }

        public new void InsertRange(int index, IEnumerable<T> collection)
        {
            collection.ToList()
                .ForEach(item =>
                {
                    item.PriceRecalculationRequested -= OnPriceRecalculationRequested;
                    item.PriceRecalculationRequested += OnPriceRecalculationRequested;
                });
            base.InsertRange(index, collection);
        }

        public new void Remove(T item)
        {
            item.PriceRecalculationRequested -= OnPriceRecalculationRequested;
            base.Remove(item);
        }

        public new void RemoveAt(int index)
        {
            base[index].PriceRecalculationRequested -= OnPriceRecalculationRequested;
            base.RemoveAt(index);
        }

        public new void RemoveRange(int index, int count)
        {
            for (int i = index; i < count; i++)
                base[index].PriceRecalculationRequested -= OnPriceRecalculationRequested;
            base.RemoveRange(index, count);
        }

        public new void RemoveAll(Predicate<T> match)
        {
            FindAll(match).ForEach(orderRow => orderRow.PriceRecalculationRequested -= OnPriceRecalculationRequested);
            base.RemoveAll(match);
        }

        private void OnPriceRecalculationRequested(object sender, OrderRowChangedEventArgs e)
        {
            PriceRecalculationRequested?.Invoke(this, e);
        }
    }
}
