using System;
using AutoMapper;
using HMapper;
using Socrat.Core.Added;
using Socrat.Core.Helpers;
using Socrat.Data.Model;
using Socrat.Data.Model.Machines;

namespace Socrat.DataProvider
{
    /// <summary>
    ///     Класс настройки преобразования из ДТО в ViewModel и обратно
    /// </summary>
    public partial class EntityMapperProfile 
    {
        public  EntityMapperProfile()
        {
            DirectOrderMapping();
            DirectPriceMapping();
            DirectAddressMapping();
            DirectMaterialMapping();
            DirectMachineMapping();
            DirectParserMapping();
            DirectStartMapping();
            DirectVendorMapping();
            DirectProcessingMapping();
            DirectShapeMapping();
            DirectCatalogShapeMapping();
            DirectSortPriceMapping();
            DirectPrintMapping();
            DirectFormulaMapping();
        }
        
       
        public static ParamAlias MapToAppParam(string alias)
        {
            return EnumHelper<ParamAlias>.Parse(alias);
        }

        //private static void FormulaItemAfterMap(FormulaItem source, Core.Entities.FormulaItem target)
        //{
        //    /*
        //    MaterialEnum _material = EnumHelper<MaterialEnum>.Parse(source?.Material.EnumCode);
        //    switch (_material)
        //    {
        //        case MaterialEnum.Glass:
        //            GlassItem _glassItem = target as GlassItem;
        //            if (_glassItem != null && source.GlassItemProperties != null)
        //            {
        //                //Mapper.Initialize(MapperConfig.Cfg);
        //                _glassItem.GlassItemProperty =
        //                    Mapper.Map<Socrat.Data.Models.GlassItemProperties, GlassItemProperty>(source.GlassItemProperties);

        //                if (_glassItem.GlassItemProperty != null)
        //                    _glassItem.GlassItemProperty.GlassItem = _glassItem;
        //            }
        //            break;
        //        case MaterialEnum.Frame:
        //            FrameItem _frameItem = target as FrameItem;
        //            if (_frameItem != null && source.FrameItemProperties != null)
        //            {
        //                //Mapper.Initialize(MapperConfig.Cfg);
        //                _frameItem.FrameItemProperty =
        //                    Mapper
        //                        .Map<Socrat.Data.Models.FrameItemProperties,
        //                            FrameItemProperty>(source.FrameItemProperties);
        //                if (_frameItem.FrameItemProperty != null)
        //                    _frameItem.FrameItemProperty.FrameItem = _frameItem;
        //            }
        //            break;
        //        case MaterialEnum.Film:
        //            break;
        //        case MaterialEnum.Triplex:
        //            Models.TriplexItem _triplexItem = target as TriplexItem;
        //            if (_triplexItem != null && source.TriplexItemProperties != null)
        //            {
        //                //Mapper.Initialize(MapperConfig.Cfg);
        //                _triplexItem.TriplexItemProperty =
        //                    Mapper
        //                        .Map<Socrat.Data.Models.TriplexItemProperties,
        //                            TriplexItemProperty>(source.TriplexItemProperties);
        //                if (_triplexItem.TriplexItemProperty != null)
        //                    _triplexItem.TriplexItemProperty.TriplexItem = _triplexItem;
        //            }
        //            break;
        //        case MaterialEnum.TriplexFilm:
        //            break;
        //        case MaterialEnum.Inset:
        //            InsetItem _insetItem = target as InsetItem;
        //            if (_insetItem != null && source.InsetItemProperties != null)
        //            {
        //                //Mapper.Initialize(MapperConfig.Cfg);
        //                _insetItem.InsetItemProperty =
        //                    Mapper
        //                        .Map<Socrat.Data.Models.InsetItemProperties,
        //                            InsetItemProperty>(
        //                            source.InsetItemProperties);
        //                if (_insetItem.InsetItemProperty != null)
        //                    _insetItem.InsetItemProperty.InsetItem = _insetItem;
        //            }
        //            break;
        //    }
        //    //Mapper.Initialize(MapperConfig.Cfg);
        //    //target.Material = Mapper.Map<DataProvider.Material, Model.Material>(source.Material);
        //    */
        //}

        //private static Core.Entities.FormulaItem FormulaItemCtor(FormulaItem sourceItem)
        //{
        //    Core.Entities.FormulaItem resultItem = null;
        //    var _material = EnumHelper<MaterialEnum>.Parse(sourceItem?.Material.EnumCode);
        //    switch (_material)
        //    {
        //        case MaterialEnum.Glass:
        //            resultItem = new GlassItem();
        //            break;
        //        case MaterialEnum.Frame:
        //            resultItem = new FrameItem();
        //            break;
        //        case MaterialEnum.Film:
        //            resultItem = new Core.Added.FilmItem();
        //            break;
        //        case MaterialEnum.Triplex:
        //            resultItem = new TriplexItem();
        //            break;
        //        case MaterialEnum.TriplexFilm:
        //            resultItem = new Core.Entities.FormulaItem();
        //            break;
        //        case MaterialEnum.Inset:
        //            resultItem = new InsetItem();
        //            break;
        //    }

        //    return resultItem;
        //}

        private static Guid MapUserIdFrom(OrderStatusHistory orderStatusHistory)
        {
            return SocratEntities.User?.Id ?? Guid.Empty;
        }

        private static string MapFromParamAlias(ParamAlias alias)
        {
            return Enum.GetName(typeof(ParamAlias), alias);
        }
    }
    public class CustomResolver : IValueResolver<Source, Destination, int>
    {
        public int Resolve(Source source, Destination destination, int member, ResolutionContext context)
        {
            return Int32.MaxValue;
        }
    }

    public class Source
    {
        public int Total { get; set; }
    }

    public class Destination
    {
        public int Total { get; set; }
    }
}