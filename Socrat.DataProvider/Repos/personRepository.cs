using System.Collections.Generic;
using Socrat.Model;

namespace Socrat.DataProvider
{
    public class PersonRepository : BaseRepository<Socrat.Model.Person>
    {
        public override void Save(Person entity)
        {
            throw new System.NotImplementedException();
        }

        public override Person Revert(Person entity)
        {
            throw new System.NotImplementedException();
        }

        public override void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public override Person GetItem(long id)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Person> GetAll()
        {
            return new List<Person>();
        }
    }
}