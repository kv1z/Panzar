namespace Panzar.Services
{
    using System;

    using Panzar.Models;

    public interface IUsersResultStorage
    {
        UsersResult Get(Guid id);

        void Set(UsersResult results);
    }
}