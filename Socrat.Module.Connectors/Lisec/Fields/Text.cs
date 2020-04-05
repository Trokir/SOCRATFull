using Socrat.Module.Connectors.Attributes;
using Socrat.Module.Connectors.Base;

namespace Socrat.Module.Connectors.Lisec.Fields
{
    /// <summary>
    /// Additional text information
    /// Item information 2 -5 are used for frame text printing. 
    /// Additional text information will not be shown on any screens by default (only on
    /// customer request). They are mainly used for printouts on certain lists and labels.
    /// </summary>
    //[FieldInfo("<TXT>")]
    public class Text : Field
    {
        public override int Lenght => 417;
        /// <summary>
        /// Additional item information 1
        /// </summary>
        [FieldInfo("TEXT1", typeof(string), 40, 1)]
        public string Line1 { get; set; }

        // <summary>
        /// Additional item information 2
        /// Used for frame text printing
        /// </summary>
        [FieldInfo("TEXT2", typeof(string), 40, 2)]
        public string Line2 { get; set; }

        // <summary>
        /// Additional item information 3
        /// Used for frame text printing
        /// </summary>
        [FieldInfo("TEXT3", typeof(string), 40, 3)]
        public string Line3 { get; set; }

        // <summary>
        /// Additional item information 4
        /// Used for frame text printing
        /// </summary>
        [FieldInfo("TEXT4", typeof(string), 40, 4)]
        public string Line4 { get; set; }

        // <summary>
        /// Additional item information 5
        /// Used for frame text printing
        /// </summary>
        [FieldInfo("TEXT5", typeof(string), 40, 5)]
        public string Line5 { get; set; }

        // <summary>
        /// Additional item information 6
        /// </summary>
        [FieldInfo("TEXT6", typeof(string), 40, 6)]
        public string Line6 { get; set; }

        // <summary>
        /// Additional item information 7
        /// </summary>
        [FieldInfo("TEXT7", typeof(string), 40, 7)]
        public string Line7 { get; set; }

        // <summary>
        /// Additional item information 8
        /// </summary>
        [FieldInfo("TEXT8", typeof(string), 40, 8)]
        public string Line8 { get; set; }

        // <summary>
        /// Additional item information 9
        /// </summary>
        [FieldInfo("TEXT9", typeof(string), 40, 9)]
        public string Line9 { get; set; }

        // <summary>
        /// Additional item information 10
        /// </summary>
        [FieldInfo("TEXT10", typeof(string), 40, 10)]
        public string Line10 { get; set; }

        public override string Export(string text = "")
        {
            text = $"<TXT> " +
                 $"{ApplyFormat(Line1, 40)} " +
                 $"{ApplyFormat(Line2, 40)} " +
                 $"{ApplyFormat(Line3, 40)} " +
                 $"{ApplyFormat(Line4, 40)} " +
                 $"{ApplyFormat(Line5, 40)} " +
                 $"{ApplyFormat(Line6, 40)} " +
                 $"{ApplyFormat(Line7, 40)} " +
                 $"{ApplyFormat(Line8, 40)} " +
                 $"{ApplyFormat(Line9, 40)} " +
                 $"{ApplyFormat(Line10, 40)}\r\n";

            return base.Export(text);
        }

        public static ItemText Empty
        {
            get => new ItemText();
        }
    }
}
