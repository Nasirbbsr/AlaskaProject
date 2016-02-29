using Alaska.Model.DataModel;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Alaska.Model.CommonModel;

namespace Alaska.DB.Infrastructure
{
    public sealed class AlaskaContext : DbContext
    {
        public DbSet<ScreenConfiguration> screenConfiguration { get; set; }
        public DbSet<ScreenControlDBMapper> screenControlDBMapper { get; set; }
        public DbSet<ScreenTableMapper> screenTableMapper { get; set; }
        public DbSet<LControlType> controlType { get; set; }
        public DbSet<ScreenDomainModel> screenDomainModel { get; set; }
        public AlaskaContext(string connstring) : base(connstring)
        {
            Database.SetInitializer<AlaskaContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure mappings
            //new FluentMapping.FluentMapping(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<ScreenDomainModel>().ToTable("ScreenDomainModel", "Core");
            modelBuilder.Entity<ScreenConfiguration>().ToTable("ScreenConfig", "Core");
            modelBuilder.Entity<ScreenControlDBMapper>().ToTable("ScreenControlsDbMapper", "Core");
            modelBuilder.Entity<ScreenTableMapper>().ToTable("ScreenDomainModelControl", "Core");
            modelBuilder.Entity<LControlType>().ToTable("ControlType", "Core");
        }
    }
}
