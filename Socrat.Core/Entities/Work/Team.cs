using Socrat.Common;
using Socrat.Common.Interfaces.References;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationResult = Socrat.Common.ValidationResult;

namespace Socrat.Core.Entities.Work
{
    [Table("Team")]
    public class Team : Entity, ITeam
    {
        public Team()
        {
            WorkShifts = new AttachedList<WorkShift>(this);
            CuttedItems = new AttachedList<OrderRowItem>(this);
            AssembledItems = new AttachedList<OrderRowItem>(this);
        }
        #region Поля
        [Column("TeamType_Id"), Required]
        public Guid TeamTypeId { get; set; }
        [Column("Division_Id"), Required]
        public Guid DivisionId { get; set; }

        private string _name;
        [Column("Name"), MaxLength(50), Required]
        public string Name
        {
            get => _name;
            set { SetField(ref _name, value, () => Name, () => Title); }
        }

        private int? _num;
        [Column("Num")]
        public int? Num
        {
            get => _num;
            set { SetField(ref _num, value, () => Num, () => Title); }
        }

        #endregion Поля

        #region Ссылки
        private TeamType _teamType;
        public virtual TeamType TeamType
        {
            get => _teamType;
            set { SetField(ref _teamType, value, () => TeamType); }
        }

        private Division _division;
        [LocalIgnoreChangesItem]
        public virtual Division Division
        {
            get => _division;
            set { SetField(ref _division, value, () => Division); }
        }
        IDivision ITeam.Division => Division;

        #endregion Ссылки

        #region Коллекции

        public virtual AttachedList<WorkShift> WorkShifts { get; }
        #endregion Коллекции

        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? "Новаая бригада" : Name;
        }

        protected override string GetTitle()
        {
            if (string.IsNullOrWhiteSpace(Name))
                return "Бригада";
            return "Бригада: " + Name + (Num != null ? " № " + Num : "") ;
        }

        public virtual AttachedList<OrderRowItem> CuttedItems { get; set; }
        public virtual AttachedList<OrderRowItem> AssembledItems { get; set; }
        public override ValidationResult Validate(ValidationStage stage, object ownedList)
        {
            if (!(ownedList is List<Team> list))
                throw new Exception("Предоставленный родительский список пуст или не является типом List<Team>");

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
                if (this.WorkShifts.Count > 0)
                    return new ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        "Удаление отменено - Бригада используется (смены).");
            }

            return new ValidationResult(ValidationResult.Success);
        }
    }
}
