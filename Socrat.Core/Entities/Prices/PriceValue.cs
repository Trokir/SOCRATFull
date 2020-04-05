using Socrat.Common;
using Socrat.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;

namespace Socrat.Core.Entities
{
    [ChangesLogging(true)]
    [EntityFormConfiguration("Перечень цен", "Редактировать цену")]
    [Common.Attributes.Editor("Socrat.Module.Price")]
    [PropertyVisualisation("Раздел", "PriceTopic", 60, 0, false)]
    [PropertyVisualisation("Тип материала", "MaterialMarkType", 70, 1, true)]
    [PropertyVisualisation("Название", "DisplayName", 100, 2)]
    [PropertyVisualisation("Толщина", "MaterialSizeType.Thickness", 20, 3,false, DevExpress.Utils.HorzAlignment.Far, "", "f0")]
    [PropertyVisualisation("Цена", "PriceVal", 20, 5, false, DevExpress.Utils.HorzAlignment.Far, "", "c2")]
    [PropertyVisualisation("за", "MeasurementUnit", 20, 6, true)]
    public class PriceValue : Entity, ICloneable
    {
        #region Ctors
        public PriceValue()
        {
            History = new AttachedList<EntityChange>(this);
        }

        #endregion

        #region Locals

        private double _priceVal;
        private MaterialNom _materialNom;
        private PricePeriod _pricePeriod;
        private FlaggedProductionTypes _FlaggedProductionType;
        private Measure _MeasurementUnit;
        private string _PriceTopic;

        #endregion

        #region Foreign keys

        public Guid PricePeriodId { get; set; }
        public Guid MaterialNomId { get; set; }
        public Guid? MeasureId { get; set; }

        #endregion

        #region Collection
        [NotMapped]
        public AttachedList<EntityChange> History { get; }

        #endregion

        #region Properties

        public double PriceVal
        {
            get => _priceVal;
            set => SetField(ref _priceVal, value, () => PriceVal);
        }
        public virtual MaterialNom MaterialNom
        {
            get => _materialNom;
            set => SetField(ref _materialNom, value, () => MaterialNom);
        }
        [ParentItem]
        public virtual PricePeriod PricePeriod
        {
            get => _pricePeriod;
            set => SetField(ref _pricePeriod, value, () => PricePeriod);
        }
        public virtual Measure MeasurementUnit
        {
            get => _MeasurementUnit;
            set => SetField(ref _MeasurementUnit, value, () => MeasurementUnit);
        }
        public virtual string PriceTopic
        {
            get => _PriceTopic;
            set => SetField(ref _PriceTopic, value, () => PriceTopic);
        }

        /// <summary>
        /// Флаг принадлежности к типам продукции (используется для формирования цены)
        /// </summary>
        public FlaggedProductionTypes FlaggedProductionType
        {
            get { return _FlaggedProductionType; }
            set { SetField(ref _FlaggedProductionType, value, () => FlaggedProductionType); }
        }

        #endregion

        #region Overrides
        public override ValidationResult Validate(ValidationStage stage, object ownedList = null)
        {
            if (ownedList != null)
            {
                if (!(ownedList is List<PriceValue> priceValues))
                    throw new Exception("Предоставленный родительскийсписок пуст или не является типом List<PriceValue>");

                if (stage == ValidationStage.OnAdd)
                {
                    if (priceValues.Where(priceValue =>
                        priceValue.PricePeriod.Id == PricePeriod.Id)
                            .Any(priceValueInPeriod =>
                                priceValueInPeriod.MaterialNom.Id == MaterialNom.Id)) 
                        return new ValidationResult(
                            ValidationState.Failed, 
                            ReportType.MessageBox, 
                            "Цена для этой номенклатуры материалов уже содержится в текущем периоде действия!");
                }

                if (stage == ValidationStage.OnEdit)
                {
                    if (priceValues.Where(priceValue =>
                        priceValue.PricePeriod.Id == PricePeriod.Id)
                            .Any(priceValueInPeriod => priceValueInPeriod.Id != Id 
                                && priceValueInPeriod.MaterialNom.Id == MaterialNom.Id))
                        return new ValidationResult(
                            ValidationState.Failed,
                            ReportType.MessageBox,
                            "Цена для этой номенклатуры материалов уже содержится в текущем периоде действия!");
                }
            }

            if (PriceVal < 0)
                return new ValidationResult(
                    ValidationState.Failed, 
                    ReportType.MessageBox, "" +
                    "Цена не может выражаться отрицательным значением!");

            return base.Validate(stage, ownedList);
        }

