using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Contexts
{
    public class Context : DbContext, IDisposable
    {
        ~Context() => Dispose();

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Context(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }

        DbSet<LoginCadastroDomain> LoginDomain { get; set; }

        DbSet<AtivarContaDomain> AtivarContaDomain { get; set; }

        public async Task<bool> Save()
        {
            var save = await SaveChangesAsync() > 0;

            ChangeTracker.Clear();

            return save;
        }
    }
}
