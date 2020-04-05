using System;
using System.Linq;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Repos
{
    internal class BankRepository : UniversalRepository<Bank>
    {
        public override bool Save(Bank entity)
        {
            if (entity.Address != null)
                DataHelper.Save(entity.Address);

            return base.Save(entity);
        }

        public override void Delete(Guid id)
        {
            Core.Entities.Bank _bank = SocratEntities.Banks.FirstOrDefault(x => x.Id == id);
            if (_bank != null)
            {
                SocratEntities.Database.ExecuteSqlCommand(string.Format("delete from dbo.Bank where id ={0}", id));
                SocratEntities.SafetySaveChanges();
            }
        }
    }
}