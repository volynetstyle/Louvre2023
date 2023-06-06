using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.Services.Utilites
{
    public static class ModelReflectionHelper
    {
        private static readonly ConcurrentDictionary<Type, PropertyInfo[]> KeyPropertiesCache = new();
        private static readonly ConcurrentDictionary<(Type, string), PropertyInfo[]> ForeignKeyPropertiesCache = new();

        public static bool IsKeyExist(Type type)
        {
            return KeyPropertiesCache.ContainsKey(type);
        }

        public static bool IsForeignKeyKeyExist(Type type, string foreignKeyName)
        {
            return ForeignKeyPropertiesCache.ContainsKey((type, foreignKeyName));
        }

        public static PropertyInfo[] GetKeyProperties<T>()
        {
            Type modelType = typeof(T);
            if (KeyPropertiesCache.TryGetValue(modelType, out PropertyInfo[]? keyProperties))
            {
                return keyProperties;
            }

            keyProperties = modelType.GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Length > 0)
                .ToArray();

            KeyPropertiesCache.TryAdd(modelType, keyProperties);
            return keyProperties;
        }

        public static PropertyInfo[] GetForeignKeyProperties<T>(string foreignKeyName)
        {
            Type modelType = typeof(T);
            var cacheKey = (modelType, foreignKeyName);

            if (ForeignKeyPropertiesCache.TryGetValue(cacheKey, out PropertyInfo[]? foreignKeyProperties))
            {
                return foreignKeyProperties;
            }

            foreignKeyProperties = modelType.GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(ForeignKeyAttribute), true)
                    .Any(attr => ((ForeignKeyAttribute)attr).Name == foreignKeyName))
                .ToArray();

            ForeignKeyPropertiesCache.TryAdd(cacheKey, foreignKeyProperties);
            return foreignKeyProperties;
        }
    }
}
