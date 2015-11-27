using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using CodeStudy.Misc.Lambdas;

// ReSharper disable All

namespace CodeStudy.Misc.Lambdas
{
    [TestClass]
    public class UnitTestLambda01
    {
        /// <summary>
        /// 输出object的所有属性、方法
        /// </summary>
        [TestMethod]
        public void TestMethod_Dump_Object()
        {
            object obj = new object();
            Dump.ToConsole(obj);
        }

        /// <summary>
        /// 输出object的所有属性、方法
        /// </summary>
        [TestMethod]
        public void TestMethod_Dump_MemberExpression()
        {
            Animal horse = new Animal();

            // Create a MemberExpression that represents getting 
            // the value of the 'species' field of class 'Animal'.
            MemberExpression memberExpression = Expression.Field(Expression.Constant(horse), "species");
            Dump.ToConsole(memberExpression);

            Dump.ToConsole(memberExpression.Expression);
            Dump.ToConsole(memberExpression.Member);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestMethod_Dump_Convert()
        {
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression represents a type convertion operation. 
            Expression convertExpr = Expression.Convert(
                                        Expression.Constant(5.5),
                                        typeof(Int16)
                                    );

            Dump.ToConsole(convertExpr);
            // Print out the expression.
            Console.WriteLine(convertExpr.ToString());

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            Console.WriteLine(Expression.Lambda<Func<Int16>>(convertExpr).Compile()());

            // This code example produces the following output:
            //
            // Convert(5.5)
            // 5
        }

        /// <summary>
        /// 输出Expression的所有属性、方法
        /// </summary>
        [TestMethod]
        public void TestMethod_Dump_ParameterExpression()
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(string), "stringParam");
            Dump.ToConsole(parameterExpression);
        }

        /// <summary>
        /// 输出多个参数的Expression所有属性、方法，及每个参数的属性、方法
        /// </summary>
        [TestMethod]
        public void TestMethod_Dump_ManyParametersExpression()
        {
            Expression<Func<int, int, int>> expr = (x, y) => x + y + 1;
            Dump.ToConsole(expr);
            Console.WriteLine("xxxxxx-------------xxxxxx");

            expr.Parameters.ToList().ForEach(m => Dump.ToConsole(m));
        }

        /// <summary>
        /// Lambda as转换
        /// </summary>
        [TestMethod]
        public void TestMethod_Dump_AsLambda()
        {
            Expression<Func<int, int, int>> expr = (x, y) => x + y + 1;
            LambdaExpression lambdaExpression1 = expr as LambdaExpression;
            Dump.ToConsole(lambdaExpression1);
            Console.WriteLine("xxxxxx-------------xxxxxx");
            lambdaExpression1.Parameters.ToList().ForEach(m => Dump.ToConsole(m));
        }

        /// <summary>
        /// Expression.Method
        /// </summary>
        [TestMethod]
        public void TestMethod_Dump_Method()
        {
            Expression<Func<string, bool>> expr = name => name.Length > 10 && name.StartsWith("G");
            Console.WriteLine(expr);

            AndAlsoModifier treeModifier = new AndAlsoModifier();
            Expression modifiedExpr = treeModifier.Modify((Expression)expr);

            Console.WriteLine(modifiedExpr);
        }

