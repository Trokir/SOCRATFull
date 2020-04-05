using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace Socrat.OldDataConnector.Min.RESMIN
{

    public partial class PASP
    {
        public PASP(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
