using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Divar.Db;

public partial class DivarContext : DbContext
{
    public DivarContext()
    {
    }

    public DivarContext(DbContextOptions<DivarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Advertisement> Advertisements { get; set; }

    public virtual DbSet<AdvertisementImage> AdvertisementImages { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<ViwShowAdvertisement> ViwShowAdvertisements { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-206H5QD;Initial Catalog=Divar;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Advertisement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_advertisement");

            entity.ToTable("Advertisement");

            entity.Property(e => e.BasePrice).HasColumnType("money");
            entity.Property(e => e.Brand).HasMaxLength(50);
            entity.Property(e => e.ChassisAndBodyCondition).HasMaxLength(50);
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.EngineCondition).HasMaxLength(50);
            entity.Property(e => e.FrontChassisCondition).HasMaxLength(50);
            entity.Property(e => e.Gearbox).HasMaxLength(50);
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ItsModel).HasMaxLength(50);
            entity.Property(e => e.Latitude)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Longitude)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NationalCode)
                .HasMaxLength(11)
                .IsFixedLength();
            entity.Property(e => e.Nationality).HasMaxLength(15);
            entity.Property(e => e.RearChassisCondition).HasMaxLength(50);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Active");
            entity.Property(e => e.ThirdPartyInsuranceTerm).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.Advertisements)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Advertisement_Category1");

            entity.HasOne(d => d.City).WithMany(p => p.Advertisements)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_Advertisement_City");
        });

        modelBuilder.Entity<AdvertisementImage>(entity =>
        {
            entity.ToTable("AdvertisementImage");

            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValue("Active");
            entity.Property(e => e.Url).IsUnicode(false);

            entity.HasOne(d => d.Advertisement).WithMany(p => p.AdvertisementImages)
                .HasForeignKey(d => d.AdvertisementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdvertisementImage_Advertisement");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValue("Active");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("City");

            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValue("Active");
        });

        modelBuilder.Entity<ViwShowAdvertisement>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViwShowAdvertisements");

            entity.Property(e => e.BasePrice).HasColumnType("money");
            entity.Property(e => e.Image).HasColumnType("image");
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