        #endregion

        #region ViewModel fields

        [NotMapped]
        public string DisplayName { get => $"{MaterialNom}"; }
        [NotMapped]
        public virtual MaterialMarkType MaterialMarkType
        {
            get => MaterialNom?.VendorMaterialNom?.MaterialMarkType;
        }
        [NotMapped]
        public virtual MaterialSizeType MaterialSizeType { get => MaterialNom?.MaterialSizeType; }
        [NotMapped]
        public virtual VendorMaterialNom VendorMaterialNom { get => MaterialNom?.VendorMaterialNom; }

        protected override string GetTitle()
        {
            return $"Цена: {DisplayName}";
        }

        public override string ToString()
        {
            return DisplayName;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        #endregion

        #region Print methods

        public int DrawJalousie(Graphics g, Point location, int width, Font font, Color borderColor)
        {
            int height = (int)(g.MeasureString("Test", font).Height * 1.3);
            StringFormat centering = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };

            int titleWidth = (width - location.X) / 2 + 1;
            int valWidth = (width + location.X - 2) / 4;

            Rectangle rectTitle = new Rectangle(location.X, location.Y, titleWidth, height);
            Rectangle rectLessSqm = new Rectangle(location.X + titleWidth, location.Y, valWidth, height);
            Rectangle rectMoreSqm = new Rectangle(location.X + titleWidth + valWidth, location.Y, valWidth, height);

            g.DrawRectangle(new Pen(borderColor, 1), rectTitle);
            g.DrawRectangle(new Pen(borderColor, 1), rectLessSqm);
            g.DrawRectangle(new Pen(borderColor, 1), rectMoreSqm);

            g.DrawString($"{MaterialMarkType} {VendorMaterialNom}", font, Brushes.Black, rectTitle, new StringFormat() { LineAlignment = StringAlignment.Center });
            g.DrawString($"{PriceVal:c2}", font, Brushes.Black, rectLessSqm, centering);
            g.DrawString($"{PriceVal:c2}", font, Brushes.Black, rectMoreSqm, centering);

            return location.Y + height;
        }

        public static int DrawJalousieTableTitle(Graphics g, Point location, int width, Font font, Brush backColor, Color borderColor)
        {
            int height = (int)(g.MeasureString("Test", font).Height * 1.3);

            StringFormat centering = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };

            int titleWidth = (width - location.X) / 2 + 1;
            int valWidth = (width + location.X - 2) / 4;

            Rectangle rectTitle = new Rectangle(location.X, location.Y, titleWidth, height);
            Rectangle rectLessSqm = new Rectangle(location.X + titleWidth, location.Y, valWidth, height);
            Rectangle rectMoreSqm = new Rectangle(location.X + titleWidth + valWidth, location.Y, valWidth, height);

            g.FillRectangle(backColor, rectTitle);
            g.FillRectangle(backColor, rectLessSqm);
            g.FillRectangle(backColor, rectMoreSqm);

            g.DrawRectangle(new Pen(borderColor, 1), rectTitle);
            g.DrawRectangle(new Pen(borderColor, 1), rectLessSqm);
            g.DrawRectangle(new Pen(borderColor, 1), rectMoreSqm);

            g.DrawString($"Жалюзи", font, Brushes.Black, rectTitle, new StringFormat() { LineAlignment = StringAlignment.Center });
            g.DrawString($"Пакет площадью менее 1 кв.м.", font, Brushes.Black, rectLessSqm, centering);
            g.DrawString($"Пакет площадью 1 и более кв.м.", font, Brushes.Black, rectMoreSqm, centering);

            return location.Y + height;
        }

