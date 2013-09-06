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

        public void Set(Guid id, UsersResult results)
        {
            SessionWrapper.SetInSession(id.ToString(), results);
        }
    }
}