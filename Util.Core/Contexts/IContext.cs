namespace Util.Core.Contexts
{
    internal interface IContext
    {
        void Add<T>(string key, T value);

        T Get<T>(string key);

        void Remove(string key);
    }
}