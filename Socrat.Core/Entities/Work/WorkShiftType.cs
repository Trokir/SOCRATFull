using Socrat.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using ValidationResult = Socrat.Common.ValidationResult;

namespace Socrat.Core.Entities.Work
{
    [Table("WorkShiftType")]
    public class WorkShiftType : Entity
    {
        public WorkShiftType()
        {
            WorkShifts = new AttachedList<WorkShift>(this);
            WorkShiftWeeks = new AttachedList<WorkShiftsTemplate>(this);
        }

        #region Поля
        [Column("Division_Id"), Required]
        public Guid DivisionId { get; set; }

        private string _name;
        [Column("Name"), MaxLength(50), Required]
        public string Name
        {
            get => _name;
            set { SetField(ref _name, value, () => Name, () => Title); }
        }

        private int? _ordernum;
        [Column("OrderNum")]
        public int? OrderNum
        {
            get => _ordernum;
            set { SetField(ref _ordernum, value, () => OrderNum); }
        }

        private Color? _color;
        
        [NotMapped]
        public Color? Color
        {
            get => _color;
            set { SetField(ref _color, value, () => Color, () => ColorRGB); }
        }

        
        [Column("Color")]
        public int? ColorRGB
        {
            get { return Color?.ToArgb(); }
            set
            {
                if (value != Color?.ToArgb())
                {
                    if (value == null)
                        Color = null;
                    else
                    {
                        Color = System.Drawing.Color.FromArgb(value.Value);
                    }
                }
            }
        }
        #endregion Поля

        #region Ссылки
        private Division _division;
        [LocalIgnoreChangesItem]
        public virtual Division Division
        {
            get => _division;
            set { SetField(ref _division, value, () => Division); }
        }
        #endregion Ссылки

        #region Коллекции
        
        public virtual AttachedList<WorkShift> WorkShifts { get; }

        public virtual AttachedList<WorkShiftsTemplate> WorkShiftWeeks { get; }
        #endregion Коллекции

        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? "Новаый тип смены" : Name;
        }

        protected override string GetTitle()
        {
            if (string.IsNullOrWhiteSpace(Name))
                return "Тип смены";
            return "Тип смены: " + Name;
        }

        [NotMapped]
        public string AliasName
        {
            get { return ToString();  }
        }

        public override ValidationResult Validate(ValidationStage stage, object ownedList)
        {
            if (!(ownedList is List<WorkShiftType> list))
                throw new Exception("Предоставленный родительский список пуст или не является типом List<WorkShiftType>");

            if (stage == ValidationStage.OnAdd || stage == ValidationStage.OnEdit)
            {

                if (list.Exists(x => x.Id != Id && x.Division.Id == Division.Id && StringEquals(x.Name, Name)))
                    return new ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        "Добавление отменено. наименование должно быть уникальным в пределах площадки.");
            }

            if (stage == ValidationStage.OnDelete)
            {
                if (this.WorkShiftWeeks.Count > 0 || this.WorkShifts.Count > 0)
                    return new ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        "Удаление отменено - Смена используется (плановый недельный график и/или смены).");
            }

            return new ValidationResult(ValidationResult.Success);
        }
    }
}
