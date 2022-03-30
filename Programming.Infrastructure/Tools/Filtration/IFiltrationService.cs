using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Programming.Core.Common;
using Programming.Core.Domain.Abstractions;

namespace Programming.Infrastructure.Tools.Filtration
{
    public interface IFiltrationService<TEntity>
        where TEntity : Entity
    {
        IQueryable<TEntity> ProcessFilter(IQueryable<TEntity> data, FilterCollection<TEntity> filterCollection);
    }
}
