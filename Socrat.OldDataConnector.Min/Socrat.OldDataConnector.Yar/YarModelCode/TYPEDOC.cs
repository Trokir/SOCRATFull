using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace Socrat.OldDataConnector.Yar.RESYAR
{

    public partial class TYPEDOC
    {
        public TYPEDOC(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
