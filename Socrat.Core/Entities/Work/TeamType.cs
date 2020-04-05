using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Socrat.Core.Added;
using Socrat.Common;

namespace Socrat.Core.Entities.Work
{
    [Table("TeamType")]
    public class TeamType : Entity
    {
        public TeamType()
        {
            Teams = new AttachedList<Team>(this);
        }

        #region Поля
        private string _name;
        [Column("Name"), MaxLength(50), Required]
        public string Name
        {
            get => _name;
            set { SetField(ref _name, value, () => Name, () => Title); }
        }
        #endregion Поля

        #region Ссылки
        #endregion Ссылки

        #region Коллекции
   
        public virtual AttachedList<Team> Teams { get; }
        #endregion Коллекции

        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? "Новаый тип бригады" : Name;
        }

        protected override string GetTitle()
        {
            if (string.IsNullOrWhiteSpace(Name))
                return "Тип бригады";
            return "Тип бригады: " + Name;
        }


        private TeamTypeEnum _Enumerator;
        public TeamTypeEnum Enumerator
        {
            get { return _Enumerator; }
            set { SetField(ref _Enumerator, value, () => Enumerator); }
        } 


        public override Common.ValidationResult Validate(ValidationStage stage, object ownedList)
        {
            if (!(ownedList is List<TeamType> list))
                throw new Exception("Предоставленный родительский список пуст или не является типом List<TeamType>");

            if (stage == ValidationStage.OnAdd || stage == ValidationStage.OnEdit)
            {

                if (list.Exists(x => x.Id != Id && StringEquals(x.Name, Name)))
                    return new Common.ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        "Добавление отменено. название типа должно быть уникальным.");
            }

            if (stage == ValidationStage.OnDelete)
            {
                if (this.Teams.Count > 0)
                    return new Common.ValidationResult(
                        ValidationState.Failed,
                        ReportType.MessageBox,
                        "Удаление отменено - Тип бригады используется (бригады).");
            }

            return new Common.ValidationResult(Common.ValidationResult.Success);
        }
    }
}
