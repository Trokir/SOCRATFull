using Socrat.Common;
using Socrat.Common.Enums;
using Socrat.Common.Exceptions;
using Socrat.Common.System;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.Core.Entities.Planing;
using Socrat.Module.Connectors;
using Socrat.Module.Connectors.Lisec.Enums;
using Socrat.Module.Connectors.Lisec.Fields;
using Socrat.Module.Connectors.Lisec.Primitives;
using Socrat.Params;
using Socrat.Services.Transformation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Socrat.Services.Export
{
    public class GpsOptExporter
    {
        /// <summary>
        /// Возвращает путь к выгруженному файлу
        /// </summary>
        /// <param name="queue">Очередь</param>
        /// <param name="exportType">Тип выгрузки</param>
        /// <param name="sortType">Параметры выгрузки</param>
        /// <param name="sortedEntities">Набор сущностей для выгрузки</param>
        /// <returns></returns>
        public static string Export(
            WorkQueue queue,
            ExportTypes exportType,
            SortTypes sortType,
            List<SortedEntityWrapper> sortedEntities)
        {
            List<SortedEntityWrapperWithQuantity> sortedEntityWrapperWithQuantity = new List<SortedEntityWrapperWithQuantity>();
            sortedEntities
                .ForEach(x =>
                    sortedEntityWrapperWithQuantity.Add(new SortedEntityWrapperWithQuantity(x)));

            List<Position> items = new List<Position>();

            //if (exportType == ExportTypes.Glasses)
            //{
            //    sortedEntities.ForEach(entity =>
            //        items.AddRange(GetGlassesAsGpsOptItems(entity)));

            //    if (sortType == SortTypes.Classic)
            //    {
            //        items = items.OrderBy(x => x.Glass1Name)
            //            .ThenBy(a => a.Shape.Number)
            //                .ThenByDescending(y => y.Height)
            //                    .ThenByDescending(z => z.Width).ToList();

            //        int i = 0;
            //        while (i < items.Count())
            //        {
            //            if (items.Count > i + 1)
            //            {
            //                if (items[i].IsPartiallyEquals(items[i + 1]))
            //                {
            //                    items[i].Quantity += items[i + 1].Quantity;
            //                    items.RemoveAt(i + 1);
            //                }
            //                else
            //                    i++;
            //            }
            //            else
            //                break;
            //        }
            //    }
            //    return string.Empty;
            //}
            //else 

            if (exportType == ExportTypes.Packages)
            {
                List<SortedEntityWrapperWithQuantity> e = new List<SortedEntityWrapperWithQuantity>();
                int index = 0;
                for (int i = 0; i < sortedEntities.Count; i++)
                {
                    if (i == 0)
                        e.Add(new SortedEntityWrapperWithQuantity(sortedEntities[i]));
                    else
                    {
                        if (CompareSortedEntities(sortedEntities[i], e[index].SortedEntityWrapper))
                            e[index].Quantity++;
                        else
                        {
                            e.Add(new SortedEntityWrapperWithQuantity(sortedEntities[i]));
                            index++;
                        }
                    }
                }

                int number = 1;
                int position = 1;
                e.ForEach(entity =>
                {
                    if (!(entity.SortedEntityWrapper.OrderRow.Formula.RootItem.Tolling ?? false))
                    {
                        if (GetGpsOptPosition(entity, position, number) is Position posItem)
                        {
                            items.Add(posItem);
                            position++;
                            number = number + entity.Quantity;
                        }
                    }
                });

                ITransferInfo<Position> transferInfo =
                    new Module.Connectors.Lisec.TransferInfo(
                        queue.Num,
                        queue.WorkDate,
                        AppParams.Params[ParamAlias.ExportToGpsDirectoryPath],
                        items);

                transferInfo?
               .GetExportProvider()
                   .Export(
                       transferInfo,
                       sortType,
                       exportType);
                return transferInfo.FileName;
            }
            else if (exportType == ExportTypes.Frames)
            {
                var frames = new List<Module.Connectors.BSV.Fields.Frame>();
                int number = 1;

                sortedEntities.ForEach(entity =>
                {
                    var entities = entity.OrderRow.Formula.GetAllItems()
                        .Where(item =>
                            item.MaterialEnum == MaterialEnum.Frame);
                    if (entities?.ToList() is List<FormulaItem> entityFrames)
                    {
                        FormulaItem frame = entityFrames.Count > 0 ? entityFrames[0] : null;
                        if (frame != null)
                        {

                            FrameItem frameItem = ((FrameItem)frame);

                            string formula = entity.ProdType == ProductionTypes.Spo ? $"СПО {entity.Formula}" : entity.ProdType == ProductionTypes.Spd ? $"СПД {entity.Formula}" : entity.Formula;

                            var fr = new Module.Connectors.BSV.Fields.Frame
                                (
                                    number++,
                                    entity.Width ?? 0,
                                    entity.Height ?? 0,
                                    entity.OrderRow.Qty * 2 ?? 0,
                                    frame.MaterialNom.MaterialSizeType.Thickness,
                                    FrameTypes.Aluminius,
                                    FrameColors.Nature,
                                    $"{entity.QueueNum}-?",
                                    entity.FullQueueNumber,
                                    formula,
                                    entity.OrderRow.Shape.ShapeParam.L_param ?? 0,
                                    entity.OrderRow.Shape.ShapeParam.L1_param,
                                    entity.OrderRow.Shape.ShapeParam.L2_param ?? 0,
                                    entity.OrderRow.Shape.ShapeParam.H_param ?? 0,
                                    entity.OrderRow.Shape.ShapeParam.H1_param ?? 0,
                                    entity.OrderRow.Shape.ShapeParam.H2_param ?? 0,
                                    entity.OrderRow.Shape.ShapeParam.R_param ?? 0,
                                    entity.OrderRow.Shape.ShapeParam.R1_param ?? 0,
                                    entity.OrderRow.Shape.ShapeParam.R2_param ?? 0,
                                    entity.OrderRow.Shape.ShapeParam.R3_param ?? 0,
                                    frameItem?.GermDepth ?? 0,
                                    entity.OrderRow.Id,
                                    frame.MaterialNom.Id,
                                    entity.CurrentCounter,
                                    (short)(entity.ProdType == ProductionTypes.Spo ? 1 : (entity.ProdType == ProductionTypes.Spd ? 2 : 0)),
                                    entity.OrderRow.OrderRowSlozs?.FirstOrDefault(x => x.SlozType.Enumerator == SlozEnum.Shpross) != null,
                                    false,
                                    $"{frameItem.MaterialNom}"
                                );
                            frames.Add(fr);
                        }
                    }
                });

                ITransferInfo<Module.Connectors.BSV.Fields.Frame> transferInfo =
                    new Module.Connectors.BSV.TransferInfo(
                        queue.Num,
                        queue.WorkDate,
                        AppParams.Params[ParamAlias.ExportToGpsDirectoryPath],
                        frames);

                transferInfo?
               .GetExportProvider()
                   .Export(
                       transferInfo,
                       sortType,
                       exportType);
                return transferInfo.FileName;
            }
            else
            {
                throw new Exception("Тип экспорта не установлен. Выгрузка данных не произведена.");
            }
        }

        public static Position GetGpsOptPosition(SortedEntityWrapperWithQuantity entity, int index, int number)
        {
            string glass1 = string.Empty;
            string glass2 = string.Empty;
            string glass3 = string.Empty;
            string frame1 = string.Empty;
            string frame2 = string.Empty;

            if (entity.SortedEntityWrapper.OrderRow.ProductionType == ProductionTypes.Spo ||
                entity.SortedEntityWrapper.OrderRow.ProductionType == ProductionTypes.Spd ||
                entity.SortedEntityWrapper.OrderRow.ProductionType == ProductionTypes.CuttedGlass ||
                entity.SortedEntityWrapper.OrderRow.ProductionType == ProductionTypes.Triplex)
            {
                string glassFull = string.Empty;
                if (entity.SortedEntityWrapper.OrderRow.ProductionType == ProductionTypes.CuttedGlass ||
                   entity.SortedEntityWrapper.OrderRow.ProductionType == ProductionTypes.Triplex) 
                {
                    //Проверяем наличие трансформаций для кодов материалов нарезки
                    if (entity.SortedEntityWrapper.OrderRow.Formula.RootItem is FormulaItem formulaItem)
                    {
                        glassFull = formulaItem.MaterialNom?.Code;
                        if (string.IsNullOrEmpty(glassFull))
                            glassFull = $"{formulaItem}";

                        glass1 = Transformator.Transform(
                            TransformationRules.GpsOptTrfOptGlass,
                            glassFull,
                            formulaItem.MaterialNom?.Transformations,
                            $"[Позиция сортировки #{entity.SortedEntityWrapper.Position}]");
                        if (entity.SortedEntityWrapper.FirstTrash ?? false)
                            glass1 = glass1.Insert(0, "*");
                    }
                    else
                        glass1 = $"NONE";
                }
                else
                if (entity.SortedEntityWrapper.OrderRow.ProductionType != ProductionTypes.Spo ||
                        entity.SortedEntityWrapper.OrderRow.ProductionType != ProductionTypes.Spd)
                {
                    string glass1full = string.Empty;
                    //Проверяем наличие трансформаций для кодов материалов СП
                    if (entity.SortedEntityWrapper.OrderRow.Formula.RootItem.Items[0] is FormulaItem formulaItem1
                        && (!(entity.SortedEntityWrapper.OrderRow.Formula.RootItem.Items[0].Tolling ?? false)))
                    {
                        glass1full = formulaItem1.MaterialNom?.Code;
                        if (string.IsNullOrEmpty(glass1full))
                            glass1full = $"{formulaItem1}";

                        glass1 = Transformator.Transform(
                            TransformationRules.GpsOptTrfOptGlass,
                            formulaItem1.MaterialNom?.Code,
                            formulaItem1.MaterialNom.Transformations,
                            $"[Позиция сортировки #{entity.SortedEntityWrapper.Position}]");
                        if (entity.SortedEntityWrapper.FirstTrash ?? false)
                            glass1 = glass1.Insert(0, "*");
                    }
                    else
                        glass1 = $"NONE";

                    string frame1full = string.Empty;
                    if (entity.SortedEntityWrapper.OrderRow.GetFrame(0) is FrameItem frameItem1)
                    {
                        frame1full = frameItem1.MaterialNom?.Code;
                        frame1 = Transformator.Transform(
                            TransformationRules.GpsOptTrfOptFrame,
                            frame1full,
                            frameItem1.MaterialNom?.Transformations,
                            $"[Позиция сортировки #{entity.SortedEntityWrapper.Position}]");
                    }

                    string glass2full = string.Empty;
                    if (entity.SortedEntityWrapper.OrderRow.Formula.RootItem.Items[2] is FormulaItem formulaItem2
                        && (!(entity.SortedEntityWrapper.OrderRow.Formula.RootItem.Items[2].Tolling ?? false)))
                    {
                        glass2full = formulaItem2.MaterialNom?.Code;
                        if (string.IsNullOrEmpty(glass2full))
                            glass2full = $"{formulaItem2}";

                        glass2 = Transformator.Transform(
                                TransformationRules.GpsOptTrfOptGlass,
                                glass2full,
                                formulaItem2.MaterialNom.Transformations,
                                $"[Позиция сортировки #{entity.SortedEntityWrapper.Position}]");

                        if (entity.SortedEntityWrapper.SecondTrash ?? false)
                            glass2 = glass2.Insert(0, "*");

                        if (string.IsNullOrEmpty(glass2))
                            glass2 = $"{formulaItem2}";
                    }
                    else
                        glass2 = $"NONE";

                    if (entity.SortedEntityWrapper.OrderRow.ProductionType == ProductionTypes.Spd)
                    {
                        string frame2full = string.Empty;
                        if (entity.SortedEntityWrapper.OrderRow.GetFrame(1) is FrameItem frameItem2)
                        {
                            frame2full = frameItem2.MaterialNom?.Code;
                            frame2 = Transformator.Transform(
                                TransformationRules.GpsOptTrfOptFrame,
                                frame2full,
                                frameItem2.MaterialNom?.Transformations,
                                    $"[Позиция сортировки #{entity.SortedEntityWrapper.Position}]");
                        }

                        string glass3full = string.Empty;
                        if (entity.SortedEntityWrapper.OrderRow.Formula.RootItem.Items[4] is FormulaItem formulaItem3
                            && (!(entity.SortedEntityWrapper.OrderRow.Formula.RootItem.Items[4].Tolling ?? false)))
                        {
                            glass3full = formulaItem3.MaterialNom?.Code;
                            if (string.IsNullOrEmpty(glass3full))
                                glass3full = $"{formulaItem3}";

                            glass3 = Transformator.Transform(
                                TransformationRules.GpsOptTrfOptGlass,
                                glass3full,
                                formulaItem3.MaterialNom?.Transformations,
                                $"[Позиция сортировки #{entity.SortedEntityWrapper.Position}]");

                            if (string.IsNullOrEmpty(glass3))
                                glass3 = $"{formulaItem3}";

                            if (entity.SortedEntityWrapper.ThirdTrash ?? false)
                                glass3 = glass3.Insert(0, "*");
                        }
                        else
                            glass3 = $"NONE";

                        //Конец проверки
                    }
                }


                int hermDepth = 0;
                if (entity.SortedEntityWrapper.OrderRow.GetFrame(0) is FrameItem frameItem)
                    hermDepth = (int)Math.Truncate(frameItem.GermDepth ?? 0) * 10;

                string nameEn = entity.SortedEntityWrapper.OrderRow.ProductionType == ProductionTypes.Spo
                        ? $"{Transliterator.CyrillicToLatin(entity.SortedEntityWrapper.OrderRow.Formula.Gost24866Formula)}"
                            : entity.SortedEntityWrapper.OrderRow.ProductionType == ProductionTypes.Spd
                                ? $"{Transliterator.CyrillicToLatin(entity.SortedEntityWrapper.OrderRow.Formula.Gost24866Formula)}"
                                    : string.Empty;

                string nameRu =
                        entity.SortedEntityWrapper.OrderRow.ProductionType == ProductionTypes.Spo
                            ? $"СПО {entity.SortedEntityWrapper.OrderRow.Formula.Gost24866Formula}"
                                : entity.SortedEntityWrapper.OrderRow.ProductionType == ProductionTypes.Spd
                                    ? $"СПД {entity.SortedEntityWrapper.OrderRow.Formula.Gost24866Formula}"
                                        : string.Empty;


                string posNumberValue = string.Empty;

                if (Preferences.GpsOpt.QUEUE_NUMBER_AS_PREFIX_IN_POSITION_NUMBER)
                    posNumberValue = entity.Quantity == 1
                        ? $"{entity.SortedEntityWrapper.QueueNum}/{number}"
                        : $"{entity.SortedEntityWrapper.QueueNum}/{number}-{number - 1 + entity.Quantity}";
                else
                    //Из позиции удален номер очереди: распоряжение АК
                    //При выгрузке на GPS возникла ошибка – выгружено 96 вместо 98
                    posNumberValue = entity.Quantity == 1
                        ? $"{number}"
                        : $"{number}-{number - 1 + entity.Quantity}";

                Position position = new Position
                (
                    entity.SortedEntityWrapper.StateCounter,
                    index,
                    posNumberValue,
                    0,
                    entity.Quantity,
                    new GpsOptSize(entity.SortedEntityWrapper.GetAllowancedWidth(entity.SortedEntityWrapper.Width ?? 0)),
                    new GpsOptSize(entity.SortedEntityWrapper.GetAllowancedHeight(entity.SortedEntityWrapper.Height ?? 0)),
                    glass1,
                    frame1,
                    glass2,
                    frame2,
                    glass3,
                    hermDepth,
                    0,
                    entity.SortedEntityWrapper.OrderRow.Formula.GazState == GazState.FirstFrame || entity.SortedEntityWrapper.OrderRow.Formula.GazState == GazState.BothFrame ? 1 : 0,
                    entity.SortedEntityWrapper.OrderRow.Formula.GazState == GazState.BothFrame ? 1 : 0,
                    SealTypes.Thiokol,
                    ElementWindowTypes.Fixed,
                    new GpsOptSize(0),
                    PatternDirections.None,
                    entity.SortedEntityWrapper.StateCounter,
                    entity.SortedEntityWrapper.OrderRow.Shape?.CatalogNumber ?? 0,
                    nameRu,
                    nameEn);
                return position;
                
            }
            throw new WrongProductionTypeException("СПО или СПД", $"{entity.SortedEntityWrapper.OrderRow.ProductionType}");
        }

        public static bool CompareSortedEntities(SortedEntityWrapper entityA, SortedEntityWrapper entityB, bool fullEquality = false)
        {
            if (entityA.ProdType != entityB.ProdType) return false;
            if (entityA.OrderRow.ProductionType != entityB.OrderRow.ProductionType) return false;
            if (entityA.OrderRow.Width != entityB.OrderRow.Width || entityA.OrderRow.Height != entityB.OrderRow.Height) return false;
            
            var glassesA = entityA.OrderRow.Formula.GetAllItems().Where(x => x.MaterialEnum == MaterialEnum.Glass).OrderBy(y => y.Position).ToList();
            var glassesB = entityB.OrderRow.Formula.GetAllItems().Where(x => x.MaterialEnum == MaterialEnum.Glass).OrderBy(y => y.Position).ToList();

            if (glassesA.Count != glassesB.Count) return false;

            if (fullEquality)
            {
                var itemsA = entityA.OrderRow.Formula.GetAllItems();
                var itemsB = entityA.OrderRow.Formula.GetAllItems();

                for (int i = 0; i < itemsA.Count; i++)
                    if (itemsA[i].MaterialNom != itemsB[i].MaterialNom) return false;
            }
            else
            {
                for (int i = 0; i < glassesA.Count; i++)
                    if (glassesA[i].MaterialNom != glassesB[i].MaterialNom) return false;
                
                var framesA = entityA.OrderRow.Formula.GetAllItems().Where(x => x.MaterialEnum == MaterialEnum.Frame).ToArray();
                var framesB = entityA.OrderRow.Formula.GetAllItems().Where(x => x.MaterialEnum == MaterialEnum.Frame).ToArray();

                for (int i = 0; i < framesA.Count(); i++)
                    if (framesA[i].MaterialNom != framesB[i].MaterialNom) return false;

            }

            return true;           
        }

        public static List<Position> GetGlassesAsGpsOptItems(SortedEntityWrapper entity)
        {
            List<Position> glasses = new List<Position>();

            var a = entity.OrderRow.Formula.GatAllGlasses();


            a.ForEach(glass =>
            {
                glasses.Add(new Position(
                    entity.Position,
                    "?",
                    0,
                    entity.ThingsCount,
                    new GpsOptSize(entity.GetAllowancedWidth(entity.Width ?? 0)),
                    new GpsOptSize(entity.GetAllowancedHeight(entity.Height ?? 0)),
                    glass.MaterialNom.Code,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    0,
                    0,
                    0,
                    0,
                    SealTypes.Thiokol,
                    ElementWindowTypes.Fixed,
                    new GpsOptSize(0),
                    PatternDirections.None,
                    entity.StateCounter,
                    new Module.Connectors.Lisec.Fields.Shape(entity.OrderRow.Shape.CatalogNumber, false)));
            });
            return glasses;
        }

        public  class SortedEntityWrapperWithQuantity
        {
            public SortedEntityWrapper SortedEntityWrapper { get; private set; }
            public int Quantity { get; set; } = 1;

            public SortedEntityWrapperWithQuantity(SortedEntityWrapper sortedEntityWrapper)
            {
                SortedEntityWrapper = sortedEntityWrapper;
            }

            public override string ToString()
            {
                return $"{SortedEntityWrapper.OrderRow.FormulaStr} х {Quantity} [{SortedEntityWrapper.OrderRow.Height}x{SortedEntityWrapper.OrderRow.Width}";
            }
        }
    }
}
