using System.Web;

namespace Util.Core.Contexts
{
    public class WebContext : IContext
    {
        public void Add<T>(string key, T value)
        {
            if (HttpContext.Current == null)
            {
                return;
            }

            HttpContext.Current.Items[key] = value;
        }

        public T Get<T>(string key)
        {
            if (HttpContext.Current == null)
            {
                return default(T);
            }

            return (T) HttpContext.Current.Items[key];
        }

        public void Remove(string key)
        {
            if (HttpContext.Current == null)
            {
                return;
            }

            HttpContext.Current.Items.Remove(key);
        }
    }
}