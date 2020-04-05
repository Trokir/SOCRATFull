using Socrat.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using ValidationResult = Socrat.Common.ValidationResult;

namespace Socrat.Core.Entities.Work
{
    [NotMapped]
    public class WeeklyWorkShifts : Entity
    {
        public WeeklyWorkShifts()
        {
            WorkShifts = new AttachedList<WorkShift>(this);
        }

        #region Поля
        //[Required]
        //public Guid? TeamId { get; set; }
        //[Required]
        public Guid MachineNomId { get; set; }
        //[Required]
        public Guid WorkShiftTypeId { get; set; }

        public DateTime FirstDate { get; private set; }

        private int _year;
        public int Year
        {
            get => _year;
            set
            {
                SetField(ref _year, value, () => _year, () => Title);
                if (WeekNum > 0)
                    FirstDate = GetMondayOfWeek(Year, WeekNum);
            }
        }

        private int _weekNum;
        public int WeekNum
        {
            get => _weekNum;
            set
            {
                SetField(ref _weekNum, value, () => _weekNum, () => Title);
                if(Year >0)
                    FirstDate = GetMondayOfWeek(Year, WeekNum);
            }
        }

        public string WeekText
        {
            get
            {
                DateTime monday = GetMondayOfWeek(Year, WeekNum);
                DateTime sunday = monday.AddDays(6);
                return $"{WeekNum} неделя {Year}г. [{monday.ToString("dd.MM")} - {sunday.ToString("dd.MM")}]";

            }
        }

        private DateTime GetMondayOfWeek(int year, int week)
        {
            int firstWDayOfYear = (int)new DateTime(year, 1, 1).DayOfWeek;
            if (firstWDayOfYear == 0) firstWDayOfYear = 7;

            DateTime date0 = new DateTime(year, 1, 1).AddDays(-firstWDayOfYear); // последнее воскресенье предыдущего года
            return date0.AddDays(week * 7 + 1);
        }
                      
        public int? ShiftDuration1
        {
            get
            {
                return WorkShifts.FirstOrDefault(t => t.WeekDay == 1)?.ShiftDuration;
            }
            set
            {
                WorkShift ws = WorkShifts.FirstOrDefault(t => t.WeekDay == 1);
                if (ws == null)
                {
                    ws = new WorkShift() { MachineNom = this.MachineNom, WorkShiftType = this.WorkShiftType, WorkDate = FirstDate, WeeklyWorkShifts = this };
                    WorkShifts.Add(ws);
                }
                ws.ShiftDuration = value;                    
            }
        }

        
        public int? ShiftDuration2
        {
            get
            {
                return WorkShifts.FirstOrDefault(t => t.WeekDay == 2)?.ShiftDuration;
            }
            set
            {
                WorkShift ws = WorkShifts.FirstOrDefault(t => t.WeekDay == 2);
                if (ws == null)
                {
                    ws = new WorkShift() { MachineNom = this.MachineNom, WorkShiftType = this.WorkShiftType, WorkDate = FirstDate.AddDays(1), WeeklyWorkShifts = this };
                    WorkShifts.Add(ws);
                }
                ws.ShiftDuration = value;
            }
        }
      
        public int? ShiftDuration3
        {
            get
            {
                return WorkShifts.FirstOrDefault(t => t.WeekDay == 3)?.ShiftDuration;
            }
            set
            {
                WorkShift ws = WorkShifts.FirstOrDefault(t => t.WeekDay == 3);
                if (ws == null)
                {
                    ws = new WorkShift() { MachineNom = this.MachineNom, WorkShiftType = this.WorkShiftType, WorkDate = FirstDate.AddDays(2), WeeklyWorkShifts = this };
                    WorkShifts.Add(ws);
                }
                ws.ShiftDuration = value;
            }
        }

        public int? ShiftDuration4
        {
            get
            {
                return WorkShifts.FirstOrDefault(t => t.WeekDay == 4)?.ShiftDuration;
            }
            set
            {
                WorkShift ws = WorkShifts.FirstOrDefault(t => t.WeekDay == 4);
                if (ws == null)
                {
                    ws = new WorkShift() { MachineNom = this.MachineNom, WorkShiftType = this.WorkShiftType, WorkDate = FirstDate.AddDays(3), WeeklyWorkShifts = this };
                    WorkShifts.Add(ws);
                }
                ws.ShiftDuration = value;
            }
        }
      
        public int? ShiftDuration5
        {
            get
            {
                return WorkShifts.FirstOrDefault(t => t.WeekDay == 5)?.ShiftDuration;
            }
            set
            {
                WorkShift ws = WorkShifts.FirstOrDefault(t => t.WeekDay == 5);
                if (ws == null)
                {
                    ws = new WorkShift() { MachineNom = this.MachineNom, WorkShiftType = this.WorkShiftType, WorkDate = FirstDate.AddDays(4), WeeklyWorkShifts = this };
                    WorkShifts.Add(ws);
                }
                ws.ShiftDuration = value;
            }
        }
       
