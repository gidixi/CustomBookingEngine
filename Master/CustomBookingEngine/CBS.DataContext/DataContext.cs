using CBS.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CBS.DataContext;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Ottieni tutti gli overload del metodo Entity
        var entityMethods = typeof(ModelBuilder).GetMethods()
            .Where(m => m.Name == "Entity" && m.IsGenericMethod);

        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            var entityTypes = assembly.GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract && x.Namespace == "Test.MyEntity" && typeof(EntityAssembly).IsAssignableFrom(x));

            foreach (var type in entityTypes)
            {
                // Trova il metodo Entity che corrisponde al tipo di entità
                var entityMethod = entityMethods.FirstOrDefault(m => m.GetParameters().Length == 0);
                if (entityMethod != null)
                {
                    entityMethod.MakeGenericMethod(type)
                        .Invoke(modelBuilder, new object[] { });
                }
            }
        }

        /**
         * ApplyConfigurationsFromAssembly
         * 
         * Configura il modello di entità per un contesto di database da un assembly.
         * 
         * 
         * Add-Migration InitialCreate -Context CBS.DataContext.DataContext -Project CBS.DataContext -StartupProject CBS.WebAPI
         * 
         * 
         * Update-Database -Context CBS.DataContext.DataContext -Project CBS.DataContext -StartupProject CBS.WebAPI
         */

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityAssembly).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //optionsBuilder.UseSqlite("Data Source=finework.db");
        }
    }

    // Metodo per caricare automaticamente tutte le DbSet
    private void LoadDbSets()
    {
        var entityTypes = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(a => a.GetTypes())
            .Where(t => t.IsClass && !t.IsAbstract && t.Namespace == "Test.MyEntity" && typeof(EntityAssembly).IsAssignableFrom(t));

        foreach (var type in entityTypes)
        {
            var dbSetProperty = this.GetType().GetProperties()
                .FirstOrDefault(p => p.PropertyType == typeof(DbSet<>).MakeGenericType(type));

            if (dbSetProperty == null)
            {
                var dbSetType = typeof(DbSet<>).MakeGenericType(type);
                var dbSetPropertyInfo = this.GetType().GetProperty(type.Name, dbSetType);

                if (dbSetPropertyInfo == null)
                {
                    dbSetPropertyInfo = this.GetType().GetProperty(type.Name + "s", dbSetType);
                }

                if (dbSetPropertyInfo == null)
                {
                    dbSetPropertyInfo = this.GetType().GetProperty(type.Name + "es", dbSetType);
                }

                if (dbSetPropertyInfo == null)
                {
                    dbSetPropertyInfo = this.GetType().GetProperty(type.Name + "ies", dbSetType);
                }

                if (dbSetPropertyInfo == null)
                {
                    dbSetPropertyInfo = this.GetType().GetProperty(type.Name + "s", dbSetType);
                }

                if (dbSetPropertyInfo != null)
                {
                    var dbSet = this.GetType().GetMethod("Set", new Type[] { }).MakeGenericMethod(type).Invoke(this, null);
                    dbSetPropertyInfo.SetValue(this, dbSet);
                }
            }
        }
    }

    public override DbSet<TEntity> Set<TEntity>() where TEntity : class
    {
        LoadDbSets();
        return base.Set<TEntity>();
    }
}
