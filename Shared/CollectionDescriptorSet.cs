using System;
using System.Linq.Expressions;

namespace Shared
{
    public class CollectionDescriptorSet<TEntity>
        where TEntity : EntityBase
    {
        // projection
        public Expression<Func<TEntity, object>> Projection { get; set; } = x => x.Id;

        // predicate/filter
        public Expression<Func<TEntity, bool>> Predicate { get; set; } = x => true;

        // orderby
        public Expression<Func<TEntity, object>> OrderBy { get; set; } = x => x.Id;

        // paging
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 1;
    }
}
