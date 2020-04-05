using Socrat.Core.Added;
using Socrat.Core.Entities.Machines;

namespace Socrat.Core.Helpers
{
    public static class OrderStatusIcon
    {
        public static string GetName(OrderStatusEnum statusEnum)
        {
            switch (statusEnum)
            {
                case OrderStatusEnum.Plan:
                    return "GreenRomb";
                case OrderStatusEnum.Template:
                case OrderStatusEnum.Input:
                    return "EmptyRomb";
                case OrderStatusEnum.Ready:
                    return "RedRomb";
                case OrderStatusEnum.Assemble:
                    return "BlueRomb";
                case OrderStatusEnum.Сutting:
                    return "YellowRomb";
                case OrderStatusEnum.Unload:
                    return "GreyRomb";
            }
            return "EmptyRomb";
        }
    }

    public static class QueueLineIcon
    {
        public static string GetName(MachineNom machineNom)
        {
            if (machineNom != null)
            switch (machineNom.AliasName)
            {
                case "Линия 1":
                    return "1LineQueue";
                case "Линия 2":
                    return "2LineQueue";
                case "Линия 3":
                    return "3LineQueue";
                case "Линия 4":
                    return "4LineQueue";
                }
            return "EmptyQueue";
        }
    }
}