using AutoMapper;
using Socrat.Data.Model;

namespace Socrat.DataProvider
{
    public partial class EntityMapperProfile : Profile
    {
     

        void DirectStartMapping()
        {
            CreateMap<AppParamValue, Core.Entities.AppParamValue>()
               .ForMember(m => m.AppParam, a => a.Ignore())
               .ForMember(m => m.Division, a => a.Ignore())
               .ReverseMap();


            CreateMap<TreeItem, Core.Entities.TreeItem>()
               .ForMember(x => x.RoleTreeItems, a => a.Ignore())
               .ForMember(x => x.ParentTreeItem, a => a.MapFrom(s => s.ParentTreeItem))
               .ForMember(x => x.TreeItems, a => a.MapFrom(s => s.TreeItems))
               .ForMember(x => x.TreeItemTemplates, a => a.Ignore())
               .ReverseMap();


            CreateMap<TreeItemTemplate, Core.Entities.Printing.TreeItemTemplate>().ReverseMap();



            CreateMap<RoleTreeItem, Core.Entities.RoleTreeItem>()
                .ForMember(x => x.ParentEntities, a => a.Ignore())
                .ReverseMap();


            CreateMap<AppParam, Core.Entities.AppParam>().ReverseMap();

            CreateMap<Role, Core.Entities.Role>()
                .ForMember(x => x.RoleTreeItems, a => a.MapFrom(s => s.RoleTreeItems))
                .ForMember(x => x.Users, a => a.Ignore())
                .ReverseMap();

            CreateMap<User, Core.Entities.User>()
                 .ForMember(x => x.Role, a => a.MapFrom(s => s.Role))
                .ForMember(x => x.UserSettings, a => a.MapFrom(s => s.UserSettings))
                 .ForMember(x => x.OrderStatusHistories, a => a.MapFrom(s => s.OrderStatusHistories))
                  .ForMember(x => x.ContractShippingSquares, a => a.Ignore())

                .ReverseMap();

            CreateMap<Module, Core.Entities.Module>()
                .ForMember(x => x.TreeItems, a => a.Ignore())
                .ReverseMap();
            CreateMap<TreeItemType, Core.Entities.TreeItemType>().ReverseMap();

            CreateMap<UserSettings, Core.Entities.UserSettings>().MaxDepth(2).ReverseMap();
        }
    }
}

