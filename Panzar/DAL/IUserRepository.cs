namespace Panzar.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Panzar.Models;

    public interface IUserRepository
    {
        IEnumerable<User> Find(Expression<Func<User, bool>> where);
    }
}