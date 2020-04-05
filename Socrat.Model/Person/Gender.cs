using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socrat.Model
{
    public class Gender: Entity
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetField(ref _Name, value, () => Name); }
        } 
    }
}
