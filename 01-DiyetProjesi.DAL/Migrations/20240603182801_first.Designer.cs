﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _01_DiyetProjesi.DAL;

#nullable disable

namespace _01_DiyetProjesi.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240603182801_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GunKullanici", b =>
                {
                    b.Property<int>("GunlerGunID")
                        .HasColumnType("int");

                    b.Property<int>("KullanicilarUserID")
                        .HasColumnType("int");

                    b.HasKey("GunlerGunID", "KullanicilarUserID");

                    b.HasIndex("KullanicilarUserID");

                    b.ToTable("GunKullanici");
                });

            modelBuilder.Entity("_01_DiyetProjesi.DATA.Entities.Gun", b =>
                {
                    b.Property<int>("GunID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GunID"));

                    b.Property<DateTime>("BugununTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("GunID");

                    b.ToTable("Gunler");
                });

            modelBuilder.Entity("_01_DiyetProjesi.DATA.Entities.GunUrunDetay", b =>
                {
                    b.Property<int>("UrunID")
                        .HasColumnType("int");

                    b.Property<int>("GunID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<double>("AlinmisKalori")
                        .HasColumnType("float");

                    b.Property<string>("GununZamani")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("UrunGramaj")
                        .HasColumnType("float");

                    b.HasKey("UrunID", "GunID", "UserID");

                    b.HasIndex("GunID");

                    b.HasIndex("UserID");

                    b.ToTable("GunUrunDetaylari");
                });

            modelBuilder.Entity("_01_DiyetProjesi.DATA.Entities.Kullanici", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Boy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("GuncelKilo")
                        .HasColumnType("float");

                    b.Property<double>("HedefKilo")
                        .HasColumnType("float");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("_01_DiyetProjesi.DATA.Entities.Urun", b =>
                {
                    b.Property<int>("UrunID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UrunID"));

                    b.Property<double>("CokluDoymamisYag")
                        .HasColumnType("float");

                    b.Property<double>("DoymusYag")
                        .HasColumnType("float");

                    b.Property<double>("Fiber")
                        .HasColumnType("float");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Kalori")
                        .HasColumnType("int");

                    b.Property<double>("Karbonhidrat")
                        .HasColumnType("float");

                    b.Property<string>("Kategori")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Potasyum")
                        .HasColumnType("float");

                    b.Property<double>("Protein")
                        .HasColumnType("float");

                    b.Property<double>("Seker")
                        .HasColumnType("float");

                    b.Property<double>("Sodyum")
                        .HasColumnType("float");

                    b.Property<double>("TekliDoymamisYag")
                        .HasColumnType("float");

                    b.Property<double>("TransYag")
                        .HasColumnType("float");

                    b.Property<string>("UrunAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UrunID");

                    b.ToTable("Urunler");
                });

            modelBuilder.Entity("GunKullanici", b =>
                {
                    b.HasOne("_01_DiyetProjesi.DATA.Entities.Gun", null)
                        .WithMany()
                        .HasForeignKey("GunlerGunID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_01_DiyetProjesi.DATA.Entities.Kullanici", null)
                        .WithMany()
                        .HasForeignKey("KullanicilarUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_01_DiyetProjesi.DATA.Entities.GunUrunDetay", b =>
                {
                    b.HasOne("_01_DiyetProjesi.DATA.Entities.Gun", "Gun")
                        .WithMany("GunUrunDetaylar")
                        .HasForeignKey("GunID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_01_DiyetProjesi.DATA.Entities.Urun", "Urun")
                        .WithMany("UrunGunDetaylar")
                        .HasForeignKey("UrunID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_01_DiyetProjesi.DATA.Entities.Kullanici", "Kullanici")
                        .WithMany("GunUrunDetays")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gun");

                    b.Navigation("Kullanici");

                    b.Navigation("Urun");
                });

            modelBuilder.Entity("_01_DiyetProjesi.DATA.Entities.Gun", b =>
                {
                    b.Navigation("GunUrunDetaylar");
                });

            modelBuilder.Entity("_01_DiyetProjesi.DATA.Entities.Kullanici", b =>
                {
                    b.Navigation("GunUrunDetays");
                });

            modelBuilder.Entity("_01_DiyetProjesi.DATA.Entities.Urun", b =>
                {
                    b.Navigation("UrunGunDetaylar");
                });
#pragma warning restore 612, 618
        }
    }
}
