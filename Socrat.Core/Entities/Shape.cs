using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Socrat.Core.Entities
{
    public class Shape : Entity
    {

        private int _SidesCount;
        private byte[] _ShapeImage;

        public Shape()
        {

            ShapePoints = new List<ShapePoint>();
        }


        [Browsable(false)]
        protected override string GetTitle()
        {
            return $"Фигура";
        }



        [DisplayName("Резка стекла")]
        [Description("Технологические особенности")]
        [ReadOnly(false)]
        [Category("Коррекция")]
        [Browsable(false)]
        [Display(AutoGenerateField = false)]
        public int SidesCount
        {
            get { return _SidesCount; }
            set { SetField(ref _SidesCount, value, () => SidesCount); }
        }

        private int _CatalogNumber;
        [Display(Name = "Номер в каталоге")]
        public int CatalogNumber
        {
            get { return _CatalogNumber; }
            set { SetField(ref _CatalogNumber, value, () => CatalogNumber); }
        }

        /// <summary>
        /// The is catalog
        /// </summary>
        private bool _IsCatalogShape;

        [Description("Технологические особенности")]
        [ReadOnly(false)]
        [Category("Тип записи")]
        [Display(AutoGenerateField = false)]
        public bool IsCatalogShape
        {
            get { return _IsCatalogShape; }
            set { SetField(ref _IsCatalogShape, value, () => IsCatalogShape); }
        }

        [Display(Name = "Изображение")]
        public byte[] ShapeImage
        {
            get { return _ShapeImage; }
            set { SetField(ref _ShapeImage, value, () => ShapeImage); }
        }
        //[NotMapped]
        //public Guid? FormTypeId { get; set; }

        //[ParentItem]
        //private FormType _formType;
        //[NotMapped]
        //public virtual FormType FormType
        //{
        //    get { return _formType; }
        //    set { SetField(ref _formType, value, () => FormType); }
        //}

        /// <summary>
        /// The shape points
        /// </summary>
        private List<ShapePoint> _ShapePoints;

        private double? _allSidesGermDepth;

        [Browsable(false)]
        public virtual List<ShapePoint> ShapePoints
        {
            get { return _ShapePoints; }
            set { SetField(ref _ShapePoints, value, () => ShapePoints); }
        }
        [Browsable(false)]
        public virtual ShapeParam ShapeParam { get; set; }
        [Browsable(false)]
        public virtual ShapeModifedParam ShapeModifedParam { get; set; }

        public virtual ObservableCollection<OrderRow> OrderRows { get; set; }
        [NotMapped]
        [Browsable(false)]
        public bool IsAddAdwansedParams { get; set; }
        public virtual bool IsValidCatalogShape(double? h, double? w)
        {
            bool flag = true;
            var arr = new int[] { 20, 21, 22, 23, 24, 27, 28, 29, 41, 44, 46, 51, 54, 58, 60, 61, 62 };
            if (arr.Contains(CatalogNumber))
            {
                flag = false;
            }
            else
            {
                ShapeParam.H_param = h;
                ShapeParam.L_param = w;
                flag = true;
            }
            return flag;
        }

        public double GetIdentSquare()
        {
            var value = (ShapeParam.IsToothVector is true)
                ? ShapeModifedParam.TrueArea - ShapeParam.Area
                : ShapeParam.Area - ShapeModifedParam.TrueArea;
            return value ?? 0;
        }
    }

}

