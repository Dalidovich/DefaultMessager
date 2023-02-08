using DefaultMessager.Domain.SpecificationPattern.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Domain.SpecificationPattern.CompositeSpecification
{
    public class AndSpecification<T>:Specification<T>
    {
        private readonly Specification<T> _spec0;
        private readonly Specification<T> _spec1;

        public AndSpecification(Specification<T> spec0, Specification<T> spec1)
        {
            _spec0 = spec0;
            _spec1 = spec1;


            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.AndAlso(_spec0.ToExpression().Body, _spec1.ToExpression().Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            expression = finalExpr;

            //expression = Expression.Lambda<Func<T, bool>>
            //    (Expression.And(_spec0.ToExpression().Body,
            //    Expression.Invoke(_spec1.ToExpression(), _spec0.ToExpression().Parameters)), _spec0.ToExpression().Parameters);
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            return expression;
        }
    }

}
