using Universal.Domains;
using Universal.Domains.Models;
using Universal.Domains.Queries;
using Util.Core.Datas;
using Util.Datas.Ef;
using Util.Datas.Sql.Queries;
using Util.Domains.Repositories;

namespace Universal.Infrastructure.Datas.Ef.Repositories
{
    public class UserRepository : Repository<User, string>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        //public UserRepository(IUnitOfWork unitOfWork, ISqlQuery sqlQuery)
        //    : base(unitOfWork)
        //{
        //    _sqlQuery = sqlQuery;
        //}

        //private readonly ISqlQuery _sqlQuery;

        public PagerList<User> Query(UserQuery query)
        {
            throw new System.NotImplementedException();
        }
    }
}