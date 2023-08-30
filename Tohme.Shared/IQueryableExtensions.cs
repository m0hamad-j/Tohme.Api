using Tohme.Shared.Abstraction;
using Microsoft.EntityFrameworkCore;
namespace Tohme.Shared
{
    public static  class IQueryableExtensions
    {
        public static IQueryable<TEntity> MultiInclude<TEntity>(this IQueryable<TEntity> source, string[]? includes)
            where TEntity : BaseEntity
        {
            if (includes is not null && !includes.Any())
                return source.IgnoreAutoIncludes();

            var props = typeof(TEntity).GetProperties();
            includes ??= props.Where(t => !t.PropertyType.IsAbstract
                                          && (t.PropertyType.IsSubclassOf(typeof(BaseEntity))
                                              || (t.PropertyType.IsGenericType
                                                  && t.PropertyType.GenericTypeArguments.First().IsSubclassOf(typeof(BaseEntity)))))
                               .Select(p => p.Name).ToArray();

            foreach (var include in includes)
                if (props.Any(p => p.Name == include))
                    source = source.Include(include);

            return source;
        }
    }
}
