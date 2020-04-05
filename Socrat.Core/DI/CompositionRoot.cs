using System.Collections.Generic;
using Ninject;
using Ninject.Modules;

namespace Socrat.Core.DI
{
    /// <summary>
    /// Начало имплементации DI в блоке прайсов от СЮ. Дальше дефиниции IPriceService в формах дело не пошло
    /// </summary>
    public class CompositionRoot
    {
        private static IKernel _ninjectKernel;

        public static void Initialize(INinjectModule module)
        {
            _ninjectKernel = new StandardKernel(module);
        }

        public static T Resolve<T>()
        {
            return _ninjectKernel.Get<T>();
        }

        public static IEnumerable<T> ResolveAll<T>()
        {
            return _ninjectKernel.GetAll<T>();
        }
    }
}
