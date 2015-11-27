using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CodeStudy.Misc
{
    public static class Dump
    {
        public static void ToConsole(object param)
        {
            Console.WriteLine();
            Console.WriteLine("****{0} : {1}---", MethodBase.GetCurrentMethod().Name, param.GetType().Name);
            //Console.WriteLine("****{0} : {1}---", MethodBase.GetCurrentMethod().Name, param.GetType().FullName);
            Console.WriteLine("  ---Properties...");
            param.GetType().GetProperties().ToList().ForEach(m => Console.WriteLine("    {0} : 【{1}】", m.Name, m.GetValue(param)));

            Console.WriteLine();
            Console.WriteLine("  ---Methods...");
            param.GetType().GetMethods().ToList().ForEach(m =>
            {
                try
                {
                    Console.WriteLine("    {0} : 【{1}】", m.Name, m.Invoke(param, null));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("    {0} : 【{1}】{2}", m.Name, "...Error...", ex.Message);
                }
            });

            Console.WriteLine();
            Console.WriteLine("    ---Parameters...");
            LambdaExpression leExpression = param as LambdaExpression;
            leExpression?.Parameters.ToList().ForEach(p => Console.WriteLine("      {0}: {1}", p.Name, p.Type));
        }
    }
}
