namespace Panzar.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Panzar.Models;
    using Panzar.DAL;

    public sealed class SearchService
    {
        private static readonly object SyncRoot = new Object();

        private static volatile SearchService instance;
        
        private readonly IUserRepository repository;

        private readonly IUsersResultStorage storage;

        private SearchService(IUsersResultStorage storage, IUserRepository repository)
        {
            this.storage = storage;
            this.repository = repository;
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
                            instance = new SearchService(new UsersResultStorage(), new UserRepository());                            
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

            Task.Factory.StartNew(() => userResult.SetResult(repository.Find(x => x.Name.Contains(queryString))));

            storage.Set(userResult);
            return userResult.Id;
        }
    }
}