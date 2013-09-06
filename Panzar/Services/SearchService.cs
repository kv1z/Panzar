namespace Panzar.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Panzar.Models;

    public sealed class SearchService
    {
        private static readonly object SyncRoot = new Object();

        private static volatile SearchService instance;

        private readonly IUsersResultStorage storage;

        private SearchService(IUsersResultStorage storage)
        {
            this.storage = storage;
        }

        public static SearchService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (instance == null)
                        {
                            // да, да я в курсе что это антипаттерн.
                            instance = new SearchService(new UsersResultStorage());                            
                        }
                    }
                }

                return instance;
            }
        }

        public UsersResult GetUsersResult(Guid id)
        {
            return storage.Get(id);
        }

        public Guid Search(string queryString)
        {
            var userResult = new UsersResult();

            Task.Factory.StartNew(
                () =>
                    {
                        Thread.Sleep(5000);
                        var users = new List<User>
                                        {
                                            new User { Name = Guid.NewGuid().ToString() }, 
                                            new User { Name = Guid.NewGuid().ToString() }
                                        };

                        userResult.SetResult(users);
                    });

            storage.Set(userResult.Id, userResult);
            return userResult.Id;
        }
    }
}