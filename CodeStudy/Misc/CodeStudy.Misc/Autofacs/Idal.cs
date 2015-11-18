namespace CodeStudy.Misc.Autofacs
{
    public interface IDal<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
