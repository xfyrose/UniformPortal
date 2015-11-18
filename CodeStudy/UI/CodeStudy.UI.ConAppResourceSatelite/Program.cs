using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeStudy.UI.ConAppResourceSatelite
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cultures = {"en-CA", "en-US", "fr-FR", "ru-RU"};

            ResourceManager rm = new ResourceManager("CodeStudy.UI.ConAppResourceSatelite.Greeting", typeof(Program).Assembly);

            for (int cultureNdx = 0; cultureNdx < cultures.Length; cultureNdx++)
            {
                CultureInfo newCulture = CultureInfo.CreateSpecificCulture(cultures[cultureNdx]);

                Console.WriteLine("Culture: {0}", cultures[cultureNdx]);
                string greeting =
                    $"The current culture is {Thread.CurrentThread.CurrentUICulture}.\n{rm.GetString("HelloString", newCulture)}";
                Console.WriteLine(greeting + "\n\n");
            }

            //CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;

            //try
            //{
            //    CultureInfo newCulture = new CultureInfo(cultures[cultureNdx]);

            //    Thread.CurrentThread.CurrentCulture = newCulture;
            //    Thread.CurrentThread.CurrentUICulture = newCulture;

            //    Console.WriteLine("Culture: {0}", cultures[cultureNdx]);
            //    ResourceManager rm = new ResourceManager("CodeStudy.UI.ConAppResourceSatelite.Greeting", typeof (Program).Assembly);
            //    string greeting =
            //        $"The current culture is {Thread.CurrentThread.CurrentUICulture}.\n{rm.GetString("HelloString")}";
            //    Console.WriteLine(greeting);
            //}
            //catch (CultureNotFoundException e)
            //{
            //    Console.WriteLine("Unable to instantiate culture {0}", e.InvalidCultureName);
            //}
            //finally
            //{
            //    Thread.CurrentThread.CurrentCulture = originalCulture;
            //    Thread.CurrentThread.CurrentUICulture = originalCulture;
            //}

            PersonTable table = new PersonTable("Name", "Employee Number", "Age", 30, 18, 5);
            ResXResourceWriter rr = new ResXResourceWriter(@".\UIResources.resx");
            rr.AddResource("TableName", "Employees of Acme Corporation");
            rr.AddResource("Employees", table);
            rr.Generate();
            rr.Close();

            Console.ReadLine();

            string fmtString = String.Empty;
            rm = new ResourceManager("UIResources", typeof(Program).Assembly);
            string title = rm.GetString("TableName");
            PersonTable tableInfo = (PersonTable)rm.GetObject("Employees");

            if (!String.IsNullOrEmpty(title))
            {
                fmtString = "{0," + ((Console.WindowWidth + title.Length) / 2).ToString() + "}";
                Console.WriteLine(fmtString, title);
                Console.WriteLine();
            }

            for (int ctr = 1; ctr <= tableInfo.nColumns; ctr++)
            {
                string columnName = "column" + ctr.ToString();
                string widthName = "width" + ctr.ToString();
                string value = tableInfo.GetType().GetField(columnName).GetValue(tableInfo).ToString();
                int width = (int)tableInfo.GetType().GetField(widthName).GetValue(tableInfo);
                fmtString = "{0,-" + width.ToString() + "}";
                Console.Write(fmtString, value);
            }
            Console.WriteLine();

        }
    }

    [Serializable]
    public struct PersonTable
    {
        public readonly int nColumns;

        public readonly string column1;
        public readonly string column2;
        public readonly string column3;
        public readonly int width1;
        public readonly int width2;
        public readonly int width3;

        public PersonTable(string column1, string column2, string column3,
                       int width1, int width2, int width3)
        {
            this.column1 = column1;
            this.column2 = column2;
            this.column3 = column3;
            this.width1 = width1;
            this.width2 = width2;
            this.width3 = width3;
            this.nColumns = typeof(PersonTable).GetFields().Length / 2;
        }
    }
}
