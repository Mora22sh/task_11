using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ch11.Models;

namespace ch11.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Drug> Drugs { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Staff> Staffs { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;initial catalog = BikeStores;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__brands__5E5A8E27C2C78CCC");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__categori__D54EE9B462CC9FFA");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyName).HasName("PK__Company__9BCE05DD49CC3206");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__customer__CD65CB8564765DA9");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctor__2DC00EDF0CEA7660");

            entity.Property(e => e.DoctorId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Drug>(entity =>
        {
            entity.HasKey(e => e.DrugId).HasName("PK__Drug__908D66F61C7516D7");

            entity.Property(e => e.DrugId).ValueGeneratedNever();

            entity.HasOne(d => d.CompanyNameNavigation).WithMany(p => p.Drugs)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Drug__CompanyNam__6EF57B66");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__orders__46596229D46D9784");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__orders__customer__5AEE82B9");

            entity.HasOne(d => d.Staff).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__orders__staff_id__5CD6CB2B");

            entity.HasOne(d => d.Store).WithMany(p => p.Orders).HasConstraintName("FK__orders__store_id__5BE2A6F2");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ItemId }).HasName("PK__order_it__837942D46944FDA7");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems).HasConstraintName("FK__order_ite__order__60A75C0F");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems).HasConstraintName("FK__order_ite__produ__619B8048");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.UrNumber).HasName("PK__Patient__6617A304D22BD88B");

            entity.Property(e => e.UrNumber).ValueGeneratedNever();

            entity.HasOne(d => d.Doctor).WithMany(p => p.Patients).HasConstraintName("FK__Patient__DoctorI__6C190EBB");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.PrescriptionId).HasName("PK__Prescrip__4013081279B61ACD");

            entity.Property(e => e.PrescriptionId).ValueGeneratedNever();

            entity.HasOne(d => d.Doctor).WithMany(p => p.Prescriptions).HasConstraintName("FK__Prescript__Docto__71D1E811");

            entity.HasOne(d => d.Drug).WithMany(p => p.Prescriptions).HasConstraintName("FK__Prescript__DrugI__73BA3083");

            entity.HasOne(d => d.UrNumberNavigation).WithMany(p => p.Prescriptions).HasConstraintName("FK__Prescript__UR_Nu__72C60C4A");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__products__47027DF57F5F1E5B");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products).HasConstraintName("FK__products__brand___4F7CD00D");

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("FK__products__catego__4E88ABD4");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__staffs__1963DD9C30AE5F2C");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager).HasConstraintName("FK__staffs__manager___5812160E");

            entity.HasOne(d => d.Store).WithMany(p => p.Staff).HasConstraintName("FK__staffs__store_id__571DF1D5");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => new { e.StoreId, e.ProductId }).HasName("PK__stocks__E68284D322B12F21");

            entity.HasOne(d => d.Product).WithMany(p => p.Stocks).HasConstraintName("FK__stocks__product___656C112C");

            entity.HasOne(d => d.Store).WithMany(p => p.Stocks).HasConstraintName("FK__stocks__store_id__6477ECF3");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PK__stores__A2F2A30C70EC7F05");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
