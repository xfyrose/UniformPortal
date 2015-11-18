using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace CodeStudy
{
    public static class Dump
    {
        public static void ToConsole(object param)
        {
            Console.WriteLine();
            Console.WriteLine("---{0} : {1}---", MethodBase.GetCurrentMethod().Name, param.GetType().FullName);
            Console.WriteLine("---Properties...");
            param.GetType().GetProperties().ToList().ForEach(m => Console.WriteLine("{0} : 【{1}】", m.Name, m.GetValue(param)));

            Console.WriteLine();
            Console.WriteLine("---Methods...");
            param.GetType().GetMethods().ToList().ForEach(m =>
            {
                try
                {
                    Console.WriteLine("{0} : 【{1}】", m.Name, m.Invoke(param, null));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} : 【{1}】{2}", m.Name, "...Error...", ex.Message);
                }
            });

            LambdaExpression leExpression = param as LambdaExpression;
            if (leExpression != null)
            {
                leExpression.Parameters.ToList().ForEach(Console.WriteLine);
            }

        }
    }
}
