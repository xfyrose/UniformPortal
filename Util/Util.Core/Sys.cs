using System;

namespace Util.Core
{
    public class Sys
    {
        public static Type GetType<T>()
        {
            return Nullable.GetUnderlyingType(typeof(T)) ?? typeof (T);
        } 
    }
}