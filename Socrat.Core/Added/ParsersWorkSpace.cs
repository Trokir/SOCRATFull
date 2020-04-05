using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DevExpress.DirectX.Common.Direct2D;
using Socrat.Core.Entities;
using Socrat.Core.Entities.Parsers;

namespace Socrat.Core.Added
{
    public class ParsersWorkSpace: Entity
    {
        public event EventHandler CustomerChanged; 

        public string WorkDir { get; set; } 

        private Customer _Customer;
        public Customer Customer
        {
            get { return _Customer; }
            set
            {
                SetField(ref _Customer, value, () => Customer);
                if (_Customer != null)
                    OnCustomerChanged();
            }
        }

        public string InputDir
        {
            get => Path.Combine(WorkDir, Customer.Id.ToString(), "Input");
        }

        public string OutputDir
        {
            get => Path.Combine(WorkDir, Customer.Id.ToString(), "Output");
        }

        public string ArchDir
        {
            get => Path.Combine(WorkDir, Customer.Id.ToString(), "Arch");
        }

        private List<ParsersWorkItem> _Items = new List<ParsersWorkItem>();
        public List<ParsersWorkItem> Items
        {
            get { return _Items; }
            set { SetField(ref _Items, value, () => Items); }
        }

        public void AddInputFile(ParsersWorkItem inputFile)
        {
            ParsersWorkItem _item = Items.FirstOrDefault(x => x.Path.EndsWith("Input"));
            if (_item != null)
                _item.Items.Add(inputFile);
        }

        public ParsersWorkItem InputItem
        {
            get => Items.FirstOrDefault(x => x.Path.EndsWith("Input"));
        }

        public ParsersWorkItem OutputItem
        {
            get => Items.FirstOrDefault(x => x.Path.EndsWith("Output"));
        }

        public ParsersWorkItem ArchItem
        {
            get => Items.FirstOrDefault(x => x.Path.EndsWith("Arch"));
        }

        public object CustomerDir
        {
            get { return Path.Combine(WorkDir, Customer?.Id.ToString()); }
        }

        private void OnCustomerChanged()
        {
            CustomerChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanSelectItem(Guid id)
        {
            bool res = false;
            res = InputItem.Id == id;
            if (!res)
                res = InputItem.Items.Exists(x => x.Id == id);
            return res;
        }

        public List<CustomerOrderRow> GetAllRows()
        {
            return OutputItem.Items.Select(f => f.CustomerOrderFile)
                .SelectMany(o => o.CustomerOrders)
                .SelectMany(r => r.Rows).ToList();
        }

        public List<CustomerOrder> GetAllOrders()
        {
            return OutputItem.Items.Select(f => f.CustomerOrderFile)
                .SelectMany(o => o.CustomerOrders).ToList();
        }

        public List<CustomerOrderFile> GetAllOrdersFiles()
        {
            return OutputItem.Items.Select(f => f.CustomerOrderFile).ToList();
        }

        public void ReloadOutputItems()
        {
            OutputItem.Items.Clear();
            foreach (CustomerOrderFile customerOrderFile in Customer.CustomerOrderFiles.Where(x => !x.Used))
            {
                OutputItem.Items.Add(new ParsersWorkItem
                {
                    Name = customerOrderFile.ToString(),
                    Path = customerOrderFile.FileName,
                    CustomerOrderFile = customerOrderFile,
                    ParsersWorkItemType = ParsersWorkItemType.Output
                });
            }
        }



        public ParsersWorkItem GetItemByCustomerOrderFile(CustomerOrderFile file)
        {
            ParsersWorkItem _item = null;
            if (OutputItem != null)
            {
                _item = OutputItem.Items.FirstOrDefault(x => x.CustomerOrderFile != null && x.CustomerOrderFile.Id == file.Id);
            }

            return _item;
        }

        public void ReloadUsedItems(ParsersWorkItem usedItems)
        {
            usedItems.Items.Clear();
            foreach (CustomerOrderFile customerOrderFile in Customer.CustomerOrderFiles.Where(x => x.Used))
            {
                usedItems.Items.Add(new ParsersWorkItem
                {
                    Name = Path.GetFileName(customerOrderFile.FileName),
                    Path = customerOrderFile.FileName,
                    CustomerOrderFile = customerOrderFile,
                    ParsersWorkItemType = ParsersWorkItemType.Used
                });
            }
        }
    }
}