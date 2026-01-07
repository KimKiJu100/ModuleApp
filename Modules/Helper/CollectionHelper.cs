using Modules.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Helper
{
    static class CollectionHelper
    {
        public static List<T> LoadStrategies<T>()
        {
            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(T).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .Select(t => (T)Activator.CreateInstance(t))
                .ToList();
        }

        public static List<T> LoadCollectionAuttribute<T>()
        {
            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(T).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .Select(t => (T)Activator.CreateInstance(t))
                .OrderBy(t =>
                {
                    var attr = t.GetType().GetCustomAttribute<OrderByAttribute>();
                    return attr?.Order ?? int.MaxValue; 
                })
                .ToList();
        }

        public static List<T> LoadCollectionBaseClass<T>()
        {
            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(T).IsAssignableFrom(t) && !t.IsAbstract && t.IsClass)
                .Select(t => (T)Activator.CreateInstance(t))
                .OrderBy(t =>
                {
                    var attr = t.GetType().GetCustomAttribute<OrderByAttribute>();
                    return attr?.Order ?? int.MaxValue;
                })
                .ToList();
        }
    }
}
