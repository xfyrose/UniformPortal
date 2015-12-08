using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using Util.Core;
using Util.Core.Datas;
using Util.Core.Exceptions;
using Util.Datas.Ef.Exceptions;

namespace Util.Datas.Ef
{
    public class EfUnitOfWork : DbContext, IUnitOfWork
    {
        public string TraceId { get; private set; }

        protected EfUnitOfWork(string connectionName)
            : base(connectionName)
        {
            TraceId = Guid.NewGuid().ToString();
        }

        private bool IsStart { get; set; }

        public void Start()
        {
            IsStart = true;
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException(ex);
            }
            catch (DbEntityValidationException ex)
            {
                throw new EfValidationException(ex);
            }
            finally
            {
                IsStart = false;
            }
        }

        //internal void CommitByStart()
        public void CommitByStart()
        {
            if (IsStart)
            {
                return;
            }

            Commit();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            GetMapps().ForEach(mapper => mapper.AddTo(modelBuilder.Configurations));
        }

        private List<IMap> GetMapps()
        {
            List<IMap> result = new List<IMap>();
            GetAssemblies().ToList().ForEach(assembly =>
            {
                result.AddRange(Reflection.GetByInterface<IMap>(assembly));
            });

            return result;
        }

        protected virtual Assembly[] GetAssemblies()
        {
            return new[] { GetType().Assembly };
        }

        public static void Init(params IUnitOfWork[] unitOfWorks)
        {
            unitOfWorks.ToList().ForEach(InitUnitOfWork);
        }

        private static void InitUnitOfWork(IUnitOfWork unitOfWork)
        {
            using (unitOfWork)
            {
                IObjectContextAdapter adapter = unitOfWork as IObjectContextAdapter;
                if (adapter == null)
                {
                    return;
                }

                ObjectContext objectContext = adapter.ObjectContext;
                StorageMappingItemCollection mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                mappingCollection.GenerateViews(new List<EdmSchemaError>());
            }
        }
    }
}