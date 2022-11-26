using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HotelManagement.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BcDoanhThuNgay> BcDoanhThuNgays { get; set; }
        public virtual DbSet<ChiTietDatPhong> ChiTietDatPhongs { get; set; }
        public virtual DbSet<ChiTietKhachO> ChiTietKhachOs { get; set; }
        public virtual DbSet<CtBcDoanhThuNgay> CtBcDoanhThuNgays { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<DonDatPhong> DonDatPhongs { get; set; }
        public virtual DbSet<DonGiaoCa> DonGiaoCas { get; set; }
        public virtual DbSet<DonGiaoTien> DonGiaoTiens { get; set; }
        public virtual DbSet<GiaPhong> GiaPhongs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public virtual DbSet<PhieuDichVu> PhieuDichVus { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<Tang> Tangs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BcDoanhThuNgay>(entity =>
            {
                entity.HasKey(e => e.Mabc)
                    .HasName("PK__BC_DOANH__603FFF88B89FFE43");

                entity.ToTable("BC_DOANH_THU_NGAY");

                entity.Property(e => e.Mabc)
                    .HasColumnType("date")
                    .HasColumnName("MABC");

                entity.Property(e => e.ChenhLech)
                    .HasColumnType("money")
                    .HasColumnName("CHENH_LECH");

                entity.Property(e => e.MaTk)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MA_TK")
                    .IsFixedLength(true);

                entity.Property(e => e.TongDoanhThu)
                    .HasColumnType("money")
                    .HasColumnName("TONG_DOANH_THU");

                entity.Property(e => e.TongThucThu)
                    .HasColumnType("money")
                    .HasColumnName("TONG_THUC_THU");

                entity.HasOne(d => d.MaTkNavigation)
                    .WithMany(p => p.BcDoanhThuNgays)
                    .HasForeignKey(d => d.MaTk)
                    .HasConstraintName("FK__BC_DOANH___MA_TK__693CA210");
            });

            modelBuilder.Entity<ChiTietDatPhong>(entity =>
            {
                entity.HasKey(e => new { e.MaDonDatPhong, e.MaPhong })
                    .HasName("PK__CHI_TIET__A6E69B3E820E97FA");

                entity.ToTable("CHI_TIET_DAT_PHONG");

                entity.Property(e => e.MaDonDatPhong)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MA_DON_DAT_PHONG")
                    .IsFixedLength(true);

                entity.Property(e => e.MaPhong)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MA_PHONG")
                    .IsFixedLength(true);

                entity.Property(e => e.GioRa).HasColumnName("GIO_RA");

                entity.Property(e => e.GioVao).HasColumnName("GIO_VAO");

                entity.Property(e => e.NgayThueBd)
                    .HasColumnType("date")
                    .HasColumnName("NGAY_THUE_BD");

                entity.Property(e => e.NgayThueKt)
                    .HasColumnType("date")
                    .HasColumnName("NGAY_THUE_KT");

                entity.HasOne(d => d.MaDonDatPhongNavigation)
                    .WithMany(p => p.ChiTietDatPhongs)
                    .HasForeignKey(d => d.MaDonDatPhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CHI_TIET___MA_DO__4D94879B");

                entity.HasOne(d => d.MaPhongNavigation)
                    .WithMany(p => p.ChiTietDatPhongs)
                    .HasForeignKey(d => d.MaPhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CHI_TIET___MA_PH__4E88ABD4");
            });

            modelBuilder.Entity<ChiTietKhachO>(entity =>
            {
                entity.HasKey(e => new { e.MaKhachO, e.MaDonDat })
                    .HasName("PK__CHI_TIET__25C63A4FEB62704B");

                entity.ToTable("CHI_TIET_KHACH_O");

                entity.Property(e => e.MaKhachO)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MA_KHACH_O")
                    .IsFixedLength(true);

                entity.Property(e => e.MaDonDat)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MA_DON_DAT")
                    .IsFixedLength(true);

                entity.HasOne(d => d.MaDonDatNavigation)
                    .WithMany(p => p.ChiTietKhachOs)
                    .HasForeignKey(d => d.MaDonDat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CHI_TIET___MA_DO__4AB81AF0");

                entity.HasOne(d => d.MaKhachONavigation)
                    .WithMany(p => p.ChiTietKhachOs)
                    .HasForeignKey(d => d.MaKhachO)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CHI_TIET___MA_KH__49C3F6B7");
            });

            modelBuilder.Entity<CtBcDoanhThuNgay>(entity =>
            {
                entity.HasKey(e => e.MaBc)
                    .HasName("PK__CT_BC_DO__53E64F39451A135E");

                entity.ToTable("CT_BC_DOANH_THU_NGAY");

                entity.Property(e => e.MaBc)
                    .HasColumnType("date")
                    .HasColumnName("MA_BC");

                entity.Property(e => e.DoanhThu)
                    .HasColumnType("money")
                    .HasColumnName("DOANH_THU");

                entity.Property(e => e.PhuThu)
                    .HasColumnType("money")
                    .HasColumnName("PHU_THU");

                entity.Property(e => e.SoLuongHd).HasColumnName("SO_LUONG_HD");

                entity.Property(e => e.ThucThuTuHd)
                    .HasColumnType("money")
                    .HasColumnName("THUC_THU_TU_HD");

                entity.Property(e => e.TienChi)
                    .HasColumnType("money")
                    .HasColumnName("TIEN_CHI");

                entity.Property(e => e.TienDichVu)
                    .HasColumnType("money")
                    .HasColumnName("TIEN_DICH_VU");

                entity.Property(e => e.TienPhong)
                    .HasColumnType("money")
                    .HasColumnName("TIEN_PHONG");

                entity.HasOne(d => d.MaBcNavigation)
                    .WithOne(p => p.CtBcDoanhThuNgay)
                    .HasForeignKey<CtBcDoanhThuNgay>(d => d.MaBc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CT_BC_DOA__MA_BC__6C190EBB");
            });

            modelBuilder.Entity<DichVu>(entity =>
            {
                entity.HasKey(e => e.Madv)
                    .HasName("PK__DICH_VU__603F005550E008F1");

                entity.ToTable("DICH_VU");

                entity.Property(e => e.Madv)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MADV")
                    .IsFixedLength(true);

                entity.Property(e => e.DonGia)
                    .HasColumnType("money")
                    .HasColumnName("DON_GIA");

                entity.Property(e => e.NgayTao)
                    .HasColumnType("date")
                    .HasColumnName("NGAY_TAO");

                entity.Property(e => e.TenDv)
                    .HasMaxLength(50)
                    .HasColumnName("TEN_DV");

                entity.Property(e => e.TinhTheo)
                    .HasMaxLength(20)
                    .HasColumnName("TINH_THEO");

                entity.Property(e => e.TrangThai)
                    .HasMaxLength(30)
                    .HasColumnName("TRANG_THAI");
            });

            modelBuilder.Entity<DonDatPhong>(entity =>
            {
                entity.HasKey(e => e.Madd)
                    .HasName("PK__DON_DAT___603F004B98D9FF37");

                entity.ToTable("DON_DAT_PHONG");

                entity.Property(e => e.Madd)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MADD")
                    .IsFixedLength(true);

                entity.Property(e => e.GhiChu)
                    .HasMaxLength(250)
                    .HasColumnName("GHI_CHU");

                entity.Property(e => e.MaKhDat)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MA_KH_DAT")
                    .IsFixedLength(true);

                entity.Property(e => e.MaTk)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MA_TK")
                    .IsFixedLength(true);

                entity.Property(e => e.NgayTao)
                    .HasColumnType("date")
                    .HasColumnName("NGAY_TAO");

                entity.Property(e => e.SoTienCoc)
                    .HasColumnType("money")
                    .HasColumnName("SO_TIEN_COC");

                entity.Property(e => e.TongTien)
                    .HasColumnType("money")
                    .HasColumnName("TONG_TIEN");

                entity.Property(e => e.TrangThai)
                    .HasMaxLength(30)
                    .HasColumnName("TRANG_THAI");

                entity.HasOne(d => d.MaKhDatNavigation)
                    .WithMany(p => p.DonDatPhongs)
                    .HasForeignKey(d => d.MaKhDat)
                    .HasConstraintName("FK__DON_DAT_P__MA_KH__46E78A0C");

                entity.HasOne(d => d.MaTkNavigation)
                    .WithMany(p => p.DonDatPhongs)
                    .HasForeignKey(d => d.MaTk)
                    .HasConstraintName("FK__DON_DAT_P__MA_TK__45F365D3");
            });

            modelBuilder.Entity<DonGiaoCa>(entity =>
            {
                entity.HasKey(e => e.MaDonGiaoCa)
                    .HasName("PK__DON_GIAO__4BCBC9F64D989D03");

                entity.ToTable("DON_GIAO_CA");

                entity.Property(e => e.MaDonGiaoCa)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MA_DON_GIAO_CA")
                    .IsFixedLength(true);

                entity.Property(e => e.GhiChu)
                    .HasMaxLength(250)
                    .HasColumnName("GHI_CHU");

                entity.Property(e => e.MaTkCaSau)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MA_TK_CA_SAU")
                    .IsFixedLength(true);

                entity.Property(e => e.MaTkCaTruc)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MA_TK_CA_TRUC")
                    .IsFixedLength(true);

                entity.Property(e => e.TienChenhLech)
                    .HasColumnType("money")
                    .HasColumnName("TIEN_CHENH_LECH");

                entity.Property(e => e.TienGiaoCa)
                    .HasColumnType("money")
                    .HasColumnName("TIEN_GIAO_CA");

                entity.HasOne(d => d.MaTkCaSauNavigation)
                    .WithMany(p => p.DonGiaoCaMaTkCaSauNavigations)
                    .HasForeignKey(d => d.MaTkCaSau)
                    .HasConstraintName("FK__DON_GIAO___MA_TK__6FE99F9F");

                entity.HasOne(d => d.MaTkCaTrucNavigation)
                    .WithMany(p => p.DonGiaoCaMaTkCaTrucNavigations)
                    .HasForeignKey(d => d.MaTkCaTruc)
                    .HasConstraintName("FK__DON_GIAO___MA_TK__6EF57B66");
            });

            modelBuilder.Entity<DonGiaoTien>(entity =>
            {
                entity.HasKey(e => e.MaDonGiaoTien)
                    .HasName("PK__DON_GIAO__F7669B0B919B4056");

                entity.ToTable("DON_GIAO_TIEN");

                entity.Property(e => e.MaDonGiaoTien)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MA_DON_GIAO_TIEN")
                    .IsFixedLength(true);

                entity.Property(e => e.GhiChu)
                    .HasMaxLength(250)
                    .HasColumnName("GHI_CHU");

                entity.Property(e => e.HienCo)
                    .HasColumnType("money")
                    .HasColumnName("HIEN_CO");

                entity.Property(e => e.MaTkGiaoTien)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MA_TK_GIAO_TIEN")
                    .IsFixedLength(true);

                entity.Property(e => e.MaTkQuanLy)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MA_TK_QUAN_LY")
                    .IsFixedLength(true);

                entity.Property(e => e.TienNhan)
                    .HasColumnType("money")
                    .HasColumnName("TIEN_NHAN");

                entity.HasOne(d => d.MaTkGiaoTienNavigation)
                    .WithMany(p => p.DonGiaoTienMaTkGiaoTienNavigations)
                    .HasForeignKey(d => d.MaTkGiaoTien)
                    .HasConstraintName("FK__DON_GIAO___MA_TK__72C60C4A");

                entity.HasOne(d => d.MaTkQuanLyNavigation)
                    .WithMany(p => p.DonGiaoTienMaTkQuanLyNavigations)
                    .HasForeignKey(d => d.MaTkQuanLy)
                    .HasConstraintName("FK__DON_GIAO___MA_TK__73BA3083");
            });

            modelBuilder.Entity<GiaPhong>(entity =>
            {
                entity.HasKey(e => e.Magia)
                    .HasName("PK__GIA_PHON__7984C26BA22A5CA1");

                entity.ToTable("GIA_PHONG");

                entity.Property(e => e.Magia)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MAGIA")
                    .IsFixedLength(true);

                entity.Property(e => e.GhiChu)
                    .HasMaxLength(250)
                    .HasColumnName("GHI_CHU");

                entity.Property(e => e.GiaTheoGio)
                    .HasColumnType("money")
                    .HasColumnName("GIA_THEO_GIO");

                entity.Property(e => e.GiaTheoNgay)
                    .HasColumnType("money")
                    .HasColumnName("GIA_THEO_NGAY");

                entity.Property(e => e.GiaTheoThang)
                    .HasColumnType("money")
                    .HasColumnName("GIA_THEO_THANG");

                entity.Property(e => e.GiaTheoTuan)
                    .HasColumnType("money")
                    .HasColumnName("GIA_THEO_TUAN");

                entity.Property(e => e.NgayHieuLucBd)
                    .HasColumnType("date")
                    .HasColumnName("NGAY_HIEU_LUC_BD");

                entity.Property(e => e.NgayHieuLucKt)
                    .HasColumnType("date")
                    .HasColumnName("NGAY_HIEU_LUC_KT");
                entity.Property(e => e.Qua_1h)
                    .HasColumnType("money")
                    .HasColumnName("QUA_1H");
                entity.Property(e => e.Qua_2h)
                    .HasColumnType("money")
                    .HasColumnName("QUA_2H");
                entity.Property(e => e.Truoc_3h)
                    .HasColumnType("money")
                    .HasColumnName("TRUOC_3H");
                entity.Property(e => e.Truoc_4h)
                    .HasColumnType("money")
                    .HasColumnName("TRUOC_4H");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.Mahd)
                    .HasName("PK__HOA_DON__603F20CE45DA6CAE");

                entity.ToTable("HOA_DON");

                entity.Property(e => e.Mahd)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MAHD")
                    .IsFixedLength(true);

                entity.Property(e => e.GhiChu)
                    .HasMaxLength(250)
                    .HasColumnName("GHI_CHU");

                entity.Property(e => e.Httt)
                    .HasMaxLength(30)
                    .HasColumnName("HTTT");

                entity.Property(e => e.MaDonDat)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MA_DON_DAT")
                    .IsFixedLength(true);

                entity.Property(e => e.MaTaiKhoan)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MA_TAI_KHOAN")
                    .IsFixedLength(true);

                entity.Property(e => e.PhuThu)
                    .HasColumnType("money")
                    .HasColumnName("PHU_THU");

                entity.Property(e => e.TongTien)
                    .HasColumnType("money")
                    .HasColumnName("TONG_TIEN");

                entity.Property(e => e.TrangThai)
                    .HasMaxLength(30)
                    .HasColumnName("TRANG_THAI");

                entity.HasOne(d => d.MaDonDatNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaDonDat)
                    .HasConstraintName("FK__HOA_DON__MA_DON___628FA481");

                entity.HasOne(d => d.MaTaiKhoanNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaTaiKhoan)
                    .HasConstraintName("FK__HOA_DON__MA_TAI___6383C8BA");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.Makh)
                    .HasName("PK__KHACH_HA__603F592C4D7724B8");

                entity.ToTable("KHACH_HANG");

                entity.Property(e => e.Makh)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MAKH")
                    .IsFixedLength(true);

                entity.Property(e => e.Cmnd)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("CMND")
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                //entity.Property(e => e.NgayCap)
                //    .HasColumnType("date")
                //    .HasColumnName("NGAY_CAP");

                entity.Property(e => e.NgaySinh)
                    .HasColumnType("date")
                    .HasColumnName("NGAY_SINH");

                //entity.Property(e => e.NoiCap)
                //    .HasMaxLength(50)
                //    .HasColumnName("NOI_CAP");

                entity.Property(e => e.QuocTich)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QUOC_TICH");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("SDT")
                    .IsFixedLength(true);

                entity.Property(e => e.TenKh)
                    .HasMaxLength(100)
                    .HasColumnName("TEN_KH");

                entity.Property(e => e.GioiTinh).HasColumnName("GIOI_TINH");
            });

            modelBuilder.Entity<LoaiPhong>(entity =>
            {
                entity.HasKey(e => e.Malp)
                    .HasName("PK__LOAI_PHO__603F4155A3D00FF8");

                entity.ToTable("LOAI_PHONG");

                entity.Property(e => e.Malp)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MALP")
                    .IsFixedLength(true);

                entity.Property(e => e.KhongGian)
                    .HasMaxLength(50)
                    .HasColumnName("KHONG_GIAN");

                entity.Property(e => e.LoaiPhong1)
                    .HasMaxLength(50)
                    .HasColumnName("LOAI_PHONG");

                entity.Property(e => e.MaGia)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MA_GIA")
                    .IsFixedLength(true);

                entity.HasOne(d => d.MaGiaNavigation)
                    .WithMany(p => p.LoaiPhongs)
                    .HasForeignKey(d => d.MaGia)
                    .HasConstraintName("FK__LOAI_PHON__MA_GI__3B75D760");
                entity.Property(e => e.SoGiuong).HasColumnName("SO_GIUONG");
                entity.Property(e => e.SoNguoi).HasColumnName("SO_NGUOI");
            });

            modelBuilder.Entity<PhieuDichVu>(entity =>
            {
                entity.HasKey(e => new { e.MaDv, e.MaDonDat })
                    .HasName("PK__PHIEU_DI__111E7440740645CF");

                entity.ToTable("PHIEU_DICH_VU");

                entity.Property(e => e.MaDv)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MA_DV")
                    .IsFixedLength(true);

                entity.Property(e => e.MaDonDat)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MA_DON_DAT")
                    .IsFixedLength(true);

                entity.Property(e => e.Gia)
                    .HasColumnType("money")
                    .HasColumnName("GIA");

                entity.Property(e => e.SoLuong).HasColumnName("SO_LUONG");

                entity.Property(e => e.ThanhTien)
                    .HasColumnType("money")
                    .HasColumnName("THANH_TIEN");

                entity.HasOne(d => d.MaDonDatNavigation)
                    .WithMany(p => p.PhieuDichVus)
                    .HasForeignKey(d => d.MaDonDat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PHIEU_DIC__MA_DO__5FB337D6");

                entity.HasOne(d => d.MaDvNavigation)
                    .WithMany(p => p.PhieuDichVus)
                    .HasForeignKey(d => d.MaDv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PHIEU_DIC__MA_DV__5EBF139D");
            });

            modelBuilder.Entity<Phong>(entity =>
            {
                entity.HasKey(e => e.Maphong)
                    .HasName("PK__PHONG__CE71B252DAB1B5B9");

                entity.ToTable("PHONG");

                entity.Property(e => e.Maphong)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MAPHONG")
                    .IsFixedLength(true);

                entity.Property(e => e.MaLp)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MA_LP")
                    .IsFixedLength(true);

                entity.Property(e => e.MaTang)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MA_TANG")
                    .IsFixedLength(true);

                entity.Property(e => e.PhongSo).HasColumnName("PHONG_SO");

                entity.Property(e => e.TinhTrang)
                    .HasMaxLength(50)
                    .HasColumnName("TINH_TRANG");

                entity.HasOne(d => d.MaLpNavigation)
                    .WithMany(p => p.Phongs)
                    .HasForeignKey(d => d.MaLp)
                    .HasConstraintName("FK__PHONG__MA_LP__3E52440B");

                entity.HasOne(d => d.MaTangNavigation)
                    .WithMany(p => p.Phongs)
                    .HasForeignKey(d => d.MaTang)
                    .HasConstraintName("FK__PHONG__MA_TANG__3F466844");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.Matk)
                    .HasName("PK__TAI_KHOA__6023721682974B68");

                entity.ToTable("TAI_KHOAN");

                entity.Property(e => e.Matk)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MATK")
                    .IsFixedLength(true);

                entity.Property(e => e.ChucVu)
                    .HasMaxLength(50)
                    .HasColumnName("CHUC_VU");

                entity.Property(e => e.Cmnd)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("CMND")
                    .IsFixedLength(true);

                entity.Property(e => e.GhiChu)
                    .HasMaxLength(250)
                    .HasColumnName("GHI_CHU");

                entity.Property(e => e.GioiTinh).HasColumnName("GIOI_TINH");

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MAT_KHAU");

                entity.Property(e => e.NgaySinh)
                    .HasColumnType("date")
                    .HasColumnName("NGAY_SINH");

                entity.Property(e => e.TaiKhoan1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TAI_KHOAN");

                entity.Property(e => e.TenNv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TEN_NV");
            });

            modelBuilder.Entity<Tang>(entity =>
            {
                entity.HasKey(e => e.Matang)
                    .HasName("PK__TANG__2F66118885F46877");

                entity.ToTable("TANG");

                entity.Property(e => e.Matang)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MATANG")
                    .IsFixedLength(true);

                entity.Property(e => e.Tang1).HasColumnName("TANG");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
