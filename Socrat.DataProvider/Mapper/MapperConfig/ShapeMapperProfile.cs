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

      
        void DirectShapeMapping()
        {
            CreateMap<Shape, Core.Entities.Shape>()
                .ForMember(x => x.FormType, a => a.Ignore())
                .ForMember(x => x.OrderRow, a => a.Ignore())
                .MaxDepth(6).ReverseMap();
            CreateMap<ShapeParam, Core.Entities.ShapeParam>().MaxDepth(6).ReverseMap();
            CreateMap<ShapeModifedParam, Core.Entities.ShapeModifedParam>().MaxDepth(6).ReverseMap();
            CreateMap<ShapePoint, Core.Entities.ShapePoint>().MaxDepth(6).ReverseMap();
            CreateMap<ShprossElement, Core.Entities.ShprossElement>().MaxDepth(2).ReverseMap();
            CreateMap<ShprossMainElement, Core.Entities.ShprossMainElement>().MaxDepth(2).ReverseMap();
        }
    }
}
