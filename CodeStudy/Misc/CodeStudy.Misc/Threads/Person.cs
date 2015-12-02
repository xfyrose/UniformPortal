using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.Misc.Threads
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            Person another = obj as Person;
            if (another == null)
                return false;

            if (another.Id != this.Id)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
