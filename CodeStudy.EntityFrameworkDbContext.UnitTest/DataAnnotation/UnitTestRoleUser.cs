using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using CodeStudy.EntityFrameworkDbContext.DataAccess.DataAnnotation.Chapter02;
using CodeStudy.EntityFrameworkDbContext.Model.DataAnnotation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeStudy.EntityFrameworkDbContext.UnitTest.DataAnnotation
{
    /// <summary>
    /// Summary description for UnitTestRoleUser
    /// </summary>
    [TestClass]
    public class UnitTestRoleUser
    {
        public UnitTestRoleUser()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance { get; set; }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        //public TestContext TestContext
        //{
        //    get
        //    {
        //        return testContextInstance;
        //    }
        //    set
        //    {
        //        testContextInstance = value;
        //    }
        //}

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
        public void TestMethod_InitialDatabase()
        {
            using (RoleUserContext context = new RoleUserContext())
            {
                List<Role> roles = context.Roles.ToList();
                List<User> users = context.Users.ToList();

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_InsertData()
        {
            Role role1 = new Role { Id = "role1", RoleName = "rolename1" };
            Role role2 = new Role { Id = "role2", RoleName = "rolename2" };
            Role role3 = new Role { Id = "role3", RoleName = "rolename3" };
            Role role4 = new Role { Id = "role4", RoleName = "rolename4" };

            User user1 = new User { Id = "user1", UserName = "username1" };
            User user2 = new User { Id = "user2", UserName = "username2" };
            User user3 = new User { Id = "user3", UserName = "username3" };
            User user4 = new User { Id = "user4", UserName = "username4" };

            using (RoleUserContext context = new RoleUserContext())
            {
                context.Entry(role1).State = EntityState.Added;
                context.Entry(role2).State = EntityState.Added;
                context.Entry(role3).State = EntityState.Added;
                context.Entry(role4).State = EntityState.Added;

                context.Entry(user1).State = EntityState.Added;
                context.Entry(user2).State = EntityState.Added;
                context.Entry(user3).State = EntityState.Added;
                context.Entry(user4).State = EntityState.Added;

                //role1.Users = new List<User> { user1, user2, user3 };
                //role2.Users = new List<User> { user2, user3, user4 };

                context.SaveChanges();
            }
        }


        [TestMethod]
        public void TestMethod_InsertRelationship()
        {
            Role role1, role2, role3, role4;
            User user1, user2, user3, user4;

            using (RoleUserContext context = new RoleUserContext())
            {
                role1 = context.Roles.FirstOrDefault(r => r.Id == "role1");
                role2 = context.Roles.FirstOrDefault(r => r.Id == "role2");
                role3 = context.Roles.FirstOrDefault(r => r.Id == "role3");
                role4 = context.Roles.FirstOrDefault(r => r.Id == "role4");

                user1 = context.Users.FirstOrDefault(r => r.Id == "user1");
                user2 = context.Users.FirstOrDefault(r => r.Id == "user2");
                user3 = context.Users.FirstOrDefault(r => r.Id == "user3");
                user4 = context.Users.FirstOrDefault(r => r.Id == "user4");

                context.Entry(role1).Collection(r => r.Users).Load();
                context.Entry(role2).Collection(r => r.Users).Load();
            }

            RoleUserContext context2 = new RoleUserContext();
            //using ()
            {
                context2.Configuration.AutoDetectChangesEnabled = true;

                context2.Entry(role1).State = EntityState.Unchanged;
                context2.Entry(role2).State = EntityState.Unchanged;

                context2.Entry(user1).State = EntityState.Unchanged;
                context2.Entry(user2).State = EntityState.Unchanged;
                context2.Entry(user3).State = EntityState.Unchanged;
                context2.Entry(user4).State = EntityState.Unchanged;

                role1.Users.Add(user1);
                role1.Users.Add(user2);
                role1.Users.Add(user3);

                role2.Users.Add(user2);
                role2.Users.Add(user3);
                role2.Users.Add(user4);

                ((IObjectContextAdapter)context2).ObjectContext.ObjectStateManager.ChangeRelationshipState(
                    role1,
                    user4,
                    r => r.Users,
                    EntityState.Added);

                User user5 = new User {Id = "user5", UserName = "username5"};
                context2.Entry(user5).State = EntityState.Added;
                ((IObjectContextAdapter)context2).ObjectContext.ObjectStateManager.ChangeRelationshipState(
                    role1,
                    user5,
                    r => r.Users,
                    EntityState.Added);

                User user6 = new User { Id = "user6", UserName = "username6" };
                context2.Entry(user6).State = EntityState.Added;

                role1.Users.Add(user6);

                context2.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_SelectRelationship()
        {
            Role role1; //role2, role3, role4;
            //User user1, user2, user3, user4;

            using (RoleUserContext context = new RoleUserContext())
            {
                role1 = context.Roles.Include(r => r.Users).FirstOrDefault(r => r.Id == "role1");
            }

            using (RoleUserContext context = new RoleUserContext())
            {
                role1 = context.Roles.FirstOrDefault(r => r.Id == "role1");

                context.Entry(role1).Collection(r => r.Users).Load();
            }
        }

        [TestMethod]
        public void TestMethod_DeleteRelationship()
        {
            Role role1, role2, role3, role4;
            User user1, user2, user3, user4;

            using (RoleUserContext context = new RoleUserContext())
            {
                role1 = context.Roles.FirstOrDefault(r => r.Id == "role1");
                role2 = context.Roles.FirstOrDefault(r => r.Id == "role2");
                role3 = context.Roles.FirstOrDefault(r => r.Id == "role3");
                role4 = context.Roles.FirstOrDefault(r => r.Id == "role4");

                user1 = context.Users.FirstOrDefault(r => r.Id == "user1");
                user2 = context.Users.FirstOrDefault(r => r.Id == "user2");
                user3 = context.Users.FirstOrDefault(r => r.Id == "user3");
                user4 = context.Users.FirstOrDefault(r => r.Id == "user4");

                context.Entry(role1).Collection(r => r.Users).Load();
                context.Entry(role2).Collection(r => r.Users).Load();
            }

            RoleUserContext context2 = new RoleUserContext();
            context2.Configuration.AutoDetectChangesEnabled = false;
            //using ()
            {
                //role1.Users.Remove(user1);
                context2.Entry(role1).State = EntityState.Unchanged;
                context2.Entry(user1).State = EntityState.Unchanged;

                ((IObjectContextAdapter)context2).ObjectContext.ObjectStateManager.ChangeRelationshipState(
                    role1,
                    user1,
                    r => r.Users,
                    EntityState.Deleted);

                context2.Entry(user2).State = EntityState.Unchanged;
                role1.Users.Remove(user2);

                //context2.Entry(user4).State = EntityState.Unchanged;
                //((IObjectContextAdapter)context2).ObjectContext.ObjectStateManager.ChangeRelationshipState(
                //    role1,
                //    user4,
                //    r => r.Users,
                //    EntityState.Added);

                context2.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_DeleteRelationship2()
        {
            Role role1, role2, role3, role4;
            User user1, user2, user3, user4;

            using (RoleUserContext context = new RoleUserContext())
            {
                role1 = context.Roles.FirstOrDefault(r => r.Id == "role1");
                role2 = context.Roles.FirstOrDefault(r => r.Id == "role2");
                role3 = context.Roles.FirstOrDefault(r => r.Id == "role3");
                role4 = context.Roles.FirstOrDefault(r => r.Id == "role4");

                user1 = context.Users.FirstOrDefault(r => r.Id == "user1");
                user2 = context.Users.FirstOrDefault(r => r.Id == "user2");
                user3 = context.Users.FirstOrDefault(r => r.Id == "user3");
                user4 = context.Users.FirstOrDefault(r => r.Id == "user4");

                context.Entry(role1).Collection(r => r.Users).Load();
                context.Entry(role2).Collection(r => r.Users).Load();
            }

            RoleUserContext context2 = new RoleUserContext();
            context2.Configuration.AutoDetectChangesEnabled = true;
            //using ()
            {
                //role1.Users.Remove(user1);
                context2.Entry(user2).State = EntityState.Unchanged;
                context2.Users.Remove(user2);
                context2.SaveChanges();
            }
        }


        [TestMethod]
        public void TestMethod_SelectProxy()
        {
            Role role1;//, role2, role3, role4;
            //User user1, user2, user3, user4;

            using (RoleUserContext context = new RoleUserContext())
            {
                role1 = context.Roles.Include(r => r.Users).FirstOrDefault(r => r.Id == "role1");
                Console.WriteLine("role1原始Role: {0}", typeof (Role).FullName);
                Console.WriteLine("role1实际Role Dynamic Proxy: {0}", role1.GetType());
            }

        }

    }
}
