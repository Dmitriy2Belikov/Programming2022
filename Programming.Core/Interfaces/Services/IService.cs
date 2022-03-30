using Programming.Core.Common;
using Programming.Core.DataTransfer.Abstractions;
using Programming.Core.Domain.Abstractions;
using Programming.Core.Interfaces.Specifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Programming.Core.Domain.Project;

namespace Programming.Core.Interfaces.Services
{
    public interface IService<TEntity, in TCreateDto, in TUpdateDto, TFullDto, TShortDto, in TSortFields>
        where TEntity : Entity
        where TCreateDto : ICreateDto
        where TUpdateDto : IUpdateDto
        where TFullDto : IFullDto
        where TShortDto : IShortDto
        where TSortFields : Enum
    {
        Task Create(TCreateDto data);
        Task Update(long id, TUpdateDto data);
        Task Remove(long id);
        Task<TFullDto> Find(long id);
        Task<List<TShortDto>> Query(
            FilterCollection<TEntity> filterCollection,
            SortDirection sortDirection,
            TSortFields sortField,
            int skip = 0,
            int take = 20);
    }
}
