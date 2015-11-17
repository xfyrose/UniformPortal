using System.Web;
using Util.Core.Contexts;

namespace Util.Core
{
    public class Context
    {
        static Context()
        {
            if (IsWeb)
            {
                _context = new WebContext();
            }
            else
            {
                _context = new WindowsContext();
            }
        }

        private static readonly IContext _context;

        private static bool IsWeb => HttpContext.Current != null;

        public static void Add<T>(string key, T value)
        {
            _context.Add(key, value);
        }

        public static T Get<T>(string key)
        {
            return _context.Get<T>(key);
        }

        public static void Remove(string key)
        {
            _context.Remove(key);
        }
    }
}