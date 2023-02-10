﻿using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.RelationSpecification
{
    public class RelationById<T> : Specification<Relations>
    {
        private readonly Guid _id;
        public RelationById(Guid id)
        {
            _id = id;
            expression = x => x.Id == _id;
        }
        public override Expression<Func<Relations, bool>> ToExpression()
        {
            return expression;
        }
    }
}