        public static int DrawCuttingTableTitle(Graphics g, Point location, int width, Font font, Brush backColor, Color borderColor)
        {
            int height = (int)(g.MeasureString("Test", font).Height * 1.3);

            StringFormat centering = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };

            int titleWidth = (width - location.X) / 2 ;
            int valWidth = titleWidth + location.X - 2 ;

            Rectangle rectTitle = new Rectangle(location.X, location.Y, titleWidth, height);
            Rectangle rectvalue = new Rectangle(location.X + titleWidth, location.Y, valWidth, height);

            g.FillRectangle(backColor, rectTitle);
            g.FillRectangle(backColor, rectvalue);

            g.DrawRectangle(new Pen(borderColor, 1), rectTitle);
            g.DrawRectangle(new Pen(borderColor, 1), rectvalue);

            g.DrawString($"Тип стакла", font, Brushes.Black, rectTitle, new StringFormat() { LineAlignment = StringAlignment.Center });
            g.DrawString($"Цена, за кв.м.", font, Brushes.Black, rectvalue, centering);
            return location.Y + height;
        }

        public int DrawCutting(Graphics g, Point location, int width, Font font, Color borderColor)
        {
            int height = (int)(g.MeasureString("Test", font).Height * 1.3);
            StringFormat centering = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };

            int titleWidth = (width - location.X) / 2;
            int valWidth = titleWidth + location.X - 2;

            Rectangle rectTitle = new Rectangle(location.X, location.Y, titleWidth, height);
            Rectangle rectvalue = new Rectangle(location.X + titleWidth, location.Y, valWidth, height);

            g.DrawRectangle(new Pen(borderColor, 1), rectTitle);
            g.DrawRectangle(new Pen(borderColor, 1), rectvalue);

            g.DrawString($"{MaterialMarkType} {VendorMaterialNom} {MaterialSizeType}", font, Brushes.Black, rectTitle, new StringFormat() { LineAlignment = StringAlignment.Center });
            g.DrawString($"{PriceVal:c2}", font, Brushes.Black, rectvalue, centering);
            

            return location.Y + height;
        }

        public static int DrawReplacementTableTitle(Graphics g, Point location, int width, Font font, Brush backColor, Color borderColor)
        {
            int height = (int)(g.MeasureString("Test", font).Height * 1.3);

            StringFormat centering = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };

            int titleWidth = (width - location.X) / 2;
            int valWidth = titleWidth + location.X - 2;

            Rectangle rectTitle = new Rectangle(location.X, location.Y, titleWidth, height);
            Rectangle rectvalue = new Rectangle(location.X + titleWidth, location.Y, valWidth, height);

            g.FillRectangle(backColor, rectTitle);
            g.FillRectangle(backColor, rectvalue);

            g.DrawRectangle(new Pen(borderColor, 1), rectTitle);
            g.DrawRectangle(new Pen(borderColor, 1), rectvalue);

            g.DrawString($"Тип стакла", font, Brushes.Black, rectTitle, new StringFormat() { LineAlignment = StringAlignment.Center });
            g.DrawString($"Цена, за кв.м.", font, Brushes.Black, rectvalue, centering);
            return location.Y + height;
        }

        public int DrawReplacement(Graphics g, Point location, int width, Font font, Color borderColor)
        {
            int height = (int)(g.MeasureString("Test", font).Height * 1.3);
            StringFormat centering = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };

            int titleWidth = (width - location.X) / 2;
            int valWidth = titleWidth + location.X - 2;

            Rectangle rectTitle = new Rectangle(location.X, location.Y, titleWidth, height);
            Rectangle rectvalue = new Rectangle(location.X + titleWidth, location.Y, valWidth, height);

            g.DrawRectangle(new Pen(borderColor, 1), rectTitle);
            g.DrawRectangle(new Pen(borderColor, 1), rectvalue);

            g.DrawString($"{MaterialMarkType} {VendorMaterialNom} {MaterialSizeType}", font, Brushes.Black, rectTitle, new StringFormat() { LineAlignment = StringAlignment.Center });
            g.DrawString($"{PriceVal:c2}", font, Brushes.Black, rectvalue, centering);


            return location.Y + height;
        }

        #endregion
    }
}
