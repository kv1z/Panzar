using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Panzar.Models;

namespace Panzar.Wrappers
{
    public static class SessionWrapper
    {
        public static UsersResult GetUserResult(Guid id)
        {
            return GetFromSession<UsersResult>(id.ToString());
        }

        public static void SetUserResult(Guid id, UsersResult results)
        {
            SetInSession(id.ToString(), results);
        }

        private static T GetFromSession<T>(string key)
        {
            object obj = HttpContext.Current.Session[key];
            if (obj == null)
            {
                return default(T);
            }

            return (T)obj;
        }

        private static void SetInSession<T>(string key, T value) where T : class
        {
            if (value == null)
            {
                HttpContext.Current.Session.Remove(key);
            }
            else
            {
                HttpContext.Current.Session[key] = value;
            }
        }
    }
}