namespace DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DModel : DbContext
    {
        public DModel()
            : base("name=DModel")
        {
        }

        public virtual DbSet<pkind> pkinds { get; set; }
        public virtual DbSet<POrder> POrders { get; set; }
        public virtual DbSet<PPrice> PPrices { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<userinfo> userinfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<pkind>()
                .Property(e => e.Title)
                .IsFixedLength();

            modelBuilder.Entity<pkind>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<pkind>()
                .HasMany(e => e.POrders)
                .WithRequired(e => e.pkind)
                .HasForeignKey(e => e.PID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pkind>()
                .HasMany(e => e.PPrices)
                .WithRequired(e => e.pkind)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<POrder>()
                .Property(e => e.Descrip)
                .IsFixedLength();

            modelBuilder.Entity<PPrice>()
                .Property(e => e.Time)
                .IsFixedLength();

            modelBuilder.Entity<PPrice>()
                .HasMany(e => e.POrders)
                .WithRequired(e => e.PPrice)
                .HasForeignKey(e => e.PriceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<userinfo>()
                .Property(e => e.NameSurname)
                .IsFixedLength();

            modelBuilder.Entity<userinfo>()
                .Property(e => e.MobileNumber)
                .IsFixedLength();

            modelBuilder.Entity<userinfo>()
                .HasMany(e => e.POrders)
                .WithRequired(e => e.userinfo)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);
        }
    }
}
