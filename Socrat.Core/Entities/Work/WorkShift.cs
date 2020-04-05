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
using Socrat.Common.Interfaces.References;

namespace Socrat.Core.Entities.Work
{
    [Table("WorkShift")]
    public class WorkShift : Entity
    {
        public WorkShift()
        {
            WorkQueues = new AttachedList<WorkQueue>(this);           
        }

        #region Поля
        [Column("Team_Id")]//, Required
        public Guid? TeamId { get; set; }
        [Column("MachineNom_Id"), Required]
        public Guid MachineNomId { get; set; }
        [Column("WorkShiftType_Id"), Required]
        public Guid WorkShiftTypeId { get; set; }

        private DateTime _workDate;
        [Column("WorkDate"), Required]
        public DateTime WorkDate
        {
            get => _workDate;
            set { SetField(ref _workDate, value, () => WorkDate, () => Title, () => WeekNum); }
        }

        private int? _shiftDuration;
        [Column("ShiftDuration")]
        public int? ShiftDuration
        {
            get => _shiftDuration;
            set { SetField(ref _shiftDuration, value, () => ShiftDuration); }
        }
        

        #endregion Поля

        #region Ссылки
        private Team _team;
        public virtual Team Team
        {
            get => _team;
            set { SetField(ref _team, value, () => Team); }
        }

        private WorkShiftType _workShiftType;
        public virtual WorkShiftType WorkShiftType
        {
            get => _workShiftType;
            set { SetField(ref _workShiftType, value, () => WorkShiftType); }
        }

        private Machines.MachineNom _machineNom;
        public virtual Machines.MachineNom MachineNom
        {
            get => _machineNom;
            set { SetField(ref _machineNom, value, () => MachineNom); }
        }

        [NotMapped]
        [ParentItem]
        public WeeklyWorkShifts WeeklyWorkShifts { get; set; }
        #endregion Ссылки

        #region Коллекции       
        public virtual AttachedList<WorkQueue> WorkQueues { get; }
       
        #endregion Коллекции

        public override string ToString()
        {
            return $"'{WorkShiftType?.Name}' на {WorkDate.ToString("d")} (оборудование: {MachineNom})" ;
        }

        protected override string GetTitle()
        {
            return "Смена: " + this.ToString();
        }

        public string Title2
        { get { return $"Смена: {WorkShiftType?.Name} ({ShiftDuration} ч.), оборудование: {MachineNom}"; } }

        [NotMapped]
        public int WeekNum
        {
            get
            {
                int firstWDayOfYear = (int)new DateTime(WorkDate.Year, 1, 1).DayOfWeek;
                if (firstWDayOfYear == 0) firstWDayOfYear = 7;
                return (WorkDate.DayOfYear + firstWDayOfYear -2) / 7;
            }
        }

        [NotMapped]
        public int WeekDay
        {
            get
            {
                if (WorkDate.DayOfWeek == 0)
                    return 7;
                return (int)WorkDate.DayOfWeek;
            }
        }


        public override ValidationResult Validate(ValidationStage stage, object ownedList)
        {
            if (!(ownedList is List<WorkShift> list))
                throw new Exception("Предоставленный родительский список пуст или не является типом List<WorkShift>");

            if (stage == ValidationStage.OnAdd || stage == ValidationStage.OnEdit)
            {

                if (list.Exists( x => x.Id != Id && x.WorkDate == WorkDate && x.MachineNom.Id == MachineNom.Id && x.WorkShiftType.Id == WorkShiftType.Id))
                    return new ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        "Добавление отменено. набор данных: Дата, оборудование и тип смены должен быть уникальным");
            }

            if (stage == ValidationStage.OnDelete)
            {
                if (this.WorkQueues.Count > 0)
                    return new ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        "Удаление отменено - Смена используется (очереди).");
            }

            return new ValidationResult(ValidationResult.Success);
        }
    }
}
