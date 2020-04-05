using Socrat.Core.Entities;
namespace Socrat.DataProvider.Repos
{
    internal class AccountRepository : UniversalRepository<Account>
//BaseRepository<Socrat.Model.Account>
    {
        //public override void Save(Model.Account entity)
        //{
        //    Mapper.Initialize(MapperConfig.CfgDesc);
        //    Account _account = null;
        //    if (entity.Id > 0)
        //    {
        //        _account = _socratEntities.Accounts.FirstOrDefault(x => x.Id == entity.Id);
        //        Mapper.Map<Model.Account, Account>(entity, _account);
        //    }
        //    else
        //    {
        //        _account = Mapper.Map<Model.Account, Account>(entity);
        //        _socratEntities.Accounts.Add(_account);
        //    }

        //    _account.Customer = _socratEntities.Customers.FirstOrDefault(x => x.Id == entity.Customer_Id);
        //    _account.Customer_Id = entity.Customer_Id;
        //    _socratEntities.SafetySaveChanges();
        //    entity.Id = _account.Id;
        //    entity.Changed = false;
        //}

        //public override Model.Account Revert(Model.Account entity)
        //{
        //    Model.Account _account = entity;
        //    if (entity.Id > 0)
        //    {
        //        Account _accountDto = _socratEntities.Accounts.FirstOrDefault(x => x.Id == entity.Id);
        //        if (_accountDto != null)
        //        {
        //            _socratEntities.DiscardEntityChanges(_accountDto);
        //            _accountDto = _socratEntities.Accounts.FirstOrDefault(x => x.Id == entity.Id);
        //            Mapper.Initialize(MapperConfig.Cfg);
        //            _account = Mapper.Map<Account, Model.Account>(_accountDto);
        //        }
        //    }
        //    entity.Changed = false;
        //    return _account;
        //}

        //public override void Delete(long id)
        //{
        //    _socratEntities.Database.ExecuteSqlCommand(string.Format("delete from dbo.Account where Id ={0}", id));
        //}

        //public override Model.Account GetItem(long id)
        //{
        //    Mapper.Initialize(MapperConfig.Cfg);
        //    Model.Account _account =
        //        Mapper.Map<Account, Model.Account>(_socratEntities.Accounts.FirstOrDefault(x => x.Id == id));
        //    _account.Changed = false;
        //    return _account;
        //}

        //public override IEnumerable<Model.Account> GetAll()
        //{
        //    Mapper.Initialize(MapperConfig.Cfg);
        //    List<Model.Account> _accounts = Mapper.Map<DbSet<Account>, List<Model.Account>>(_socratEntities.Accounts);
        //    _accounts.ForEach(x => x.Changed = false);
        //    return _accounts;
        //}
    }
}