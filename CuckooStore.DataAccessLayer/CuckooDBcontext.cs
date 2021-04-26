using CuckooStore.Models;
using System.Data.Entity;

namespace CuckooStore.DataAccessLayer
{
    public class CuckooDBcontext : DbContext
    {
        public CuckooDBcontext()
            : base("name=CucKooStoreDb")
        {
        }
        public static CuckooDBcontext Create()
        {
            return new CuckooDBcontext();
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<BallotImportDetail> BallotImportDetails { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Coupon> Coupons { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<BallotImport> BallotImports { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BallotImport>()
                .HasMany(e => e.BallotImportDetails)
                .WithRequired(e => e.BallotImport)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Product>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .IsOptional();
            modelBuilder.Entity<Category>()
                .Property(p => p.Description)
                .IsOptional();
            modelBuilder.Entity<Coupon>()
               .Property(p => p.Description)
               .IsOptional();
            modelBuilder.Entity<BallotImport>()
                .Property(p => p.Kho)
                .IsOptional();
            modelBuilder.Entity<Order>()
                .Property(p => p.ToName)
                .IsOptional();
            modelBuilder.Entity<Order>()
               .Property(p => p.ToAddr)
               .IsOptional();
            modelBuilder.Entity<Order>()
               .Property(p => p.ToPhone)
               .IsOptional();
            modelBuilder.Entity<Coupon>()
               .Property(p => p.Description)
               .IsOptional();
            modelBuilder.Entity<User>()
               .Property(p => p.Image)
               .IsOptional();
            modelBuilder.Entity<Order>()
               .Property(p => p.UserID)
               .IsOptional();
            modelBuilder.Entity<Order>()
               .Property(p => p.Code)
               .IsOptional();
        }
    }
}
