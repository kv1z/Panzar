using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Panzar.Models;
using System.Threading.Tasks;
using System.Threading;

namespace Panzar.Services
{
    public sealed class SearchService
    {
        private static readonly object SyncRoot = new Object();

        private static volatile SearchService instance;

        private SearchService()
        {
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
                            instance = new SearchService();
                        }
                    }
                }

                return instance;
            }
        }

        public Guid Search(string queryString, HttpSessionStateBase session)
        {
            var usersResult = new UsersResult();

            Task.Factory.StartNew(
                    () =>
                    {
                        Thread.Sleep(5000);
                        var users = new List<User>
                                        {
                                            new User { Name = Guid.NewGuid().ToString() }, 
                                            new User { Name = Guid.NewGuid().ToString() }
                                        };
                        usersResult.SetResult(users);
                    });


            session[usersResult.Id.ToString()] = usersResult;
            return usersResult.Id;
        }
    }

}