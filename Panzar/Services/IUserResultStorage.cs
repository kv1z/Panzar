namespace Panzar.Services
{
    using System;

    using Panzar.Models;

    public interface IUsersResultStorage
    {
        UsersResult Get(Guid id);

        void Set(Guid id, UsersResult results);
    }
}