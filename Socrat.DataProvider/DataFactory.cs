using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socrat.DataProvider
{
    /// <summary>
    /// Фабрика репозиториев
    /// </summary>
    public class DataFactory: IDisposable
    {
        public T CreateRepository<T>() where T : class
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
                throw new InvalidOperationException(String.Format("Не реализован репозиторий для {0}", abstractType));
            return Activator.CreateInstance(concreteType) as T;
        }

        public void Dispose()
        {
        }
    }
}
