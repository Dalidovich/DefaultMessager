﻿using DefaultMessager.Domain.Specification.Base;
using DefaultMessager.Domain.ViewModel.AccountModel;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.AccountSpecification
{
    public class AccountAuthByLogin<T> : Specification<AccountAuthenticateViewModel>
    {
        private readonly string _login;
        public AccountAuthByLogin(string login)
        {
            _login = login;
            expression = x => x.Login == _login;
        }
        public override Expression<Func<AccountAuthenticateViewModel, bool>> ToExpression()
        {
            return expression;
        }
    }
}
