using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.DescriptionAccountSpecification
{
    public class DescriptionAccountByAnyFullName<T> : Specification<DescriptionAccount>
    {
        private readonly string _personalInfo;
        public DescriptionAccountByAnyFullName(string personalInfo)
        {
            _personalInfo = personalInfo;
            expression = x => x.Name == _personalInfo || x.Surname == _personalInfo || x.Patronymic == _personalInfo;
        }
        public override Expression<Func<DescriptionAccount, bool>> ToExpression()
        {
            return expression;
        }
    }
}
