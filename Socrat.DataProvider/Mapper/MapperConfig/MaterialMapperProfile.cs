using AutoMapper;
using Socrat.Data.Model;

namespace Socrat.DataProvider
{
    public partial class EntityMapperProfile : Profile
    {
       
        void DirectMaterialMapping()
        {

            CreateMap<FieldValue, Core.Entities.FieldValue>()
                // .IncludeAllDerived()
                .ReverseMap();

            CreateMap<Field, Core.Entities.Field>()
                // .IncludeAllDerived()
                .ReverseMap();

            CreateMap<MaterialField, Core.Entities.MaterialField>()
                // .IncludeAllDerived()
                .ReverseMap();

            CreateMap<MaterialMarkType, Core.Entities.MaterialMarkType>()
                .ForMember(x => x.SlozType, a => a.Ignore())
               .ForMember(x => x.Material, a => a.Ignore())
               .ForMember(x => x.ProsessingMaterialMarkTypes, a => a.Ignore())
               .ForMember(x => x.PriceTypeMarkTypes, a => a.MapFrom(p => p.PriceTypeMarkTypes))
               .ForMember(x => x.MaterialSizeTypes, a => a.MapFrom(p => p.MaterialSizeTypes))
               .ForMember(x => x.ComponentMaterialsMarkTypes, a => a.Ignore())
               .ForMember(x => x.ProsessingMaterialMarkTypes, a => a.MapFrom(p => p.ProsessingMaterialMarkTypes))
               .MaxDepth(4)
               //  .IncludeAllDerived()
               .ReverseMap();


            CreateMap<MaterialSizeType, Core.Entities.MaterialSizeType>()
                .ForMember(x => x.MaterialNoms, a => a.Ignore())
                .ForMember(x => x.DefaultMaterialNom, a => a.MapFrom(s => s.DefaultMaterialNom))
                .MaxDepth(2)
               //  .IncludeAllDerived()
                .ReverseMap();

            CreateMap<MaterialNomDefault, Core.Entities.MaterialNomDefault>()
              //   .IncludeAllDerived()
                .ReverseMap();




            CreateMap<MaterialNom, Core.Entities.MaterialNom>()
                .ForMember(x => x.FormulaItems, a => a.Ignore())
                .ForMember(x => x.MaterialSizeTypes, a => a.Ignore())
                .ForMember(x => x.FrameItemProperties, a => a.Ignore())
                .ForMember(x => x.MaterialNomDefaults, a => a.Ignore())
                .ForMember(x => x.ProcessingComponents, a => a.Ignore())
                .ForMember(x => x.MaterialNomFormulas, a => a.Ignore())
                .ForMember(x => x.SubMaterialNoms, a => a.Ignore())
                .ForMember(x => x.Transformations, a => a.Ignore())
                 .ForMember(x => x.PriceValues, a => a.Ignore())
                // .IncludeAllDerived()
                .ReverseMap();



            CreateMap<MaterialSpecProperty, Core.Entities.MaterialSpecProperty>()
               // .IncludeAllDerived()
                .ReverseMap();

            CreateMap<MaterialNomFormula, Core.Entities.MaterialNomFormula>()
               // .IncludeAllDerived()
                .ReverseMap();

            CreateMap<MaterialType, Core.Entities.MaterialType>()
               // .IncludeAllDerived()
                .ReverseMap();

            CreateMap<Material, Core.Entities.Material>()
                .ForMember(x => x.Brands, a => a.Ignore())
                .ForMember(x => x.FormulaItems, a => a.Ignore())
                .ForMember(x => x.PriceTypes, a => a.Ignore())
                .ForMember(x => x.ProcessingTypeMaterials, a => a.Ignore())
                .ForMember(x => x.MaterialSpecProperties, a => a.Ignore())
                .ForMember(x => x.MaterialMarkTypes, a => a.Ignore())
                .ForMember(x => x.MaterialFields, a => a.Ignore())
                .ForMember(x => x.TradeMarks, a => a.Ignore())
                .ForMember(x => x.VendorMaterialNoms, a => a.Ignore())
                .ForMember(x => x.VendorMaterialNoms, a => a.Ignore())
                //  .IncludeAllDerived()
                .ReverseMap();


            CreateMap<SubMaterialNom, Core.Entities.SubMaterialNom>()
             .ForMember(x => x.Processings, a => a.MapFrom(p => p.Processings))
            // .IncludeAllDerived()
         .ReverseMap();

            CreateMap<SubMaterialNomProcessing, Core.Entities.SubMaterialNomProcessing>()
               // .IncludeAllDerived()
                .ReverseMap();

            CreateMap<SubMaterialNomProcessingComponent, Core.Entities.SubMaterialNomProcessingComponent>()
               // .IncludeAllDerived()
                .ReverseMap();

            CreateMap<MaterialNomTransformationRule, Core.Entities.Transformations.MaterialNomTransformationRule>()
              //  .IncludeAllDerived()
                .ReverseMap();
        }
    }
}