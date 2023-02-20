﻿using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.RelationSpecification
{
    public class RelationByFromAccountId<T> : Specification<Relations>
    {
        private readonly Guid _id;
        public RelationByFromAccountId(Guid id)
        {
            _id = id;
            expression = x => x.AccountId1 == _id;
        }
        public override Expression<Func<Relations, bool>> ToExpression()
        {
            return expression;
        }
    }
}
