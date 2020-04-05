using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using Socrat.Core.Added;

namespace Socrat.Core.Entities
{
    public class FormulaItemProcessing: Entity
    {
        public Guid? FormulaItemId { get; set; }
        public Guid? ProcessingId { get; set; }

        [ParentItem]
        private FormulaItem _FormulaItem;
        public virtual FormulaItem FormulaItem
        {
            get { return _FormulaItem; }
            set { SetField(ref _FormulaItem, value, () => FormulaItem); }
        }

        private Processing _Processing;
        public virtual Processing Processing
        {
            get { return _Processing; }
            set { SetField(ref _Processing, value, () => Processing); }
        }

        public string Name
        {
            get { return Processing?.Name; }
        }

        public string Title
        {
            get { return Processing?.Title;}
        }

        public override string ToString()
        {
            return Processing?.ToString();
        }

        private double? _Distance1;
        public double? Distance1
        {
            get { return _Distance1; }
            set { SetField(ref _Distance1, value, () => Distance1); }
        }


        private double? _Distance2;
        public double? Distance2
        {
            get { return _Distance2; }
            set { SetField(ref _Distance2, value, () => Distance2); }
        }

        private double? _Distance3;
        public double? Distance3
        {
            get { return _Distance3; }
            set { SetField(ref _Distance3, value, () => Distance3); }
        }
        
        private double? _Distance4;
        public double? Distance4
        {
            get { return _Distance4; }
            set { SetField(ref _Distance4, value, () => Distance4); }
        }

        private double? _Distance5;
        public double? Distance5
        {
            get { return _Distance5; }
            set { SetField(ref _Distance5, value, () => Distance5); }
        }

        private double? _Distance6;
        public double? Distance6
        {
            get { return _Distance6; }
            set { SetField(ref _Distance6, value, () => Distance6); }
        }
        
        private double? _Distance7;
        public double? Distance7
        {
            get { return _Distance7; }
            set { SetField(ref _Distance7, value, () => Distance7); }
        }

        private double? _Distance8;
        public double? Distance8
        {
            get { return _Distance8; }
            set { SetField(ref _Distance8, value, () => Distance8); }
        } 

        
        private ObservableCollection<ProcessingComponent> _components = new ObservableCollection<ProcessingComponent>();
        public virtual ObservableCollection<ProcessingComponent> Components
        {
            get => _components;
            set => _components = value;
        }

        [NotMapped]
        public FormulaItemProcessingEnum Enumerator { get; set; } = FormulaItemProcessingEnum.СomponentsProcessing;

        public FormulaItemProcessing Clone()
        {
            FormulaItemProcessing _item = new FormulaItemProcessing();
            CopyFieldsValues(this, _item);
            _item.Id = Guid.NewGuid();
            _item.Processing = Processing;
            foreach (ProcessingComponent processingComponent in Components)
                _item.Components.Add(processingComponent.Clone());
            return _item;
        }
    }
}
