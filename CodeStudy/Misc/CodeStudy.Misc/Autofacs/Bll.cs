namespace CodeStudy.Misc.Autofacs
{
    public class Bll<T> : IDependency<T> where T : class 
    {
        private readonly IRepository<T> _repository;

        public Bll(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Insert(T c)
        {
            _repository.Insert(c);
        }

        public void Update(T c)
        {
            _repository.Update(c);
        }

        public void Delete(T c)
        {
            _repository.Delete(c);
        }
    }
}
