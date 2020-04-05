using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Socrat.Core;
using Socrat.Lib;
using Socrat.Lib.Module;

namespace Socrat.Module.Order
{
    [ModuleStarter]
    public class ModuleOrderStarter: IModule
    {
        private string _name;
        private SqlHelper _sqlHelper;
        private ITabable _form;

        public string Name
        {
            get => "Модуль заказа";
        }

        public SqlHelper SqlHelper
        {
            get => _sqlHelper;
            set => _sqlHelper = value;
        }

        public ITabable Form
        {
            get => new FxOrders();
        }
    }
}
