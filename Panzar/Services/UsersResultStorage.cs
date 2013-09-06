namespace Panzar.Services
{
    using System;

    using Panzar.Models;
    using Panzar.Wrappers;

    internal class UsersResultStorage : IUsersResultStorage
    {
        public UsersResult Get(Guid id)
        {
            return SessionWrapper.GetFromSession<UsersResult>(id.ToString());
        }

        public void Set(UsersResult results)
        {
            SessionWrapper.SetInSession(results.Id.ToString(), results);
        }
    }
}