using DevExpress.Data.Async;
using Socrat.Core.Entities;

namespace Socrat.Core.Added
{
    public class FrameItemTag
    {
        public int Key
        {
            get { return GetKey(); }
        }
        private int GetKey()
        {
            return Level * 100 + Num;
        }

        public int Level { get; set; }
        public int Num { get; set; }
        public string ItemStr { get; set; }

        public override bool Equals(object obj)
        {
            FrameItemTag _tag = obj as FrameItemTag;
            return _tag != null 
                   && _tag.Level == Level 
                   && _tag.Num == Num 
                   && _tag.ItemStr == ItemStr;
        }
    }
}