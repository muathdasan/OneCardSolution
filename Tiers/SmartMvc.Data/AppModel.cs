using SmartMvc.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMvc.Data
{
    public class AppModel : DbContext
    {
        public AppModel() : base("name=DefaultConnection")
        {
        }

        public DbSet<CategoryType> CategoryTypes { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<FoodMenu> FoodMenus { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //  modelBuilder.Entity<AppUser>().Map(m => m.MapInheritedProperties());

            //prevent delete parent with its dependencies automatically
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
