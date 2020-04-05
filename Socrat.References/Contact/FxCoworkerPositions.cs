using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References
{
    public partial class FxCoworkerPositions : FxGenericListTable<CoworkerPosition>
    {
        public FxCoworkerPositions()
        {
            InitializeComponent();
        }

        protected override string GetTitle()
        {
            return "Личный состав предприятия";
        }
    }
}