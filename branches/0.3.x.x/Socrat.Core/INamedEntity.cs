namespace Socrat.Core
{
    public interface INamedEntity : IEntity
    {
        string Name { get; set; }
    }
}