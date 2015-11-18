namespace CodeStudy.Misc.Autofacs
{
    public class PersonBll : IDependency<Person>
    {
        private readonly IRepository<Person> _repository;

        public PersonBll(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public void Insert(Person c)
        {
            _repository.Insert(c);
        }

        public void Update(Person c)
        {
            _repository.Update(c);
        }

        public void Delete(Person c)
        {
            _repository.Delete(c);
        }
    }

    public class Person2Bll : IDependency
    {
        private readonly IRepository<Person> _repository;

        public Person2Bll(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public void Insert(Person c)
        {
            _repository.Insert(c);
        }

        public void Update(Person c)
        {
            _repository.Update(c);
        }

        public void Delete(Person c)
        {
            _repository.Delete(c);
        }
    }
}
