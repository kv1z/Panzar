using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Panzar.Models
{
    public class UsersResult
    {
        public Guid Id { get; private set; }

        public bool IsComplete { get; private set; }

        public IEnumerable<User> Result { get; private set; }

        public UsersResult()
        {
            Id = Guid.NewGuid();
            IsComplete = false;
        }

        public void SetResult(IEnumerable<User> users)
        {
            Result = users;
            IsComplete = true;
        }
    }
}