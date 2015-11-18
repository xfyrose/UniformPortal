namespace CodeStudy.Misc.Autofacs
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDal<T> _dal;

        public Repository(IDal<T> dal)
        {
            _dal = dal;
        }

        public void Insert(T entity)
        {
            _dal.Insert(entity);
        }

        public void Update(T entity)
        {
            _dal.Update(entity);
        }

        public void Delete(T entity)
        {
            _dal.Delete(entity);
        }
    }
}
