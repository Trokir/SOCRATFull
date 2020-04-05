using System.Collections.Generic;
using Socrat.Model;

namespace Socrat.DataProvider
{
    public class ContactRepository : BaseRepository<Socrat.Model.Contact>
    {
        public override void Save(Contact entity)
        {
            throw new System.NotImplementedException();
        }

        public override Contact Revert(Contact entity)
        {
            throw new System.NotImplementedException();
        }

        public override void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public override Contact GetItem(long id)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Contact> GetAll()
        {
            return new List<Contact>();
        }
    }
}