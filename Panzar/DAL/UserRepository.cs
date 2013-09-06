namespace Panzar.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading;

    using Panzar.Models;

    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> Find(Expression<Func<User, bool>> where)
        {
            Thread.Sleep(5000);
            return new[]
                       {
                          new User { Name = Guid.NewGuid().ToString() }, new User { Name = Guid.NewGuid().ToString() } 
                       };
        }
    }
}