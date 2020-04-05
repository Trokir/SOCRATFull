using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Socrat.Core;
using Socrat.Lib;
using Socrat.Lib.Module;
using Socrat.Shape;
using Socrat.Shape.Forms;

namespace Socrat.Module.Order
{
    [ModuleStarter]
    public class ShapeModuleStarter : IModule
    {
        private string _name;
        private SqlHelper _sqlHelper;
        private ITabable _form;
        private Guid id;

        public string Name
        {
            get => "Каталог фигур";
        }

        public SqlHelper SqlHelper
        {
            get => _sqlHelper;
            set => _sqlHelper = value;
        }

        public ITabable Form
        {
    get => new FxShapeEditor(id);
   // get => new FxShapeCatalogEditor(id);
        }
       
    }
}