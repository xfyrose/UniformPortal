using System;

namespace CodeStudy.Misc.Autofacs
{
    public class Dal<T> : IDal<T> where T : class
    {
        public void Insert(T entity)
        {
            Console.WriteLine("添加：" + entity.GetType().FullName);
        }
        public void Update(T entity)
        {
            Console.WriteLine("修改：" + entity.GetType().FullName);
        }
        public void Delete(T entity)
        {
            Console.WriteLine("删除：" + entity.GetType().FullName);
        }
    }
}
