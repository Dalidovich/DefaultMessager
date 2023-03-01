namespace DefaultMessager.Domain.SpecificationPattern.Base
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
    }
}