        public int? ShiftDuration6
        {
            get
            {
                return WorkShifts.FirstOrDefault(t => t.WeekDay == 6)?.ShiftDuration;
            }
            set
            {
                WorkShift ws = WorkShifts.FirstOrDefault(t => t.WeekDay == 6);
                if (ws == null)
                {
                    ws = new WorkShift() { MachineNom = this.MachineNom, WorkShiftType = this.WorkShiftType, WorkDate = FirstDate.AddDays(5), WeeklyWorkShifts = this };
                    WorkShifts.Add(ws);
                }
                ws.ShiftDuration = value;
            }
        }
       
        public int? ShiftDuration7
        {
            get
            {
                return WorkShifts.FirstOrDefault(t => t.WeekDay == 7)?.ShiftDuration;
            }
            set
            {
                WorkShift ws = WorkShifts.FirstOrDefault(t => t.WeekDay == 7);
                if (ws == null)
                {
                    ws = new WorkShift() { MachineNom = this.MachineNom, WorkShiftType = this.WorkShiftType, WorkDate = FirstDate.AddDays(6), WeeklyWorkShifts = this };
                    WorkShifts.Add(ws);
                }
                ws.ShiftDuration = value;
            }
        }

        public Team Team1
        {
            get
            {
                return WorkShifts.FirstOrDefault(t => t.WeekDay == 1)?.Team;
            }
            set
            {
                WorkShift ws = WorkShifts.FirstOrDefault(t => t.WeekDay == 1);
                if (ws == null)
                {
                    ws = new WorkShift() { MachineNom = this.MachineNom, WorkShiftType = this.WorkShiftType, WorkDate = FirstDate, WeeklyWorkShifts = this };
                    WorkShifts.Add(ws);
                }
                ws.Team = value;
            }
        }


        public Team Team2
        {
            get
            {
                return WorkShifts.FirstOrDefault(t => t.WeekDay == 2)?.Team;
            }
            set
            {
                WorkShift ws = WorkShifts.FirstOrDefault(t => t.WeekDay == 2);
                if (ws == null)
                {
                    ws = new WorkShift() { MachineNom = this.MachineNom, WorkShiftType = this.WorkShiftType, WorkDate = FirstDate.AddDays(1), WeeklyWorkShifts = this };
                    WorkShifts.Add(ws);
                }
                ws.Team = value;
            }
        }

        public Team Team3
        {
            get
            {
                return WorkShifts.FirstOrDefault(t => t.WeekDay == 3)?.Team;
            }
            set
            {
                WorkShift ws = WorkShifts.FirstOrDefault(t => t.WeekDay == 3);
                if (ws == null)
                {
                    ws = new WorkShift() { MachineNom = this.MachineNom, WorkShiftType = this.WorkShiftType, WorkDate = FirstDate.AddDays(2), WeeklyWorkShifts = this };
                    WorkShifts.Add(ws);
                }
                ws.Team = value;
            }
        }

        public Team Team4
        {
            get
            {
                return WorkShifts.FirstOrDefault(t => t.WeekDay == 4)?.Team;
            }
            set
            {
                WorkShift ws = WorkShifts.FirstOrDefault(t => t.WeekDay == 4);
                if (ws == null)
                {
                    ws = new WorkShift() { MachineNom = this.MachineNom, WorkShiftType = this.WorkShiftType, WorkDate = FirstDate.AddDays(3), WeeklyWorkShifts = this };
                    WorkShifts.Add(ws);
                }
                ws.Team = value;
            }
        }

        public Team Team5
        {
            get
            {
                return WorkShifts.FirstOrDefault(t => t.WeekDay == 5)?.Team;
            }
            set
            {
                WorkShift ws = WorkShifts.FirstOrDefault(t => t.WeekDay == 5);
                if (ws == null)
                {
                    ws = new WorkShift() { MachineNom = this.MachineNom, WorkShiftType = this.WorkShiftType, WorkDate = FirstDate.AddDays(4), WeeklyWorkShifts = this };
                    WorkShifts.Add(ws);
                }
                ws.Team = value;
            }
        }

        public Team Team6
        {
            get
            {
                return WorkShifts.FirstOrDefault(t => t.WeekDay == 6)?.Team;
            }
            set
            {
                WorkShift ws = WorkShifts.FirstOrDefault(t => t.WeekDay == 6);
                if (ws == null)
                {
                    ws = new WorkShift() { MachineNom = this.MachineNom, WorkShiftType = this.WorkShiftType, WorkDate = FirstDate.AddDays(5), WeeklyWorkShifts = this };
                    WorkShifts.Add(ws);
                }
                ws.Team = value;
            }
        }

