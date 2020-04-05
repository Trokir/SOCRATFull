using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;
using Sorat.Test.SocratEntitiesDataModel;

namespace Sorat.Test.ViewModels {
    /// <summary>
    /// Represents the root POCO view model for the SocratEntities data model.
    /// </summary>
    public partial class SocratEntitiesViewModel : DocumentsViewModel<SocratEntitiesModuleDescription, ISocratEntitiesUnitOfWork> {

		const string TablesGroup = "Tables";

		const string ViewsGroup = "Views";
	
        /// <summary>
        /// Creates a new instance of SocratEntitiesViewModel as a POCO view model.
        /// </summary>
        public static SocratEntitiesViewModel Create() {
            return ViewModelSource.Create(() => new SocratEntitiesViewModel());
        }

		
        /// <summary>
        /// Initializes a new instance of the SocratEntitiesViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the SocratEntitiesViewModel type without the POCO proxy factory.
        /// </summary>
        protected SocratEntitiesViewModel()
		    : base(UnitOfWorkSource.GetUnitOfWorkFactory()) {
        }

        protected override SocratEntitiesModuleDescription[] CreateModules() {
			return new SocratEntitiesModuleDescription[] {
                new SocratEntitiesModuleDescription( "Accounts", "AccountCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Accounts)),
                new SocratEntitiesModuleDescription( "Banks", "BankCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Banks)),
                new SocratEntitiesModuleDescription( "Countries", "CountryCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Countries)),
                new SocratEntitiesModuleDescription( "Currencies", "CurrencyCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Currencies)),
                new SocratEntitiesModuleDescription( "Customers", "CustomerCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Customers)),
                new SocratEntitiesModuleDescription( "Customer Prop Types", "CustomerPropTypeCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.CustomerPropTypes)),
                new SocratEntitiesModuleDescription( "Customer Types", "CustomerTypeCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.CustomerTypes)),
                new SocratEntitiesModuleDescription( "OPFs", "OPFCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.OPFs)),
                new SocratEntitiesModuleDescription("Customer Props", "CustomerPropCollectionView", ViewsGroup),
			};
        }
                	}

    public partial class SocratEntitiesModuleDescription : ModuleDescription<SocratEntitiesModuleDescription> {
        public SocratEntitiesModuleDescription(string title, string documentType, string group, Func<SocratEntitiesModuleDescription, object> peekCollectionViewModelFactory = null)
            : base(title, documentType, group, peekCollectionViewModelFactory) {
        }
    }
}