using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace Socrat.OldDataConnector.Min.RESMIN
{

    public partial class FORMCATALOG
    {
        public FORMCATALOG(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
