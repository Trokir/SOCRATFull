using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Socrat.Common;
using ValidationResult = Socrat.Common.ValidationResult;

namespace Socrat.Core.Entities.Pyramids
{
    [Table("TruckPyramidType")]
    public class TruckPyramidType : Entity
    {
        public TruckPyramidType()
        {
            Pyramids = new AttachedList<TruckPyramid>(this);
        }

        #region Поля
        private string _name;
        [Column("Name"), MaxLength(50), Required]
        public string Name
        {
            get => _name;
            set { SetField(ref _name, value, () => Name, () => Title); }
        }

        private int _sideCount;
        [Column("SideCount"), Required]
        public int SideCount
        {
            get => _sideCount;
            set { SetField(ref _sideCount, value, () => SideCount); }
        }

        //private int _sideWidth;
        //[Column("SideWidth"), Required]
        //public int SideWidth
        //{
        //    get => _sideWidth;
        //    set { SetField(ref _sideWidth, value, () => SideWidth); }
        //}

        //private int _sideHeight;
        //[Column("SideHeight"), Required]
        //public int SideHeight
        //{
        //    get => _sideHeight;
        //    set { SetField(ref _sideHeight, value, () => SideHeight); }
        //}

        private int _a;
        /// <summary>
        /// Габаритная длина пирамиды
        /// </summary>
        [Column("A"), Required]
        public int A
        {
            get => _a;
            set { SetField(ref _a, value, () => A); }
        }

        private int _a1;
        /// <summary>
        /// Габаритная длина привалочной стороны пирамиды
        /// </summary>
        [Column("A1"), Required]
        public int A1
        {
            get => _a1;
            set { SetField(ref _a1, value, () => A1); }
        }
        private int _a4;

        /// <summary>
        /// Расстояние между опорными планками
        /// </summary>
        [Column("A4"), Required]       
        public int A4
        {
            get => _a4;
            set { SetField(ref _a4, value, () => A4); }
        }
        private int _b;
        /// <summary>
        /// Габаритная ширина пирамиды
        /// </summary>
        [Column("B"), Required]
        public int B
        {
            get => _b;
            set { SetField(ref _b, value, () => B); }
        }
        private int _b1;
        /// <summary>
        /// Глубина стороны пирамиды
        /// </summary>
        [Column("B1"), Required]
        public int B1
        {
            get => _b1;
            set { SetField(ref _b1, value, () => B1); }
        }
        private int _h;
        /// <summary>
        /// Габаритная высота пирамиды
        /// </summary>
        [Column("H"), Required]
        public int H
        {
            get => _h;
            set { SetField(ref _h, value, () => H); }
        }
        private int _h1;
        /// <summary>
        /// Высота привалочной стороны пирамиды
        /// </summary>
        [Column("H1"), Required]
        public int H1
        {
            get => _h1;
            set { SetField(ref _h1, value, () => H1); }
        }

        private bool _isDefault;
        /// <summary>
        /// пирамида по умолчанию
        /// </summary>
        [Column("IsDefault"), Required]
        public bool IsDefault
        {
            get => _isDefault;
            set { SetField(ref _isDefault, value, () => IsDefault); }
        }

        #endregion Поля

        #region Ссылки
        #endregion Ссылки

        #region Коллекции

        public virtual AttachedList<TruckPyramid> Pyramids { get; }
        #endregion Коллекции

        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? "Новый тип пирамид" : Name;          
        }

        protected override string GetTitle()
        {
            if (string.IsNullOrWhiteSpace(Name))
                return "Тип пирамиды";
            return "Тип пирамиды: " + Name;
        }

        public override ValidationResult Validate(ValidationStage stage, object ownedList)
        {
            if (!(ownedList is List<TruckPyramidType> list))
                throw new Exception("Предоставленный родительский список пуст или не является типом List<TruckPyramidType>");

            if (stage == ValidationStage.OnAdd || stage == ValidationStage.OnEdit)
            {

                if (list.Exists(x => x.Id != Id && StringEquals(x.Name, Name)))
                    return new ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        "Добавление отменено. наименование должно быть уникальным.");


                if(this.A < 1000 || this.A > 7000)
                    return new ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        "Введена некорректная габаритная длина пирамиды.");

                if (this.A1 < 1000 || this.A1 > 7000 || this.A1 > this.A)
                    return new ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        "Введена некорректная габаритная длина привалочной стороны пирамиды.");

                if (this.A4 < 100 || this.A4 > 2000 || this.A4 > this.A1)
                    return new ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        "Введено некорректное расстояние между опорными планками.");

                if (this.B < 400 || this.B > 2000)
                    return new ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        "Введена некорректная габаритная ширина пирамиды.");

                if (this.B1 < 200 || this.B1 > 1000 || this.B1 > this.B)
                    return new ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        "Введена некорректная глубина стороны пирамиды.");

                if (this.H < 1000 || this.H > 4000)
                    return new ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        "Введена некорректная габаритная высота пирамиды.");

                if (this.H1 < 1000 || this.H1 > 3500 ||  this.H1 > this.H )
                    return new ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        "Введена некорректная высота привалочной стороны пирамиды.");

            

              
            }

            if (stage == ValidationStage.OnDelete)
            {
                if (this.Pyramids.Count > 0 )
                    return new ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        "Удаление отменено - Тип пирамид используется.");
            }

            return new ValidationResult(ValidationResult.Success);
        }
    }
}
