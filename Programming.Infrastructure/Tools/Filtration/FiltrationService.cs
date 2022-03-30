using Programming.Core.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Programming.Core.Common;

namespace Programming.Infrastructure.Tools.Filtration
{
    public class FiltrationService<TEntity> : IFiltrationService<TEntity>
        where TEntity : Entity
    {
        public IQueryable<TEntity> ProcessFilter(IQueryable<TEntity> data, FilterCollection<TEntity> filterCollection)
        {
            if (!filterCollection.Any())
            {
                return data;
            }

            foreach (var filterExpression in filterCollection)
            {
                data = data.Where(filterExpression);
            }

            return data;
        }
    }
}
