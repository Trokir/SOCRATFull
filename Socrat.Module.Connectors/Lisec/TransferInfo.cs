using Socrat.Module.Connectors.Attributes;
using Socrat.Module.Connectors.Lisec.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Socrat.Module.Connectors.Lisec
{
    /// <summary>
    /// The transfer file information is split into several types of records
    /// (ORD, POS, SHP, TXT, ...). Each transfer file has to consist of at least
    /// one order record<ORD> and one item<POS> record. All other records may be combined as necessary.
    /// </summary>
    public class TransferInfo : Base.Field, ITransferInfo<Fields.Position>
    {

        #region Lisec data fields

        public override int Lenght => 0;

        /// <summary>
        /// Transfer file version record
        /// </summary>
        [FieldInfo(1, typeof(Fields.Release), "<REL>")]
        public Fields.Release Release { get; set; }

        /// <summary>
        /// Batch information record 
        /// </summary>
        [FieldInfo(2, typeof(Fields.Batch), "<BTH>")]
        public Fields.Batch Batch { get; set; }

        /// <summary>
        /// Order records 
        /// </summary>
        [FieldInfo(3, typeof(Fields.Order), "<ORD>")]
        public List<Fields.Order> Orders { get; } = new List<Fields.Order>();

        #endregion

        public string FileName { get; private set; }

        public TransferInfo(int number, DateTime date, string exchangeDirectoryPath, List<Fields.Position> items)
        {
            if (number < 1)
                throw new BadOrderNumberException($"{number}");

            if (!Directory.Exists(exchangeDirectoryPath))
                throw new WrongExportTargetPath(exchangeDirectoryPath);

            FileName = $"{exchangeDirectoryPath}\\" +
                $"{date.Year}" +
                $"{date.Month.ToString().PadLeft(2, '0')}" +
                $"{date.Day.ToString().PadLeft(2, '0')}-" +
                $"{number.ToString().PadLeft(3, '0')}.trf";
            Release = new Fields.Release();
            Batch = new Fields.Batch();

            Fields.Order order = new Fields.Order(
                number, 
                $"{date.Year-2000}{date.Month.ToString().PadLeft(2, '0')}{date.Day.ToString().PadLeft(2, '0')}-{number.ToString().PadLeft(3,'0')}");
            order.GpsOptItems.AddRange(items);
            Orders.Add(order);
        }

        public Fields.Order DefaultOrder { get => Orders.FirstOrDefault(); }

        public override string Export(string text = "")
        {
            string res =
                $"{Release.Export()}";
            
            Orders?.ForEach(order =>
                res += order.Export());

            return res;
        }

        public IExportProvider<Fields.Position> GetExportProvider()
        {
            return new ExportProvider();
        }

        public List<Fields.Position> GetItems()
        {
            return DefaultOrder.GpsOptItems;
        }
    }
}
