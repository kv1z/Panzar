namespace Panzar.Wrappers
{
    using System.Web;

    public static class SessionWrapper
    {
        public static T GetFromSession<T>(string key)
        {
            object obj = HttpContext.Current.Session[key];
            if (obj == null)
            {
                return default(T);
            }

            return (T)obj;
        }

        public static void SetInSession<T>(string key, T value) where T : class
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