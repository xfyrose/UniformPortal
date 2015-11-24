namespace Util.Core.Datas
{
    public interface IUnitOfWork
    {
        void Start();
        void Commit();
    }
}