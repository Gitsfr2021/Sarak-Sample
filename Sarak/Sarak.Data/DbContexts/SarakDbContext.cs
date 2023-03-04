using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sarak.Data.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sarak.Data.DbContexts
{
    public class SarakDbContext : IdentityDbContext<User, Role, string>
    {
        public Guid UserId = Guid.Parse("00000000-0000-0000-0000-000000000000");
        public DbContextOptions<SarakDbContext> Options { get; set; }

        public SarakDbContext(DbContextOptions<SarakDbContext> options) : base(options)
        {
            this.Options = options;
        }

        #region Products
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            //#region ها Cascade Delete  حذف همه 
            //var cascadeFKs = builder.Model.GetEntityTypes()
            //        .SelectMany(t => t.GetForeignKeys())
            //        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            //foreach (var fk in cascadeFKs)
            //    fk.DeleteBehavior = DeleteBehavior.Restrict;
            //#endregion

            builder.Entity<User>().ToTable("Users");
            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<UserRole>().ToTable("UserRoles");

        }

        #region SaveChanges overrides

        public new int SaveChanges(bool ignoreFilter = default)
        {
            try
            {
                //DataChangeTracking();

                //if (!ignoreFilter)
                //    SetBrachID();

                return base.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SaveChanges(bool acceptAllChangesOnSuccess, bool ignoreFilter = default)
        {
            try
            {
                //DataChangeTracking();

                //if (!ignoreFilter)
                //    SetBrachID();

                return base.SaveChanges(acceptAllChangesOnSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken), bool ignoreFilter = default)
        {
            try
            {
                // DataChangeTracking();

                //if (!ignoreFilter)
                //    SetBrachID();
                return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken), bool ignoreFilter = default)
        {
            try
            {
                //DataChangeTracking();
                //if (!ignoreFilter)
                //    SetBrachID();
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
