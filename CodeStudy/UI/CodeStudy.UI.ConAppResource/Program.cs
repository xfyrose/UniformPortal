﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.UI.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Resource1.TimeHeader);
            //ResourceManager resManager =
            //    ResourceManager.CreateFileBasedResourceManager("Resource2", AppDomain.CurrentDomain.BaseDirectory, null);
            //Console.WriteLine("--" + resManager.GetString("StringABC"));

            Contract.Requires<InvalidOperationException>(false, nameof(Program) + " 不可为空");

            Console.WriteLine("XXXXXXXXXXXXX");


            Console.ReadLine();
        }
    }
}
