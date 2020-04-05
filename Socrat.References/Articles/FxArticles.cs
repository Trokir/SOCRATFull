using System;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Articles
{
    public class FxArticles : FxGenericListTable2<Article>
    {
        protected override Article GetNewInstance()
        {
            return new Article();
        }
    }
}
