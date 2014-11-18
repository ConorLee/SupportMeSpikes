using SupportMe.Data.Model;
using SupportMe.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportMe.Data
{
    /// <summary>
    /// Represents the concrete unit of work used for DBAccess
    /// </summary>
    public class EntityUnitOfWork : DbContext, IUnitOfWork
    {
        #region EF DBSets. Needed Because of EF

        private IDbSet<Person> personRepository { get; set; }

        #endregion 

        #region Constructor

        /// <summary>
        /// Constructs a new UnitOfWork using the standard connection string
        /// </summary>
        public EntityUnitOfWork(): base("smdbconn")
        {
            personRepository = this.Set<Person>();
            PersonRepository = new Repository<Person>(personRepository); 

            Database.SetInitializer(new System.Data.Entity.MigrateDatabaseToLatestVersion<EntityUnitOfWork, Configuration>());
        }

        #endregion  

        #region Unit Of Work Repositories

        /// <summary>
        /// Gets the offers repository
        /// </summary>
        public IRepository<Person> PersonRepository { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Commits any outstanding changes to the database. 
        /// </summary>
        public void Commit()
        {
            this.SaveChanges();
        }

        /// <summary>
        /// Allow for fine grain database creation
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Allows for the automatic setting of Audit Properties.
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            foreach (var auditableEntity in ChangeTracker.Entries<BaseEntity>())
            {
                if (auditableEntity.State == EntityState.Added || auditableEntity.State == EntityState.Modified)
                {
                    auditableEntity.Entity.Updated = DateTime.Now;

                    if (auditableEntity.State == EntityState.Added)
                    {
                        auditableEntity.Entity.Created = DateTime.Now;
                    }
                    else
                    {
                        auditableEntity.Property(p => p.Created).IsModified = false;
                        auditableEntity.Property(p => p.Updated).IsModified = false;
                    }
                }
            }

            return base.SaveChanges();
        }

        #endregion 
    }
}
