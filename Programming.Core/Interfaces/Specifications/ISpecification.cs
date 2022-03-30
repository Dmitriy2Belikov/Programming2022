using Programming.Core.Domain.Abstractions;

namespace Programming.Core.Interfaces.Specifications
{
    public interface ISpecification<TEntity>
        where TEntity : Entity
    {
        bool IsSatisfiedBy(TEntity project);
        ISpecification<TEntity> And(ISpecification<TEntity> other);
        ISpecification<TEntity> Or(ISpecification<TEntity> other);
    }
}
