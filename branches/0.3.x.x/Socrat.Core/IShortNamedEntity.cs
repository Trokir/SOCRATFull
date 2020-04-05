namespace Socrat.Core
{
    public interface IShortNamedEntity : INamedEntity
    {
        string ShortName { get; set; }
    }
}