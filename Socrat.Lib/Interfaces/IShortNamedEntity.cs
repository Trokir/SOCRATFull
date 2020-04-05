namespace Socrat.Lib
{
    public interface IShortNamedEntity : INamedEntity
    {
        string ShortName { get; set; }
    }
}