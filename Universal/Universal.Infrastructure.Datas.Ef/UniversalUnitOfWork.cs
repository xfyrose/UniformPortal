using Universal.Infrastructure.Datas.Core;
using Util.Datas.Ef;
using System.Data.Entity;

namespace Universal.Infrastructure.Datas.Ef
{
    public class UniversalUnitOfWork : EfUnitOfWork, IUniversalUnitOfWork
    {
        //static UniversalUnitOfWork()
        //{
        //    Database.SetInitializer<UniversalUnitOfWork>(null);
        //}

        public UniversalUnitOfWork()
            : base("Application")
        {
            
        }
    }
}