using DevExpress.Mvvm.DataModel;
using Socrat.DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorat.Test.SocratEntitiesDataModel {

    /// <summary>
    /// ISocratEntitiesUnitOfWork extends the IUnitOfWork interface with repositories representing specific entities.
    /// </summary>
    public interface ISocratEntitiesUnitOfWork : IUnitOfWork {
        
        /// <summary>
        /// The Account entities repository.
        /// </summary>
		IRepository<Account, long> Accounts { get; }
        
        /// <summary>
        /// The Bank entities repository.
        /// </summary>
		IRepository<Bank, long> Banks { get; }
        
        /// <summary>
        /// The Country entities repository.
        /// </summary>
		IRepository<Country, long> Countries { get; }
        
        /// <summary>
        /// The Currency entities repository.
        /// </summary>
		IRepository<Currency, long> Currencies { get; }
        
        /// <summary>
        /// The Customer entities repository.
        /// </summary>
		IRepository<Customer, long> Customers { get; }
        
        /// <summary>
        /// The CustomerPropType entities repository.
        /// </summary>
		IRepository<CustomerPropType, long> CustomerPropTypes { get; }
        
        /// <summary>
        /// The CustomerType entities repository.
        /// </summary>
		IRepository<CustomerType, long> CustomerTypes { get; }
        
        /// <summary>
        /// The OPF entities repository.
        /// </summary>
		IRepository<OPF, long> OPFs { get; }
        
        /// <summary>
        /// The CustomerProp entities repository.
        /// </summary>
		IReadOnlyRepository<CustomerProp> CustomerProps { get; }
    }
}
