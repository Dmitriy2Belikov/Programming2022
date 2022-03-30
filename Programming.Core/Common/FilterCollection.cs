using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Programming.Core.Domain.Abstractions;

namespace Programming.Core.Common
{
    public class FilterCollection<TEntity> : IEnumerable<Expression<Func<TEntity, bool>>>
        where TEntity : Entity
    {
        private List<Expression<Func<TEntity, bool>>> _filters = new List<Expression<Func<TEntity, bool>>>();

        public FilterCollection<TEntity> Add(Expression<Func<TEntity, bool>> filterExpression, object value)
        {
            if (value == null)
            {
                return this;
            }

            _filters.Add(filterExpression);
            return this;
        }

        public bool Any()
        {
            return _filters.Any();
        }

        public IEnumerator<Expression<Func<TEntity, bool>>> GetEnumerator()
        {
            return _filters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
