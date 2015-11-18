using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeStudy.Misc.Lists
{
    [TestClass]
    public class UnitTestEnumerable
    {
        [TestMethod]
        public void TestMethod_Aggregate()
        {
            string sentence = "the quick brown fox jumps over the lazy dog";

            // Split the string into individual words.
            string[] words = sentence.Split(' ');

            // Prepend each word to the beginning of the 
            // new sentence to reverse the word order.
            string reversed = words.Aggregate(Animal.Converters);

            Console.WriteLine("+++++" + reversed);
        }

        [TestMethod]
        public void TestMethod_List()
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            List<ViewDto> list = new List<ViewDto>();
            for (int i = 0; i < 50000000; i++)
            {
                list.Add(new ViewDto
                {
                    Id = i + 1,
                    Name = "测试" + (i + 1).ToString(),
                    Skin = "Yellow" + i.ToString(),
                    Language = "Chinese",
                    LianXiDianHua = "13456789" + i.ToString(),
                    LianXiRen = "LianXiRen " + i.ToString(),
                    Operator = "wertyui"
                });

                if ((i % 10000) == 0)
                {
                    Console.WriteLine("Count: {0}", i);
                }
            }

            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }
    }

    public class ViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Skin { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string LianXiDianHua { get; set; }
        public string LianXiRen { get; set; }
        public string Operator { get; set; }
    }
}
