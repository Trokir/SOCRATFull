using System;
using System.Linq;
using Socrat.Core;
using Socrat.Lib;

namespace Socrat.References
{
    public class SelectionDialgsFactory: IDisposable
    {
        public IEntitySelector CreateDialog<T>() where T : class, IEntitySelector, ITabable
        {
            //TODO: Implement some caching to avoid overhead of repeated reflection
            var abstractType = typeof(T);
            var types = AppDomain.CurrentDomain.GetAssemblies().ToList()
                .SelectMany(s => s.GetTypes())
                .Where(p => p.IsClass &&
                            !p.IsAbstract &&
                            abstractType.IsAssignableFrom(p));

            var concreteType = types.FirstOrDefault();
            if (concreteType == null)
                throw new InvalidOperationException(String.Format("Не риализован табличный контрол для {0}", abstractType));

            return Activator.CreateInstance(concreteType) as IEntitySelector;
        }

        public void Dispose()
        {
        }
        
    }
}
