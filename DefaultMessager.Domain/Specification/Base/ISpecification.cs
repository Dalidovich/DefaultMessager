namespace DefaultMessager.Domain.Specification.Base
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
    }
}
