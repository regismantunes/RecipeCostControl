using RecipeCostControl.Data.Entities;
using System.Reflection;

namespace RecipeCostControl.Data.Extensions
{
    public static class IIdentityEntityExtensions
    {
        public static void CopyFrom<T>(this T entity, T source) where T : class, IIdentityEntity
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(entity);

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties.Where(p => p.CanWrite && p.Name != nameof(IIdentityEntity.Id)))
            {
                var value = property.GetValue(source);
                property.SetValue(entity, value);
            }
        }
    }
}