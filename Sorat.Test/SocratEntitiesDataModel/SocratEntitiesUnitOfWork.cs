using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.DataModel.EF6;
using Socrat.DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorat.Test.SocratEntitiesDataModel {

    /// <summary>
    /// A SocratEntitiesUnitOfWork instance that represents the run-time implementation of the ISocratEntitiesUnitOfWork interface.
    /// </summary>
    public class SocratEntitiesUnitOfWork : DbUnitOfWork<SocratEntities>, ISocratEntitiesUnitOfWork {

        public SocratEntitiesUnitOfWork(Func<SocratEntities> contextFactory)
            : base(contextFactory) {
        }

        IRepository<Account, long> ISocratEntitiesUnitOfWork.Accounts {
            get { return GetRepository(x => x.Set<Account>(), (Account x) => x.Id); }
        }

        IRepository<Bank, long> ISocratEntitiesUnitOfWork.Banks {
            get { return GetRepository(x => x.Set<Bank>(), (Bank x) => x.Id); }
        }

        IRepository<Country, long> ISocratEntitiesUnitOfWork.Countries {
            get { return GetRepository(x => x.Set<Country>(), (Country x) => x.Id); }
        }

        IRepository<Currency, long> ISocratEntitiesUnitOfWork.Currencies {
            get { return GetRepository(x => x.Set<Currency>(), (Currency x) => x.Id); }
        }

        IRepository<Customer, long> ISocratEntitiesUnitOfWork.Customers {
            get { return GetRepository(x => x.Set<Customer>(), (Customer x) => x.Id); }
        }

        IRepository<CustomerPropType, long> ISocratEntitiesUnitOfWork.CustomerPropTypes {
            get { return GetRepository(x => x.Set<CustomerPropType>(), (CustomerPropType x) => x.Id); }
        }

        IRepository<CustomerType, long> ISocratEntitiesUnitOfWork.CustomerTypes {
            get { return GetRepository(x => x.Set<CustomerType>(), (CustomerType x) => x.Id); }
        }

        IRepository<OPF, long> ISocratEntitiesUnitOfWork.OPFs {
            get { return GetRepository(x => x.Set<OPF>(), (OPF x) => x.Id); }
        }

        IReadOnlyRepository<CustomerProp> ISocratEntitiesUnitOfWork.CustomerProps {
            get { return GetReadOnlyRepository(x => x.Set<CustomerProp>()); }
        }
    }
}
