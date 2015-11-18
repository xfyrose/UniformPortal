using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace DomainEvent.Fx.Helper
{
    public class Serializer
    {
        /// <summary>
        ///     从XML字符串中反序列化对象
        /// </summary>
        /// <typeparam name="T"> 结果对象类型 </typeparam>
        /// <param name="s">        包含对象的XML字符串 </param>
        /// <param name="encoding"> 编码方式 </param>
        /// <returns> 反序列化得到的对象 </returns>
        public static T XmlDeserialize<T>(string s, Encoding encoding)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException("s");
            if (encoding == null)
                throw new ArgumentNullException("encoding");

            var mySerializer = new XmlSerializer(typeof(T));
            using (var ms = new MemoryStream(encoding.GetBytes(s)))
            {
                using (var sr = new StreamReader(ms, encoding))
                {
                    return (T)mySerializer.Deserialize(sr);
                }
            }
        }
    }
}