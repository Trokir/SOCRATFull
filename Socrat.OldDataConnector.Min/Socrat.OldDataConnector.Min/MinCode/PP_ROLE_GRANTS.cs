using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace Socrat.OldDataConnector.Min.RESMIN
{

    public partial class PP_ROLE_GRANTS
    {
        public PP_ROLE_GRANTS(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
