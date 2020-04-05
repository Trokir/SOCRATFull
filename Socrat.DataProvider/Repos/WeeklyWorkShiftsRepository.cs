using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.Core.Entities.Work;
using Socrat.Log;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace Socrat.DataProvider.Repos
{
    public class WeeklyWorkShiftsRepository : UniversalRepository<Core.Entities.Work.WeeklyWorkShifts>
    {
        public override IQueryable<WeeklyWorkShifts> GetAll(Expression<Func<WeeklyWorkShifts, bool>> criteria = null)//, Expression<Func<WeeklyWorkShifts, bool>> extCriteria = null
        {
            var weeklyWorkShifts = SocratEntities.Set<WorkShift>()
               .AsEnumerable()
                   .GroupBy(t => new { t.MachineNom, t.WorkShiftType, t.Team, t.WorkDate.Year, t.WeekNum })
                   .Select(g => new WeeklyWorkShifts
                   {
                       MachineNom = g.Key.MachineNom,
                       WorkShiftType = g.Key.WorkShiftType,
                       Year = g.Key.Year,
                       WeekNum = g.Key.WeekNum,
                       Hash = 1,
                       ShiftDuration1 = g.Where(d => d.WeekDay == 1).FirstOrDefault()?.ShiftDuration,
                       ShiftDuration2 = g.Where(d => d.WeekDay == 2).FirstOrDefault()?.ShiftDuration,
                       ShiftDuration3 = g.Where(d => d.WeekDay == 3).FirstOrDefault()?.ShiftDuration,
                       ShiftDuration4 = g.Where(d => d.WeekDay == 4).FirstOrDefault()?.ShiftDuration,
                       ShiftDuration5 = g.Where(d => d.WeekDay == 5).FirstOrDefault()?.ShiftDuration,
                       ShiftDuration6 = g.Where(d => d.WeekDay == 6).FirstOrDefault()?.ShiftDuration,
                       ShiftDuration7 = g.Where(d => d.WeekDay == 7).FirstOrDefault()?.ShiftDuration,
                  
                       Loaded = true
                   })
                .AsQueryable();

            return weeklyWorkShifts;


        }





        public override IQueryable<WeeklyWorkShifts> GetAllEx(object criteria)
        {
            Expression<Func<WorkShift, bool>> cr = (Expression<Func<WorkShift, bool>>)criteria;
            var weeklyWorkShifts = SocratEntities.Set<WorkShift>().Where(cr)
               .AsEnumerable()
                   .GroupBy(t => new { t.MachineNom, t.WorkShiftType, t.Team, t.WorkDate.Year, t.WeekNum })
                   .Select(g => new WeeklyWorkShifts
                   {
                       MachineNom = g.Key.MachineNom,
                       WorkShiftType = g.Key.WorkShiftType,
                       Year = g.Key.Year,
                       WeekNum = g.Key.WeekNum,
                       Hash = 1,
                       ShiftDuration1 = g.Where(d => d.WeekDay == 1).FirstOrDefault()?.ShiftDuration,
                       ShiftDuration2 = g.Where(d => d.WeekDay == 2).FirstOrDefault()?.ShiftDuration,
                       ShiftDuration3 = g.Where(d => d.WeekDay == 3).FirstOrDefault()?.ShiftDuration,
                       ShiftDuration4 = g.Where(d => d.WeekDay == 4).FirstOrDefault()?.ShiftDuration,
                       ShiftDuration5 = g.Where(d => d.WeekDay == 5).FirstOrDefault()?.ShiftDuration,
                       ShiftDuration6 = g.Where(d => d.WeekDay == 6).FirstOrDefault()?.ShiftDuration,
                       ShiftDuration7 = g.Where(d => d.WeekDay == 7).FirstOrDefault()?.ShiftDuration,                      
                       Loaded = true
                   })
                .AsQueryable();

            return weeklyWorkShifts;

            //// привязка к WeeklyWorkShifts соответствующих WorkShift ()
            //Core.IRepository<WorkShift> repo = DataHelper.GetRepository<WorkShift>();
            //foreach (WeeklyWorkShifts entity in q)
            //{
            //    for (int i = 1; i <= 7; i++)
            //    {
            //        WorkShift ws = GetWorkShift(repo, entity.MachineNom.Id, entity.WorkShiftType.Id, entity.Team?.Id, entity.WeekNum, entity.Year, i);

            //        if (ws != null)
            //        {
            //            entity.WorkShifts.Add(ws);
            //        }
            //    }
            //}

            //return q;      
        }

        public override void RefreshSet()
        {
            SocratEntities.ObjectContext.Refresh(RefreshMode.StoreWins, SocratEntities.Set<WorkShift>());
        }
    }
}
