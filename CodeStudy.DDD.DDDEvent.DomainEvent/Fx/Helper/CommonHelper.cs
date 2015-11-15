using System.Collections.Generic;

namespace DomainEvent.Fx.Helper
{
    public class CommonHelper
    {
        #region Private Constants

        private const int InitialPrime = 23;
        private const int FactorPrime = 29;

        #endregion Private Constants

        public static int GetHashCode(params int[] hashCodesForProperties)
        {
            unchecked
            {
                int hash = InitialPrime;
                // ReSharper disable once LoopCanBeConvertedToQuery
                foreach (var code in hashCodesForProperties)
                    hash = hash * FactorPrime + code;
                return hash;
            }
        }

        /// <summary>
        ///     获得所给定的对象集合的总 HashCode
        /// </summary>
        /// <param name="objects">对象集合</param>
        /// <returns>总 HashCode</returns>
        public static int GetHashCode(params object[] objects)
        {
            var hashCodes = new List<int>();
            objects.Do(@object => hashCodes.Add(@object.GetHashCode()));
            return GetHashCode(hashCodes.ToArray());
        }
    }
}