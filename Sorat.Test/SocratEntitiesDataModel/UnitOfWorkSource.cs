using DevExpress.Mvvm;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.DataModel.DesignTime;
using DevExpress.Mvvm.DataModel.EF6;
using Socrat.DataProvider;
using System;
using System.Collections;
using System.Linq;

namespace Sorat.Test.SocratEntitiesDataModel {

    /// <summary>
    /// Provides methods to obtain the relevant IUnitOfWorkFactory.
    /// </summary>
    public static class UnitOfWorkSource {

		/// <summary>
        /// Returns the IUnitOfWorkFactory implementation.
        /// </summary>
        public static IUnitOfWorkFactory<ISocratEntitiesUnitOfWork> GetUnitOfWorkFactory() {
            return new DbUnitOfWorkFactory<ISocratEntitiesUnitOfWork>(() => new SocratEntitiesUnitOfWork(() => new SocratEntities()));
        }
    }
}