using System.Linq;
using System.Linq.Dynamic.Core;

namespace RestAPI.Application.Helpers
{
    public static class LinqFilterBuilder
    {
        private static string CHARACTER_CONTAINS = "*";

        public static IQueryable<TEntity> ApplyFilter<TEntity>(this IQueryable<TEntity> source, string propertyName, string propertyValue)
        {
            if (propertyValue.StartsWith(CHARACTER_CONTAINS) && propertyValue.EndsWith(CHARACTER_CONTAINS))
            {
                var predicate = string.Format("{0}.ToLower().Contains(@0)", propertyName);
                source = source.Where(predicate, propertyValue[1..^1].ToLower());
            }
            else if (propertyValue.StartsWith(CHARACTER_CONTAINS))
            {
                var predicate = string.Format("{0}.ToLower().EndsWith(@0)", propertyName);
                source = source.Where(predicate, propertyValue[1..].ToLower());
            }
            else if (propertyValue.EndsWith(CHARACTER_CONTAINS))
            {
                var predicate = string.Format("{0}.ToLower().StartsWith(@0)", propertyName);
                source = source.Where(predicate, propertyValue[0..^1].ToLower());
            }
            else
            {
                var predicate = string.Format("{0}.ToLower().Equals(@0)", propertyName);
                source = source.Where(predicate, propertyValue.ToLower());
            }

            return source;
        }
    }
}
