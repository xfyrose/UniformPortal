using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CodeStudy.EntityFrameworkCodeFirst.DataAccess.FluentApi.Chapter01;
using CodeStudy.EntityFrameworkCodeFirst.DataAccess.MigrationsDataAnnotationChapter01;
using CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter01;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalType = CodeStudy.EntityFrameworkCodeFirst.Model.DataAnnotation.Chapter01.AnimalType;
using Patient = CodeStudy.EntityFrameworkCodeFirst.Model.DataAnnotation.Chapter01.Patient;
using VetContext = CodeStudy.EntityFrameworkCodeFirst.DataAccess.DataAnnotation.Chapter01.VetContext;
using Visit = CodeStudy.EntityFrameworkCodeFirst.Model.DataAnnotation.Chapter01.Visit;

namespace CodeStudy.EntityFrameworkCodeFirst.UnitTest.DataAnnotation
{
    [TestClass]
    public class UnitTestChapter01
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Database.SetInitializer<VetContext>(new MigrateDatabaseToLatestVersion<VetContext, CodeStudy.EntityFrameworkCodeFirst.DataAccess.MigrationsDataAnnotationChapter01.Configuration>());

            AnimalType dog = new AnimalType { TypeName = "Dog" };

            Patient patient = new Patient
            {
                Name = "Sampson",
                BirthDate = new DateTime(2008, 1, 28),
                AnimalType = dog,
                FirstVisit = new DateTime(2008, 1, 29),
                Visits = new List<Visit>
                {
                    new Visit
                    {
                        Date = new DateTime(2011, 9, 1)
                    }
                }
            };

            Console.WriteLine("Start...");
            using (VetContext context = new VetContext())
            {
                context.Patients.Add(patient);
                context.SaveChanges();
            }
            Console.WriteLine("Stop...");
        }

        [TestMethod]
        public void TestMethod_IntialData()
        {
            using (RolePermissionContext context = new RolePermissionContext())
            {
                Role role = new Role
                {
                    Name = "role1",
                    Permissions = new List<Permission>
                    {
                        new Permission { Id = 1, Name = "p_1_1"},
                        new Permission { Id = 2, Name = "p_1_2"},
                        new Permission { Id = 3, Name = "p_1_3"}
                    }
                };

                context.Roles.Add(role);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_DeleteData()
        {
            using (RolePermissionContext context = new RolePermissionContext())
            {
                var role = context.Roles.Find(1);
                var permission = role.Permissions.Single(p => p.Id == 2);
                role.Permissions.Remove(permission);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestMethod_DeleteData2()
        {
            using (RolePermissionContext context = new RolePermissionContext())
            {
                var role = context.Roles.Find(1);
                var permission = role.Permissions.Single(p => p.Id == 2);
                role.Permissions.Remove(permission);
                context.SaveChanges();
            }
        }
    }
}
