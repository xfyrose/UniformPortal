using Universal.Domains.Models;
using Universal.Domains.Queries;
using Util.Domains.Repositories;

namespace Universal.Domains
{
    public interface IUserRepository : IRepository<User, string>
    {
        PagerList<User> Query(UserQuery query);
    }
}