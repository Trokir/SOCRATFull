using System;
using System.Data.Entity.Migrations;
using Socrat.Core.Entities;
using Socrat.Log;

namespace Socrat.DataProvider.Repos
{
    internal class DivisionRepository : UniversalRepository<Division>
    {
        public override bool Save(Division entity)
        {
            bool _res = false;
            try
            {
                DataHelper.Save(entity.Address);

                SocratEntities.Set<Division>().AddOrUpdate(entity);
                _res = SocratEntities.SafetySaveChanges();
                if (_res)
                    entity.Changed = false;

                DataHelper.SaveCollection(entity.DivisionCustomers);
                DataHelper.SaveCollection(entity.DivisionSignatures);
                DataHelper.SaveCollection(entity.DivisionContacts);
                DataHelper.SaveCollection(entity.CoworkerPositions);


                entity.Changed = false;
            }
            catch (Exception e)
            {
                Logger.AddErrorMsgEx($"{this}.Save", e);
            }
            return _res;
        }
    }
}