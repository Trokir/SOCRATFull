using System;
using AutoMapper;
using Socrat.Core.Added;
using Socrat.Core.Helpers;
using Socrat.Data.Model;
using Socrat.Data.Model.Machines;

namespace Socrat.DataProvider
{
    /// <summary>
    ///     Класс настройки преобразования из ДТО в ViewModel и обратно
    /// </summary>
    public partial class EntityMapperProfile : Profile
    {

     
        void DirectPrintMapping()
        {

            CreateMap<TemplateFormat, Core.Entities.Printing.TemplateFormat>()
                 // .IncludeAllDerived()
                .ReverseMap();

            CreateMap<Template, Core.Entities.Printing.Template>()
                .ForMember(m => m.Customer, a => a.Ignore())
                .MaxDepth(2)
                //  .IncludeAllDerived()
                .ReverseMap();
        }
    }
}