        public Team Team7
        {
            get
            {
                return WorkShifts.FirstOrDefault(t => t.WeekDay == 7)?.Team;
            }
            set
            {
                WorkShift ws = WorkShifts.FirstOrDefault(t => t.WeekDay == 7);
                if (ws == null)
                {
                    ws = new WorkShift() { MachineNom = this.MachineNom, WorkShiftType = this.WorkShiftType, WorkDate = FirstDate.AddDays(6), WeeklyWorkShifts = this };
                    WorkShifts.Add(ws);
                }
                ws.Team = value;
            }
        }       


        #endregion Поля

        #region Ссылки
        //private Team _team;
        //public virtual Team Team
        //{
        //    get => _team;
        //    set { SetField(ref _team, value, () => Team); }
        //}



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
        public WeeklyWorkShiftsList WeeklyWorkShiftsList { get; set; }
        #endregion Ссылки

        #region Коллекции
        
        public AttachedList<WorkShift> WorkShifts { get;  }       

        #endregion Коллекции

        public override string ToString()
        {
            return $"неделя: {WeekNum} ({Year}) # {WorkShiftType}";
        }

        protected override string GetTitle()
        {
            return $"Смены на неделю: {WeekNum} ({Year}) # площадка: {WorkShiftType?.Division} # смена: {WorkShiftType}";
        }

        private int?[] _hashValues = new int?[4];
        private int _hash =0;
        public int Hash
        {
            get
            {                
                return _hash;
            }
            set
            {
                _hashValues[0] = MachineNom?.Id.GetHashCode();
                _hashValues[1] = WorkShiftType?.Id.GetHashCode();                
                _hashValues[2] = Year;
                _hashValues[3] = WeekNum;
                _hash = value;

            }
        }

        private bool EqualHash(WeeklyWorkShifts wws)
        {
            return _hashValues[0] == wws.MachineNom?.Id.GetHashCode()
                && _hashValues[1] == wws.WorkShiftType?.Id.GetHashCode()
                && _hashValues[2] == Year
                && _hashValues[3] == WeekNum
                ;
        }

        public bool EqualSimplyHash(WeeklyWorkShifts wws)
        {
            return _hashValues[0] == wws.MachineNom?.Id.GetHashCode()
                && _hashValues[1] == wws.WorkShiftType?.Id.GetHashCode();
        }

        public override ValidationResult Validate(ValidationStage stage, object ownedList)
        {

            if (!(ownedList is List<WeeklyWorkShifts> list))
                throw new Exception("Предоставленный родительский список пуст или не является типом List<WeeklyWorkShifts>");
                       
            if (stage == ValidationStage.OnEdit || stage == ValidationStage.OnAdd)
            {
                
                if (list.Any(     x => !EqualHash(x)  &&  x.MachineNom.Id == MachineNom.Id && x.WorkShiftType.Id == WorkShiftType.Id && x.Year == Year && x.WeekNum == WeekNum))
                    return new ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        $"Недельный плановый график работы оборудования: '{MachineNom}' (тип смены: {WorkShiftType}) на {WeekNum}-ю неделю уже содержится в базе данных!");
            }
            if (stage == ValidationStage.OnDelete)
            {
                if (this.WorkShifts.Sum(ws => ws.WorkQueues.Count) > 0 )
                    return new ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        "Удаление отменено - Набор смен используется (очереди).");
            }

            return new ValidationResult(ValidationResult.Success);
        }

        //protected new void SetField<WorkShift>(ref WorkShift field, WorkShift value, Expression<Func<WorkShift>> selectorExpression, params Expression<Func<object>>[] additonal)
        //{
        //    if (EqualityComparer<WorkShift>.Default.Equals(field, value))
        //        return;
        //    Entity _entity = value as Entity;
        //    if (null != _entity)
        //    {
        //        Entity _field = field as Entity;
        //        if (_field != null && _field.Id == _entity.Id)
        //        {
        //            field = value;
        //            return;
        //        }
        //    }

        //    //Socrat.DataProvider.DataHelper


        //    //System.Diagnostics.Debug.Print($"Изменен {this} Значение: {value}");

         
        //    field = value;

        //    OnPropertyChanged(selectorExpression);



        //    // проверка - изменен ли entity в контексте, если да - то устанавливаем флаг изменений
        //    IsChangedEventArgs eargs = new IsChangedEventArgs();
        //    RaiseCheckIsChanged(, eargs);


        //    bool isChanged = eargs.IsChanged;
        //    if (isChanged)
        //    {
        //        //_Changed = !NoFireParentChanges;
        //        //if (!NoFireParentChanges)
        //        _Changed = true;

        //        //если есть родитель
        //        SetParentsChanged(true);
        //        OnPropertyChanged(() => Changed);
        //    }

        //    _tmpOld = null;
        //    _tmpNew = null;
        //    foreach (var item in additonal)
        //        OnPropertyChanged(item);



        //}
    }
}
