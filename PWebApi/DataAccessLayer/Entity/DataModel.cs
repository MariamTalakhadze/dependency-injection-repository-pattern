namespace DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {

        }

        public virtual DbSet<Agwera> Agweras { get; set; }
        public virtual DbSet<Momxmarebeli> Momxmarebelis { get; set; }
        public virtual DbSet<Shekvetebi> Shekvetebis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agwera>()
                .Property(e => e.Dasaxeleba)
                .IsFixedLength();

            modelBuilder.Entity<Momxmarebeli>()
                .Property(e => e.Saxeli)
                .IsFixedLength();

            modelBuilder.Entity<Momxmarebeli>()
                .Property(e => e.Gvari)
                .IsFixedLength();

            modelBuilder.Entity<Momxmarebeli>()
                .Property(e => e.Nomeri)
                .IsFixedLength();

            modelBuilder.Entity<Momxmarebeli>()
                .Property(e => e.Statusi)
                .IsFixedLength();

            modelBuilder.Entity<Shekvetebi>()
                .Property(e => e.Shemkveti)
                .IsFixedLength();

            modelBuilder.Entity<Shekvetebi>()
                .Property(e => e.dasaxeleba)
                .IsFixedLength();
        }
    }
}
