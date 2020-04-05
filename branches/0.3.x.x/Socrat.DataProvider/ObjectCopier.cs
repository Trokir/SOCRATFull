using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Socrat.Core;

namespace Socrat.DataProvider
{
    //public static class ObjectCopier
    //{
    //    /// <summary>
    //    /// Клонирование с созданием нового экземпляра
    //    /// </summary>
    //    /// <typeparam name="T">тип объекта</typeparam>
    //    /// <param name="source">исходный объект</param>
    //    /// <returns></returns>
    //    public static T Clone<T>(T source)
    //        where T : class,  new()
    //    {
    //        T res = new T();
    //        Mapper.Map<T, T>(source, res);
    //        return res;
    //    }

    //    /// <summary>
    //    /// Клонирование в существующий экземпляр
    //    /// </summary>
    //    /// <typeparam name="T">тип объекта</typeparam>
    //    /// <param name="source">исходный объект</param>
    //    /// <param name="target">целевой объект</param>
    //    public static void Clone<T>(T source, T target)
    //        where T : class, new()
    //    {
    //        Mapper.Map<T, T>(source, target);
    //    }

    //    public static void CloneEscapeParent<T>(T source, T target)
    //        where T : class, IEntity, new()
    //    {
    //        Mapper.Map<T, T>(source, target);
    //    }
    //}
}
