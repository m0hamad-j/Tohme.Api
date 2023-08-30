using Microsoft.EntityFrameworkCore;

using Tohme.Shared.Abstraction;
namespace Tohme.Shared
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TEntity> MultiInclude<TEntity>(this IQueryable<TEntity> source, string[]? includes)
            where TEntity : BaseEntity
        {

            if (includes is not null)
            {
                var props = typeof(TEntity).GetProperties();
                includes ??= props.Where(t => !t.PropertyType.IsAbstract
                                              && (t.PropertyType.IsSubclassOf(typeof(BaseEntity))
                                                  || (t.PropertyType.IsGenericType
                                                      && t.PropertyType.GenericTypeArguments.First().IsSubclassOf(typeof(BaseEntity)))))
                                   .Select(p => p.Name).ToArray();
                foreach (var include in includes)
                {
                    source = source.Include(include);
                }
            }
            return source;
            //var props = typeof(TEntity).GetProperties();
            //includes ??= props.Where(t => !t.PropertyType.IsAbstract
            //                              && (t.PropertyType.IsSubclassOf(typeof(BaseEntity))
            //                                  || (t.PropertyType.IsGenericType
            //                                      && t.PropertyType.GenericTypeArguments.First().IsSubclassOf(typeof(BaseEntity)))))
            //                   .Select(p => p.Name).ToArray();

            //foreach (var include in includes)
            //    if (props.Any(p => p.Name == include))
            //        source = source.Include(include);

            //return source;
        }
    }
}
