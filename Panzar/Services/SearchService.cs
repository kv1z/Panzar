namespace Panzar.Services
{
    using System;
    using System.Threading.Tasks;

    using Panzar.DAL;
    using Panzar.Models;

    public sealed class SearchService
    {
        private static readonly Lazy<SearchService> lazy =
            new Lazy<SearchService>(() => new SearchService(new UsersResultStorage(), new UserRepository()));

        private readonly IUserRepository repository;

        private readonly IUsersResultStorage storage;

        /// <remarks>
        ///     internal - для тестов
        /// </remarks>
        /// >
        internal SearchService(IUsersResultStorage storage, IUserRepository repository)
        {
            this.storage = storage;
            this.repository = repository;
        }

        public static SearchService Instance
        {
            get
            {
                return lazy.Value;
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