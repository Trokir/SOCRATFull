using AutoMapper;
using Socrat.Data.Model.Machines;

namespace Socrat.DataProvider
{
    public partial class EntityMapperProfile : Profile
    {

       
        void DirectMachineMapping()
        {
            CreateMap<MachineTypeProcessing, Core.Entities.Machines.MachineTypeProcessing>()
               //  .IncludeAllDerived()
                .ReverseMap();

            CreateMap<MachineNom, Core.Entities.Machines.MachineNom>()
                .ForMember(x => x.Division, a => a.MapFrom(p => p.Division))
                .ForMember(x => x.VendorMachineNom, a => a.MapFrom(p => p.VendorMachineNom))
                .ForMember(x => x.MachineNomOptions, a => a.Ignore())
                .ForMember(x => x.WorkShiftWeeks, a => a.Ignore())
                .ForMember(x => x.WorkShifts, a => a.Ignore())
               // .IncludeAllDerived()
               .ReverseMap();

            CreateMap<MachineGroup, Core.Entities.Machines.MachineGroup>()
              .ForMember(x => x.Division, a => a.Ignore())
              .ForMember(x => x.ProcessingNoms, a => a.Ignore())
              .ForMember(x => x.MachineNoms, a => a.MapFrom(p => p.MachineNoms))
             //  .IncludeAllDerived()
              .ReverseMap();

            CreateMap<MachineType, Core.Entities.Machines.MachineType>()
                // .IncludeAllDerived()
               .ReverseMap();

            CreateMap<MachineNomOption, Core.Entities.Machines.MachineNomOption>()
                // .IncludeAllDerived()
                .ReverseMap();
        }
    }
}