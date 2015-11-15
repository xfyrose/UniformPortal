using System;

namespace BeiDream.AutoMapper.Reflection
{
    public interface ITypeFinder
    {
        IAssemblyFinder AssemblyFinder { get; set; }
        Type[] Find(Func<Type, bool> predicate);

        Type[] FindAll();
    }
}