using Gtf.Interfaces;
using System.Data.Entity;
using System.Linq;

namespace Gtf.Entity
{
    public partial class MyContext : DbContext, IMyContext
    {
        public MyContext()
            : base("name=MyContext")
        {
            Database.SetInitializer<MyContext>(null);
        }

        public virtual DbSet<Meal> Meal { get; set; }
        public virtual DbSet<Period> Period { get; set; }
        public virtual DbSet<Type> Type { get; set; }

        public string GetMealDescription(int typeId, int periodId)
        {
            return Meal.First(x => x.TypeId == typeId && x.PeriodId == periodId).Description;
        }

        public Period GetFirstPeriod(string period)
        {
            return Period.First(x => x.Description == period);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Period>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Period>()
                .HasMany(e => e.Meal)
                .WithRequired(e => e.Period)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Meal)
                .WithRequired(e => e.Type)
                .WillCascadeOnDelete(false);
        }        
    }
}
