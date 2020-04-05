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

       
        void DirectFormulaMapping()
        {

            CreateMap<InsetPosition, Core.Entities.InsetPosition>()
                // .IncludeAllDerived()
              .ReverseMap();

            CreateMap<InsetItemProperty, Core.Entities.InsetItemProperty>()
                .ForMember(x => x.InsetPositions, a => a.MapFrom(p => p.InsetPositions))
                // .IncludeAllDerived()
                .ReverseMap();

            CreateMap<Formula, Core.Entities.Formula>()
           .ForMember(x => x.TenderFormulas, a => a.Ignore())
           .ForMember(x => x.OrderRows, a => a.Ignore())
           .ForMember(x => x.MaterialNomFormulas, a => a.Ignore())
           .MaxDepth(2)
           // .IncludeAllDerived()
           .ReverseMap();

            CreateMap<FormulaItem, Core.Entities.FormulaItem>()
               .ForMember(x => x.Formula, a => a.Ignore())
               .ForMember(x => x.FormulaItemProcessings, a => a.Ignore())
               .ForMember(x => x.FormulaItems, a => a.MapFrom(p => p.FormulaItems))
               .MaxDepth(4)
               // .IncludeAllDerived()
               .ReverseMap();

            CreateMap<FormulaItemProcessing, Core.Entities.FormulaItemProcessing>()
                .ForMember(x => x.Components, a => a.Ignore())
                // .IncludeAllDerived()
                .ReverseMap();




            CreateMap<FrameItemProperty, Core.Entities.FrameItemProperty>()
                // .IncludeAllDerived()
                .ReverseMap();



            CreateMap<GlassItemProperty, Core.Entities.GlassItemProperty>()
                .ForMember(x => x.GlassItem, a => a.Ignore())
                .MaxDepth(2)
                // .IncludeAllDerived()
                .ReverseMap();

            CreateMap<GlassItemProperty, Core.Entities.FrameItemProperty>()
                //.ForMember(x => x.FrameItem, a => a.Ignore())
                //.MaxDepth(2)
                .IncludeAllDerived()
                .ReverseMap();

            CreateMap<GlassItemProperty, Core.Entities.TriplexItemProperty>()
                .ForMember(x => x.TriplexItem, a => a.Ignore())
                .MaxDepth(2)
                // .IncludeAllDerived()
                .ReverseMap();

            CreateMap<GlassItemProperty, Core.Entities.InsetItemProperty>()
                .ForMember(x => x.InsetItem, a => a.Ignore())
                .MaxDepth(2)
               //  .IncludeAllDerived()
                .ReverseMap();
        }
    }
}