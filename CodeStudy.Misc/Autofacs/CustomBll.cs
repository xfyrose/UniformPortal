namespace CodeStudy.Misc.Autofacs
{
    public class CustomBll : IDependency<Custom>
    {
        private readonly IRepository<Custom> _repository;

        public CustomBll(IRepository<Custom> repository)
        {
            _repository = repository;
        }

        public void Insert(Custom c)
        {
            _repository.Insert(c);
        }

        public void Update(Custom c)
        {
            _repository.Update(c);
        }

        public void Delete(Custom c)
        {
            _repository.Delete(c);
        }
    }

    public class Custom2Bll : IDependency
    {
        private readonly IRepository<Custom> _repository;

        public Custom2Bll(IRepository<Custom> repository)
        {
            _repository = repository;
        }

        public void Insert(Custom c)
        {
            _repository.Insert(c);
        }

        public void Update(Custom c)
        {
            _repository.Update(c);
        }

        public void Delete(Custom c)
        {
            _repository.Delete(c);
        }
    }
}
