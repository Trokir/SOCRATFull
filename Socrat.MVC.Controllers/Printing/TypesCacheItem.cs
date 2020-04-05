using DevExpress.XtraReports.UI;
using Socrat.Common;
using Socrat.Core.Entities.Printing;
using Socrat.Interfaces;
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Socrat.MVC.Controllers.Printing
{
    public class TypesCacheItem : ITemplate
    {
        public string RequestorFullClassName { get; private set; }
        public Type RxTemplateType { get; private set; }
        public PrintableAttribute PrintableAttribute { get; private set; }
        public Template Template { get; private set; }
        public XtraReport EmbeddedReport { get; set; }
        public TemplateTypes TemplateType { get; private set; }
        public string Content { get => Template?.Contents; }

        /// <summary>
        /// Создаем элемент кэша из определения, взятого из БД
        /// </summary>
        /// <param name="template">Запись о шаблоне печати</param>
        public TypesCacheItem(Template template)
        {
            Template = template
                ?? throw new ArgumentNullException(
                    "Невозможно инициализировать печать сущности " +
                    "поскольку предоставленный экземпляр шаблона есть null");

            if (!string.IsNullOrEmpty(template.Contents))
            {
                try
                {
                    EmbeddedReport = ReportHelper.GetReport(Encoding.UTF8.GetBytes(Template?.Contents));
                }
                catch
                {
                    EmbeddedReport = null;
                }
            }

            if (!string.IsNullOrEmpty(template.BuiltInReportClassName))
            {
                if (Assembly.Load("Socrat.Reports") is Assembly assy)
                    if (assy.ExportedTypes.Where(type => 
                        type.FullName == template.BuiltInReportClassName).FirstOrDefault() is Type builtInReport)
                        RxTemplateType = builtInReport;
            }

            TemplateType = TemplateTypes.PrintTemplate;
        }

        /// <summary>
        ///  Создаем элемент кэша из определения, взятого из аттрибута класса
        /// </summary>
        /// <param name="printableAttribute"></param>
        public TypesCacheItem(PrintableAttribute printableAttribute, Type templateType )
        {
            PrintableAttribute = printableAttribute
                ?? throw new ArgumentNullException(
                    "Невозможно инициализировать печать сущности, " +
                    "поскольку предоставленный атрибут " +
                    "определения печати есть null");
            RequestorFullClassName = PrintableAttribute.EntityClassName;
            RxTemplateType = templateType;
            TemplateType = TemplateTypes.PrintTemplate;
        }

        /// <summary>
        ///  Создаем элемент кэша из определения, взятого из класса
        /// </summary>
        /// <param name="type"></param>
        public TypesCacheItem(Type type)
        {
            RxTemplateType = type
                ?? throw new ArgumentNullException(
                    "Невозможно инициализировать печать сущности " +
                    "поскольку предоставленный тип сущности есть null");

            RequestorFullClassName = type.FullName;
            PrintableAttribute = type.GetCustomAttributes(typeof(PrintableAttribute), true).FirstOrDefault() as PrintableAttribute;
            TemplateType = TemplateTypes.PrintTemplate;
        }

        /// <summary>
        ///  Типа признак валидности элемента кэша. Хотя пока не понятно что именно проверять и как.
        /// </summary>
        public bool CanPrint { get; private set; } = true;

        public string Title { get => ToString(); }

        public override string ToString()
        {
            if (Template != null)
                return Template.Name;
            if (PrintableAttribute != null)
                return PrintableAttribute.Alias;
            if (RxTemplateType != null)
                return RxTemplateType.FullName;
            return base.ToString();
        }
    }
}
