using Socrat.Common.Interfaces.Planning;
using System;

namespace Socrat.MVC.PrintModels.Planning
{
    public class ModelWithPlanningActivityHeader : PrintModel, IPlanningActivityHeader
    {
        #region Properties

        /// <summary>
        /// Производственная площадка
        /// </summary>
        public string Division { get; set; }
        /// <summary>
        /// Локация
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Цех
        /// </summary>
        public string Workshop { get; set; }
        /// <summary>
        /// Смена
        /// </summary>
        public string WorkShift { get; set; }
        /// <summary>
        /// Бригада
        /// </summary>
        public string Team { get; set; }
        /// <summary>
        /// Линия
        /// </summary>
        public string MachineNom { get; set; }
        /// <summary>
        /// Дата плана
        /// </summary>
        public DateTime Dated { get; set; }
        /// <summary>
        /// День недели
        /// </summary>
        public string Weekday { get; set; }
        /// <summary>
        /// Номер очереди
        /// </summary>
        public string QueueNumber { get; set; }

        #endregion

        public ModelWithPlanningActivityHeader(){}

        public ModelWithPlanningActivityHeader(IPlanningActivityHeader iHeader)
        {
            if (iHeader != null)
            {
                Division = iHeader.Division;
                City = iHeader.City;
                Workshop = iHeader.Workshop;
                MachineNom = iHeader.MachineNom;
                WorkShift = iHeader.WorkShift;
                Team = iHeader.Team;
                Dated = iHeader.Dated;
                Weekday = $"{System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(iHeader.Dated.DayOfWeek)}";
                QueueNumber = iHeader.QueueNumber;
            }
            else
                Title = "Нет данных!";
        }

        public override string ToString()
        {
            return $"{Title}: {Division}:{Dated}:{QueueNumber}";
        }
    }
}
