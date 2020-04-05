using Socrat.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationResult = Socrat.Common.ValidationResult;

namespace Socrat.Core.Entities.Pyramids
{
    [Table("TruckPyramid")]
    public class TruckPyramid : Entity
    {
        #region Поля
        [Column("Type_Id"), Required]
       
        public Guid TruckPyramidTypeId { get; set; }
        [Column("Division_Id")]
        public Guid? DivisionId { get; set; }
        private string _mark;
        [Column("Mark"), MaxLength(50)]
        public string Mark
        {
            get => _mark;
            set { SetField(ref _mark, value, () => Mark, () => Title); }
        }
        private string _num;
        [Column("Num"), MaxLength(15)]
        public string Num
        {
            get => _num;
            set { SetField(ref _num, value, () => Num, () => Title); }
        }
        #endregion Поля

        #region Ссылки
        private TruckPyramidType _truckPyramidType;
        public virtual TruckPyramidType TruckPyramidType
        {
            get => _truckPyramidType;
            set { SetField(ref _truckPyramidType, value, () => TruckPyramidType); }
        }

        private Division _division;
        [LocalIgnoreChangesItem]
        public virtual Division Division
        {
            get => _division;
            set { SetField(ref _division, value, () => Division); }
        }
        #endregion Ссылки
        #region Коллекции
        
        #endregion Коллекции
        public override string ToString()
        {  
            string name = Mark == null /* && Num == null */ ? Id.GetHashCode().ToString() : ((Mark != null ? Mark : "") + (/* Num != null ? */ " № " + Num /* : "" */));
            return name;
        }

        protected override string GetTitle()
        {          
            return $"Пирамида: {this}" ;
        }

        public override ValidationResult Validate(ValidationStage stage, object ownedList)
        {

            if (!(ownedList is List<TruckPyramid> list))
                throw new Exception("Предоставленный родительский список пуст или не является типом List<TruckPyramid>");

            if (stage == ValidationStage.OnEdit || stage == ValidationStage.OnAdd)
            {
                if (list.Any(x => x.Id != Id && x.Division.Id == Division.Id && x.Num == Num))
                    return new ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        $"Пирамида c номером: '{Num}' уже есть на площадке '{Division}'!");
            }

            if (stage == ValidationStage.OnDelete)
            {
                //if (this.Pyramids.Count > 0)
                //    return new ValidationResult(
                //        ValidationState.Failed,
                //        ReportType.MessageBox,
                //        "Удаление отменено - Тип пирамид используется.");
            }

            return new ValidationResult(ValidationResult.Success);
        }
    }
}
