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
      
        void DirectProcessingMapping()
        {
            CreateMap<ProcessingComponent, Core.Entities.ProcessingComponent>()
                 // .IncludeAllDerived()
                .ReverseMap();

            CreateMap<ProcessingNom, Core.Entities.ProcessingNom>()
              .ForMember(x => x.Processing, s => s.Ignore())
              .ForMember(x => x.MachineGroup, s => s.Ignore())
              .ForMember(x => x.PriceProcessings, s => s.MapFrom(d => d.PriceProcessings))
              .ForMember(x => x.FormulaItemProcessings, s => s.MapFrom(d => d.FormulaItemProcessings))
               // .IncludeAllDerived()
              .ReverseMap();


            CreateMap<TransformationRule, Core.Entities.Transformations.TransformationRule>()
                 // .IncludeAllDerived()
                .ReverseMap();

            CreateMap<Measure, Core.Entities.Measure>()
                  .ForMember(x => x.MaterialSizeTypes, a => a.Ignore())
                  .ForMember(x => x.ProcessingComponents, a => a.Ignore())
                  .ForMember(x => x.ProcessingTypes, a => a.Ignore())
                // .IncludeAllDerived()
                .ReverseMap();


            CreateMap<ProcessingMaterialMarkType, Core.Entities.ProcessingMaterialMarkType>()
                  .ForMember(x => x.Processing, a => a.Ignore())
                  .ForMember(x => x.MaterialMarkType, a => a.Ignore())
                // .IncludeAllDerived()
                .ReverseMap();








            CreateMap<ProcessingType, Core.Entities.ProcessingType>()
                  .ForMember(x => x.Measure, a => a.Ignore())
                  .ForMember(x => x.MachineTypeProcessings, a => a.MapFrom(p => p.MachineTypeProcessings))
                  .ForMember(x => x.Processings, a => a.MapFrom(p => p.Processings))
                  .ForMember(x => x.ProcessingTypeMaterials, a => a.MapFrom(p => p.ProcessingTypeMaterials))
                //  .IncludeAllDerived()
                .ReverseMap();


            CreateMap<ProcessingTypeMaterial, Core.Entities.ProcessingTypeMaterial>()
                .ReverseMap();




            CreateMap<Processing, Core.Entities.Processing>()
                 .ForMember(x => x.ProcessingType, a => a.Ignore())
                  .ForMember(x => x.SlozType, a => a.Ignore())
                  .ForMember(x => x.ProsessingMaterialMarkTypes, a => a.MapFrom(p => p.ProsessingMaterialMarkTypes))
                  .ForMember(x => x.ComponentMaterialsMarkTypes, a => a.Ignore())
                  .ForMember(x => x.VendorMachineProcessings, a => a.Ignore())
                  .ForMember(x => x.ProcessingNoms, a => a.Ignore())
                  .ForMember(x => x.WorkDifficulties, a => a.Ignore())
                  .ForMember(x => x.FormulaItemProcessings, a => a.Ignore())
                .MaxDepth(6)
                //  .IncludeAllDerived()
                .ReverseMap();


            CreateMap<ProcessingComponentMaterialsMarkType, Core.Entities.ProcessingComponentMaterialsMarkType>()
                 // .IncludeAllDerived()
                 .ReverseMap();
        }
    }
}