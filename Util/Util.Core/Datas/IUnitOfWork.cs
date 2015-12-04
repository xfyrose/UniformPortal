using System;

namespace Util.Core.Datas
{
    public interface IUnitOfWork : IDisposable
    {
        void Start();
        void Commit();
    }
}