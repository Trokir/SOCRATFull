using AutoMapper;
using Socrat.Data.Model;

namespace Socrat.DataProvider
{
    public partial class EntityMapperProfile : Profile
    {
    
        void DirectSortPriceMapping()
        {
            CreateMap<SquRange, Core.Entities.SquRange>()
                 // .IncludeAllDerived()
                .ReverseMap();

            CreateMap<WorkDifficulty, Core.Entities.WorkDifficulty>()
                  .IncludeAllDerived()
                .ReverseMap();

            CreateMap<WorkShiftsTemplate, Core.Entities.Work.WorkShiftsTemplate>()
              .ForMember(x => x.WorkShiftType, a => a.MapFrom(p => p.WorkShiftType))
              .ForMember(x => x.MachineNom, a => a.MapFrom(p => p.MachineNom))
              // .IncludeAllDerived()
              .ReverseMap();

            CreateMap<WorkShift, Core.Entities.Work.WorkShift>()
               .ForMember(x => x.MachineNom, a => a.Ignore())
               .ForMember(x => x.Team, a => a.Ignore())
               .ForMember(x => x.WorkShiftType, a => a.Ignore())
               .ForMember(x => x.WorkQueues, a => a.Ignore())

               // .IncludeAllDerived()
               .ReverseMap();

            CreateMap<WorkQueueAssignment, Core.Entities.WorkQueueAssignment>()
                   .ForMember(x => x.Division, a => a.Ignore())
                  .ForMember(x => x.WorkQueues, a => a.MapFrom(p => p.WorkQueues))
                  .ForMember(x => x.WorkDifficulties, a => a.Ignore())
                  .ForMember(x => x.MachineTypes, a => a.Ignore())
                  // .IncludeAllDerived()
                .ReverseMap();


            CreateMap<WorkShiftType, Core.Entities.Work.WorkShiftType>()
                .ForMember(x => x.Division, a => a.MapFrom(p => p.Division))
                .ForMember(x => x.WorkShifts, a => a.Ignore())
                .ForMember(x => x.WorkShiftWeeks, a => a.Ignore())
                // .IncludeAllDerived()
                .ReverseMap();



            CreateMap<TruckPyramidType, Core.Entities.Pyramids.TruckPyramidType>()
               .ForMember(x => x.Pyramids, a => a.MapFrom(s => s.Pyramids))
               .ReverseMap();

            CreateMap<WorkQueue, Core.Entities.WorkQueue>().ReverseMap()
              //  .ForMember(x => x.WorkShift, a => a.MapFrom(p => p.WorkShift))
              //.ForMember(x => x.WorkSortType, a => a.Ignore())
              //.ForMember(x => x.WorkQueueAssignment, a => a.MapFrom(p => p.WorkQueueAssignment))
              //.ForMember(x => x.MachineNom, a => a.Ignore())
              //.ForMember(x => x.Orders, a => a.MapFrom(p => p.Orders))
                .IncludeAllDerived()
              .ReverseMap();




            CreateMap<WorkSortType, Core.Entities.Planing.WorkSortType>().MaxDepth(2)
               .ForMember(x => x.WorkQueues, a => a.MapFrom(p => p.WorkQueues))
                .ForMember(x => x.WorkSorts, a => a.MapFrom(p => p.WorkSorts))
               //  .IncludeAllDerived()
               .ReverseMap();
            CreateMap<WorkSort, Core.Entities.Planing.WorkSort>()
                 // .IncludeAllDerived()
                .ReverseMap();
        }
    }
}
