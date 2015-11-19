using System;
using System.Threading;

namespace Util.Core.Contexts
{
    internal class WindowsContext : IContext
    {
        public void Add<T>(string key, T value)
        {
            LocalDataStoreSlot slot = Thread.GetNamedDataSlot(key);
            //LocalDataStoreSlot slot = Thread.AllocateNamedDataSlot(key);

            Thread.SetData(slot, value);
        }

        public T Get<T>(string key)
        {
            LocalDataStoreSlot slot = Thread.GetNamedDataSlot(key);

            return (T)Thread.GetData(slot);
        }

        public void Remove(string key)
        {
            LocalDataStoreSlot slot = Thread.GetNamedDataSlot(key);

            Thread.SetData(slot, null);

            //Thread.FreeNamedDataSlot(key);
        }
    }
}