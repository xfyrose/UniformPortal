using System;
using System.Reflection;
using Autofac;
using Autofac.Builder;
using Autofac.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeStudy.Misc.Autofacs
{
    [TestClass]
    public class UnitTestAutofac
    {
        [TestMethod]
        public void TestMethod1()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<DatabaseManager>();
            //builder.RegisterType<SqlDatabase>().As<IDatabase>();
            builder.RegisterType<OracleDatabase>().AsSelf().As<IDatabase>();

            using (IContainer container = builder.Build())
            {
                DatabaseManager manager = container.Resolve<DatabaseManager>();
                manager.Search("SELECT * FROM USER");
                Console.WriteLine(container.IsRegistered<DatabaseManager>());
                Console.WriteLine(container.IsRegistered<SqlDatabase>());
                Console.WriteLine(container.IsRegistered<OracleDatabase>());
                Console.WriteLine(container.IsRegistered<IDatabase>());
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            ContainerBuilder builder = new ContainerBuilder();
            //builder.RegisterType<DatabaseManager>();
            builder.RegisterModule(new ConfigurationSettingsReader("autofac"));
            builder.RegisterModule(new ConfigurationSettingsReader("autofac2"));

            using (IContainer container = builder.Build())
            {
                DatabaseManager manager = container.Resolve<DatabaseManager>();
                manager.Search("SELECT * FROM USER");
                Console.WriteLine(container.IsRegistered<DatabaseManager>());
                Console.WriteLine(container.IsRegistered<SqlDatabase>());
                Console.WriteLine(container.IsRegistered<OracleDatabase>());
                Console.WriteLine(container.IsRegistered<IDatabase>());
            }
            Console.WriteLine("[CodeStudy.dll] " + Assembly.GetExecutingAssembly().FullName);  
        }

        [TestMethod]
        public void TestMethod3()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(Dal<>)).As(typeof(IDal<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();

            builder.Register(c => new PersonBll(c.Resolve<IRepository<Person>>()));
            //builder.Register(c => new CustomBll(c.Resolve<IRepository<Custom>>()));
            builder.RegisterType<CustomBll>();

            using (IContainer container = builder.Build(ContainerBuildOptions.None))
            {
                Person p = new Person() {Name = "小人", Age = 27};
                PersonBll m = container.Resolve<PersonBll>();
                m.Insert(p);

                Custom c = new Custom() {CustomName = "小小", CustomId = 10};
                CustomBll cc = container.Resolve<CustomBll>();
                cc.Update(c);
            }
        }

        [TestMethod]
        public void TestMethod4()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(Dal<>)).As(typeof(IDal<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();

            builder.RegisterGeneric(typeof(Bll<>)).InstancePerDependency();

            using (IContainer container = builder.Build(ContainerBuildOptions.None))
            {
                Person p = new Person() { Name = "小人", Age = 27 };
                Bll<Person> m = container.Resolve<Bll<Person>>();
                m.Insert(p);

                Custom c = new Custom() { CustomName = "小小", CustomId = 10 };
                Bll<Custom> cc = container.Resolve<Bll<Custom>>();
                cc.Update(c);
            }
        }

        [TestMethod]
        public void TestMethod5()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(Dal<>)).As(typeof(IDal<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(Bll<>)).As(typeof(IDependency<>)).InstancePerDependency();

            using (IContainer container = builder.Build(ContainerBuildOptions.None))
            {
                Person p = new Person() { Name = "小人", Age = 27 };
                Bll<Person> m = (Bll<Person>)container.Resolve<IDependency<Person>>();
                m.Insert(p);

                Custom c = new Custom() { CustomName = "小小", CustomId = 10 };
                Bll<Custom> cc = (Bll<Custom>)container.Resolve<IDependency<Custom>>();
                cc.Update(c);
            }
        }

        [TestMethod]
        public void TestMethod6()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(Dal<>)).As(typeof(IDal<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();

            Assembly dataAccess = Assembly.Load("CodeStudy");
            //builder.RegisterAssemblyTypes(dataAccess).Where(t => typeof(IDependency<>).IsAssignableFrom(t) && t.Name.Contains("Autofacs") && t.Name.Contains("Bll"));
            Console.WriteLine("typeof(IDependency<>).IsAssignableFrom(typeof(Bll<>)):" + typeof(IDependency<>).IsAssignableFrom(typeof(Bll<>))); ;
            Console.WriteLine("Bll<T>:" + typeof(Bll<>).Name);
            Console.WriteLine("Bll<T> BaseType: " + typeof(Bll<>).BaseType.FullName);
            builder.RegisterAssemblyTypes(dataAccess).Where(t =>
            {
                //Console.WriteLine(typeof(IDependency<>).IsAssignableFrom(t) && t.Name.Contains("Autofacs") && t.Name.EndsWith("Bll") ? t.ToString() : string.Empty);
                //Bll<T> : IDependency<T>无法扫描注册
                Console.WriteLine(t.FullName.Contains("Autofacs") ? t.Name : string.Empty);
                return t.FullName.Contains("Autofacs");
            });

            using (IContainer container = builder.Build(ContainerBuildOptions.None))
            {
                Person p = new Person() { Name = "小人", Age = 27 };
                PersonBll m = container.Resolve<PersonBll>();
                m.Insert(p);

                Custom c = new Custom() { CustomName = "小小", CustomId = 10 };
                CustomBll cc = container.Resolve<CustomBll>();
                cc.Update(c);

                //Person p = new Person() { Name = "小人", Age = 27 };
                //Bll<Person> m = container.Resolve<Bll<Person>>();
                //m.Insert(p);

                //Custom c = new Custom() { CustomName = "小小", CustomId = 10 };
                //Bll<Custom> cc = container.Resolve<Bll<Custom>>();
                //cc.Update(c);

                //Person p = new Person() { Name = "小人", Age = 27 };
                //Bll<Person> m = (Bll<Person>)container.Resolve<IDependency<Person>>();
                //m.Insert(p);

                //Custom c = new Custom() { CustomName = "小小", CustomId = 10 };
                //Bll<Custom> cc = (Bll<Custom>)container.Resolve<IDependency<Custom>>();
                //cc.Update(c);
            }
        }

        [TestMethod]
        public void TestMethod7()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(Dal<>)).As(typeof(IDal<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();

            Assembly dataAccess = Assembly.Load("CodeStudy");
            builder.RegisterAssemblyTypes(dataAccess).Where(t => typeof (IDependency).IsAssignableFrom(t) && t.Name.EndsWith("Bll"));

            using (IContainer container = builder.Build(ContainerBuildOptions.None))
            {
                Person p = new Person() { Name = "小人", Age = 27 };
                Person2Bll m = container.Resolve<Person2Bll>();
                m.Insert(p);

                Custom c = new Custom() { CustomName = "小小", CustomId = 10 };
                Custom2Bll cc = container.Resolve<Custom2Bll>();
                cc.Update(c);

            }
        }
    }
}
