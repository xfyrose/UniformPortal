using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DomainEvent.Fx
{
    /// <summary>
    ///     集合封装
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CollectionWrapper<T> : DisposableResource, IEnumerable<T>, IEnumerator<T>, IList<T>
    {
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private List<T> list;

        //定义索引
        // ReSharper disable once InconsistentNaming
        private int position;

        #region Construction

        /// <summary>
        ///     Construction Function
        /// </summary>
        public CollectionWrapper()
        {
            list = new List<T>();
            position = -1;
        }

        #endregion Construction

        /// <summary>
        ///     获取 CollectionWrapper 中实际包含的元素数。
        /// </summary>
        public int Count
        {
            get
            {
                if (!list.IsNullOrEmpty())
                    return list.Count;
                return -1;
            }
        }

        /// <summary>
        ///     确定集合中特定对象的索引
        /// </summary>
        /// <param name="TObject">特定的对象</param>
        /// <returns>如果在列表中找到，则为item 的索引；否则为 -1</returns>
        public int IndexOf(T TObject)
        {
            return list.IndexOf(TObject);
        }

        #region Insert

        /// <summary>
        ///     在集合的特定位置插入对象
        /// </summary>
        /// <param name="index">索引，从0开始</param>
        /// <param name="TObject">被插入的对象</param>
        public void Insert(int index, T TObject)
        {
            list.Insert(index, TObject);
        }

        #endregion Insert

        #region Get by index

        /// <summary>
        ///     获取或设置指定索引处的元素
        /// </summary>
        /// <param name="index">索引值从0开始</param>
        /// <returns>TObject</returns>
        public T this[int index]
        {
            get { return list[index]; }
            set { list[index] = value; }
        }

        #endregion Get by index

        #region Add

        /// <summary>
        ///     将对象添加到集合的尾部
        /// </summary>
        /// <param name="TObject"></param>
        public void Add(T TObject)
        {
            list.Add(TObject);
        }

        /// <summary>
        ///     将指定集合里的元素添加到集合尾部
        /// </summary>
        /// <param name="TCollection">要添加到集合尾部的集合对象</param>
        public void AddRange(ICollection<T> TCollection)
        {
            list.AddRange(TCollection);
        }

        #endregion Add

        #region Remove

        /// <summary>
        ///     从集合中移除特定对象的第一个匹配项
        /// </summary>
        /// <param name="TObject">TObject</param>
        /// <returns>true：移除成功；false：移除失败</returns>
        public bool Remove(T TObject)
        {
            return list.Remove(TObject);
        }

        /// <summary>
        ///     从集合中移除指定索引处的对象
        /// </summary>
        /// <param name="index">索引值，从0开始</param>
        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        /// <summary>
        ///     集合删除所有对象
        /// </summary>
        public void Clear()
        {
            list.Clear();
        }

        #endregion Remove

        #region Get

        /// <summary>
        ///     返回序列中满足指定条件的一组元素
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<T> Find(Expression<Func<T, bool>> filter)
        {
            filter.CheckNull("filter");
            return list.AsQueryable().Where(filter).AsEnumerable();
        }

        /// <summary>
        ///     返回序列中满足指定条件的第一个元素。
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public T First(Expression<Func<T, bool>> filter)
        {
            filter.CheckNull("filter");
            return list.AsQueryable().First(filter);
        }

        /// <summary>
        ///     返回序列中满足指定条件的第一个元素，如果未找到这样的元素，则返回默认值。
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public T FirstOrDefault(Expression<Func<T, bool>> filter)
        {
            filter.CheckNull("filter");
            return list.AsQueryable().FirstOrDefault(filter);
        }

        #endregion Get

        #region ICollection<T> Implement

        /// <summary>
        ///     获取一个值，该值指示 System.Collections.Generic.ICollection&lt;T&gt; 是否为只读。
        /// </summary>
        public bool IsReadOnly
        {
            get { return true; }
        }

        /// <summary>
        ///     确定 System.Collections.Generic.ICollection&lt;T&gt; 是否包含特定值。
        /// </summary>
        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        /// <summary>
        ///     从特定的 System.Array 索引处开始，将 System.Collections.Generic.ICollection;T&gt; 的元素复制到一个
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        #endregion ICollection<T> Implement

        #region Foreach

        #region IEnumerable<T> Implement

        // ReSharper disable once RedundantNameQualifier
        System.Collections.Generic.IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            // ReSharper disable once RedundantCast
            return (IEnumerator<T>)this;
        }

        #region IEnumerable Implement

        IEnumerator IEnumerable.GetEnumerator()
        {
            // ReSharper disable once RedundantCast
            return (IEnumerator)this;
        }

        #endregion IEnumerable Implement

        #endregion IEnumerable<T> Implement

        #region IEnumerator<T> Implement

        //获取集合中的当前元素。
        // ReSharper disable once RedundantNameQualifier
        T System.Collections.Generic.IEnumerator<T>.Current
        {
            get
            {
                try
                {
                    return list[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        #region 实现IEnumerator接口，因为IEnumerator<T>继承IEnumerator

        //获取集合中的当前元素。
        object IEnumerator.Current
        {
            get
            {
                try
                {
                    return list[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        //将枚举数推进到集合的下一个元素。
        bool IEnumerator.MoveNext()
        {
            position++;
            return (position < list.Count);
        }

        //将枚举数设置为其初始位置，该位置位于集合中第一个元素之前。
        void IEnumerator.Reset()
        {
            position = -1;
        }

        #endregion 实现IEnumerator接口，因为IEnumerator<T>继承IEnumerator

        #region 实现IDisposable接口,因为IEnumerator<T>继承IDisposable

        /// <summary>
        ///     释放
        /// </summary>
        public override void Dispose()
        {
            position = -1;
            base.Dispose();
        }

        #endregion 实现IDisposable接口,因为IEnumerator<T>继承IDisposable

        #endregion IEnumerator<T> Implement

        #endregion Foreach
    }
}