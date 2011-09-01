using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace System.Linq {
    public static class QueryableExtensions {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class {
            if (includes != null) {
                query = includes.Aggregate(query,
                 (current, include) => current.Include(include));
            }
            return query;
        }
    }
}
