using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Socrat.Common;
using ValidationResult = Socrat.Common.ValidationResult;

namespace Socrat.Core.Entities.Work
{
    [Table("WorkShiftWeek")]
    public class WorkShiftsTemplate : Entity
    {
        #region Поля
        [Column("MachineNom_Id"), Required]
        public Guid MachineNomId { get; set; }
        [Column("WorkShiftType_Id"), Required]
        public Guid WorkShiftTypeId { get; set; }

        //private Added.WeekDaysEnum _weekDay;
        //[Column("WeekDay"), Required]
        //public Added.WeekDaysEnum WeekDay
        //{
        //    get => _weekDay;
        //    set { SetField(ref _weekDay, value, () => WeekDay, () => Title ); }
        //}

        private int? _shiftDuration1;
        [Column("ShiftDuration1")]
        public int? ShiftDuration1
        {
            get => _shiftDuration1;
            set { SetField(ref _shiftDuration1, value, () => ShiftDuration1); }
        }

        private int? _shiftDuration2;
        [Column("ShiftDuration2")]
        public int? ShiftDuration2
        {
            get => _shiftDuration2;
            set { SetField(ref _shiftDuration2, value, () => ShiftDuration2); }
        }

        private int? _shiftDuration3;
        [Column("ShiftDuration3")]
        public int? ShiftDuration3
        {
            get => _shiftDuration3;
            set { SetField(ref _shiftDuration3, value, () => ShiftDuration3); }
        }

        private int? _shiftDuration4;
        [Column("ShiftDuration4")]
        public int? ShiftDuration4
        {
            get => _shiftDuration4;
            set { SetField(ref _shiftDuration4, value, () => ShiftDuration4); }
        }

        private int? _shiftDuration5;
        [Column("ShiftDuration5")]
        public int? ShiftDuration5
        {
            get => _shiftDuration5;
            set { SetField(ref _shiftDuration5, value, () => ShiftDuration5); }
        }

        private int? _shiftDuration6;
        [Column("ShiftDuration6")]
        public int? ShiftDuration6
        {
            get => _shiftDuration6;
            set { SetField(ref _shiftDuration6, value, () => ShiftDuration6); }
        }

        private int? _shiftDuration7;
        [Column("ShiftDuration7")]
        public int? ShiftDuration7
        {
            get => _shiftDuration7;
            set { SetField(ref _shiftDuration7, value, () => ShiftDuration7); }
        }
        //private bool? _isActive;
        //[Column("IsActive")]
        //public bool? IsActive
        //{
        //    get => _isActive;
        //    set { SetField(ref _isActive, value, () => IsActive); }
        //}
        #endregion Поля

        #region Ссылки
        private WorkShiftType _workShiftType;
        public virtual WorkShiftType WorkShiftType
        {
            get => _workShiftType;
            set { SetField(ref _workShiftType, value, () => WorkShiftType); }
        }

        private Machines.MachineNom _machineNom;
        [LocalIgnoreChangesItem]
        public virtual Machines.MachineNom MachineNom
        {
            get => _machineNom;
            set { SetField(ref _machineNom, value, () => MachineNom, () => Title); }
        }

        [NotMapped]
        [ParentItem]
        public WorkShiftsTemplateList WorkShiftsTemplateList { get; set; }
        #endregion Ссылки

        #region Коллекции
        #endregion Коллекции

        public override string ToString()
        {
            return $"План для {MachineNom?.InternalName} (тип смены: {WorkShiftType?.Name})";
        }

        protected override string GetTitle()
        {
            return $"Недельный плановый график работы оборудования: {MachineNom?.InternalName} (тип смены: {WorkShiftType?.Name})" ;
        }

        public override ValidationResult Validate(ValidationStage stage, object ownedList)
        {            

            if (!(ownedList is List<WorkShiftsTemplate> list))
                throw new Exception("Предоставленный родительский список пуст или не является типом List<WorkShiftWeek>");

            if (stage == ValidationStage.OnAdd || stage == ValidationStage.OnEdit)
            {
                if (list.Any(x => x.Id != this.Id 
                                  && x.MachineNom.Id == MachineNom.Id 
                                  && x.WorkShiftType.Id == WorkShiftType.Id))
                    return new ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        $"Недельный плановый график работы оборудования: '{MachineNom}' (тип смены: {WorkShiftType}) уже содержится в базе данных!");
            }

            if (stage == ValidationStage.OnEdit)
            {
                if (list.Any(x => x.Id != Id && x.MachineNom.Id == MachineNom.Id && x.WorkShiftType.Id == WorkShiftType.Id))
                    return new ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        $"Недельный плановый график работы оборудования: '{MachineNom}' (тип смены: {WorkShiftType}) уже содержится в базе данных!");
            }

            return new ValidationResult(ValidationResult.Success);
        }
    }
}
