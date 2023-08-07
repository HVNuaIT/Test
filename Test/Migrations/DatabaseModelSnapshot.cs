﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test.DatabaseContext;

#nullable disable

namespace Test.Migrations
{
    [DbContext(typeof(Database))]
    partial class DatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Test.Model.Admin", b =>
                {
                    b.Property<string>("IDAdmin")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("maTK")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IDAdmin");

                    b.HasIndex("maTK");

                    b.ToTable("QuanTriAdmin");
                });

            modelBuilder.Entity("Test.Model.BaiGiang", b =>
                {
                    b.Property<int>("maBaiGiang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("maBaiGiang"), 1L, 1);

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("NgayUpload")
                        .HasColumnType("datetime2");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.Property<string>("UpdateByMember")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ghiChu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hinhThuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("kichThuc")
                        .HasColumnType("int");

                    b.Property<int>("maChuDe")
                        .HasColumnType("int");

                    b.Property<string>("maMonHoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("tenBaiGiang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("maBaiGiang");

                    b.HasIndex("maMonHoc");

                    b.ToTable("BaiGiang");
                });

            modelBuilder.Entity("Test.Model.CauHoi", b =>
                {
                    b.Property<int>("maCauHoi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("maCauHoi"), 1L, 1);

                    b.Property<string>("Mon")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NguoiBinhLuan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenBai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ngay")
                        .HasColumnType("datetime2");

                    b.Property<string>("noiDungCauHoi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("thich")
                        .HasColumnType("bit");

                    b.HasKey("maCauHoi");

                    b.HasIndex("Mon");

                    b.ToTable("CauHoi");
                });

            modelBuilder.Entity("Test.Model.CauHoiTN", b =>
                {
                    b.Property<int>("maCauHoiTN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("maCauHoiTN"), 1L, 1);

                    b.Property<string>("A")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("B")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("C")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("D")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdNganHangCauHoi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dapAnChinhXac")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tieuDeCauHoi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("maCauHoiTN");

                    b.ToTable("CauHoiTN");
                });

            modelBuilder.Entity("Test.Model.ChuDe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("maMonHoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("tieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("maMonHoc");

                    b.ToTable("ChuDe");
                });

            modelBuilder.Entity("Test.Model.DeThi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("TenBaiThi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenGiaoVien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThoiGiangThi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TinhTrang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hinhThuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("maMonHoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DeThi&KiemTra");
                });

            modelBuilder.Entity("Test.Model.DuyetBaiGiang", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("LoiNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("maBaiGiang")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("maBaiGiang");

                    b.ToTable("DuyetBai");
                });

            modelBuilder.Entity("Test.Model.GiaoVien", b =>
                {
                    b.Property<string>("maGiaoVien")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("maKhoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("maTK")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("maGiaoVien");

                    b.HasIndex("maKhoa");

                    b.HasIndex("maTK");

                    b.ToTable("GiaoVien");
                });

            modelBuilder.Entity("Test.Model.HocSinh", b =>
                {
                    b.Property<string>("maHocSinh")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("maKhoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("maLop")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("maTK")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("maHocSinh");

                    b.HasIndex("maKhoa");

                    b.HasIndex("maLop");

                    b.HasIndex("maTK");

                    b.ToTable("HocSinh");
                });

            modelBuilder.Entity("Test.Model.Khoa", b =>
                {
                    b.Property<string>("maKhoa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("tenKhoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("maKhoa");

                    b.ToTable("Khoa");
                });

            modelBuilder.Entity("Test.Model.Lop", b =>
                {
                    b.Property<string>("maLop")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("tenLop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("maLop");

                    b.ToTable("Lop");
                });

            modelBuilder.Entity("Test.Model.MonHoc", b =>
                {
                    b.Property<string>("maMonHoc")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("maGiaoVien")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("maLop")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("moTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tenMonHoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("maMonHoc");

                    b.HasIndex("maGiaoVien");

                    b.HasIndex("maLop");

                    b.ToTable("MonHoc");
                });

            modelBuilder.Entity("Test.Model.NganHangCauHoiTN", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("doKho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nguoiSoHuu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("suaDoiLanCuoi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("NganHangCauHoi");
                });

            modelBuilder.Entity("Test.Model.RefreshToken", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsRevoked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ThoiGianHetHan")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ThoiGianTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("idJwt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("idUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("idUser");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("Test.Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("moTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ngay")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Quyen");
                });

            modelBuilder.Entity("Test.Model.TaiNguyen", b =>
                {
                    b.Property<int>("IdTaiNguyen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTaiNguyen"), 1L, 1);

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("NgayUpload")
                        .HasColumnType("datetime2");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.Property<string>("UpdateByMember")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ghiChu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hinhThuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("maBaiGiang")
                        .HasColumnType("int");

                    b.Property<int>("maChuDe")
                        .HasColumnType("int");

                    b.Property<string>("maMonHoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tenTaiNguyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTaiNguyen");

                    b.ToTable("TaiNguyen");
                });

            modelBuilder.Entity("Test.Model.ThongBao", b =>
                {
                    b.Property<int>("maThongBao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("maThongBao"), 1L, 1);

                    b.Property<string>("TenNguoiThongBao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tieuDeThongBao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("maThongBao");

                    b.ToTable("ThongBao");
                });

            modelBuilder.Entity("Test.Model.ThongBaoAdmin", b =>
                {
                    b.Property<int>("maTBaoAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("maTBaoAdmin"), 1L, 1);

                    b.Property<string>("tieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("maTBaoAdmin");

                    b.ToTable("ThongBaoAdmin");
                });

            modelBuilder.Entity("Test.Model.TraLoi", b =>
                {
                    b.Property<int>("maTl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("maTl"), 1L, 1);

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("maCauHoi")
                        .HasColumnType("int");

                    b.Property<DateTime>("ngay")
                        .HasColumnType("datetime2");

                    b.Property<string>("tenNguoiTraLoi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("maTl");

                    b.HasIndex("maCauHoi");

                    b.ToTable("CauTraLoi");
                });

            modelBuilder.Entity("Test.Model.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("gioTinh")
                        .HasColumnType("bit");

                    b.Property<string>("hinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("maQuyen")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("maQuyen");

                    b.ToTable("TaiKhoan");
                });

            modelBuilder.Entity("Test.Model.Admin", b =>
                {
                    b.HasOne("Test.Model.User", "user")
                        .WithMany()
                        .HasForeignKey("maTK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Test.Model.BaiGiang", b =>
                {
                    b.HasOne("Test.Model.MonHoc", "MonHoc")
                        .WithMany()
                        .HasForeignKey("maMonHoc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MonHoc");
                });

            modelBuilder.Entity("Test.Model.CauHoi", b =>
                {
                    b.HasOne("Test.Model.MonHoc", "MonHoc")
                        .WithMany()
                        .HasForeignKey("Mon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MonHoc");
                });

            modelBuilder.Entity("Test.Model.ChuDe", b =>
                {
                    b.HasOne("Test.Model.MonHoc", "MonHoc")
                        .WithMany()
                        .HasForeignKey("maMonHoc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MonHoc");
                });

            modelBuilder.Entity("Test.Model.DuyetBaiGiang", b =>
                {
                    b.HasOne("Test.Model.BaiGiang", "BaiGiang")
                        .WithMany()
                        .HasForeignKey("maBaiGiang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BaiGiang");
                });

            modelBuilder.Entity("Test.Model.GiaoVien", b =>
                {
                    b.HasOne("Test.Model.Khoa", "Khoa")
                        .WithMany()
                        .HasForeignKey("maKhoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test.Model.User", "user")
                        .WithMany()
                        .HasForeignKey("maTK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khoa");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Test.Model.HocSinh", b =>
                {
                    b.HasOne("Test.Model.Khoa", "Khoa")
                        .WithMany()
                        .HasForeignKey("maKhoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test.Model.Lop", "Lop")
                        .WithMany()
                        .HasForeignKey("maLop")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test.Model.User", "user")
                        .WithMany()
                        .HasForeignKey("maTK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khoa");

                    b.Navigation("Lop");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Test.Model.MonHoc", b =>
                {
                    b.HasOne("Test.Model.GiaoVien", "GiaoVien")
                        .WithMany()
                        .HasForeignKey("maGiaoVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test.Model.Lop", "Lop")
                        .WithMany()
                        .HasForeignKey("maLop")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GiaoVien");

                    b.Navigation("Lop");
                });

            modelBuilder.Entity("Test.Model.RefreshToken", b =>
                {
                    b.HasOne("Test.Model.User", "user")
                        .WithMany()
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Test.Model.TraLoi", b =>
                {
                    b.HasOne("Test.Model.CauHoi", "CauHoi")
                        .WithMany()
                        .HasForeignKey("maCauHoi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CauHoi");
                });

            modelBuilder.Entity("Test.Model.User", b =>
                {
                    b.HasOne("Test.Model.Role", "Role")
                        .WithMany()
                        .HasForeignKey("maQuyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
