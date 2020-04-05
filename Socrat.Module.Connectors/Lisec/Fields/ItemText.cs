using Socrat.Module.Connectors.Attributes;
using Socrat.Module.Connectors.Base;

namespace Socrat.Module.Connectors.Lisec.Fields
{
    /// <summary>
    /// Additional item text record
    /// </summary>
    //[FieldInfo("<TXE>")]
    public class ItemText : Field
    {
        public override int Lenght => 80;
        /// <summary>
        /// Counter
        /// </summary>
        [FieldInfo("COUNTER", typeof(int), 3, 1)]
        public int Counter { get; set; }

        /// <summary>
        /// Text number
        /// </summary>
        [FieldInfo("TEXT_NO", typeof(int), 3, 2)]
        public int Number { get; set; }

        /// <summary>
        /// Text purpose
        /// </summary>
        [FieldInfo("TEXT_PURP", typeof(int), 3, 3)]
        public int Purpose { get; set; }

        /// <summary>
        /// Text purpose
        /// </summary>
        [FieldInfo("Text", typeof(string), 60, 4)]
        public int Text { get; set; }

        public override string Export(string text = "")
        {
            text = $"<TXE> " +
                $"{ApplyFormat(Counter, 3)} " +
                $"{ApplyFormat(Number, 3)} " +
                $"{ApplyFormat(Purpose, 3)} " +
                $"{ApplyFormat(Text, 60)}\r\n";

            return base.Export(text);
        }
    }
}
