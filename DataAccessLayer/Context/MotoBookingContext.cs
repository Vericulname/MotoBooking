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

    public virtual DbSet<TblDonDatXe> TblDonDatXes { get; set; }

    public virtual DbSet<TblHoaDon> TblHoaDons { get; set; }

    public virtual DbSet<TblHopDong> TblHopDongs { get; set; }

    public virtual DbSet<TblKhachhang> TblKhachhangs { get; set; }

    public virtual DbSet<TblLoaiHuHong> TblLoaiHuHongs { get; set; }

    public virtual DbSet<TblNhanvien> TblNhanviens { get; set; }

    public virtual DbSet<TblTaiKhoan> TblTaiKhoans { get; set; }

    public virtual DbSet<TblXe> TblXes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=NIKOCUTE;Initial Catalog=MotoBooking;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblDonDatXe>(entity =>
        {
            entity.HasKey(e => e.PkIDonDat).HasName("PK__tblDonDa__0E5EC6C38E6ADD64");

            entity.Property(e => e.DNgayTao).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.FkIKhachhangNavigation).WithMany(p => p.TblDonDatXes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_iKhachHang_tbDonDatXe");

            entity.HasOne(d => d.FkIXeNavigation).WithMany(p => p.TblDonDatXes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_iXe_tbDonDatXe");
        });

        modelBuilder.Entity<TblHoaDon>(entity =>
        {
            entity.HasKey(e => e.PkIHoaDon).HasName("PK__tblHoaDo__6B5DB2B1D732225B");

            entity.Property(e => e.DNgayLap).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.FkIHopDongNavigation).WithMany(p => p.TblHoaDons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_iHopDong_tblHoaDon");

            entity.HasOne(d => d.FkILoaiHuHongNavigation).WithMany(p => p.TblHoaDons).HasConstraintName("FK_iLoaiHuHong_tblHoaDon");
        });

        modelBuilder.Entity<TblHopDong>(entity =>
        {
            entity.HasKey(e => e.PkIHopDong).HasName("PK__tblHopDo__AC7D3350EBC32563");

            entity.Property(e => e.DGiaoThucTe).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.FkIDonDatNavigation).WithMany(p => p.TblHopDongs).HasConstraintName("FK_iDonDat_tbHopDong");

            entity.HasOne(d => d.FkIKhachhangNavigation).WithMany(p => p.TblHopDongs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_iKhachHang_tbHopDong");

            entity.HasOne(d => d.FkINhanvienNavigation).WithMany(p => p.TblHopDongs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_iNhanvien_tbHopDong");

            entity.HasOne(d => d.FkIXeNavigation).WithMany(p => p.TblHopDongs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_iXe_tbHopDong");
        });

        modelBuilder.Entity<TblKhachhang>(entity =>
        {
            entity.HasKey(e => e.PkIKhachhang).HasName("PK__tblKhach__A452B8334A185BAE");

            entity.Property(e => e.DNgayTao).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.FkITaiKhoanNavigation).WithMany(p => p.TblKhachhangs).HasConstraintName("FK__tblKhachh__Fk_iT__3B95D2F1");
        });

        modelBuilder.Entity<TblLoaiHuHong>(entity =>
        {
            entity.HasKey(e => e.PkILoaiHuHong).HasName("PK__tblLoaiH__2A25785C845BC629");
        });

        modelBuilder.Entity<TblNhanvien>(entity =>
        {
            entity.HasKey(e => e.PkINhanvien).HasName("PK__tblNhanv__10619B37BCD1F8A1");

            entity.Property(e => e.DNgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SVaiTro).HasDefaultValue("staff");

            entity.HasOne(d => d.FkITaiKhoanNavigation).WithMany(p => p.TblNhanviens).HasConstraintName("FK__tblNhanvi__Fk_iT__3C89F72A");
        });

        modelBuilder.Entity<TblTaiKhoan>(entity =>
        {
            entity.HasKey(e => e.PkITaiKhoan).HasName("PK__tblTaiKh__952402C559CB857C");
        });

        modelBuilder.Entity<TblXe>(entity =>
        {
            entity.HasKey(e => e.PkIXe).HasName("PK__tblXe__08A93450BD85DD4E");

            entity.Property(e => e.STrangThai).HasDefaultValue("available");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
