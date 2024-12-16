using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace STO.Models;

public partial class StoContext : DbContext
{
    public StoContext()
    {
    }

    public StoContext(DbContextOptions<StoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Carservice> Carservices { get; set; }

    public virtual DbSet<Carview> Carviews { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Madework> Madeworks { get; set; }

    public virtual DbSet<Master> Masters { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Part> Parts { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Wastepart> Wasteparts { get; set; }

    public virtual DbSet<Worktype> Worktypes { get; set; }

    public virtual DbSet<WpLog> WpLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=195.88.72.88;database=sto;user=sto_admin;password=qwerty", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("brands");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Website).HasMaxLength(30);
            entity.Property(e => e.Ws2)
                .HasMaxLength(255)
                .HasColumnName("WS2");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("car");

            entity.HasIndex(e => e.ClientId, "fk_Car_Clients_1");

            entity.HasIndex(e => e.ModelId, "fk_Car_Models_1");

            entity.Property(e => e.Color)
                .HasMaxLength(20)
                .HasColumnName("color");
            entity.Property(e => e.Mileage).HasColumnName("mileage");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Client).WithMany(p => p.Cars)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("fk_Car_Clients_1");

            entity.HasOne(d => d.Model).WithMany(p => p.Cars)
                .HasForeignKey(d => d.ModelId)
                .HasConstraintName("fk_Car_Models_1");
        });

        modelBuilder.Entity<Carservice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("carservice");

            entity.HasIndex(e => e.CarId, "fk_CarService_Car_1");

            entity.HasIndex(e => e.UserId, "fk_CarService_Users_1");

            entity.Property(e => e.Price).HasPrecision(10, 2);

            entity.HasOne(d => d.Car).WithMany(p => p.Carservices)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("fk_CarService_Car_1");

            entity.HasOne(d => d.User).WithMany(p => p.Carservices)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_CarService_Users_1");
        });

        modelBuilder.Entity<Carview>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("carview");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.BramdName)
                .HasMaxLength(50)
                .HasColumnName("bramdName");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.Modelname)
                .HasMaxLength(50)
                .HasColumnName("modelname");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("clients");

            entity.HasIndex(e => e.PersonId, "fk_Clients_Persons_1");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.PersonId).HasColumnName("personId");

            entity.HasOne(d => d.Person).WithMany(p => p.Clients)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Clients_Persons_1");
        });

        modelBuilder.Entity<Madework>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("madeworks");

            entity.HasIndex(e => e.Csid, "fk_MadeWorks_CarService_1");

            entity.HasIndex(e => e.MasterId, "fk_MadeWorks_Masters_1");

            entity.HasIndex(e => e.Wtid, "fk_MadeWorks_WorkType_1");

            entity.Property(e => e.Csid).HasColumnName("CSId");
            entity.Property(e => e.Price).HasPrecision(10, 2);
            entity.Property(e => e.Wtid).HasColumnName("WTId");

            entity.HasOne(d => d.Cs).WithMany(p => p.Madeworks)
                .HasForeignKey(d => d.Csid)
                .HasConstraintName("fk_MadeWorks_CarService_1");

            entity.HasOne(d => d.Master).WithMany(p => p.Madeworks)
                .HasForeignKey(d => d.MasterId)
                .HasConstraintName("fk_MadeWorks_Masters_1");

            entity.HasOne(d => d.Wt).WithMany(p => p.Madeworks)
                .HasForeignKey(d => d.Wtid)
                .HasConstraintName("fk_MadeWorks_WorkType_1");
        });

        modelBuilder.Entity<Master>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("masters");

            entity.HasIndex(e => e.PersonId, "fk_Masters_Persons_1");

            entity.Property(e => e.Specialization).HasMaxLength(200);

            entity.HasOne(d => d.Person).WithMany(p => p.Masters)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Masters_Persons_1");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("models");

            entity.HasIndex(e => e.BrandId, "fk_Models_Brands_1");

            entity.Property(e => e.BrandId).HasColumnName("brandId");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Revision)
                .HasMaxLength(10)
                .HasColumnName("revision");

            entity.HasOne(d => d.Brand).WithMany(p => p.Models)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("fk_Models_Brands_1");
        });

        modelBuilder.Entity<Part>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("parts");

            entity.Property(e => e.CurPrice).HasPrecision(10, 2);
            entity.Property(e => e.PartClass).HasMaxLength(200);
            entity.Property(e => e.PartName).HasMaxLength(200);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("persons");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.PersonId, "fk_Users_Persons_1");

            entity.Property(e => e.Login)
                .HasMaxLength(30)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .HasColumnName("password");
            entity.Property(e => e.PersonId).HasColumnName("personId");
            entity.Property(e => e.Role).HasColumnName("role");

            entity.HasOne(d => d.Person).WithMany(p => p.Users)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Users_Persons_1");
        });

        modelBuilder.Entity<Wastepart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("wasteparts");

            entity.HasIndex(e => e.Csid, "fk_WasteParts_CarService_1");

            entity.HasIndex(e => e.PartId, "fk_WasteParts_Parts_1");

            entity.Property(e => e.Csid).HasColumnName("CSId");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");

            entity.HasOne(d => d.Cs).WithMany(p => p.Wasteparts)
                .HasForeignKey(d => d.Csid)
                .HasConstraintName("fk_WasteParts_CarService_1");

            entity.HasOne(d => d.Part).WithMany(p => p.Wasteparts)
                .HasForeignKey(d => d.PartId)
                .HasConstraintName("fk_WasteParts_Parts_1");
        });

        modelBuilder.Entity<Worktype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("worktype");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.WtPrice)
                .HasPrecision(10, 2)
                .HasColumnName("wtPrice");
        });

        modelBuilder.Entity<WpLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("wp_log");

            entity.HasIndex(e => e.ModifierId, "fk_WP_Log_Persons_1");

            entity.HasIndex(e => e.WpId, "fk_WP_Log_WasteParts_1");

            entity.Property(e => e.ModifierId).HasColumnName("modifierId");
            entity.Property(e => e.Timemodifed)
                .HasColumnType("datetime")
                .HasColumnName("timemodifed");
            entity.Property(e => e.WpId).HasColumnName("WP_Id");
            entity.Property(e => e.WpPrice)
                .HasPrecision(10, 2)
                .HasColumnName("WP_Price");

            entity.HasOne(d => d.Modifier).WithMany(p => p.WpLogs)
                .HasForeignKey(d => d.ModifierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_WP_Log_Persons_1");

            entity.HasOne(d => d.Wp).WithMany(p => p.WpLogs)
                .HasForeignKey(d => d.WpId)
                .HasConstraintName("fk_WP_Log_WasteParts_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
