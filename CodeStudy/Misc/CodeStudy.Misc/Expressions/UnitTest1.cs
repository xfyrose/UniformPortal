using System;
using System.Text;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeStudy.Misc.Expressions
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {

            Animal horse = new Animal();

            // Create a MemberExpression that represents getting
            // the value of the 'species' field of class 'Animal'.
            System.Linq.Expressions.MemberExpression memberExpression =
                System.Linq.Expressions.Expression.Field(
                    System.Linq.Expressions.Expression.Constant(horse),
                    "species");

            Console.WriteLine(memberExpression.ToString());
            Console.WriteLine(memberExpression.Expression.ToString());
            Console.WriteLine(memberExpression.Member.ToString());
            Console.WriteLine(memberExpression.NodeType.ToString());
            Console.WriteLine(memberExpression.Type.ToString());

            // This code produces the following output:
            //
            // value(CodeSnippets.FieldExample+Animal).species
        }

        [TestMethod]
        public void TestMethod2()
        {
            ParameterExpression param = Expression.Parameter(typeof(int));

            // Creating an expression for the method call and specifying its parameter.
            MethodCallExpression methodCall = Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(int) }), param);

            // The following statement first creates an expression tree,
            // then compiles it, and then runs it.
            Expression.Lambda<Action<int>>(methodCall, new ParameterExpression[] { param }).Compile()(10);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

            ParameterExpression param = Expression.Parameter(typeof(Animal), "examAnimal");
            PropertyInfo propInfo = typeof (Animal).GetProperty("Species");
            MemberExpression memberExpression = Expression.MakeMemberAccess(param, propInfo);
            Console.WriteLine(memberExpression.ToString());
        }

        [TestMethod]
        public void TestMethod4()
        {
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This parameter expression represents a variable that will hold the array.
            ParameterExpression arrayExpr = Expression.Parameter(typeof(int[]), "Array");

            // This parameter expression represents an array index.            
            ParameterExpression indexExpr = Expression.Parameter(typeof(int), "Index");

            // This parameter represents the value that will be added to a corresponding array element.
            ParameterExpression valueExpr = Expression.Parameter(typeof(int), "Value");

            // This expression represents an array access operation.
            // It can be used for assigning to, or reading from, an array element.
            Expression arrayAccessExpr = Expression.ArrayAccess(
                arrayExpr,
                indexExpr
            );

            // This lambda expression assigns a value provided to it to a specified array element.
            // The array, the index of the array element, and the value to be added to the element
            // are parameters of the lambda expression.
            Expression<Func<int[], int, int, int>> lambdaExpr = Expression.Lambda<Func<int[], int, int, int>>(
                Expression.Assign(arrayAccessExpr, Expression.Add(arrayAccessExpr, valueExpr)),
                arrayExpr,
                indexExpr,
                valueExpr
            );

            // Print out expressions.
            Console.WriteLine("Array Access Expression:");
            Console.WriteLine(arrayAccessExpr.ToString());

            Console.WriteLine("Lambda Expression:");
            Console.WriteLine(lambdaExpr.ToString());

            Console.WriteLine("The result of executing the lambda expression:");

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            // Parameters passed to the Invoke method are passed to the lambda expression.
            Console.WriteLine(lambdaExpr.Compile().Invoke(new int[] { 10, 20, 30 }, 0, 5));

            // This code example produces the following output:
            //
            // Array Access Expression:
            // Array[Index]

            // Lambda Expression:
            // (Array, Index, Value) => (Array[Index] = (Array[Index] + Value))

            // The result of executing the lambda expression:
            // 15
        }

        [TestMethod]
        public void TestMethod5()
        {
            // Add the following directive to your file:
            // using System.Linq.Expressions;  

            // This expression represents a type convertion operation. 
            Expression convertExpr = Expression.Convert(
                                        Expression.Constant(5.5),
                                        typeof(Int16)
                                    );

            // Print out the expression.
            Console.WriteLine(convertExpr.ToString());
            Console.WriteLine(convertExpr.NodeType);
            Console.WriteLine(convertExpr.Type);

            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            Console.WriteLine(Expression.Lambda<Func<Int16>>(convertExpr).Compile()());

            // This code example produces the following output:
            //
            // Convert(5.5)
            // 5
        }

        [TestMethod]
        public void TestMethod6()
        {
            var p = new Product() { Price = 30 };

            Expression<Func<Product, bool>> predicate = x => x.Price == p.Price;
            BinaryExpression eq = (BinaryExpression)predicate.Body;
            MemberExpression productToPrice = (MemberExpression)eq.Right;

            //var objectMember = Expression.Convert(productToPrice, typeof(int));

            var getterLambda = Expression.Lambda<Func<int>>(productToPrice);

            var getter = getterLambda.Compile();

            Console.WriteLine(getter());

            Console.WriteLine();

            //System.Linq.Expressions.MemberExpression memberExpression =
            //    System.Linq.Expressions.Expression.Field(
            //        System.Linq.Expressions.Expression.Constant(p),
            //        "Price");

            //Console.WriteLine(memberExpression.ToString());
            //Console.WriteLine(memberExpression.Expression.ToString());
            //Console.WriteLine(memberExpression.Member.ToString());
            //Console.WriteLine(memberExpression.NodeType.ToString());
            //Console.WriteLine(memberExpression.Type.ToString());
        }
    }
}
