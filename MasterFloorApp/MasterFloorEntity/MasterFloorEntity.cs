using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MasterFloorApp
{
    public partial class MasterFloorEntity : DbContext
    {
        public MasterFloorEntity()
            : base("name=MasterFloorEntity")
        {
        }

        public virtual DbSet<MaterialType> MaterialType { get; set; }
        public virtual DbSet<PartnerProduct> PartnerProduct { get; set; }
        public virtual DbSet<Partners> Partners { get; set; }
        public virtual DbSet<PartnerType> PartnerType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaterialType>()
                .Property(e => e.typeMaterial)
                .IsUnicode(false);

            modelBuilder.Entity<Partners>()
                .Property(e => e.namePartner)
                .IsUnicode(false);

            modelBuilder.Entity<Partners>()
                .Property(e => e.directorName)
                .IsUnicode(false);

            modelBuilder.Entity<Partners>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Partners>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Partners>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Partners>()
                .Property(e => e.inn)
                .IsUnicode(false);

            modelBuilder.Entity<Partners>()
                .HasMany(e => e.PartnerProduct)
                .WithOptional(e => e.Partners)
                .HasForeignKey(e => e.idPartner);

            modelBuilder.Entity<PartnerType>()
                .Property(e => e.typePartner)
                .IsUnicode(false);

            modelBuilder.Entity<PartnerType>()
                .HasMany(e => e.Partners)
                .WithOptional(e => e.PartnerType)
                .HasForeignKey(e => e.idPartnerType);

            modelBuilder.Entity<Product>()
                .Property(e => e.nameProduct)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.articleNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.PartnerProduct)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.idProduct);

            modelBuilder.Entity<ProductType>()
                .Property(e => e.typeProduct)
                .IsUnicode(false);

            modelBuilder.Entity<ProductType>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.ProductType)
                .HasForeignKey(e => e.idTypeProduct);
        }
    }
}
