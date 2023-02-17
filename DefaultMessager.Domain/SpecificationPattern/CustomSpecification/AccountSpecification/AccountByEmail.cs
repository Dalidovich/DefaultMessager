﻿using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.AccountSpecification
{
    public class AccountByEmail<T> : Specification<Account>
    {
        private readonly string _email;
        public AccountByEmail(string email)
        {
            _email = email;
            expression = x => x.Email == _email;
        }
        public override Expression<Func<Account, bool>> ToExpression()
        {
            return expression;
        }
    }
}
