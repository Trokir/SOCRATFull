using AutoMapper;
using Socrat.Data.Model;
using Socrat.Data.Model.Machines;

namespace Socrat.DataProvider
{
    public partial class EntityMapperProfile : Profile
    {

     
        void DirectVendorMapping()
        {
            CreateMap<Vendor, Core.Entities.Vendor>()
              .ForMember(x => x.VendorMachineTypes, a => a.Ignore())
               .ForMember(x => x.VendorMachineNoms, a => a.Ignore())
              .ForMember(x => x.VendorMaterialNoms, a => a.MapFrom(p => p.VendorMaterialNoms))
              .ForMember(x => x.VendorMaterials, a => a.MapFrom(p => p.VendorMaterials))
              .ForMember(x => x.Brands, a => a.MapFrom(p => p.Brands))
              //  .IncludeAllDerived()
              .ReverseMap();

            CreateMap<VendorMachineNom, Core.Entities.Machines.VendorMachineNom>()
                   .ForMember(x => x.MachineNoms, a => a.MapFrom(p => p.MachineNoms))
                    .ForMember(x => x.VendorMachineProcessings, a => a.MapFrom(p => p.VendorMachineProcessings))
                     .ForMember(x => x.VendorMachineOptions, a => a.Ignore())
                //  .IncludeAllDerived()
                .ReverseMap();

            CreateMap<VendorMachineOption, Core.Entities.Machines.VendorMachineOption>()
                .ForMember(x => x.VendorMachineNom, a => a.Ignore())
                 .ForMember(x => x.VendorMachineProcessings, a => a.MapFrom(p => p.VendorMachineProcessings))
                  .ForMember(x => x.MachineNomOptions, a => a.MapFrom(p => p.MachineNomOptions))
                //  .IncludeAllDerived()
                .ReverseMap();

            CreateMap<VendorMachineType, Core.Entities.Machines.VendorMachineType>()
               .ForMember(x => x.MachineType, a => a.Ignore())
                .ForMember(x => x.Vendor, a => a.Ignore())
                //  .IncludeAllDerived()
               .ReverseMap();

            CreateMap<VendorMachineProcessing, Core.Entities.Machines.VendorMachineProcessing>()
                //  .IncludeAllDerived()
                .ReverseMap();

            CreateMap<Brand, Core.Entities.Brand>()
                 // .IncludeAllDerived()
                .ReverseMap();

            CreateMap<TradeMark, Core.Entities.TradeMark>()
                //  .IncludeAllDerived()
                .ReverseMap();

            CreateMap<VendorMaterial, Core.Entities.VendorMaterial>()
                // .IncludeAllDerived()
                .ReverseMap();

            CreateMap<VendorMaterialNom, Core.Entities.VendorMaterialNom>()
                //  .IncludeAllDerived()
                .ReverseMap();
        }
    }
}