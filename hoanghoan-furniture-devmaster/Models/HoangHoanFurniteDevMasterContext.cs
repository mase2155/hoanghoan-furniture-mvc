using System;
using System.Collections.Generic;
using hoanghoan_furniture_devmaster.Models.DBModel;
using Microsoft.EntityFrameworkCore;

namespace hoanghoan_furniture_devmaster.Models;

public partial class HoangHoanFurniteDevMasterContext : DbContext
{
    public HoangHoanFurniteDevMasterContext()
    {
    }

    public HoangHoanFurniteDevMasterContext(DbContextOptions<HoangHoanFurniteDevMasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomerUser> CustomerUsers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.;Database=HoangHoanFurnite_DevMaster;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC27B1E3FF45");

            entity.HasIndex(e => e.Account, "UQ__Users__A7301CB7448036D7").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Account)
                .HasMaxLength(50)
                .HasColumnName("ACCOUNT");
            entity.Property(e => e.Avatar)
                .HasMaxLength(500)
                .HasColumnName("AVATAR");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("EMAIL");
            entity.Property(e => e.IdPhongBan).HasColumnName("ID_PHONG_BAN");
            entity.Property(e => e.IsAdmin).HasColumnName("IS_ADMIN");
            entity.Property(e => e.IsDelete).HasColumnName("IS_DELETE");
            entity.Property(e => e.MaNhanSu)
                .HasMaxLength(50)
                .HasColumnName("MA_NHAN_SU");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("NAME");
            entity.Property(e => e.NgayCapNhat)
                .HasColumnType("datetime")
                .HasColumnName("NGAY_CAP_NHAT");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("NGAY_TAO");
            entity.Property(e => e.NguoiCapNhat)
                .HasMaxLength(50)
                .HasColumnName("NGUOI_CAP_NHAT");
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(50)
                .HasColumnName("NGUOI_TAO");
            entity.Property(e => e.Password).HasColumnName("PASSWORD");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("PHONE");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("ROLE");
            entity.Property(e => e.Salt).HasColumnName("SALT");
            entity.Property(e => e.SessionToken).HasColumnName("SESSION_TOKEN");
            entity.Property(e => e.TrangThai)
                .HasDefaultValue(1)
                .HasColumnName("TRANG_THAI");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
