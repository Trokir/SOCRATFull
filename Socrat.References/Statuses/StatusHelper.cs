using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.DataProvider;

namespace Socrat.References.Statuses
{
    public static class StatusHelper
    {
        public static void OrderRowSetStatus(OrderRowItem orderRowItem, OrderStatusEnum orderStatusEnum)
        {
            OrderStatus _status = DataHelper.GetItem<OrderStatus>(x => x.Enumerator == orderStatusEnum);
            if (_status == null)
                throw new Exception($"Не найден статус по указаному энумератору {orderStatusEnum}. Проверьте заполнение справочника статусов");

            orderRowItem.SetStatusWithoutControl(_status);

            //SocratEntities.Instance.Database.ExecuteSqlCommand(
            //    $"update OrderRowItem set StatusId='{_status.Id}' where Id='{orderRowItem.Id}'");
            //DataHelper.RefreshData(orderRowItem);
        }

        public static void OrderRowItemSave(OrderRowItem orderRowItem, Guid statusId)
        {
            SocratEntities.Instance.Database.ExecuteSqlCommand(
                $"update OrderRowItem set StatusId='{statusId}' where Id='{orderRowItem.Id}'");
            DataHelper.RefreshData(orderRowItem);
        }

        public static void OrderRowItemSaveDateDone(OrderRowItem orderRowItem, Guid statusId, DateTime doneDate)
        {
            SqlParameter _param = new SqlParameter { ParameterName = "@ddt", DbType = DbType.DateTime, Value = doneDate };
            SocratEntities.Instance.Database
                .ExecuteSqlCommand(
                    $"update OrderRowItem set StatusId='{statusId}', DateDone=@ddt where Id='{orderRowItem.Id}'"
                    , new[] { _param });
            DataHelper.RefreshData(orderRowItem);
        }

        public static void OrderRowItemResetDateDone(OrderRowItem orderRowItem)
        {
            SocratEntities.Instance.Database
                .ExecuteSqlCommand($"update OrderRowItem set  DateDone = null where Id='{orderRowItem.Id}'");
            DataHelper.RefreshData(orderRowItem);
        }

        public static void OrderRowItemSaveCutters(OrderRowItem orderRowItem, Guid teamId)
        {
            SocratEntities.Instance.Database.ExecuteSqlCommand(
                $"update OrderRowItem set CuttersTeamId='{teamId}' where Id='{orderRowItem.Id}'");
            DataHelper.RefreshData(orderRowItem);
        }

        public static void OrderRowItemSaveAsseblers(OrderRowItem orderRowItem, Guid teamId)
        {
            SocratEntities.Instance.Database.ExecuteSqlCommand(
                $"update OrderRowItem set AssembliesTeamId='{teamId}' where Id='{orderRowItem.Id}'");
            DataHelper.RefreshData(orderRowItem);
        }

        public static void OrderRowItemSaveMachineNom(OrderRowItem orderRowItem, Guid machineNomId)
        {
            SocratEntities.Instance.Database.ExecuteSqlCommand(
                $"update OrderRowItem set MachineNomId='{machineNomId}' where Id='{orderRowItem.Id}'");
            DataHelper.RefreshData(orderRowItem);
        }

        public static void OrderRowItemResetCuttersTeam(OrderRowItem orderRowItem)
        {
            SocratEntities.Instance.Database.ExecuteSqlCommand(
                $"update OrderRowItem set CuttersTeamId= null where Id='{orderRowItem.Id}'");
            DataHelper.RefreshData(orderRowItem);
        }

        public static void OrderRowItemResetAssabliesTeam(OrderRowItem orderRowItem)
        {
            SocratEntities.Instance.Database.ExecuteSqlCommand(
                $"update OrderRowItem set AssembliesTeamId=null where Id='{orderRowItem.Id}'");
            DataHelper.RefreshData(orderRowItem);
        }
    }
}
