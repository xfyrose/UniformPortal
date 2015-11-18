using System;

// ReSharper disable once CheckNamespace

namespace DomainEvent
{
    /// <summary>
    ///     资源释放基类
    /// </summary>
    public abstract class DisposableResource : IDisposable
    {
        /// <summary>
        ///     释放
        /// </summary>
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     析构函数
        /// </summary>
        ~DisposableResource()
        {
            Dispose(false);
        }

        /// <summary>
        ///     释放
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
        }
    }
}