        /// <summary>
        /// Invocation
        /// </summary>
        [TestMethod]
        public void TestMethod_Dump_Invocation()
        {
            Expression<Func<int, int, bool>> largeSumTest = (num1, num2) => (num1 + num2) > 1000;

            InvocationExpression invocationExpression = Expression.Invoke(
                largeSumTest,
                Expression.Constant(539),
                Expression.Constant(281)
                );

            var result = Expression.Lambda<Func<bool>>(invocationExpression);
            Console.WriteLine(result.Compile()());
            Dump.ToConsole(result);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestMethod_Dump_Point()
        {
            //new System.Windows.Point() { X = Math.Sin(a), Y = Math.Cos(a) }
            //ParameterExpression a = Expression.Parameter(typeof (double), "a");

            //MemberBinding
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestMethod_Dump_ArrayIndex()
        {
            //string[,] gradeArray = {{"chemistry", "history", "mathematics"}, {"78", "61", "82"}};

            //ConstantExpression arrayExresssion = Expression.Constant(gradeArray);

            //MethodCallExpression methodCallExpression = Expression.ArrayIndex(
            //    arrayExresssion,
            //    Expression.Constant(0),
            //    Expression.Constant(2)
            //    );
            //CodeStudy.Dump.ToConsole(methodCallExpression);
            //var a =
            //    Expression.Lambda<Func<string[,], string[,]>>(methodCallExpression, gradeArray);
        }

        /// <summary>
        ///  
        /// </summary>
        [TestMethod]
        public void TestMethod_Dump_Loop()
        {
            /*
            Expression<Action> lambdaExpression2 = () =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine("Hello");
                }
            };
            */
            LabelTarget labelBreak = Expression.Label();
            ParameterExpression loopIndex = Expression.Variable(typeof (int), "index");

            BlockExpression block = Expression.Block(
                new []{ loopIndex },
                Expression.Assign(loopIndex, Expression.Constant(1)),
                Expression.Loop(
                    Expression.IfThenElse(
                        Expression.LessThanOrEqual(loopIndex, Expression.Constant(10)),
                        Expression.Block(
                            Expression.Call(
                                null,
                                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }),
                                Expression.Constant("Hello")
                                ),
                            Expression.PostIncrementAssign(loopIndex)
                            ),
                        Expression.Break(labelBreak)
                        ),
                    labelBreak
                    )
                );

            Expression<Action> lambdaExpression = Expression.Lambda<Action>(block);
            Dump.ToConsole(lambdaExpression);
            lambdaExpression.Compile()();
        }

