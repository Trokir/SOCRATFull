using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class ParseFileExtention : Entity
    {
        public ParseFileExtention()
        {
            Parsers = new HashSet<Parser>();
        }

        public string Name { get; set; }
        public string Comment { get; set; }
        public virtual ICollection<Parser> Parsers { get; set; }
    }
}