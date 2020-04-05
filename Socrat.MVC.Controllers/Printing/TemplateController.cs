using Socrat.Common;
using Socrat.Common.Interfaces.MVC;
using Socrat.Core.Entities.Printing;
using Socrat.DataProvider;
using Socrat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Socrat.MVC.Controllers.Printing
{
    public partial class TemplateController : Controller
    {
        private static List<Template> CachedTemplates;

        public event EventHandler<ITemplate> TemplateSelected;
        public PrintTemplateSelecttionController SelectionController { get; protected set; }
        public Type RequestorType { get; private set; }
        public List<ITemplate> Templates { get; private set; } = new List<ITemplate>();
        public ITemplate SelectedTemplate { get; protected set; }

        /// <summary>
        /// Родительская форма
        /// </summary>
        public IView ParentView { get; private set; }

        public TemplateController(IController parent, IView parentView = null)
        {
            SelectionController = new PrintTemplateSelecttionController();
            SelectionController.TemplateSelectded += OnTemplateSelected;
            Parent = parent;
            RequestorType = typeof(object);
            ParentView = parentView;
            Load(RequestorType);
            
        }

        private void OnTemplateSelected(object sender, ITemplate e)
        {
            TemplateSelected?.Invoke(this, e);
        }

        public TemplateController(IController parent, Type requestorType, IView parentView = null)
        {
            SelectionController = new PrintTemplateSelecttionController();
            SelectionController.TemplateSelectded += OnTemplateSelected;
            RequestorType = requestorType;
            ParentView = parentView;
            Load(RequestorType);
        }

        public void Select(Form parentForm)
        {
            if (Templates.Count == 1)
            { 
                OnTemplateSelected(this, Templates.FirstOrDefault());
                return;
            }

            if (Templates.Count == 0)
                throw new Exception("Нет шаблронов печати");


            SelectionController
                .Run(
                    parentForm,
                    null,
                    Templates);
        }

        public ITemplate GetDefaultTemplate()
        {
            if (Templates.Count < 2)
                return Templates.FirstOrDefault();
            return null;
        }

        private void Load(Type requestorType = null)
        {
            try
            {
                if (CachedTemplates == null)
                    CachedTemplates = new List<Template>();
                if (CachedTemplates.Count == 0)
                    CachedTemplates.AddRange(DataHelper.GetRepository<Template>().GetAll().OrderBy(template => template.Name));

                Templates.Clear();

                CachedTemplates.Where(y =>
                        y.EntityClassName == requestorType.FullName).ToList()
                            .ForEach(dbTemplate =>
                                    Templates.Add(new TypesCacheItem(dbTemplate)));

                if (Templates.Count == 0)
                {
                    if (requestorType.GetCustomAttributes(typeof(PrintableAttribute), true).FirstOrDefault() is PrintableAttribute printableAttribute)
                        if (!string.IsNullOrEmpty(printableAttribute.SubstituteEntityName))
                            if (Activator.CreateInstance("Socrat.Core", printableAttribute.SubstituteEntityName).Unwrap().GetType() is Type type)
                                Load(type);
                }
            }
            //Обернуто, чтобы не падало в дизайнере
            catch { }
        }
    }
}