        [TestMethod]
        public void TestMethod_Dump_BlockWriteLine()
        {
            //string s;
            //s = "Hello World!";
            //Console.WriteLine(s);

            ParameterExpression s = Expression.Variable(typeof(string), "s");
            BinaryExpression assignExpression = Expression.Assign(s, Expression.Constant("Hello World!"));
            MethodCallExpression callExpression = Expression.Call(
                null,
                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(object) }),
                s
                );
            Expression<Action> writelineExpression = Expression.Lambda<Action>(
                Expression.Block(
                    new[] { s },
                    assignExpression,
                    callExpression
                )
                );
            writelineExpression.Compile()();

            //var writelineExpression = Expression.Lambda<Action<string>>(callExpression,
            //    new ParameterExpression[] {s});
            //var writeline = writelineExpression.Compile();

            Dump.ToConsole(writelineExpression);
        }

        /// <summary>
        /// if () then {}
        /// </summary>
        [TestMethod]
        public void TestMethod_Dump_IfThen()
        {
            ParameterExpression score = Expression.Variable(typeof(int), "score");
            BinaryExpression scoreAssign = Expression.Assign(score, Expression.Constant(30));
            ConditionalExpression ifThenExpr = Expression.IfThen(
                Expression.LessThan(scoreAssign, Expression.Constant(60)),
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new[] { typeof(object) }),
                    Expression.Constant("合格")
                )
                );
            Expression<Action> ifThenLambdaExpression = Expression.Lambda<Action>(
                Expression.Block(
                    new[] { score },
                    scoreAssign,
                    ifThenExpr
                )
                );
            ifThenLambdaExpression.Compile()();
            Dump.ToConsole(ifThenLambdaExpression);
        }

        [TestMethod]
        public void TestMethod_Dump_StringCompare()
        {
            ParameterExpression peExpression1 = Expression.Parameter(typeof(string), "str1");
            ParameterExpression peExpression2 = Expression.Parameter(typeof(string), "str2");

            MethodCallExpression mcCallExpression = Expression.Call(
                null,
                typeof(string).GetMethod("Compare", new Type[] { typeof(string), typeof(string) }),
                new Expression[] { peExpression1, peExpression2 }
                );

            LambdaExpression lambdaExpression = Expression.Lambda<Func<string, string, int>>(mcCallExpression, new ParameterExpression[] { peExpression1, peExpression2 });
            Dump.ToConsole(lambdaExpression);

            Func<string, string, int> complied = lambdaExpression.Compile() as Func<string, string, int>;
            Console.WriteLine(complied("a", "a"));
            Console.WriteLine(complied("a", "b"));
        }

        /// <summary>
        /// 解析、拆解表达式
        /// </summary>
        [TestMethod]
        public void TestMethod_Dump_ResolveExpression()
        {
            Expression<Func<int, bool>> exprTree = num => num < 5;
            exprTree.Parameters.ToList().ForEach(m => Dump.ToConsole(m));

            // Decompose the expression tree.
            ParameterExpression param = (ParameterExpression)exprTree.Parameters[0];
            BinaryExpression operation = (BinaryExpression)exprTree.Body;
            ParameterExpression left = (ParameterExpression)operation.Left;
            ConstantExpression right = (ConstantExpression)operation.Right;

            Dump.ToConsole(param);
        }

        /// <summary>
        /// (x, y) => x.Starts(y)
        /// </summary>
        [TestMethod]
        public void TestMethod_Dump_StartsWith()
        {
            //MethodInfo method = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
            //var target = Expression.Parameter(typeof(string), "x");
            //var methodArg = Expression.Parameter(typeof(string), "y");
            //Expression[] methodArgs = new[] { methodArg };
            //Expression call = Expression.Call(target, method, methodArgs);
            //var lambdaParameters = new[] { target, methodArg };
            //var lambda = Expression.Lambda<Func<string, string, bool>>(call, lambdaParameters);
            //var compiled = lambda.Compile();
            //Console.WriteLine(compiled("First", "Second"));
            //Console.WriteLine(compiled("First", "Fir"));

            ParameterExpression target = Expression.Parameter(typeof(string), "x");
            ParameterExpression methodArg = Expression.Parameter(typeof(string), "y");

            MethodCallExpression call = Expression.Call(
                target,
                typeof(string).GetMethod("StartsWith", new[] { typeof(string) }),
                methodArg
                );

            LambdaExpression lambdaExpression = Expression.Lambda<Func<string, string, bool>>(call,
                new ParameterExpression[] { target, methodArg });

            //lambdaExpression.Parameters.ToList().ForEach(m => CodeStudy.Dump.ToConsole(m));
            Dump.ToConsole(lambdaExpression);

            Func<string, string, bool> compiled = lambdaExpression.Compile() as Func<string, string, bool>;
            Console.WriteLine(compiled("First", "Second"));
            Console.WriteLine(compiled("First", "Fir"));
        }

        [TestMethod]
        public void TestMethod_Dump_CreateQueryable()
        {
            // Add a using directive for System.Linq.Expressions.
            string[] companies = { "Consolidated Messenger", "Alpine Ski House", "Southridge Video", "City Power & Light",
                               "Coho Winery", "Wide World Importers", "Graphic Design Institute", "Adventure Works",
                               "Humongous Insurance", "Woodgrove Bank", "Margie's Travel", "Northwind Traders",
                               "Blue Yonder Airlines", "Trey Research", "The Phone Company",
                               "Wingtip Toys", "Lucerne Publishing", "Fourth Coffee" };

            IQueryable<string> queryableData = companies.AsQueryable<string>();

            ParameterExpression peExpression = Expression.Parameter(typeof (string), "company");

            Expression left = Expression.Call(peExpression, typeof (string).GetMethod("ToLower", System.Type.EmptyTypes));
            Expression right = Expression.Constant("coho winery", typeof(string));
            BinaryExpression e1 = Expression.Equal(left, right);
            left = Expression.Property(peExpression, typeof (string).GetProperty("Length"));
            right = Expression.Constant(16, typeof (int));
            BinaryExpression e2 = Expression.GreaterThan(left, right);

            Expression predicateBody = Expression.OrElse(e1, e2);

            // ***** OrderBy(company => company) *****
            // Create an expression tree that represents the expression
            // 'whereCallExpression.OrderBy(company => company)'
            MethodCallExpression orderbyCallExpression = Expression.Call(
                typeof(Queryable),
                "OrderBy",
                new Type[] { queryableData.ElementType, queryableData.ElementType },
                queryableData.Expression,
                Expression.Lambda<Func<string, string>>(peExpression, new ParameterExpression[] { peExpression })
                );
            // ***** End OrderBy *****

            // Create an expression tree that represents the expression
            // 'queryableData.Where(company => (company.ToLower() == "coho winery" || company.Length > 16))'
            MethodCallExpression whereCallExpression = Expression.Call(
                typeof (Queryable),
                "Where",
                new Type[] { queryableData.ElementType },
                orderbyCallExpression,
                Expression.Lambda<Func<string, bool>>(predicateBody, new ParameterExpression[] { peExpression })
                );
            //Expression<Func<string[], IEnumerable<string>[]>> lmExpression =
            //    Expression.Lambda<Func<string[], IEnumerable<string>[]>>(whereCallExpression, new ParameterExpression[] { Expression.Parameter(typeof(string[]))});
            //lmExpression.Compile()(companies);

            Dump.ToConsole(whereCallExpression);

            // ***** End Where *****

            // Create an executable query from the expression tree.

            // Enumerate the results.
        }

        [TestMethod]
        public void TestMethod_Dump_Queryable()
        {
            // Add a using directive for System.Linq.Expressions.

            string[] companies = { "Consolidated Messenger", "Alpine Ski House", "Southridge Video", "City Power & Light",
                               "Coho Winery", "Wide World Importers", "Graphic Design Institute", "Adventure Works",
                               "Humongous Insurance", "Woodgrove Bank", "Margie's Travel", "Northwind Traders",
                               "Blue Yonder Airlines", "Trey Research", "The Phone Company",
                               "Wingtip Toys", "Lucerne Publishing", "Fourth Coffee" };

            // The IQueryable data to query.
            IQueryable<String> queryableData = companies.AsQueryable<string>();

            // Compose the expression tree that represents the parameter to the predicate.
            ParameterExpression pe = Expression.Parameter(typeof(string), "company");

            // ***** Where(company => (company.ToLower() == "coho winery" || company.Length > 16)) *****
            // Create an expression tree that represents the expression 'company.ToLower() == "coho winery"'.
            Expression left = Expression.Call(pe, typeof(string).GetMethod("ToLower", System.Type.EmptyTypes));
            Expression right = Expression.Constant("coho winery");
            Expression e1 = Expression.Equal(left, right);

            // Create an expression tree that represents the expression 'company.Length > 16'.
            left = Expression.Property(pe, typeof(string).GetProperty("Length"));
            right = Expression.Constant(16, typeof(int));
            Expression e2 = Expression.GreaterThan(left, right);

            // Combine the expression trees to create an expression tree that represents the
            // expression '(company.ToLower() == "coho winery" || company.Length > 16)'.
            Expression predicateBody = Expression.OrElse(e1, e2);

            // Create an expression tree that represents the expression
            // 'queryableData.Where(company => (company.ToLower() == "coho winery" || company.Length > 16))'
            MethodCallExpression whereCallExpression = Expression.Call(
                typeof(Queryable),
                "Where",
                new Type[] { queryableData.ElementType },
                queryableData.Expression,
                Expression.Lambda<Func<string, bool>>(predicateBody, new ParameterExpression[] { pe }));
            // ***** End Where *****

            // ***** OrderBy(company => company) *****
            // Create an expression tree that represents the expression
            // 'whereCallExpression.OrderBy(company => company)'
            MethodCallExpression orderByCallExpression = Expression.Call(
                typeof(Queryable),
                "OrderBy",
                new Type[] { queryableData.ElementType, queryableData.ElementType },
                whereCallExpression,
                Expression.Lambda<Func<string, string>>(pe, new ParameterExpression[] { pe }));
            // ***** End OrderBy *****

            // Create an executable query from the expression tree.
            IQueryable<string> results = queryableData.Provider.CreateQuery<string>(orderByCallExpression);

            // Enumerate the results.
            foreach (string company in results)
                Console.WriteLine(company);
        }

    }
}
