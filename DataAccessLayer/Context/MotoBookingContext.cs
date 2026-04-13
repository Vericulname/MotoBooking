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

            entity.ToTable("tbDonDatXe");

            entity.Property(e => e.PkIDonDat).HasColumnName("PK_iDonDat");
            entity.Property(e => e.DNgayHuy)
                .HasColumnType("datetime")
                .HasColumnName("dNgayHuy");
            entity.Property(e => e.DNgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dNgayTao");
            entity.Property(e => e.DThoiGianBatDau)
                .HasColumnType("datetime")
                .HasColumnName("dThoiGianBatDau");
            entity.Property(e => e.DThoiGianKetThuc)
                .HasColumnType("datetime")
                .HasColumnName("dThoiGianKetThuc");
            entity.Property(e => e.FGiaTamTinh)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("fGiaTamTinh");
            entity.Property(e => e.FTienCoc)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("fTienCoc");
            entity.Property(e => e.FkIKhachhang).HasColumnName("FK_iKhachhang");
            entity.Property(e => e.FkIXe).HasColumnName("FK_iXe");
            entity.Property(e => e.STrangThai)
                .HasMaxLength(20)
                .HasColumnName("sTrangThai");

            entity.HasOne(d => d.FkIKhachhangNavigation).WithMany(p => p.TbDonDatXes)
                .HasForeignKey(d => d.FkIKhachhang)
                .HasConstraintName("FK_iKhachHang_tbDonDatXe");

            entity.HasOne(d => d.FkIXeNavigation).WithMany(p => p.TbDonDatXes)
                .HasForeignKey(d => d.FkIXe)
                .HasConstraintName("FK_iXe_tbDonDatXe");
        });

        modelBuilder.Entity<TbHoaDon>(entity =>
        {
            entity.HasKey(e => e.PkIHoaDon).HasName("PK__tbHoaDon__6B5DB2B155B2EA1B");

            entity.ToTable("tbHoaDon");

            entity.Property(e => e.PkIHoaDon).HasColumnName("PK_iHoaDon");
            entity.Property(e => e.DNgayLap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dNgayLap");
            entity.Property(e => e.FTongTien)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("fTongTien");
            entity.Property(e => e.FkIHopDong).HasColumnName("FK_iHopDong");
            entity.Property(e => e.SPhuongThucThanhToan)
                .HasMaxLength(20)
                .HasColumnName("sPhuongThucThanhToan");
            entity.Property(e => e.STrangThaiThanhToan)
                .HasMaxLength(20)
                .HasColumnName("sTrangThaiThanhToan");

            entity.HasOne(d => d.FkIHopDongNavigation).WithMany(p => p.TbHoaDons)
                .HasForeignKey(d => d.FkIHopDong)
                .HasConstraintName("FK_iHopDong_tbHoaDon");
        });

        modelBuilder.Entity<TbHopDong>(entity =>
        {
            entity.HasKey(e => e.PkIHopDong).HasName("PK__tbHopDon__AC7D3350E14F60F8");

            entity.ToTable("tbHopDong");

            entity.Property(e => e.PkIHopDong).HasColumnName("PK_iHopDong");
            entity.Property(e => e.DGiaoThucTe)
                .HasColumnType("datetime")
                .HasColumnName("dGiaoThucTe");
            entity.Property(e => e.DTraDuKien)
                .HasColumnType("datetime")
                .HasColumnName("dTraDuKien");
            entity.Property(e => e.DTraThucTe)
                .HasColumnType("datetime")
                .HasColumnName("dTraThucTe");
            entity.Property(e => e.FPhatHuHong)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("fPhatHuHong");
            entity.Property(e => e.FPhatTraMuon)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("fPhatTraMuon");
            entity.Property(e => e.FTienCocDaNhan)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("fTienCocDaNhan");
            entity.Property(e => e.FTienHoanLai)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("fTienHoanLai");
            entity.Property(e => e.FTienThueThucTe)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("fTienThueThucTe");
            entity.Property(e => e.FTongTien)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("fTongTien");
            entity.Property(e => e.FkIDonDat).HasColumnName("FK_iDonDat");
            entity.Property(e => e.FkIKhachhang).HasColumnName("FK_iKhachhang");
            entity.Property(e => e.FkILoaiHuHong).HasColumnName("FK_iLoaiHuHong");
            entity.Property(e => e.FkINhanvien).HasColumnName("FK_iNhanvien");
            entity.Property(e => e.FkIXe).HasColumnName("FK_iXe");
            entity.Property(e => e.STrangThai)
                .HasMaxLength(20)
                .HasColumnName("sTrangThai");

            entity.HasOne(d => d.FkIDonDatNavigation).WithMany(p => p.TbHopDongs)
                .HasForeignKey(d => d.FkIDonDat)
                .HasConstraintName("FK_iDonDat_tbHopDong");

            entity.HasOne(d => d.FkIKhachhangNavigation).WithMany(p => p.TbHopDongs)
                .HasForeignKey(d => d.FkIKhachhang)
                .HasConstraintName("FK_iKhachHang_tbHopDong");

            entity.HasOne(d => d.FkILoaiHuHongNavigation).WithMany(p => p.TbHopDongs)
                .HasForeignKey(d => d.FkILoaiHuHong)
                .HasConstraintName("FK_iLoaiHuHong_tbHopDong");

            entity.HasOne(d => d.FkINhanvienNavigation).WithMany(p => p.TbHopDongs)
                .HasForeignKey(d => d.FkINhanvien)
                .HasConstraintName("FK_iNhanvien_tbHopDong");

            entity.HasOne(d => d.FkIXeNavigation).WithMany(p => p.TbHopDongs)
                .HasForeignKey(d => d.FkIXe)
                .HasConstraintName("FK_iXe_tbHopDong");
        });

        modelBuilder.Entity<TbKhachhang>(entity =>
        {
            entity.HasKey(e => e.PkIKhachhang).HasName("PK__tbKhachh__A452B8335BD13061");

            entity.ToTable("tbKhachhang");

            entity.HasIndex(e => e.SSoDienThoai, "UQ__tbKhachh__B6E2FD9DA206C5E8").IsUnique();

            entity.Property(e => e.PkIKhachhang).HasColumnName("PK_iKhachhang");
            entity.Property(e => e.DNgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dNgayTao");
            entity.Property(e => e.SCccd)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("sCCCD");
            entity.Property(e => e.SDiaChi)
                .HasMaxLength(200)
                .HasColumnName("sDiaChi");
            entity.Property(e => e.SEmail)
                .HasMaxLength(100)
                .HasColumnName("sEmail");
            entity.Property(e => e.SHoTen)
                .HasMaxLength(100)
                .HasColumnName("sHoTen");
            entity.Property(e => e.SSoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sSoDienThoai");
        });

        modelBuilder.Entity<TbLoaiHuHong>(entity =>
        {
            entity.HasKey(e => e.PkILoaiHuHong).HasName("PK__tbLoaiHu__2A25785CE794488D");

            entity.ToTable("tbLoaiHuHong");

            entity.Property(e => e.PkILoaiHuHong).HasColumnName("PK_iLoaiHuHong");
            entity.Property(e => e.FPhiPhat)
                .HasMaxLength(100)
                .HasColumnName("fPhiPhat");
            entity.Property(e => e.STenHuHong)
                .HasMaxLength(100)
                .HasColumnName("sTenHuHong");
        });

        modelBuilder.Entity<TbNhanvien>(entity =>
        {
            entity.HasKey(e => e.PkINhanvien).HasName("PK__tbNhanvi__10619B37095AC3DD");

            entity.ToTable("tbNhanvien");

            entity.HasIndex(e => e.SSoDienThoai, "UQ__tbNhanvi__B6E2FD9DF5A449B3").IsUnique();

            entity.Property(e => e.PkINhanvien).HasColumnName("PK_iNhanvien");
            entity.Property(e => e.DNgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dNgayTao");
            entity.Property(e => e.SHoTen)
                .HasMaxLength(100)
                .HasColumnName("sHoTen");
            entity.Property(e => e.SMatKhau)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("sMatKhau");
            entity.Property(e => e.SSoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sSoDienThoai");
            entity.Property(e => e.SVaiTro)
                .HasMaxLength(20)
                .HasDefaultValue("staff")
                .HasColumnName("sVaiTro");
        });

        modelBuilder.Entity<TbXe>(entity =>
        {
            entity.HasKey(e => e.PkIXe).HasName("PK__tbXe__08A9345011DF2211");

            entity.ToTable("tbXe");

            entity.HasIndex(e => e.SBienSo, "UQ__tbXe__EDF66DCF673901C5").IsUnique();

            entity.Property(e => e.PkIXe).HasColumnName("PK_iXe");
            entity.Property(e => e.FGiaGio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("fGiaGio");
            entity.Property(e => e.FGiaNgay)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("fGiaNgay");
            entity.Property(e => e.ISoGhe).HasColumnName("iSoGhe");
            entity.Property(e => e.SAnhUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("sAnhURL");
            entity.Property(e => e.SBienSo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sBienSo");
            entity.Property(e => e.SLoaiXe)
                .HasMaxLength(50)
                .HasColumnName("sLoaiXe");
            entity.Property(e => e.SMoTa)
                .HasColumnType("ntext")
                .HasColumnName("sMoTa");
            entity.Property(e => e.SThuongHieu)
                .HasMaxLength(50)
                .HasColumnName("sThuongHieu");
            entity.Property(e => e.STrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("available")
                .HasColumnName("sTrangThai");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
