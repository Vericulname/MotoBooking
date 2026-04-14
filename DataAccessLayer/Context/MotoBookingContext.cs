using System;
using System.Collections.Generic;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context;

public partial class MotoBookingContext : DbContext
{
    public MotoBookingContext()
    {
    }

    public MotoBookingContext(DbContextOptions<MotoBookingContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer("Data Source=NIKOCUTE;Initial Catalog=MotoBooking;Integrated Security=True;TrustServerCertificate=True");
        }
    }

    public virtual DbSet<TbDonDatXe> TbDonDatXes { get; set; }

    public virtual DbSet<TbHoaDon> TbHoaDons { get; set; }

    public virtual DbSet<TbHopDong> TbHopDongs { get; set; }

    public virtual DbSet<TbKhachhang> TbKhachhangs { get; set; }

    public virtual DbSet<TbLoaiHuHong> TbLoaiHuHongs { get; set; }

    public virtual DbSet<TbNhanvien> TbNhanviens { get; set; }

    public virtual DbSet<TbXe> TbXes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbDonDatXe>(entity =>
        {
            entity.HasKey(e => e.PkIDonDat).HasName("PK__tbDonDat__0E5EC6C3236B871E");

            entity.Property(e => e.DNgayTao).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.FkIKhachhangNavigation).WithMany(p => p.TbDonDatXes).HasConstraintName("FK_iKhachHang_tbDonDatXe");

            entity.HasOne(d => d.FkIXeNavigation).WithMany(p => p.TbDonDatXes).HasConstraintName("FK_iXe_tbDonDatXe");
        });

        modelBuilder.Entity<TbHoaDon>(entity =>
        {
            entity.HasKey(e => e.PkIHoaDon).HasName("PK__tbHoaDon__6B5DB2B155B2EA1B");

            entity.Property(e => e.DNgayLap).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.FkIHopDongNavigation).WithMany(p => p.TbHoaDons).HasConstraintName("FK_iHopDong_tbHoaDon");
        });

        modelBuilder.Entity<TbHopDong>(entity =>
        {
            entity.HasKey(e => e.PkIHopDong).HasName("PK__tbHopDon__AC7D3350E14F60F8");

            entity.Property(e => e.FPhatHuHong).HasDefaultValue(0m);
            entity.Property(e => e.FPhatTraMuon).HasDefaultValue(0m);
            entity.Property(e => e.FTienHoanLai).HasDefaultValue(0m);

            entity.HasOne(d => d.FkIDonDatNavigation).WithMany(p => p.TbHopDongs).HasConstraintName("FK_iDonDat_tbHopDong");

            entity.HasOne(d => d.FkIKhachhangNavigation).WithMany(p => p.TbHopDongs).HasConstraintName("FK_iKhachHang_tbHopDong");

            entity.HasOne(d => d.FkILoaiHuHongNavigation).WithMany(p => p.TbHopDongs).HasConstraintName("FK_iLoaiHuHong_tbHopDong");

            entity.HasOne(d => d.FkINhanvienNavigation).WithMany(p => p.TbHopDongs).HasConstraintName("FK_iNhanvien_tbHopDong");

            entity.HasOne(d => d.FkIXeNavigation).WithMany(p => p.TbHopDongs).HasConstraintName("FK_iXe_tbHopDong");
        });

        modelBuilder.Entity<TbKhachhang>(entity =>
        {
            entity.HasKey(e => e.PkIKhachhang).HasName("PK__tbKhachh__A452B8335BD13061");

            entity.Property(e => e.DNgayTao).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TbLoaiHuHong>(entity =>
        {
            entity.HasKey(e => e.PkILoaiHuHong).HasName("PK__tbLoaiHu__2A25785CE794488D");
        });

        modelBuilder.Entity<TbNhanvien>(entity =>
        {
            entity.HasKey(e => e.PkINhanvien).HasName("PK__tbNhanvi__10619B37095AC3DD");

            entity.Property(e => e.DNgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SVaiTro).HasDefaultValue("staff");
        });

        modelBuilder.Entity<TbXe>(entity =>
        {
            entity.HasKey(e => e.PkIXe).HasName("PK__tbXe__08A9345011DF2211");

            entity.Property(e => e.STrangThai).HasDefaultValue("available");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
