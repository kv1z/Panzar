namespace Panzar.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Panzar.Models;

    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> Find(Expression<Func<User, bool>> where)
        {
            using (var db = new UserContext())
            {
                return db.Users.Where(where.Compile()).ToArray();
            }
        }
    }
}