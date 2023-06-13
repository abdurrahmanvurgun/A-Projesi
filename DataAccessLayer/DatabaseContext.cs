using Armut.Model;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.AdresModelleri;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<AltKategori> AltKategoriler { get; set; }
        public DbSet<KullaniciRol> KullaniciRoller { get; set; }
        public DbSet<Rol> Roller { get; set; }

        public DbSet<Il> Iller { get; set; }
        public DbSet<Ilce> Ilceler { get; set; }
        public DbSet<Mahalle> Mahalleler { get; set; }
        public DbSet<Ulke> Ulkeler { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Aktivite>().HasOne(e => e.TeklifVeren).WithMany(e => e.TeklifVern).HasForeignKey(e => e.TeklifVerenId).OnDelete(DeleteBehavior.ClientSetNull);
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Aktivite>().HasOne(e => e.TeklifIsteyen).WithMany(e => e.TeklifAln).HasForeignKey(e => e.TeklifAlanId).OnDelete(DeleteBehavior.ClientSetNull);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Ad);
                entity.HasOne(e => e.KullaniciRol).WithOne(e => e.Rol).HasForeignKey<KullaniciRol>(e => e.RolId);

            });
            modelBuilder.Entity<KullaniciRol>(entity =>
            {
                entity.HasKey(e => e.KullaniciId);
                entity.Property(e => e.RolId);

            });

            modelBuilder.Entity<Kategori>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.KategoriAdi);


            });

            modelBuilder.Entity<AltKategori>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.KategoriId });
                entity.Property(e => e.AltKategoriAdi);
                entity.Property(e => e.Aktif);
                entity.HasOne(e => e.Kategori).WithMany(e => e.AltKategoriler).HasForeignKey(e => e.KategoriId);
            });

            modelBuilder.Entity<Soru>(entity =>
            {
                entity.HasKey(e => new { e.SoruId, e.AltKategoriId });
                entity.Property(e => e.Sorular);
                entity.HasOne(e => e.AltKategori).WithMany(e => e.Sorular).HasForeignKey(e => e.AltKategoriId);
            });
            modelBuilder.Entity<Cevap>(entity =>
            {
                entity.HasKey(e => new { e.CevapId, e.SoruId });
                entity.Property(e => e.Cevaplar);
                entity.HasOne(e => e.Soru).WithMany(e => e.Cevaplar).HasForeignKey(e => e.SoruId);
            });



            modelBuilder.Entity<Kullanici>(entity =>
            {
                entity.HasKey(e => new { e.Id });
                entity.Property(e => e.KullaniciAdi);
                entity.Property(e => e.Ad);
                entity.Property(e => e.Soyad);
                entity.Property(e => e.Email);
                entity.Property(e => e.Sifre);
                entity.Property(e => e.Sifre2);
                entity.Property(e => e.Adres);
                entity.Property(e => e.Cinsiyet);
                entity.Property(e => e.TelefonNumarası);
                entity.Property(e => e.Aktif);
                entity.Property(e => e.KayitTarihi);
                entity.HasOne(e => e.KullaniciRol).WithOne(e => e.Kullanici).HasForeignKey<KullaniciRol>(e => e.KullaniciId);


            });

            AddDataToKullaniciVeKullaniciRol(modelBuilder);
            AddDataToRol(modelBuilder);
            AddDataToKategori(modelBuilder);
            AddDataToAltKategori(modelBuilder);
            AddDataToAltKategori2(modelBuilder);
            AddDataToAltKategori3(modelBuilder);
            AddDataToAltKategori4(modelBuilder);
            AddDataToAltKategori5(modelBuilder);
            AddDataToAltKategori6(modelBuilder);
            AddDataToAltKategori7(modelBuilder);
            AddDataToAltKategori8(modelBuilder);
            AddDataToAltKategori9(modelBuilder);
            AddDataToAltKategori10(modelBuilder);
            AddDataToAltKategori11(modelBuilder);
            AddDataToAltKategori12(modelBuilder);
        }

        void AddDataToKullaniciVeKullaniciRol(ModelBuilder modelBuilder)
        {
            var kullaniciId = Guid.NewGuid();
            modelBuilder.Entity<Kullanici>().HasData(
                    new Kullanici
                    {
                        Id = kullaniciId,
                        KullaniciAdi = "networkakademi",
                        Ad = "Network",
                        Soyad = "Network",
                        Email = "Network@gmail.com",
                        Sifre = "123",
                        Sifre2 = "123",
                        Adres = "İstanbul",
                        Cinsiyet = "Kadın",
                        TelefonNumarası = "123456",
                        Aktif = true,
                        KayitTarihi = DateTime.Now,


                    }

            );
            modelBuilder.Entity<KullaniciRol>().HasData(
                   new KullaniciRol
                   {
                       KullaniciId = kullaniciId,
                       RolId = 1

                   }

           );
        }



        void AddDataToRol(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>().HasData(
                    new Rol
                    {
                        Id =1,
                        Ad = "Admin"
                    },
                    new Rol
                    {
                        Id = 2,
                        Ad = "Hizmet Alan"
                    },
                    new Rol
                    {
                        Id = 3,
                        Ad = "Hizmet Veren"
                    }
            );
        }

        void AddDataToKategori(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategori>().HasData(

                      new Kategori
                      {
                          Id = 1,
                          KategoriAdi = "Temizlik",

                      },
                      new Kategori
                      {
                          Id = 2,
                          KategoriAdi = "Tadilat",

                      },
                      new Kategori
                      {
                          Id = 3,
                          KategoriAdi = "Nakliyat",

                      },
                      new Kategori
                      {
                          Id = 4,
                          KategoriAdi = "Tamir",

                      },
                      new Kategori
                      {
                          Id = 5,
                          KategoriAdi = "Özel Ders",

                      },
                       new Kategori
                       {
                           Id = 6,
                           KategoriAdi = "Sağlık",

                       },
                       new Kategori
                       {
                           Id = 7,
                           KategoriAdi = "Organizasyon",

                       },
                       new Kategori
                       {
                           Id = 8,
                           KategoriAdi = "Fotoğraf Ve Video",

                       },
                        new Kategori
                        {
                            Id = 9,
                            KategoriAdi = "Dijital ve Kurumsal",

                        },
                       new Kategori
                       {
                           Id = 10,
                           KategoriAdi = "Evcil Hayvanlar",

                       },
                       new Kategori
                       {
                           Id = 11,
                           KategoriAdi = "Oto Ve Araç",

                       },
                        new Kategori
                        {
                            Id = 12,
                            KategoriAdi = "Diğer",

                        }
                  );
        }
        //Temizlik -kategoriid=1
        void AddDataToAltKategori(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AltKategori>().HasData(

                   new AltKategori
                   {
                       Id = 1,
                       AltKategoriAdi = "Ev Temizliği",
                       KategoriId = 1,
                       Aktif = true,
                       
                   },
                    new AltKategori
                    {
                        Id = 2,
                        AltKategoriAdi = "Apartman Temizliği",
                        KategoriId = 1,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 3,
                        AltKategoriAdi = "Ofis Temizliği",
                        KategoriId = 1,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 4,
                        AltKategoriAdi = "İnşaat Sonrası Ev Temizliği",
                        KategoriId = 1,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 5,
                        AltKategoriAdi = "Dükkan/Mağaza Temizliği",
                        KategoriId = 1,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 6,
                        AltKategoriAdi = "Haşere İlaçlama",
                        KategoriId = 1,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 7,
                        AltKategoriAdi = "Halı Yıkama",
                        KategoriId = 1,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 8,
                        AltKategoriAdi = "Kuru Temizleme",
                        KategoriId = 1,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 9,
                        AltKategoriAdi = "Mobilya Temizleme",
                        KategoriId = 1,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 10,
                        AltKategoriAdi = "Cam Temziliği",
                        KategoriId = 1,
                        Aktif = true
                    }

                );
        }

        void AddDataToAltKategori2(ModelBuilder modelBuilder)


        {
            modelBuilder.Entity<AltKategori>().HasData(
                 new AltKategori
                 {
                     Id = 11,
                     AltKategoriAdi = "Boya Badana",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 12,
                     AltKategoriAdi = "Kapı Tadilat",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 13,
                     AltKategoriAdi = "Pencere Tadilat",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 14,
                     AltKategoriAdi = "Banyo Tadilat",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 15,
                     AltKategoriAdi = "Duvar Örme",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 16,
                     AltKategoriAdi = "Cam Balkon",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 17,
                     AltKategoriAdi = "Zemin Döşeme",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                  {
                      Id = 18,
                      AltKategoriAdi = "Havuz Yapımı",
                      KategoriId = 2,
                      Aktif = true
                  },
                 new AltKategori
                 {
                     Id = 19,
                     AltKategoriAdi = "Gardrop Yapımı",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 20,
                     AltKategoriAdi = "iç Mimar",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 21,
                     AltKategoriAdi = "Prefabrik Ev Yapımı",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 22,
                     AltKategoriAdi = "Koltuk Döşeme",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 23,
                     AltKategoriAdi = "Çatı Tadilatı",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 24,
                     AltKategoriAdi = "Doğalgaz Tesisat",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 25,
                     AltKategoriAdi = "Gömme Dolap Yapımı",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 26,
                     AltKategoriAdi = "Güneş Enerjisi",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 27,
                     AltKategoriAdi = "Sineklik",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 28,
                     AltKategoriAdi = "Mezar Yapımı",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 29,
                     AltKategoriAdi = "Vestiyer ve Portmanto",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 30,
                     AltKategoriAdi = "Sandalye Döşeme",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 31,
                     AltKategoriAdi = "Ses Yalıtımı",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 32,
                     AltKategoriAdi = "Sıva",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 33,
                     AltKategoriAdi = "Kaynak",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 34,
                     AltKategoriAdi = "Alçı",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 35,
                     AltKategoriAdi = "Deprem Testi",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 36,
                     AltKategoriAdi = "Stor Perde",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 37,
                     AltKategoriAdi = "Panjur",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 38,
                     AltKategoriAdi = "Hazır Rulo Çim",
                     KategoriId = 2,
                     Aktif = true
                 }, new AltKategori
                 {
                     Id = 39,
                     AltKategoriAdi = "Özel Mobilya Yapımı",
                     KategoriId = 2,
                     Aktif = true
                 }, new AltKategori
                 {
                     Id = 40,
                     AltKategoriAdi = "Mermer",
                     KategoriId = 2,
                     Aktif = true
                 }, new AltKategori
                 {
                     Id = 41,
                     AltKategoriAdi = "Panel Çit",
                     KategoriId = 2,
                     Aktif = true
                 }, new AltKategori
                 {
                     Id = 42,
                     AltKategoriAdi = "Tente Branda",
                     KategoriId = 2,
                     Aktif = true
                 }, new AltKategori
                 {
                     Id = 43,
                     AltKategoriAdi = "Bina Güçlendirme",
                     KategoriId = 2,
                     Aktif = true
                 }, new AltKategori
                 {
                     Id = 44,
                     AltKategoriAdi = "Teras Kapatma",
                     KategoriId = 2,
                     Aktif = true
                 },
                 new AltKategori
                 {
                     Id = 45,
                     AltKategoriAdi = "Mutfak",
                     KategoriId = 2,
                     Aktif = true
                 }
                 );
        }

        void AddDataToAltKategori3(ModelBuilder modelBuilder)


        {
            modelBuilder.Entity<AltKategori>().HasData(
                     new AltKategori
                     {
                         Id = 46,
                         AltKategoriAdi = "Ambar Kargo",
                         KategoriId = 3,
                         Aktif = true
                     },
                    new AltKategori
                    {
                        Id = 47,
                        AltKategoriAdi = "Araç Taşıma",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 48,
                        AltKategoriAdi = "Asansörlü Nakliyat",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 49,
                        AltKategoriAdi = "BUlaşık Makinesi Taşıma",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 50,
                        AltKategoriAdi = "Buzdolabı Taşıma",
                        KategoriId = 3,
                        Aktif = true
                    },
                     new AltKategori
                     {
                         Id = 51,
                         AltKategoriAdi = "Çamaşır Makinesi Taşıma",
                         KategoriId = 3,
                         Aktif = true
                     },
                    new AltKategori
                    {
                        Id = 52,
                        AltKategoriAdi = "Depo Kiralama",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 53,
                        AltKategoriAdi = "Doblo Nakliye",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 54,
                        AltKategoriAdi = "Eşya Depolama",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 55,
                        AltKategoriAdi = "Eşya Taşıma",
                        KategoriId = 3,
                        Aktif = true
                    },
                     new AltKategori
                     {
                         Id = 56,
                         AltKategoriAdi = "Ev İçi Eşya Taşıma",
                         KategoriId = 3,
                         Aktif = true
                     },
                    new AltKategori
                    {
                        Id = 57,
                        AltKategoriAdi = "Evden Eve Nakliyat",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 58,
                        AltKategoriAdi = "Günlük Şöför",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 59,
                        AltKategoriAdi = "Havaalanı Transfer",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 60,
                        AltKategoriAdi = "Kamyonet Kiralama",
                        KategoriId = 3,
                        Aktif = true
                    },
                     new AltKategori
                     {
                         Id = 61,
                         AltKategoriAdi = "Kamyonet Nakliye",
                         KategoriId = 3,
                         Aktif = true
                     },
                    new AltKategori
                    {
                        Id = 62,
                        AltKategoriAdi = "Kedi Taşıma",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 63,
                        AltKategoriAdi = "Koltuk Taşıma",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 64,
                        AltKategoriAdi = "Köpe Taşıma",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 65,
                        AltKategoriAdi = "Minibüs Kiralama",
                        KategoriId = 3,
                        Aktif = true
                    },
                     new AltKategori
                     {
                         Id = 66,
                         AltKategoriAdi = "Minivan Nakliye",
                         KategoriId = 3,
                         Aktif = true
                     },
                    new AltKategori
                    {
                        Id = 67,
                        AltKategoriAdi = "Moto Kurye",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 68,
                        AltKategoriAdi = "Motosiklet Taşıma",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 69,
                        AltKategoriAdi = "Ofis Taşıma",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 70,
                        AltKategoriAdi = "Oto Çekici",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 71,
                        AltKategoriAdi = "Köpe Taşıma",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 72,
                        AltKategoriAdi = "Minibüs Kiralama",
                        KategoriId = 3,
                        Aktif = true
                    },
                     new AltKategori
                     {
                         Id =73,
                         AltKategoriAdi = "Minivan Nakliye",
                         KategoriId = 3,
                         Aktif = true
                     },
                    new AltKategori
                    {
                        Id = 74,
                        AltKategoriAdi = "Moto Kurye",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 75,
                        AltKategoriAdi = "Motosiklet Taşıma",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 76,
                        AltKategoriAdi = "Ofis Taşıma",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 77,
                        AltKategoriAdi = "Oto Çekici",
                        KategoriId = 3,
                        Aktif = true
                    },

                    new AltKategori
                    {
                        Id = 78,
                        AltKategoriAdi = "Oto Kurtarma",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 79,
                        AltKategoriAdi = "Otobüs Kiralama",
                        KategoriId = 3,
                        Aktif = true
                    },
                        new AltKategori
                        {
                            Id = 80,
                            AltKategoriAdi = "Özel Şöför",
                            KategoriId = 3,
                            Aktif = true
                        },
                    new AltKategori
                    {
                        Id = 81,
                        AltKategoriAdi = "Paletli Yük Taşıma",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 82,
                        AltKategoriAdi = "Panelvan Nakliye",
                        KategoriId = 3,
                        Aktif = true
                    },
                      new AltKategori
                      {
                          Id = 83,
                          AltKategoriAdi = "Personel Servisi",
                          KategoriId = 3,
                          Aktif = true
                      },
                    new AltKategori
                    {
                        Id = 84,
                        AltKategoriAdi = "Şehir İçi Nakliye",
                        KategoriId = 3,
                        Aktif = true
                    },
                        new AltKategori
                        {
                            Id = 85,
                            AltKategoriAdi = "Şehirler Arası Araç Taşıma",
                            KategoriId = 3,
                            Aktif = true
                        },
                    new AltKategori
                    {
                        Id = 86,
                        AltKategoriAdi = "Şehirler Arası Eşya Taşıma",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 87,
                        AltKategoriAdi = "Şehirler Arası Motosiklet Taşıma",
                        KategoriId = 3,
                        Aktif = true
                    },
                      new AltKategori
                      {
                          Id = 88,
                          AltKategoriAdi = "Şehirler Arası Nakliye",
                          KategoriId = 3,
                          Aktif = true
                      },
                    new AltKategori
                    {
                        Id = 89,
                        AltKategoriAdi = "Şehirler Arası Yük Taşıma",
                        KategoriId = 3,
                        Aktif = true
                    },
                        new AltKategori
                        {
                            Id = 90,
                            AltKategoriAdi = "Şöförlü Araç Kiralama",
                            KategoriId = 3,
                            Aktif = true
                        },
                    new AltKategori
                    {
                        Id = 91,
                        AltKategoriAdi = "Taksi",
                        KategoriId = 3,
                        Aktif = true
                    },
                    new AltKategori
                    {
                        Id = 92,
                        AltKategoriAdi = "Transfer",
                        KategoriId = 3,
                        Aktif = true
                    },
                     new AltKategori
                     {
                         Id = 93,
                         AltKategoriAdi = "Uluslararası Evden Eve Nakliyat",
                         KategoriId = 3,
                         Aktif = true
                     },
                    new AltKategori
                    {
                        Id = 94,
                        AltKategoriAdi = "Uluslararası Nakliyat",
                        KategoriId = 3,
                        Aktif = true
                    },
                     new AltKategori
                     {
                         Id = 95,
                         AltKategoriAdi = "Yük Taşıma",
                         KategoriId = 3,
                         Aktif = true
                     },
                    new AltKategori
                    {
                        Id = 96,
                        AltKategoriAdi = "Yurtdışı Kargo",
                        KategoriId = 3,
                        Aktif = true
                    });
        }
        void AddDataToAltKategori4(ModelBuilder modelBuilder)


        {
            modelBuilder.Entity<AltKategori>().HasData(
                   //////////tamir katid=4
                   new AltKategori
                   {
                       Id = 97,
                       AltKategoriAdi = "Ahşap Kapı Tamiri",
                       KategoriId = 4,
                       Aktif = true
                   },
                   new AltKategori
                   {
                       Id = 98,
                       AltKategoriAdi = "Amerikan Panel Kapı Montajı",
                       KategoriId = 4,
                       Aktif = true
                   },
                    new AltKategori
                    {
                        Id = 99,
                        AltKategoriAdi = "Amerikan Panel Kapı Tamiri",
                        KategoriId = 4,
                        Aktif = true
                    },
                     new AltKategori
                     {
                         Id = 100,
                         AltKategoriAdi = "Asansör Bakım",
                         KategoriId = 4,
                         Aktif = true
                     },
                      new AltKategori
                      {
                          Id = 101,
                          AltKategoriAdi = "Avize Montaj",
                          KategoriId = 4,
                          Aktif = true
                      },
                       new AltKategori
                       {
                           Id = 102,
                           AltKategoriAdi = "Baza Tamiri",
                           KategoriId = 4,
                           Aktif = true
                       },
                        new AltKategori
                        {
                            Id = 103,
                            AltKategoriAdi = "Beyaz Eşya Tamiri",
                            KategoriId = 4,
                            Aktif = true
                        },
                         new AltKategori
                         {
                             Id = 104,
                             AltKategoriAdi = "Bilgisayar Format Atma",
                             KategoriId = 4,
                             Aktif = true
                         },
                          new AltKategori
                          {
                              Id = 105,
                              AltKategoriAdi = "Bilgisayar Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 106,
                              AltKategoriAdi = "Bilgisayar ve Laptop Parça Değişimi",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 107,
                              AltKategoriAdi = "Bulaşık Makinesi Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 108,
                              AltKategoriAdi = "Buzdolabı Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 109,
                              AltKategoriAdi = "Cam Kestirme",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 110,
                              AltKategoriAdi = "Cama Menfez Açma",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 111,
                              AltKategoriAdi = "Çamaşır Makinesi Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 112,
                              AltKategoriAdi = "Çanak Anten Ayarlama",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 113,
                              AltKategoriAdi = "Çanak Anten Kurulumu",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 114,
                              AltKategoriAdi = "Çelik Kapı Kilit Değiştirme",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 115,
                              AltKategoriAdi = "Çelik Kapı Montajı",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 116,
                              AltKategoriAdi = "Çelik Kapı Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 117,
                              AltKategoriAdi = "Çilingir Kapı Açma",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 118,
                              AltKategoriAdi = "Dolap Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 119,
                              AltKategoriAdi = "Duşakabin Montajı",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 120,
                              AltKategoriAdi = "Duşakabin Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 121,
                              AltKategoriAdi = "Duvara Raf Montajı",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 122,
                              AltKategoriAdi = "Elektrik Hattı Çekme",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 123,
                              AltKategoriAdi = "Elektrik Montaj",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 124,
                              AltKategoriAdi = "Elektrik Proje Çizimi",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 125,
                              AltKategoriAdi = "Elektrik Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 126,
                              AltKategoriAdi = "Elektrik Tesisatı",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 127,
                              AltKategoriAdi = "Elektrikçi",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 128,
                              AltKategoriAdi = "Elektrikli Süpürge Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 129,
                              AltKategoriAdi = "Fan Temizliği ve Termal Macun Değişimi",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 130,
                              AltKategoriAdi = "Fiber Kablo Çekimi",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 131,
                              AltKategoriAdi = "Gider Açma",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 132,
                              AltKategoriAdi = "Gömme Rezervuar Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 133,
                              AltKategoriAdi = "İnternet Kablosu Çekme",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 134,
                              AltKategoriAdi = "iPhone Batarya Değişimi",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 135,
                              AltKategoriAdi = "iPhone Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 136,
                              AltKategoriAdi = "Kablo ve Hat Çekme",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 137,
                              AltKategoriAdi = "Kamera Güvenlik Sistemleri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 138,
                              AltKategoriAdi = "Kamera Sistemleri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 139,
                              AltKategoriAdi = "Kapı Kilidi Değiştirme",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 140,
                              AltKategoriAdi = "Kırmadan Su Kaçağı Tespiti",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 141,
                              AltKategoriAdi = "Klima Bakım",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 142,
                              AltKategoriAdi = "Klima Gaz Dolumu",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 143,
                              AltKategoriAdi = "Klima Montaj",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 144,
                              AltKategoriAdi = "Klima Sökme",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 145,
                              AltKategoriAdi = "Klima Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 146,
                              AltKategoriAdi = "Klozet Montajı",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 147,
                              AltKategoriAdi = "Klozet Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 148,
                              AltKategoriAdi = "Koltuk Yanık Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 149,
                              AltKategoriAdi = "Kombi Bakım",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 150,
                              AltKategoriAdi = "Kombi Montaj",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 151,
                              AltKategoriAdi = "Kombi Petek Temizleme",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 152,
                              AltKategoriAdi = "Kombi Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 153,
                              AltKategoriAdi = "Korniş Montaj",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 154,
                              AltKategoriAdi = "Laptop Tamir",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 155,
                              AltKategoriAdi = "Masa Camı Kestirme",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 156,
                              AltKategoriAdi = "Mobilya Montaj",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 157,
                              AltKategoriAdi = "Mobilya Sabitleme",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 158,
                              AltKategoriAdi = "Mobilya Sökme Taşıma ve Montaj",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 159,
                              AltKategoriAdi = "Mobilya Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 160,
                              AltKategoriAdi = "Musluk Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 161,
                              AltKategoriAdi = "Mutfak Dolabı Montajı",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 162,
                              AltKategoriAdi = "Mutfak Dolabı Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 163,
                              AltKategoriAdi = "Mutfak Dolap Kapağı Değiştirme",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 164,
                              AltKategoriAdi = "Mutfak Gider Açma",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 165,
                              AltKategoriAdi = "Mutfak Tezgahı Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 166,
                              AltKategoriAdi = "Panjur Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 167,
                              AltKategoriAdi = "Pencere Camı Değişimi",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 168,
                              AltKategoriAdi = "Pencere Kapı Ve Pimapen Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 169,
                              AltKategoriAdi = "Pencere Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 170,
                              AltKategoriAdi = "Perde Korniş Takma",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 171,
                              AltKategoriAdi = "Petek Montajı",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 172,
                              AltKategoriAdi = "Petek Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 173,
                              AltKategoriAdi = "Petek Temizliği",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 174,
                              AltKategoriAdi = "Pimapen Kapı Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 175,
                              AltKategoriAdi = "Pimapen Pencere Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 176,
                              AltKategoriAdi = "PVC Pencere Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 177,
                              AltKategoriAdi = "Samsung Telefon Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 178,
                              AltKategoriAdi = "Sifon Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 179,
                              AltKategoriAdi = "Sıhhi Tesisat",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 180,
                              AltKategoriAdi = "Su Arıtma Filtre Değişimi",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 181,
                              AltKategoriAdi = "Su Arıtma Montaj",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 182,
                              AltKategoriAdi = "Su Kaçağı Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 183,
                              AltKategoriAdi = "Su Kaçağı Tespiti",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 184,
                              AltKategoriAdi = "Su Tesisatçısı",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 185,
                              AltKategoriAdi = "Su Tesisatı Döşeme",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 186,
                              AltKategoriAdi = "Su Tesisatı Montaj",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 187,
                              AltKategoriAdi = "Sürgülü Dolap Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 188,
                              AltKategoriAdi = "Taharet Musluğu Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 189,
                              AltKategoriAdi = "Tıkanıklık Açma",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 190,
                              AltKategoriAdi = "TV Ekran Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 191,
                              AltKategoriAdi = "TV LED Değişimi",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 192,
                              AltKategoriAdi = "TV Montajı",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 193,
                              AltKategoriAdi = "TV Panel Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 194,
                              AltKategoriAdi = "TV Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 195,
                              AltKategoriAdi = "Uydu Ayarlama",
                              KategoriId = 4,
                              Aktif = true
                          },
                          new AltKategori
                          {
                              Id = 196,
                              AltKategoriAdi = "Xiaomi Telefon Tamiri",
                              KategoriId = 4,
                              Aktif = true
                          });
        }
        void AddDataToAltKategori5(ModelBuilder modelBuilder)


        {
            modelBuilder.Entity<AltKategori>().HasData(
                    ///özel ders=katid=5
                    new AltKategori
                    {
                        Id = 287,
                        AltKategoriAdi = "Almanca Özel Ders",
                        KategoriId = 5,
                        Aktif = true
                    },
                           new AltKategori
                           {
                               Id = 2,
                               AltKategoriAdi = "Arapça Özel Ders",
                               KategoriId = 5,
                               Aktif = true
                           },
                           new AltKategori
                           {
                               Id = 3,
                               AltKategoriAdi = "Bağlama Dersi",
                               KategoriId = 5,
                               Aktif = true
                           },
                           new AltKategori
                           {
                               Id = 4,
                               AltKategoriAdi = "Basketbol Özel Ders",
                               KategoriId = 5,
                               Aktif = true
                           },
                           new AltKategori
                           {
                               Id = 5,
                               AltKategoriAdi = "Bateri Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 6,
                               AltKategoriAdi = "Boks Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 7,
                               AltKategoriAdi = "Çello Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 8,
                               AltKategoriAdi = "DGS Matematik Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 9,
                               AltKategoriAdi = "Diferansiyel Denklemler Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 10,
                               AltKategoriAdi = "Dikiş Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 11,
                               AltKategoriAdi = "Diksiyon Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 12,
                               AltKategoriAdi = "Direksiyon Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 13,
                               AltKategoriAdi = "Eğitim Koçu",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 14,
                               AltKategoriAdi = "Excel Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 15,
                               AltKategoriAdi = "Fen Bilimleri Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 16,
                               AltKategoriAdi = "Fitness Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 17,
                               AltKategoriAdi = "Fizik Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 18,
                               AltKategoriAdi = "Fransızca Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 19,
                               AltKategoriAdi = "Gitar Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 20,
                               AltKategoriAdi = "Gitar Kursu",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 21,
                               AltKategoriAdi = "Gölge Öğretmen",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 22,
                               AltKategoriAdi = "Grup Pilates Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 23,
                               AltKategoriAdi = "Hızlı Okuma Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 24,
                               AltKategoriAdi = "Hukuk Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 25,
                               AltKategoriAdi = "IELTS Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 26,
                               AltKategoriAdi = "İktisat Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 27,
                               AltKategoriAdi = "İlkokul Matematik Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 28,
                               AltKategoriAdi = "İlkokul Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 29,
                               AltKategoriAdi = "İngilizce Konuşma Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 30,
                               AltKategoriAdi = "İngilizce Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 31,
                               AltKategoriAdi = "İspanyolca Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 32,
                               AltKategoriAdi = "İstatistik Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 33,
                               AltKategoriAdi = "İtalyanca Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 34,
                               AltKategoriAdi = "Keman Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 35,
                               AltKategoriAdi = "Kick Boks Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 36,
                               AltKategoriAdi = "Kimya Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 37,
                               AltKategoriAdi = "Klarnet Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 38,
                               AltKategoriAdi = "KPSS Matematik Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 39,
                               AltKategoriAdi = "Kuran Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 40,
                               AltKategoriAdi = "LGS Matematik Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 41,
                               AltKategoriAdi = "Lise Matematik Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 42,
                               AltKategoriAdi = "Matematik Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 43,
                               AltKategoriAdi = "Motosiklet Eğitimi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 44,
                               AltKategoriAdi = "Ödev Ablası",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 1,
                               AltKategoriAdi = "Öğrenci Koçu",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 2,
                               AltKategoriAdi = "Okuma Yazma Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 3,
                               AltKategoriAdi = "Online Almanca Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 4,
                               AltKategoriAdi = "Online Arapça Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 5,
                               AltKategoriAdi = "Online Calculus Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 6,
                               AltKategoriAdi = "Online Diksiyon Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 7,
                               AltKategoriAdi = "Online Eğitim Koçu",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 8,
                               AltKategoriAdi = "Online Fizik Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 9,
                               AltKategoriAdi = "Online Fransızca Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 10,
                               AltKategoriAdi = "Online Gitar Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 11,
                               AltKategoriAdi = "Online IELTS Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 12,
                               AltKategoriAdi = "Online İlkokul Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 13,
                               AltKategoriAdi = "Online İngilizce Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 14,
                               AltKategoriAdi = "Online İspanyolca Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 15,
                               AltKategoriAdi = "Online İtalyanca Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 16,
                               AltKategoriAdi = "Online LGS Matematik Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 17,
                               AltKategoriAdi = "Online Lise Matematik Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 18,
                               AltKategoriAdi = "Online Muhasebe Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 19,
                               AltKategoriAdi = "Online Öğrenci Koçu",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 20,
                               AltKategoriAdi = "Online Ortaokul Matematik Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 21,
                               AltKategoriAdi = "Online Personal Trainer",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 22,
                               AltKategoriAdi = "Online Pilates Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 23,
                               AltKategoriAdi = "Online Resim Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 24,
                               AltKategoriAdi = "Online Rusça Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 25,
                               AltKategoriAdi = "Online Şan Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 1,
                               AltKategoriAdi = "Online Türkçe Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 2,
                               AltKategoriAdi = "Online TYT AYT Matematik Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 3,
                               AltKategoriAdi = "Online Yabancılar İçin Türkçe Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 4,
                               AltKategoriAdi = "Online Yoga Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 5,
                               AltKategoriAdi = "Ortaokul Matematik Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 6,
                               AltKategoriAdi = "Otizm Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 7,
                               AltKategoriAdi = "Özel Ders",
                               KategoriId = 5,
                               Aktif = true
                           },
                           new AltKategori
                           {
                               Id = 8,
                               AltKategoriAdi = "Personal Trainer",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 9,
                               AltKategoriAdi = "Pilates Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 10,
                               AltKategoriAdi = "Piyano Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 11,
                               AltKategoriAdi = "Reformer Pilates Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 12,
                               AltKategoriAdi = "Resim Kursu",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 13,
                               AltKategoriAdi = "Resim Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 14,
                               AltKategoriAdi = "Rusça Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 15,
                               AltKategoriAdi = "Şan Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 16,
                               AltKategoriAdi = "Satranç Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 17,
                               AltKategoriAdi = "Sınıf Öğretmeni",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 18,
                               AltKategoriAdi = "Spor Koçu",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 19,
                               AltKategoriAdi = "Tenis Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 20,
                               AltKategoriAdi = "Türkçe Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 21,
                               AltKategoriAdi = "TYT AYT Matematik Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 22,
                               AltKategoriAdi = "Üniversite Fizik Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 23,
                               AltKategoriAdi = "Üniversite Kimya Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 1,
                               AltKategoriAdi = "Üniversite Matematik Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 2,
                               AltKategoriAdi = "Yabancılar İçin Türkçe Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 3,
                               AltKategoriAdi = "Yan Flüt Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 4,
                               AltKategoriAdi = "Yazılım Özel Ders",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 5,
                               AltKategoriAdi = "Yoga Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 6,
                               AltKategoriAdi = "Yüzme Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           },
                           new AltKategori
                           {
                               Id = 7,
                               AltKategoriAdi = "Zeybek Dersi",
                               KategoriId = 5,
                               Aktif = true,
                           });
        }
        void AddDataToAltKategori6(ModelBuilder modelBuilder)


        {
            modelBuilder.Entity<AltKategori>().HasData(

       new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Aile Danışmanı",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Aile Terapisi",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Astroloji Danışmanlığı",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Bioenerji Uzmanı",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Çift Terapisi",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "ACilt Bakımı",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Cinsel Terapi",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Çocuk Bakımı",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Çocuk Bakımı Ve Ev",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Yardımcısı",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Çocuk Psikoloğu",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Dil Ve Konuşma Terapisi",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Diyetisyen",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Doğum Haritası Çıkarma",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Dövme Tattoo",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "EMDR Terapisi",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Emzirme Danışmanı",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Epilasyon",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Erkek Epilasyon",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Ev Yardımcısı",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Evde Bakım Hizmetleri",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Evde Fizik Tedavi",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Evde Hasta Bakımı",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Evde Hemşire",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Evde Yaşlı Bakımı",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Evlilik Terapisi",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Fal Bakma",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Fizyoterapist",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Gelin Makyajı",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Gelin Saçı",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Hasta Bakımı",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Hastane Refakatçisi",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Hemşire",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Hipnoterapi",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "İngilizce Oyun Ablası",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "İpek Kirpik",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Kalıcı Oje Yapımı",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Kaş Kontürü",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Kayropraktik",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Klinik Psikolog",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Kuaför",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Makyaj",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Manuel Terapi",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Masaj (Erkek İçin)",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Masaj (Kadın İçin)",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Medyum",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Microblading",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Nefes Terapisi",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Nişan Makyajı",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Ombre",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Online Çift Terapisi",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Online Cinsel Terapisi",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Online Çocuk Psikoloğo",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Online Dil Ve Konuşma",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Terapisi",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Online Diyetisyen",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Online Evlilik Terapisi",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Online Pedagog",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Online Psikolog",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Online Psikolojik",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Danışman",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Online Psikoterapi",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Online Stil Danışmanı",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Online Terapi",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Online Yaşam Koçu",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Oyun Ablası",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Oyun Terapisi",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Özel Ambulans",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Özel Eğitim",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Pedagog",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Personel Trainer",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Pilates Dersi",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Protez Tırnak Yapımı",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "APsikolog",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Psikolojik Danışmanı",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Psikoterapi",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Saatlik Çocuk Bakımı",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Saç Boyama",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Saç Kaynağı",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Stil Danışmanı",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "AUzman Psikolog",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Yaşam Koçu",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Yaşlı Bakımı",
           KategoriId = 6,
           Aktif = true
       }, new AltKategori
       {
           Id = 1,
           AltKategoriAdi = "Yetişkin Psikolog",
           KategoriId = 6,
           Aktif = true
       });
        }
        void AddDataToAltKategori7(ModelBuilder modelBuilder)


        {
            modelBuilder.Entity<AltKategori>().HasData(
                   new AltKategori
                   {
                       Id = 43,
                       AltKategoriAdi = "Açılış Organizasyonu",
                       KategoriId = 7,
                       Aktif = true
                   },
              new AltKategori
              {
                  Id = 43,
                  AltKategoriAdi = "Animatör",
                  KategoriId = 7,
                  Aktif = true
              },
               new AltKategori
               {
                   Id = 43,
                   AltKategoriAdi = "Bando Takımı",
                   KategoriId = 7,
                   Aktif = true
               },
              new AltKategori
              {
                  Id = 43,
                  AltKategoriAdi = "Butik Pasta",
                  KategoriId = 7,
                  Aktif = true
              },
               new AltKategori
               {
                   Id = 43,
                   AltKategoriAdi = "Canlı Müzik",
                   KategoriId = 7,
                   Aktif = true
               },
              new AltKategori
              {
                  Id = 43,
                  AltKategoriAdi = "Catering",
                  KategoriId = 7,
                  Aktif = true
              },
               new AltKategori
               {
                   Id = 43,
                   AltKategoriAdi = "Davet Catering",
                   KategoriId = 7,
                   Aktif = true
               },
              new AltKategori
              {
                  Id = 43,
                  AltKategoriAdi = "Davul Zurnacı Kiralama",
                  KategoriId = 7,
                  Aktif = true
              },
               new AltKategori
               {
                   Id = 43,
                   AltKategoriAdi = "DJ",
                   KategoriId = 7,
                   Aktif = true
               },
             new AltKategori
             {
                 Id = 43,
                 AltKategoriAdi = "Doğum Günü Catering",
                 KategoriId = 7,
                 Aktif = true
             },
              new AltKategori
              {
                  Id = 43,
                  AltKategoriAdi = "Doğum Günü Mekanları",
                  KategoriId = 7,
                  Aktif = true
              },
               new AltKategori
               {
                   Id = 43,
                   AltKategoriAdi = "Doğum Günü Organizasyonu",
                   KategoriId = 7,
                   Aktif = true
               },
              new AltKategori
              {
                  Id = 43,
                  AltKategoriAdi = "Doğum Günü Pastası",
                  KategoriId = 7,
                  Aktif = true
              },
               new AltKategori
               {
                   Id = 43,
                   AltKategoriAdi = "Düğün Bandosu",
                   KategoriId = 7,
                   Aktif = true
               },
              new AltKategori
              {
                  Id = 43,
                  AltKategoriAdi = "Düğün Catering",
                  KategoriId = 7,
                  Aktif = true
              },
               new AltKategori
               {
                   Id = 43,
                   AltKategoriAdi = "Düğün Organizasyon",
                   KategoriId = 7,
                   Aktif = true
               },
              new AltKategori
              {
                  Id = 43,
                  AltKategoriAdi = "Düğün Orkestrası",
                  KategoriId = 7,
                  Aktif = true
              },
               new AltKategori
               {
                   Id = 43,
                   AltKategoriAdi = "Düğün Yemeği",
                   KategoriId = 7,
                   Aktif = true
               },
              new AltKategori
              {
                  Id = 43,
                  AltKategoriAdi = "Evlilik Teklifi Organizasyon",
                  KategoriId = 7,
                  Aktif = true
              },
               new AltKategori
               {
                   Id = 43,
                   AltKategoriAdi = "Garson Kiralama",
                   KategoriId = 7,
                   Aktif = true
               },
              new AltKategori
              {
                  Id = 43,
                  AltKategoriAdi = "Gelin Alma Bandosu",
                  KategoriId = 7,
                  Aktif = true
              },
               new AltKategori
               {
                   Id = 43,
                   AltKategoriAdi = "Gelin Arabası Kiralama",
                   KategoriId = 7,
                   Aktif = true
               },
              new AltKategori
              {
                  Id = 43,
                  AltKategoriAdi = "Gelinlik Dikimi",
                  KategoriId = 7,
                  Aktif = true
              },
               new AltKategori
               {
                   Id = 43,
                   AltKategoriAdi = "Hastane Odası Süsleme",
                   KategoriId = 7,
                   Aktif = true
               },
              new AltKategori
              {
                  Id = 43,
                  AltKategoriAdi = "İftar Yemeği Catering",
                  KategoriId = 7,
                  Aktif = true
              },
               new AltKategori
               {
                   Id = 43,
                   AltKategoriAdi = "Kına Organizasyon",
                   KategoriId = 7,
                   Aktif = true
               },
              new AltKategori
              {
                  Id = 43,
                  AltKategoriAdi = "Klasik Araba Kiralama",
                  KategoriId = 7,
                  Aktif = true
              },
               new AltKategori
               {
                   Id = 43,
                   AltKategoriAdi = "Kokteyl Catering",
                   KategoriId = 7,
                   Aktif = true
               },
              new AltKategori
              {
                  Id = 43,
                  AltKategoriAdi = "Masa Sandalye Kiralama",
                  KategoriId = 7,
                  Aktif = true
              },
               new AltKategori
               {
                   Id = 43,
                   AltKategoriAdi = "Mevlüt Yemeği",
                   KategoriId = 7,
                   Aktif = true
               },
              new AltKategori
              {
                  Id = 43,
                  AltKategoriAdi = "Mevlüt Yemeği Catering",
                  KategoriId = 7,
                  Aktif = true
              },
               new AltKategori
               {
                   Id = 43,
                   AltKategoriAdi = "Müzisyen",
                   KategoriId = 7,
                   Aktif = true
               },
              new AltKategori
              {
                  Id = 43,
                  AltKategoriAdi = "Nişan İkramlıkları Catering",
                  KategoriId = 7,
                  Aktif = true
              },
                new AltKategori
                {
                    Id = 43,
                    AltKategoriAdi = "Nişan Menüsü Catering",
                    KategoriId = 7,
                    Aktif = true
                },
              new AltKategori
              {
                  Id = 43,
                  AltKategoriAdi = "Nişan Organizasyon",
                  KategoriId = 7,
                  Aktif = true
              },
               new AltKategori
               {
                   Id = 43,
                   AltKategoriAdi = "Nişan Pastası",
                   KategoriId = 7,
                   Aktif = true
               },
              new AltKategori
              {
                  Id = 43,
                  AltKategoriAdi = "Palyaço",
                  KategoriId = 7,
                  Aktif = true
              },
               new AltKategori
               {
                   Id = 43,
                   AltKategoriAdi = "Sihirbaz",
                   KategoriId = 7,
                   Aktif = true
               },
              new AltKategori
              {
                  Id = 43,
                  AltKategoriAdi = "Söz Organizyon",
                  KategoriId = 7,
                  Aktif = true
              },
               new AltKategori
               {
                   Id = 43,
                   AltKategoriAdi = "Sünnet Organizasyon",
                   KategoriId = 7,
                   Aktif = true
               },
              new AltKategori
              {
                  Id = 43,
                  AltKategoriAdi = "Tabldot Yemek",
                  KategoriId = 7,
                  Aktif = true
              },
               new AltKategori
               {
                   Id = 43,
                   AltKategoriAdi = "Temsili Nikah Memuru",
                   KategoriId = 7,
                   Aktif = true
               },
               new AltKategori
               {
                   Id = 43,
                   AltKategoriAdi = "Yaş Pasta",
                   KategoriId = 7,
                   Aktif = true
               },
               new AltKategori
               {
                   Id = 43,
                   AltKategoriAdi = "Yat Kiralama",
                   KategoriId = 7,
                   Aktif = true
               },
              new AltKategori
              {
                  Id = 43,
                  AltKategoriAdi = "Yatta Evlilik Teklifi",
                  KategoriId = 7,
                  Aktif = true
              });
        }
        void AddDataToAltKategori8(ModelBuilder modelBuilder)


        {
            modelBuilder.Entity<AltKategori>().HasData(

                //fotograf ve video katid=8
                new AltKategori
                {
                    Id = 1,
                    AltKategoriAdi = "Bebek Fotoğrafçısı",
                    KategoriId = 8,
                    Aktif = true
                }, new AltKategori
                {
                    Id = 1,
                    AltKategoriAdi = "Dış Çekim Fotoğraf",
                    KategoriId = 8,
                    Aktif = true
                }, new AltKategori
                {
                    Id = 1,
                    AltKategoriAdi = "Doğum Günü Fotoğrafçısı",
                    KategoriId = 8,
                    Aktif = true
                }, new AltKategori
                {
                    Id = 1,
                    AltKategoriAdi = "Drone Çekimi",
                    KategoriId = 8,
                    Aktif = true
                }, new AltKategori
                {
                    Id = 1,
                    AltKategoriAdi = "Drone Fotoğraf Ve Video",
                    KategoriId = 8,
                    Aktif = true
                }, new AltKategori
                {
                    Id = 1,
                    AltKategoriAdi = "Düğün Fotoğrafçısı",
                    KategoriId = 8,
                    Aktif = true
                }, new AltKategori
                {
                    Id = 1,
                    AltKategoriAdi = "Düğün Video Çekimi",
                    KategoriId = 8,
                    Aktif = true
                }, new AltKategori
                {
                    Id = 1,
                    AltKategoriAdi = "Fotoğrafçı",
                    KategoriId = 8,
                    Aktif = true
                }, new AltKategori
                {
                    Id = 1,
                    AltKategoriAdi = "Hamile Fotoğraf Çekimi",
                    KategoriId = 8,
                    Aktif = true
                }, new AltKategori
                {
                    Id = 1,
                    AltKategoriAdi = "İnstagram İçin Fotoğraf Çekimi",
                    KategoriId = 8,
                    Aktif = true
                }, new AltKategori
                {
                    Id = 1,
                    AltKategoriAdi = "Mekan Fotoğraf Çekimi",
                    KategoriId = 8,
                    Aktif = true
                }, new AltKategori
                {
                    Id = 1,
                    AltKategoriAdi = "Nişan Fotoğrafçısı",
                    KategoriId = 8,
                    Aktif = true
                }, new AltKategori
                {
                    Id = 1,
                    AltKategoriAdi = "Sosyal Medya İçin Fotoğraf Çekimi",
                    KategoriId = 8,
                    Aktif = true
                }, new AltKategori
                {
                    Id = 1,
                    AltKategoriAdi = "Sosyal Medya Video Çekimi",
                    KategoriId = 8,
                    Aktif = true
                }, new AltKategori
                {
                    Id = 1,
                    AltKategoriAdi = "Stüdyo Fotoğraf Çekimi",
                    KategoriId = 8,
                    Aktif = true
                }, new AltKategori
                {
                    Id = 1,
                    AltKategoriAdi = "Tanıtım Filmi Çekimi",
                    KategoriId = 8,
                    Aktif = true
                }, new AltKategori
                {
                    Id = 1,
                    AltKategoriAdi = "Ürün Fotoğraf Çekimi",
                    KategoriId = 8,
                    Aktif = true
                }, new AltKategori
                {
                    Id = 1,
                    AltKategoriAdi = "Video Çekimi",
                    KategoriId = 8,
                    Aktif = true
                }, new AltKategori
                {
                    Id = 1,
                    AltKategoriAdi = "Video Editörü",
                    KategoriId = 8,
                    Aktif = true
                });
        }
        void AddDataToAltKategori9(ModelBuilder modelBuilder)


        {
            modelBuilder.Entity<AltKategori>().HasData(
                  //dijital ve kurumsal katid=9
                  new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "3D Animasyon Yapımı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "3D Baskı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Abiye Dikimi",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Afiş Tasarım",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Almanca Çeviri",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Almanca Yeminli Tercüme",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Ambalaj Tasarım",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Android Uygulama",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Geliştirme",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Animasyon Yapımı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Arapça Çeviri",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "AutoCAD Çizim",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Banner Tasarımı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Broşür Baskı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Broşür Dağıtım",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Broşür Tasarım",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "CV Hazırlama Danışmanlığı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Davetiye Baskı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Dijital Baskı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Dijital Pazarlama ve Reklam",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Dış Ticaret Danışmanlık",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Duvara Resim Yapma",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "E Ticaret Danışmanı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "E Ticaret Sitesi Yapımı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Elbise Dikimi",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Elbise İmalatı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Elektronik Devre Tasarımı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Freelance Yazılımcı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Fuar Hostesi",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Google Reklam Yönetimi",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Graffiti",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Grafik Tasarım",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Gümrük Müşaviri",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "3D Animasyon Yapımı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "İllüstrasyon Çizim",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "İngilizce Çeviri",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "İngilizce Makale Yazımı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "İngilizce Yeminli Tercüme",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "İş Sağlığı ve Güvenliği",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Kadın Manken",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Karakalem Çizim",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Karikatür Çizim",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Kartvizit Baskı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Kartvizit Tasarımı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Katalog Tasarımı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Kitap Baskı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Kitap Editörü",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Kitap Kapağı Tasarımı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "KOSGEB Danışmanlık",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Kutu Harf Tabela",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Limited Şirket Kurma",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Logo Tasarım",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Marka Tescil",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Metin Yazarı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Metin Yazma",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Mevcut Web Sitesi Düzenleme",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Mobil Uygulama Geliştirme",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Moda Tasarım",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Modelist",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Müzik Prodüksiyon",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Osmanlıca Çeviri",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Oyun Programlama",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Özel Güvenlik",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Özel Koruma",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Photoshop Uzmanı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Pleksi Tabela",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Python Programlama",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Reklam Tasarımı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Ressam",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Rusça Çeviri",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Şahıs Şirketi Kurma",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Senaryo Yazarı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Logo Tasarım",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "SEO Hizmeti",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "SEO Uyumlu Makale Yazımı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Seslendirme",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "SGK Danışmanlık",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Simultane Çeviri",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Site Bina ve Apartman Yönetimi",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Sosyal Medya Danışmanlığı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Sosyal Medya Tasarım",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Sosyal Medya Uzmanı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Sosyal Medya Yönetimi ve Danışmanlığı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "SPSS Analizi",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Sunum Hazırlama",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Sweatshirt İmalatı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Tabela",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Tekstil Fason Dikim ve İmalat",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Tişört Baskı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Tişört İmalatı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Vize Danışmanı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Web Site Yapımı",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Web Tasarım",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Web Tasarım Programlama",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Web Yazılım",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Yazılım Geliştirme",
                      KategoriId = 9,
                      Aktif = true
                  }, new AltKategori
                  {
                      Id = 1,
                      AltKategoriAdi = "Yeminli Mütercim Tercüman",
                      KategoriId = 9,
                      Aktif = true
                  });
        }
        void AddDataToAltKategori10(ModelBuilder modelBuilder)


        {
            modelBuilder.Entity<AltKategori>().HasData(
                    //evcil hayvanlar katid=10
                    new AltKategori
                    {
                        Id = 1,
                        AltKategoriAdi = "Evde Kedi Bakımı",
                        KategoriId = 10,
                        Aktif = true
                    },
                   new AltKategori
                   {
                       Id = 1,
                       AltKategoriAdi = "Kedi Bakımı",
                       KategoriId = 10,
                       Aktif = true
                   },
                   new AltKategori
                   {
                       Id = 1,
                       AltKategoriAdi = "Kedi Oteli",
                       KategoriId = 10,
                       Aktif = true
                   },
                   new AltKategori
                   {
                       Id = 1,
                       AltKategoriAdi = "Kedi Teli",
                       KategoriId = 10,
                       Aktif = true
                   }, new AltKategori
                   {
                       Id = 1,
                       AltKategoriAdi = "Kedi Traşı",
                       KategoriId = 10,
                       Aktif = true
                   }, new AltKategori
                   {
                       Id = 1,
                       AltKategoriAdi = "Köpek Eğitimi",
                       KategoriId = 10,
                       Aktif = true
                   }, new AltKategori
                   {
                       Id = 1,
                       AltKategoriAdi = "Köpek Gezdirme",
                       KategoriId = 10,
                       Aktif = true
                   }, new AltKategori
                   {
                       Id = 1,
                       AltKategoriAdi = "Köpek Kuaförü",
                       KategoriId = 10,
                       Aktif = true
                   }, new AltKategori
                   {
                       Id = 1,
                       AltKategoriAdi = "Köpek Oteli",
                       KategoriId = 10,
                       Aktif = true
                   }, new AltKategori
                   {
                       Id = 1,
                       AltKategoriAdi = "Köpek Pansiyonu",
                       KategoriId = 10,
                       Aktif = true
                   }, new AltKategori
                   {
                       Id = 1,
                       AltKategoriAdi = "Köpek Traşı",
                       KategoriId = 10,
                       Aktif = true
                   }, new AltKategori
                   {
                       Id = 1,
                       AltKategoriAdi = "Pet Kuaförü",
                       KategoriId = 10,
                       Aktif = true
                   });
        }
        void AddDataToAltKategori11(ModelBuilder modelBuilder)


        {
            modelBuilder.Entity<AltKategori>().HasData(
                     //oto ve araç katid=11
                     new AltKategori
                     {
                         Id = 1,
                         AltKategoriAdi = "Araç Bakım",
                         KategoriId = 11,
                         Aktif = true
                     }, new AltKategori
                     {
                         Id = 1,
                         AltKategoriAdi = "Araç Folyo Kaplama",
                         KategoriId = 11,
                         Aktif = true
                     }, new AltKategori
                     {
                         Id = 1,
                         AltKategoriAdi = "Araç Koltuk Temizleme",
                         KategoriId = 11,
                         Aktif = true
                     }, new AltKategori
                     {
                         Id = 1,
                         AltKategoriAdi = "Araç Seramik Kaplama",
                         KategoriId = 11,
                         Aktif = true
                     }, new AltKategori
                     {
                         Id = 1,
                         AltKategoriAdi = "Balata Değişimi",
                         KategoriId = 11,
                         Aktif = true
                     }, new AltKategori
                     {
                         Id = 1,
                         AltKategoriAdi = "Baskı Balata Değişimi",
                         KategoriId = 11,
                         Aktif = true
                     }, new AltKategori
                     {
                         Id = 1,
                         AltKategoriAdi = "Boyasız Göçük Düzeltme",
                         KategoriId = 11,
                         Aktif = true
                     }, new AltKategori
                     {
                         Id = 1,
                         AltKategoriAdi = "Motor Yağ Değişimi",
                         KategoriId = 11,
                         Aktif = true
                     }, new AltKategori
                     {
                         Id = 1,
                         AltKategoriAdi = "Oto Bakım",
                         KategoriId = 11,
                         Aktif = true
                     }, new AltKategori
                     {
                         Id = 1,
                         AltKategoriAdi = "Oto Boya",
                         KategoriId = 11,
                         Aktif = true
                     }, new AltKategori
                     {
                         Id = 1,
                         AltKategoriAdi = "AOto Cam Filmi",
                         KategoriId = 11,
                         Aktif = true
                     }, new AltKategori
                     {
                         Id = 1,
                         AltKategoriAdi = "Oto Ekspertiz",
                         KategoriId = 11,
                         Aktif = true
                     }, new AltKategori
                     {
                         Id = 1,
                         AltKategoriAdi = "Oto Kuaför",
                         KategoriId = 11,
                         Aktif = true
                     }, new AltKategori
                     {
                         Id = 1,
                         AltKategoriAdi = "Pasta Cila",
                         KategoriId = 11,
                         Aktif = true
                     }, new AltKategori
                     {
                         Id = 1,
                         AltKategoriAdi = "Triger Seti Değişimi",
                         KategoriId = 11,
                         Aktif = true
                     });
        }
        void AddDataToAltKategori12(ModelBuilder modelBuilder)


        {
                modelBuilder.Entity<AltKategori>().HasData(
                          //diğer katid=12
                          new AltKategori
                          {
                              Id = 1,
                              AltKategoriAdi = "Emlak Satış Danışmanı",
                              KategoriId = 12,
                              Aktif = true
                          }, new AltKategori
                          {
                              Id = 1,
                              AltKategoriAdi = "Gayrimenkul Değerleme",
                              KategoriId = 12,
                              Aktif = true
                          }, new AltKategori
                          {
                              Id = 1,
                              AltKategoriAdi = "Özel Dedektif",
                              KategoriId = 12,
                              Aktif = true
                          }, new AltKategori
                          {
                              Id = 1,
                              AltKategoriAdi = "Trafik Sigortası",
                              KategoriId = 12,
                              Aktif = true
                          });
            }

        void AddDataToSoru(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Soru>().HasData(
                //Ev temizliği
                      new Soru
                      {
                          SoruId=1,
                          AltKategoriId=1,
                          Sorular="Evin Büyüklüğü"
                      }, 
                      new Soru
                      {
                          SoruId=2,
                          AltKategoriId=1,
                          Sorular="Banyo Sayısı"
                      },
                      new Soru
                      {
                          SoruId=3,
                          AltKategoriId=1,
                          Sorular="Kaç Saat"
                      },
                      new Soru
                      {
                          SoruId=4,
                          AltKategoriId=1,
                          Sorular="Hangi Sıklık"
                      },
                      new Soru
                      {
                          SoruId=5,
                          AltKategoriId=1,
                          Sorular="Ek Hizmet"
                      },
                      new Soru
                      {
                          SoruId=6,
                          AltKategoriId=1,
                          Sorular="il"
                      },new Soru
                      {
                          SoruId=7,
                          AltKategoriId=1,
                          Sorular="ilçe"
                      },
                      new Soru
                      {
                          SoruId=8,
                          AltKategoriId=1,
                          Sorular="Detay"
                      },
                      /////Apartman Temizliği
                      ///
                      new Soru
                      {
                          SoruId =9,
                          AltKategoriId = 2,
                          Sorular = "Daire Sayısı"
                      }, 
                      new Soru
                      {
                          SoruId =10,
                          AltKategoriId = 2,
                          Sorular = "Çöp Toplansın mı"
                      }, 
                      new Soru
                      {
                          SoruId =11,
                          AltKategoriId = 2,
                          Sorular = "Hangi Sıklık"
                      }, 
                      new Soru
                      {
                          SoruId =12,
                          AltKategoriId = 2,
                          Sorular = "il"
                      }, new Soru
                      {
                          SoruId =13,
                          AltKategoriId = 2,
                          Sorular = "ilçe"
                      },
                      new Soru
                      {
                          SoruId =14,
                          AltKategoriId = 2,
                          Sorular = "Detay"
                      },
                      ///Ofis Temizliği
                      new Soru
                      {
                          SoruId = 15,
                          AltKategoriId = 3,
                          Sorular = "Hangi Sıklık"
                      },
                      new Soru
                      {
                          SoruId = 16,
                          AltKategoriId = 3,
                          Sorular = "Kaç Metrekare"
                      },
                      new Soru
                      {
                          SoruId = 17,
                          AltKategoriId = 3,
                          Sorular = "il"
                      }, new Soru
                      {
                          SoruId = 18,
                          AltKategoriId = 3,
                          Sorular = "ilçe"
                      },new Soru
                      {
                          SoruId = 19,
                          AltKategoriId = 3,
                          Sorular = "Detay"
                      },
                      ////İnşaat sonrası ev temizliği
                      new Soru
                      {
                          SoruId = 20,
                          AltKategoriId = 4,
                          Sorular = "Evin Büyüklüğü"
                      }, new Soru
                      {
                          SoruId = 21,
                          AltKategoriId = 4,
                          Sorular = "Banyo Sayısı"
                      }, new Soru
                      {
                          SoruId = 22,
                          AltKategoriId = 4,
                          Sorular = "Kaç Metrekare"
                      }, new Soru
                      {
                          SoruId = 23,
                          AltKategoriId = 4,
                          Sorular = "İl"
                      },new Soru
                      {
                          SoruId = 24,
                          AltKategoriId = 4,
                          Sorular = "İlçe"
                      }, new Soru
                      {
                          SoruId = 25,
                          AltKategoriId = 4,
                          Sorular = "Detay"
                      },
                       //////Dükkan Mağaza Temizliği
                       ///
                       new Soru
                       {
                           SoruId = 26,
                           AltKategoriId = 5,
                           Sorular = "Dükkan Büyüklüğü"
                       }, new Soru
                       {
                           SoruId = 27,
                           AltKategoriId = 5,
                           Sorular = "Hangi Sıklık"
                       }, new Soru
                       {
                           SoruId = 28,
                           AltKategoriId = 5,
                           Sorular = "İl"
                       },new Soru
                       {
                           SoruId = 29,
                           AltKategoriId = 5,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 30,
                           AltKategoriId = 5,
                           Sorular = "Detay"
                       },
                       //////Haşere İlaçlama
                       new Soru
                       {
                           SoruId = 31,
                           AltKategoriId = 6,
                           Sorular = "Haşere Tipi"
                       },new Soru
                       {
                           SoruId = 32,
                           AltKategoriId = 6,
                           Sorular = "Alan Büyüklüğü"
                       },new Soru
                       {
                           SoruId = 33,
                           AltKategoriId = 6,
                           Sorular = "Mekan Tipi"
                       },new Soru
                       {
                           SoruId = 34,
                           AltKategoriId = 6,
                           Sorular = "İl"
                       },new Soru
                       {
                           SoruId = 35,
                           AltKategoriId = 6,
                           Sorular = "İlçe"
                       },new Soru
                       {
                           SoruId = 36,
                           AltKategoriId = 6,
                           Sorular = "Detay"
                       },
                       /////halı yıkama id=7
                       new Soru
                       {
                           SoruId = 37,
                           AltKategoriId = 7,
                           Sorular = "Halı Nerede Yıkansın"
                       },
                       new Soru
                       {
                           SoruId = 38,
                           AltKategoriId = 7,
                           Sorular = "Metrekaresi"
                       },
                       new Soru
                       {
                           SoruId = 39,
                           AltKategoriId = 7,
                           Sorular = "Leke Var mı"
                       },
                       new Soru
                       {
                           SoruId = 40,
                           AltKategoriId = 7,
                           Sorular = "İl"
                       },
                       new Soru
                       {
                           SoruId = 41,
                           AltKategoriId = 7,
                           Sorular = "İlçe"
                       },new Soru
                       {
                           SoruId = 42,
                           AltKategoriId = 7,
                           Sorular = "Detay"
                       },

                       //////kuru temizleme id=8
                       new Soru
                       {
                           SoruId = 43,
                           AltKategoriId = 8,
                           Sorular = "Ürün"
                       },new Soru
                       {
                           SoruId = 44,
                           AltKategoriId = 8,
                           Sorular = "Ütü Yapılsın mı"
                       },new Soru
                       {
                           SoruId = 45,
                           AltKategoriId = 8,
                           Sorular = "Adet"
                       },new Soru
                       {
                           SoruId = 46,
                           AltKategoriId = 8,
                           Sorular = "İl"
                       },new Soru
                       {
                           SoruId = 47,
                           AltKategoriId = 8,
                           Sorular = "İlçe"
                       },new Soru
                       {
                           SoruId = 48,
                           AltKategoriId = 8,
                           Sorular = "Detay"
                       },
                       //////Mobilya temizleme
                       new Soru
                       {
                           SoruId = 49,
                           AltKategoriId = 9,
                           Sorular = "Mobilya"
                       }, new Soru
                       {
                           SoruId = 50,
                           AltKategoriId = 9,
                           Sorular = "Koltuk Minderli mi"
                       }, new Soru
                       {
                           SoruId = 51,
                           AltKategoriId = 9,
                           Sorular = "Adet"
                       }, new Soru
                       {
                           SoruId = 52,
                           AltKategoriId = 9,
                           Sorular = "İl"
                       }, new Soru
                       {
                           SoruId = 53,
                           AltKategoriId = 9,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 54,
                           AltKategoriId = 9,
                           Sorular = "Detay"
                       },

                      /////cam temizleme
                      new Soru
                      {
                          SoruId = 55,
                          AltKategoriId = 10,
                          Sorular = "Mekan"
                      }, new Soru
                      {
                          SoruId = 56,
                          AltKategoriId = 10,
                          Sorular = "İl"
                      },new Soru
                      {
                          SoruId = 57,
                          AltKategoriId = 10,
                          Sorular = "İlçe"
                      },new Soru
                      {
                          SoruId = 58,
                          AltKategoriId = 10,
                          Sorular = "Detay"
                      },

                      /////Tadilat, Dekorasyon ve İnşaat Hizmetleri
                      //Boya, badana
                       new Soru
                       {
                           SoruId = 59,
                           AltKategoriId = 11,
                           Sorular = "Alan Büyüklüğü"
                       }, new Soru
                       {
                           SoruId = 60,
                           AltKategoriId = 11,
                           Sorular = "Kaç Oda"
                       }, new Soru
                       {
                           SoruId = 61,
                           AltKategoriId = 11,
                           Sorular = "Malzeme Dahil mi?"
                       }, new Soru
                       {
                           SoruId = 62,
                           AltKategoriId = 11,
                           Sorular = "İl"
                       }, new Soru
                       {
                           SoruId = 63,
                           AltKategoriId = 11,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 64,
                           AltKategoriId = 11,
                           Sorular = "Detay"
                       },
                       // Kapı
                       new Soru
                       {
                           SoruId = 65,
                           AltKategoriId = 12,
                           Sorular = "Yapılacak İş"
                       }, new Soru
                       {
                           SoruId = 66,
                           AltKategoriId = 12,
                           Sorular = "Kaç Adet?",

                       }, new Soru
                       {
                           SoruId = 67,
                           AltKategoriId = 12,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 68,
                           AltKategoriId = 12,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 69,
                           AltKategoriId = 12,
                           Sorular = "Detay"
                       },
                       //Pencere
                       new Soru
                       {
                           SoruId = 70,
                           AltKategoriId = 13,
                           Sorular = "Tamir Tipi"
                       }, new Soru
                       {
                           SoruId = 71,
                           AltKategoriId = 13,
                           Sorular = "Kaç Adet"
                       }, new Soru
                       {
                           SoruId = 72,
                           AltKategoriId = 13,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 73,
                           AltKategoriId = 13,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 74,
                           AltKategoriId = 13,
                           Sorular = "Detay"
                       },
                       // Banyo Tadilat
                       new Soru
                       {
                           SoruId = 75,
                           AltKategoriId = 14,
                           Sorular = "Tamir Tipi"
                       }, new Soru
                       {
                           SoruId = 76,
                           AltKategoriId = 14,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 77,
                           AltKategoriId = 14,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 78,
                           AltKategoriId = 14,
                           Sorular = "Detay"
                       },
                       // Duvar Örme
                       new Soru
                       {
                           SoruId = 79,
                           AltKategoriId = 15,
                           Sorular = "Duvar malzemesi"
                       }, new Soru
                       {
                           SoruId = 80,
                           AltKategoriId = 15,
                           Sorular = "Duvar Uzunluğu(metre):"
                       }, new Soru
                       {
                           SoruId = 81,
                           AltKategoriId = 15,
                           Sorular = "Duvar Yüksekliği",
                       }, new Soru
                       {
                           SoruId = 82,
                           AltKategoriId = 15,
                           Sorular = "Malzeme Dahil Olsun mu?"
                       }, new Soru
                       {
                           SoruId = 83,
                           AltKategoriId = 15,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 84,
                           AltKategoriId = 15,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 85,
                           AltKategoriId = 15,
                           Sorular = "Detay"
                       },
                       //Cam Balkon
                       new Soru
                       {
                           SoruId = 86,
                           AltKategoriId = 16,
                           Sorular = "Balkon Sistemi"
                       }, new Soru
                       {
                           SoruId = 87,
                           AltKategoriId = 16,
                           Sorular = "Cam Çevresi"
                       }, new Soru
                       {
                           SoruId = 88,
                           AltKategoriId = 16,
                           Sorular = "Cam Yüksekliği"
                       }, new Soru
                       {
                           SoruId = 89,
                           AltKategoriId = 16,
                           Sorular = "Balkon Şekli"
                       }, new Soru
                       {
                           SoruId = 90,
                           AltKategoriId = 16,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 91,
                           AltKategoriId = 16,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 92,
                           AltKategoriId = 16,
                           Sorular = "Detay"
                       },
                       //Zemin Döşeme
                       new Soru
                       {
                           SoruId = 93,
                           AltKategoriId = 17,
                           Sorular = "Döşeme Tipi"
                       }, new Soru
                       {
                           SoruId = 94,
                           AltKategoriId = 17,
                           Sorular = "Döşeme Alanı"
                       }, new Soru
                       {
                           SoruId = 95,
                           AltKategoriId = 17,
                           Sorular = "Fiyata Malzeme Dahil olsun mu?"
                       }, new Soru
                       {
                           SoruId = 96,
                           AltKategoriId = 17,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 97,
                           AltKategoriId = 17,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 98,
                           AltKategoriId = 17,
                           Sorular = "Detay"
                       },
                       // Havuz yapımı
                       new Soru
                       {
                           SoruId = 99,
                           AltKategoriId = 18,
                           Sorular = "Havuz Türü"
                       }, new Soru
                       {
                           SoruId = 100,
                           AltKategoriId = 18,
                           Sorular = "Havuz Boyu"
                       }, new Soru
                       {
                           SoruId = 101,
                           AltKategoriId = 18,
                           Sorular = "Havuz Eni"
                       }, new Soru
                       {
                           SoruId = 102,
                           AltKategoriId = 18,
                           Sorular = "Havuz Derinliği"
                       }, new Soru
                       {
                           SoruId = 103,
                           AltKategoriId = 18,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 104,
                           AltKategoriId = 18,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 105,
                           AltKategoriId = 18,
                           Sorular = "Detay"
                       },
                       // Gardrop yapımı
                       new Soru
                       {
                           SoruId = 106,
                           AltKategoriId = 19,
                           Sorular = "En"
                       }, new Soru
                       {
                           SoruId = 107,
                           AltKategoriId = 19,
                           Sorular = "Boy"
                       }, new Soru
                       {
                           SoruId = 108,
                           AltKategoriId = 19,
                           Sorular = "Derinlik"
                       }, new Soru
                       {
                           SoruId = 109,
                           AltKategoriId = 19,
                           Sorular = "Kapı Tipi"
                       }, new Soru
                       {
                           SoruId = 110,
                           AltKategoriId = 19,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 111,
                           AltKategoriId = 19,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 112,
                           AltKategoriId = 19,
                           Sorular = "Detay"
                       },
                       // İç Mimar
                       new Soru
                       {
                           SoruId = 113,
                           AltKategoriId = 20,
                           Sorular = "Mekan"
                       }, new Soru
                       {
                           SoruId = 114,
                           AltKategoriId = 20,
                           Sorular = "Yapılacak iş"
                       }, new Soru
                       {
                           SoruId = 115,
                           AltKategoriId = 20,
                           Sorular = "Proje Alanı"
                       }, new Soru
                       {
                           SoruId = 116,
                           AltKategoriId = 20,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 117,
                           AltKategoriId = 20,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 118,
                           AltKategoriId = 20,
                           Sorular = "Detay"
                       },
                       // •	Prefabrik Ev Yapımı
                       new Soru
                       {
                           SoruId = 119,
                           AltKategoriId = 21,
                           Sorular = "Alan"
                       }, new Soru
                       {
                           SoruId = 120,
                           AltKategoriId = 21,
                           Sorular = "Kaç Katlı"
                       }, new Soru
                       {
                           SoruId = 121,
                           AltKategoriId = 21,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 122,
                           AltKategoriId = 21,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 123,
                           AltKategoriId = 21,
                           Sorular = "Detay"
                       },
                       // •	Koltuk Döşeme
                       new Soru
                       {
                           SoruId = 124,
                           AltKategoriId = 22,
                           Sorular = "Koltuk Tipi"
                       }, new Soru
                       {
                           SoruId = 125,
                           AltKategoriId = 22,
                           Sorular = "Adet"
                       }, new Soru
                       {
                           SoruId = 126,
                           AltKategoriId = 22,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 127,
                           AltKategoriId = 22,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 128,
                           AltKategoriId = 22,
                           Sorular = "Detay"
                       },
                       // •	Çatı Tadilatı
                       new Soru
                       {
                           SoruId = 129,
                           AltKategoriId = 23,
                           Sorular = "Çatı kaplama malzemesi nedir?"
                       }, new Soru
                       {
                           SoruId = 130,
                           AltKategoriId = 23,
                           Sorular = "Çatıda yapılması gereken işler neler?"
                       }, new Soru
                       {
                           SoruId = 131,
                           AltKategoriId = 23,
                           Sorular = "Tadilat yapılacak çatı alanı yaklaşık kaç m2?"
                       }, new Soru
                       {
                           SoruId = 132,
                           AltKategoriId = 23,
                           Sorular = "Fiyata malzeme dahil olsun mu?"
                       }, new Soru
                       {
                           SoruId = 133,
                           AltKategoriId = 23,
                           Sorular = "Fiyata malzeme dahil olsun mu?"
                       }, new Soru
                       {
                           SoruId = 134,
                           AltKategoriId = 23,
                           Sorular = "Çatı Eğimi Ne kadar"
                       }, new Soru
                       {
                           SoruId = 135,
                           AltKategoriId = 23,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 136,
                           AltKategoriId = 23,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 137,
                           AltKategoriId = 23,
                           Sorular = "Detay"
                       },
                       //•	Doğalgaz Tesisat
                       new Soru
                       {
                           SoruId = 138,
                           AltKategoriId = 24,
                           Sorular = "Yapılacak İş"
                       }, new Soru
                       {
                           SoruId = 139,
                           AltKategoriId = 24,
                           Sorular = "Kaç dairede çalışma yapılacak?"
                       }, new Soru
                       {
                           SoruId = 140,
                           AltKategoriId = 24,
                           Sorular = "Proje çizimi ve gaz açma yapılacak mı?"
                       }, new Soru
                       {
                           SoruId = 141,
                           AltKategoriId = 24,
                           Sorular = "Çalışma yapılacak alan kaç m2?"
                       }, new Soru
                       {
                           SoruId = 142,
                           AltKategoriId = 24,
                           Sorular = "Hangi tesisat(lar) döşenecek?"
                       }, new Soru
                       {
                           SoruId = 143,
                           AltKategoriId = 24,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 144,
                           AltKategoriId = 24,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 145,
                           AltKategoriId = 24,
                           Sorular = "Detay"
                       },
                       // •	Gömme Dolap Yapımı
                       new Soru
                       {
                           SoruId = 146,
                           AltKategoriId = 25,
                           Sorular = "Detay"
                       }, new Soru
                       {
                           SoruId = 147,
                           AltKategoriId = 25,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 148,
                           AltKategoriId = 25,
                           Sorular = "İlçe"
                       },
                       //•	Güneş Enerjisi
                       new Soru
                       {
                           SoruId = 149,
                           AltKategoriId = 26,
                           Sorular = "Ne yaptırmak istiyorsun?"
                       }, new Soru
                       {
                           SoruId = 150,
                           AltKategoriId = 26,
                           Sorular = "Güneş enerjisi sisteminin kullanım amacı nedir?"
                       }, new Soru
                       {
                           SoruId = 151,
                           AltKategoriId = 26,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 152,
                           AltKategoriId = 26,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 153,
                           AltKategoriId = 26,
                           Sorular = "Detay"
                       },
                       // •	Sineklik
                       new Soru
                       {
                           SoruId = 154,
                           AltKategoriId = 27,
                           Sorular = "Sineklik nereye yapılacak?"
                       }, new Soru
                       {
                           SoruId = 155,
                           AltKategoriId = 27,
                           Sorular = "Ne tür sineklik istiyorsun?"
                       }, new Soru
                       {
                           SoruId = 156,
                           AltKategoriId = 27,
                           Sorular = "Kaç adet kapı sinekliği gerekiyor?"
                       }, new Soru
                       {
                           SoruId = 157,
                           AltKategoriId = 27,
                           Sorular = "Kapı eni ne kadar?"
                       }, new Soru
                       {
                           SoruId = 158,
                           AltKategoriId = 27,
                           Sorular = "Kapı boyu ne kadar?"
                       }, new Soru
                       {
                           SoruId = 159,
                           AltKategoriId = 27,
                           Sorular = "Kaç adet pencere sinekliği gerekiyor?"
                       }, new Soru
                       {
                           SoruId = 160,
                           AltKategoriId = 27,
                           Sorular = "Pencere eni ne kadar?"
                       }, new Soru
                       {
                           SoruId = 161,
                           AltKategoriId = 27,
                           Sorular = "Pencere boyu ne kadar?"
                       }, new Soru
                       {
                           SoruId = 162,
                           AltKategoriId = 27,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 163,
                           AltKategoriId = 27,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 164,
                           AltKategoriId = 27,
                           Sorular = "Detay"
                       },
                       //•	Mezar Yapımı
                       new Soru
                       {
                           SoruId = 165,
                           AltKategoriId = 28,
                           Sorular = "Kaç Kişilik"
                       }, new Soru
                       {
                           SoruId = 166,
                           AltKategoriId = 28,
                           Sorular = "Ne kadarı Yapılacak?"
                       }, new Soru
                       {
                           SoruId = 167,
                           AltKategoriId = 28,
                           Sorular = "Malzeme tercihi"
                       }, new Soru
                       {
                           SoruId = 168,
                           AltKategoriId = 28,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 169,
                           AltKategoriId = 28,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 170,
                           AltKategoriId = 28,
                           Sorular = "Detay"
                       },
                       // •	Vestiyer & Portmanto
                       new Soru
                       {
                           SoruId = 171,
                           AltKategoriId = 29,
                           Sorular = "Detay"
                       }, new Soru
                       {
                           SoruId = 172,
                           AltKategoriId = 29,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 173,
                           AltKategoriId = 29,
                           Sorular = "İlçe"
                       },
                       // •	Sandalye Döşeme
                       new Soru
                       {
                           SoruId = 174,
                           AltKategoriId = 30,
                           Sorular = "Kaç adet sandalye döşenecek?"
                       }, new Soru
                       {
                           SoruId = 175,
                           AltKategoriId = 30,
                           Sorular = "Sandalye tipi nedir?"
                       }, new Soru
                       {
                           SoruId = 176,
                           AltKategoriId = 30,
                           Sorular = "Nasıl bir döşeme istiyorsunuz?"
                       }, new Soru
                       {
                           SoruId = 177,
                           AltKategoriId = 30,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 178,
                           AltKategoriId = 30,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 179,
                           AltKategoriId = 30,
                           Sorular = "Detay"
                       },
                       // •	Ses Yalıtımı
                       new Soru
                       {
                           SoruId = 180,
                           AltKategoriId = 31,
                           Sorular = "Nereye ses yalıtımı yapılacak?"
                       }, new Soru
                       {
                           SoruId = 181,
                           AltKategoriId = 31,
                           Sorular = "Ses yalıtımı yapılacak tavan alanı kaç metrekare?"
                       }, new Soru
                       {
                           SoruId = 182,
                           AltKategoriId = 31,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 183,
                           AltKategoriId = 31,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 184,
                           AltKategoriId = 31,
                           Sorular = "Detay"
                       },
                       // Sıva
                       new Soru
                       {
                           SoruId = 185,
                           AltKategoriId = 32,
                           Sorular = "Sıva hangilerine yapılacak?"
                       }, new Soru
                       {
                           SoruId = 186,
                           AltKategoriId = 32,
                           Sorular = "Toplam kaç metrekare alan sıva yapılacak?"
                       }, new Soru
                       {
                           SoruId = 187,
                           AltKategoriId = 32,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 188,
                           AltKategoriId = 32,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 189,
                           AltKategoriId = 32,
                           Sorular = "Detay"
                       },
                       // Kaynak
                       new Soru
                       {
                           SoruId = 190,
                           AltKategoriId = 33,
                           Sorular = "Kaynak yapılacak olan nedir?"
                       }, new Soru
                       {
                           SoruId = 191,
                           AltKategoriId = 33,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 192,
                           AltKategoriId = 33,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 193,
                           AltKategoriId = 33,
                           Sorular = "Detay"
                       },
                       // Alçı
                       new Soru
                       {
                           SoruId = 194,
                           AltKategoriId = 34,
                           Sorular = "Kaç metrekare oda/ev alçı yapılacak?"
                       }, new Soru
                       {
                           SoruId = 195,
                           AltKategoriId = 34,
                           Sorular = "Fiyata malzeme dahil olsun mu?"
                       }, new Soru
                       {
                           SoruId = 196,
                           AltKategoriId = 34,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 197,
                           AltKategoriId = 34,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 198,
                           AltKategoriId = 34,
                           Sorular = "Detay"
                       },
                       // •	Deprem Testi
                       new Soru
                       {
                           SoruId = 199,
                           AltKategoriId = 35,
                           Sorular = "Kaç adet bina / blok için deprem testi yapılacak?"
                       }, new Soru
                       {
                           SoruId = 200,
                           AltKategoriId = 35,
                           Sorular = "Bina(lar) kaç katlı? (Zemin altı katlar dahil)"
                       }, new Soru
                       {
                           SoruId = 201,
                           AltKategoriId = 35,
                           Sorular = "Bina zemin oturum alanı kaç metrekare?"
                       }, new Soru
                       {
                           SoruId = 202,
                           AltKategoriId = 35,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 203,
                           AltKategoriId = 35,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 204,
                           AltKategoriId = 35,
                           Sorular = "Detay"
                       },
                       // •	Stor Perde
                       new Soru
                       {
                           SoruId = 205,
                           AltKategoriId = 36,
                           Sorular = "Hangisine ihtiyacın var?"
                       }, new Soru
                       {
                           SoruId = 206,
                           AltKategoriId = 36,
                           Sorular = "Hangi tip stor perde yapılacak?"
                       }, new Soru
                       {
                           SoruId = 207,
                           AltKategoriId = 36,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 208,
                           AltKategoriId = 36,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 209,
                           AltKategoriId = 36,
                           Sorular = "Detay"
                       },
                       // •	Panjur
                       new Soru
                       {
                           SoruId = 210,
                           AltKategoriId = 37,
                           Sorular = "Ne yapılması gerekiyor?"
                       }, new Soru
                       {
                           SoruId = 211,
                           AltKategoriId = 37,
                           Sorular = "Ne tür bir panjur?"
                       }, new Soru
                       {
                           SoruId = 212,
                           AltKategoriId = 37,
                           Sorular = "Nereye yapılacak?"
                       }, new Soru
                       {
                           SoruId = 213,
                           AltKategoriId = 37,
                           Sorular = "Kaç adet panjur?"
                       }, new Soru
                       {
                           SoruId = 214,
                           AltKategoriId = 37,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 215,
                           AltKategoriId = 37,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 216,
                           AltKategoriId = 37,
                           Sorular = "Detay"
                       },
                       // •	Hazır Rulo Çim
                       new Soru
                       {
                           SoruId = 217,
                           AltKategoriId = 38,
                           Sorular = "Kaç metrekare hazır rulo çim yapılacak?"
                       }, new Soru
                       {
                           SoruId = 218,
                           AltKategoriId = 38,
                           Sorular = "Fiyata sulama sistemi kurulması da dahil olsun mu?"
                       }, new Soru
                       {
                           SoruId = 219,
                           AltKategoriId = 38,
                           Sorular = "Uygulama öncesi ne gibi toprak hazırlıklarına ihtiyacın var?"
                       }, new Soru
                       {
                           SoruId = 220,
                           AltKategoriId = 38,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 221,
                           AltKategoriId = 38,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 222,
                           AltKategoriId = 38,
                           Sorular = "Detay"
                       },
                       // Özel Mobilya Yapımı
                       new Soru
                       {
                           SoruId = 223,
                           AltKategoriId = 39,
                           Sorular = "Ne yaptırmak İstiyorsunuz?"
                       }, new Soru
                       {
                           SoruId = 224,
                           AltKategoriId = 39,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 225,
                           AltKategoriId = 39,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 226,
                           AltKategoriId = 39,
                           Sorular = "Detay"
                       },
                       // Mermer
                       new Soru
                       {
                           SoruId = 227,
                           AltKategoriId = 40,
                           Sorular = "Neye ihtiyacın var?"
                       }, new Soru
                       {
                           SoruId = 228,
                           AltKategoriId = 40,
                           Sorular = "Hangi tip mermer "
                       }, new Soru
                       {
                           SoruId = 229,
                           AltKategoriId = 40,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 230,
                           AltKategoriId = 40,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 231,
                           AltKategoriId = 40,
                           Sorular = "Detay"
                       },
                       // Panel Çit
                       new Soru
                       {
                           SoruId = 232,
                           AltKategoriId = 41,
                           Sorular = "Ne tip çit istiyorsun?"
                       }, new Soru
                       {
                           SoruId = 233,
                           AltKategoriId = 41,
                           Sorular = "Hangi zemine yapılacak?"
                       }, new Soru
                       {
                           SoruId = 234,
                           AltKategoriId = 41,
                           Sorular = "Çit uzunluğu kaç metre olacak?"
                       }, new Soru
                       {
                           SoruId = 235,
                           AltKategoriId = 41,
                           Sorular = "Yüksekliği kaç santimetre olacak?:"
                       }, new Soru
                       {
                           SoruId = 236,
                           AltKategoriId = 41,
                           Sorular = "Kaç kapı olacak?"
                       }, new Soru
                       {
                           SoruId = 237,
                           AltKategoriId = 41,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 238,
                           AltKategoriId = 41,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 239,
                           AltKategoriId = 41,
                           Sorular = "Detay"
                       },
                       // •	Tente Branda
                       new Soru
                       {
                           SoruId = 240,
                           AltKategoriId = 42,
                           Sorular = "Ne yaptırmak istiyorsun?"
                       }, new Soru
                       {
                           SoruId = 241,
                           AltKategoriId = 42,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 242,
                           AltKategoriId = 42,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 243,
                           AltKategoriId = 42,
                           Sorular = "Detay"
                       },
                       // Bina güçlendirme
                       new Soru
                       {
                           SoruId = 244,
                           AltKategoriId = 43,
                           Sorular = "Kaç adet bina / blok için bina güçlendirme yapılacak?"
                       }, new Soru
                       {
                           SoruId = 245,
                           AltKategoriId = 43,
                           Sorular = "Bina(lar) kaç katlı? (Zemin altı katlar dahil)"
                       }, new Soru
                       {
                           SoruId = 246,
                           AltKategoriId = 43,
                           Sorular = "Bina zemin oturum alanı kaç metrekare?"
                       }, new Soru
                       {
                           SoruId = 247,
                           AltKategoriId = 43,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 248,
                           AltKategoriId = 43,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 249,
                           AltKategoriId = 43,
                           Sorular = "Detay"
                       },
                       // Teras Kapatma
                       new Soru
                       {
                           SoruId = 250,
                           AltKategoriId = 44,
                           Sorular = "Hangi tip tavan ile teras kapatılacak?"
                       }, new Soru
                       {
                           SoruId = 251,
                           AltKategoriId = 44,
                           Sorular = "Kapatılacak teras alanı kaç metrekare?"
                       }, new Soru
                       {
                           SoruId = 252,
                           AltKategoriId = 44,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 253,
                           AltKategoriId = 44,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 254,
                           AltKategoriId = 44,
                           Sorular = "Detay"
                       },
                       // Mutfak 
                       new Soru
                       {
                           SoruId = 255,
                           AltKategoriId = 45,
                           Sorular = "Yapılacak iş"
                       }, new Soru
                       {
                           SoruId = 256,
                           AltKategoriId = 45,
                           Sorular = "Alan"
                       }, new Soru
                       {
                           SoruId = 257,
                           AltKategoriId = 45,
                           Sorular = "Malzeme dahil mi?"
                       }, new Soru
                       {
                           SoruId = 258,
                           AltKategoriId = 45,
                           Sorular = "İl",
                       }, new Soru
                       {
                           SoruId = 259,
                           AltKategoriId = 45,
                           Sorular = "İlçe"
                       }, new Soru
                       {
                           SoruId = 260,
                           AltKategoriId = 45,
                           Sorular = "Detay",
                       }


                      );
        }

        void AddDataToCevap(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Cevap>().HasData(
                      //Ev temizliği
                      new Cevap
                      {
                          CevapId = 1,
                          SoruId = 1,
                          Cevaplar="1+0"
                      },
                      new Cevap
                      {
                          CevapId = 2,
                          SoruId = 1,
                          Cevaplar="1+1"
                      }, new Cevap
                      {
                          CevapId = 3,
                          SoruId = 1,
                          Cevaplar="2+1"
                      },new Cevap
                      {
                          CevapId = 4,
                          SoruId = 1,
                          Cevaplar="3+1"
                      },new Cevap
                      {
                          CevapId = 5,
                          SoruId = 1,
                          Cevaplar="Diğer"
                      },new Cevap
                      {
                          CevapId = 6,
                          SoruId = 2,
                          Cevaplar="1"
                      },new Cevap
                      {
                          CevapId = 7,
                          SoruId = 2,
                          Cevaplar="2"
                      },new Cevap
                      {
                          CevapId = 8,
                          SoruId = 2,
                          Cevaplar="diğer"
                      },new Cevap
                      {
                          CevapId = 9,
                          SoruId = 3,
                          Cevaplar="3"
                      },new Cevap
                      {
                          CevapId = 10,
                          SoruId = 3,
                          Cevaplar="4"
                      },new Cevap
                      {
                          CevapId = 11,
                          SoruId = 3,
                          Cevaplar="5"
                      },new Cevap
                      {
                          CevapId = 12,
                          SoruId = 3,
                          Cevaplar="6"
                      },new Cevap
                      {
                          CevapId = 13,
                          SoruId = 3,
                          Cevaplar="Diğer"
                      },new Cevap
                      {
                          CevapId = 14,
                          SoruId = 4,
                          Cevaplar="Haftada Bir"
                      },new Cevap
                      {
                          CevapId = 15,
                          SoruId = 4,
                          Cevaplar="Haftada iki"
                      },new Cevap
                      {
                          CevapId = 16,
                          SoruId = 4,
                          Cevaplar="Tek Seferlik"
                      },
                      new Cevap
                      {
                          CevapId = 17,
                          SoruId = 4,
                          Cevaplar="Diğer"
                      },new Cevap
                      {
                          CevapId = 18,
                          SoruId = 5,
                          Cevaplar="Yemek"
                      },new Cevap
                      {
                          CevapId = 19,
                          SoruId = 5,
                          Cevaplar="Çamaşır Yıkama"
                      },new Cevap
                      {
                          CevapId = 20,
                          SoruId = 5,
                          Cevaplar="Ütü"
                      },new Cevap
                      {
                          CevapId = 21,
                          SoruId = 6,
                          Cevaplar="il"
                      },new Cevap
                      {
                          CevapId = 22,
                          SoruId = 7,
                          Cevaplar="ilçe"
                      },new Cevap
                      {
                          CevapId = 23,
                          SoruId = 8,
                          Cevaplar="Mesaj"
                      },
                      /////apartman temizliği
                      new Cevap
                      {
                          CevapId = 24,
                          SoruId = 9,
                          Cevaplar = "1-5"
                      },
                      new Cevap
                      {
                          CevapId = 25,
                          SoruId = 9,
                          Cevaplar = "6-12"
                      },
                      new Cevap
                      {
                          CevapId = 26,
                          SoruId = 9,
                          Cevaplar = "13-20"
                      },
                      new Cevap
                      {
                          CevapId = 27,
                          SoruId = 9,
                          Cevaplar = "Diğer"
                      },new Cevap
                      {
                          CevapId = 28,
                          SoruId = 10,
                          Cevaplar = "Evet"
                      },new Cevap
                      {
                          CevapId = 29,
                          SoruId = 10,
                          Cevaplar = "Hayır"
                      }, new Cevap
                      {
                          CevapId = 30,
                          SoruId = 11,
                          Cevaplar = "Haftada bir"
                      }, new Cevap
                      {
                          CevapId = 31,
                          SoruId = 11,
                          Cevaplar = "Haftada iki"
                      }, new Cevap
                      {
                          CevapId = 32,
                          SoruId = 11,
                          Cevaplar = "Tek Seferlik"
                      }, new Cevap
                      {
                          CevapId = 33,
                          SoruId = 11,
                          Cevaplar = "Diğer"
                      },new Cevap
                      {
                          CevapId = 34,
                          SoruId = 12,
                          Cevaplar = "İl"
                      },new Cevap
                      {
                          CevapId = 35,
                          SoruId = 13,
                          Cevaplar = "İlçe"
                      },new Cevap
                      {
                          CevapId = 36,
                          SoruId = 14,
                          Cevaplar = "Mesaj"
                      },
                      //
                      ////Ofis temizliği
                      new Cevap
                      {
                          CevapId = 37,
                          SoruId = 15,
                          Cevaplar = "Haftada Bir"
                      },new Cevap
                      {
                          CevapId = 38,
                          SoruId = 15,
                          Cevaplar = "Haftada iki"
                      },new Cevap
                      {
                          CevapId = 39,
                          SoruId = 15,
                          Cevaplar = "Tek Seferlik"
                      },new Cevap
                      {
                          CevapId = 40,
                          SoruId = 15,
                          Cevaplar = "Diğer"
                      },new Cevap
                      {
                          CevapId = 41,
                          SoruId = 16,
                          Cevaplar = "30-80"
                      },new Cevap
                      {
                          CevapId = 42,
                          SoruId = 16,
                          Cevaplar = "80-120"
                      },new Cevap
                      {
                          CevapId = 43,
                          SoruId = 16,
                          Cevaplar = "120-200"
                      },new Cevap
                      {
                          CevapId = 44,
                          SoruId = 17,
                          Cevaplar = "İl"
                      },new Cevap
                      {
                          CevapId = 45,
                          SoruId = 18,
                          Cevaplar = "İlçe"
                      },new Cevap
                      {
                          CevapId = 46,
                          SoruId = 19,
                          Cevaplar = "Mesaj"
                      },
                      /////İnşaat sonrası ev temizliği
                      new Cevap
                      {
                          CevapId = 47,
                          SoruId = 20,
                          Cevaplar = "1+0"
                      },
                      new Cevap
                      {
                          CevapId = 48,
                          SoruId = 20,
                          Cevaplar = "1+1"
                      },
                      new Cevap
                      {
                          CevapId = 49,
                          SoruId = 20,
                          Cevaplar = "2+1"
                      },
                      new Cevap
                      {
                          CevapId = 50,
                          SoruId = 20,
                          Cevaplar = "3+1"
                      },
                      new Cevap
                      {
                          CevapId = 51,
                          SoruId = 20,
                          Cevaplar = "Diğer"
                      },new Cevap
                      {
                          CevapId = 52,
                          SoruId = 21,
                          Cevaplar = "1"
                      },new Cevap
                      {
                          CevapId = 53,
                          SoruId = 21,
                          Cevaplar = "2"
                      },new Cevap
                      {
                          CevapId = 54,
                          SoruId = 21,
                          Cevaplar = "Diğer"
                      },new Cevap
                      {
                          CevapId = 55,
                          SoruId = 22,
                          Cevaplar = "30-80"
                      },new Cevap
                      {
                          CevapId = 56,
                          SoruId = 22,
                          Cevaplar = "80-120"
                      },new Cevap
                      {
                          CevapId = 57,
                          SoruId = 22,
                          Cevaplar = "120-200"
                      },new Cevap
                      {
                          CevapId = 58,
                          SoruId = 23,
                          Cevaplar = "İl"
                      },new Cevap
                      {
                          CevapId = 59,
                          SoruId = 24,
                          Cevaplar = "İlçe"
                      },new Cevap
                      {
                          CevapId = 60,
                          SoruId = 25,
                          Cevaplar = "Mesaj"
                      },
                      ////Dükkan/Mağaza Temizliği
                      new Cevap
                      {
                          CevapId = 61,
                          SoruId = 26,
                          Cevaplar = "30-80"
                      }, new Cevap
                      {
                          CevapId = 62,
                          SoruId = 26,
                          Cevaplar = "80-120"
                      }, new Cevap
                      {
                          CevapId = 63,
                          SoruId = 26,
                          Cevaplar = "120-200"
                      },new Cevap
                      {
                          CevapId = 64,
                          SoruId = 27,
                          Cevaplar = "Haftada Bir"
                      },new Cevap
                      {
                          CevapId = 65,
                          SoruId = 27,
                          Cevaplar = "Haftada İki"
                      },new Cevap
                      {
                          CevapId = 66,
                          SoruId = 27,
                          Cevaplar = "Tek seferlik"
                      },new Cevap
                      {
                          CevapId = 67,
                          SoruId = 27,
                          Cevaplar = "Diğer"
                      },new Cevap
                      {
                          CevapId = 68,
                          SoruId = 28,
                          Cevaplar = "İl"
                      },new Cevap
                      {
                          CevapId = 69,
                          SoruId = 29,
                          Cevaplar = "İlçe"
                      },
                      new Cevap
                      {
                          CevapId = 70,
                          SoruId = 30,
                          Cevaplar = "Mesaj"
                      },
                      /////Haşere İlaçlama
                        new Cevap
                        {
                            CevapId = 71,
                            SoruId = 31,
                            Cevaplar = "Hamam Böceği"
                        },new Cevap
                        {
                            CevapId = 72,
                            SoruId = 31,
                            Cevaplar = "Bit/Pire"
                        },new Cevap
                        {
                            CevapId = 73,
                            SoruId = 31,
                            Cevaplar = "Fare"
                        },new Cevap
                        {
                            CevapId = 74,
                            SoruId = 31,
                            Cevaplar = "Diğer"
                        },new Cevap
                        {
                            CevapId = 75,
                            SoruId = 32,
                            Cevaplar = "30-80"
                        },new Cevap
                        {
                            CevapId = 76,
                            SoruId = 32,
                            Cevaplar = "80-120"
                        },new Cevap
                        {
                            CevapId = 77,
                            SoruId = 32,
                            Cevaplar = "120-200"
                        },new Cevap
                        {
                            CevapId = 78,
                            SoruId = 33,
                            Cevaplar = "Ev"
                        },new Cevap
                        {
                            CevapId = 79,
                            SoruId = 33,
                            Cevaplar = "Bahçe"
                        },new Cevap
                        {
                            CevapId = 80,
                            SoruId = 33,
                            Cevaplar = "Bina"
                        },new Cevap
                        {
                            CevapId = 81,
                            SoruId = 33,
                            Cevaplar = "Diğer"
                        },new Cevap
                        {
                            CevapId = 82,
                            SoruId = 34,
                            Cevaplar = "İl"
                        },new Cevap
                        {
                            CevapId = 83,
                            SoruId = 35,
                            Cevaplar = "İlçe"
                        },new Cevap
                        {
                            CevapId = 84,
                            SoruId = 36,
                            Cevaplar = "Mesaj"
                        },
                        ///Halı Yıkama
                        new Cevap
                        {
                            CevapId = 85,
                            SoruId = 37,
                            Cevaplar = "Adresten alınıp teslim edilsin"
                        }, new Cevap
                        {
                            CevapId = 86,
                            SoruId = 37,
                            Cevaplar = "Evde halı temizliği"
                        }, new Cevap
                        {
                            CevapId = 87,
                            SoruId = 37,
                            Cevaplar = "Ofiste halı temizliği"
                        }, new Cevap
                        {
                            CevapId = 88,
                            SoruId = 38,
                            Cevaplar = "5-15"
                        },new Cevap
                        {
                            CevapId = 89,
                            SoruId = 38,
                            Cevaplar = "15-30"
                        },new Cevap
                        {
                            CevapId = 90,
                            SoruId = 38,
                            Cevaplar = "30-50"
                        },new Cevap
                        {
                            CevapId = 91,
                            SoruId = 38,
                            Cevaplar = "60-80"
                        },new Cevap
                        {
                            CevapId = 92,
                            SoruId = 38,
                            Cevaplar = "diğer"
                        },new Cevap
                        {
                            CevapId = 93,
                            SoruId = 39,
                            Cevaplar = "Evet"
                        },new Cevap
                        {
                            CevapId = 94,
                            SoruId = 39,
                            Cevaplar = "Hayır"
                        },new Cevap
                        {
                            CevapId = 95,
                            SoruId = 40,
                            Cevaplar = "İl"
                        },new Cevap
                        {
                            CevapId = 96,
                            SoruId = 41,
                            Cevaplar = "İlçe"
                        },new Cevap
                        {
                            CevapId = 97,
                            SoruId = 42,
                            Cevaplar = "Mesaj"
                        },
                        ///Kuru Temizleme
                        new Cevap
                        {
                            CevapId = 98,
                            SoruId = 43,
                            Cevaplar = "Yorgan"
                        }, new Cevap
                        {
                            CevapId = 99,
                            SoruId = 43,
                            Cevaplar = "Battaniye"
                        }, new Cevap
                        {
                            CevapId = 100,
                            SoruId = 43,
                            Cevaplar = "Perde"
                        }, new Cevap
                        {
                            CevapId = 101,
                            SoruId = 43,
                            Cevaplar = "Ceket"
                        }, new Cevap
                        {
                            CevapId = 102,
                            SoruId = 43,
                            Cevaplar = "Pantolon"
                        }, new Cevap
                        {
                            CevapId = 103,
                            SoruId = 43,
                            Cevaplar = "Gömlek"
                        }, new Cevap
                        {
                            CevapId = 104,
                            SoruId = 43,
                            Cevaplar = "Mont/Kaban/Palto"
                        }, new Cevap
                        {
                            CevapId = 105,
                            SoruId = 43,
                            Cevaplar = "Gelinlik"
                        },new Cevap
                        {
                            CevapId = 106,
                            SoruId = 43,
                            Cevaplar = "Diğer"
                        },new Cevap
                        {
                            CevapId = 107,
                            SoruId = 44,
                            Cevaplar = "Evet"
                        },new Cevap
                        {
                            CevapId = 108,
                            SoruId = 44,
                            Cevaplar = "Hayır"
                        },
                        
                        new Cevap
                        {
                            CevapId = 109,
                            SoruId = 45,
                            Cevaplar = "1-3"
                        },new Cevap
                        {
                            CevapId = 110,
                            SoruId = 45,
                            Cevaplar = "3-5"
                        },new Cevap
                        {
                            CevapId = 111,
                            SoruId = 45,
                            Cevaplar = "5-7"
                        },new Cevap
                        {
                            CevapId = 112,
                            SoruId = 45,
                            Cevaplar = "diğer"
                        },new Cevap
                        {
                            CevapId = 113,
                            SoruId = 46,
                            Cevaplar = "İl"
                        },new Cevap
                        {
                            CevapId = 114,
                            SoruId = 47,
                            Cevaplar = "İlçe"
                        },new Cevap
                        {
                            CevapId = 115,
                            SoruId = 48,
                            Cevaplar = "Mesaj"
                        },
                        ///Mobilya Temizleme:
                        new Cevap
                        {
                            CevapId = 116,
                            SoruId = 49,
                            Cevaplar = "Yatak"
                        },new Cevap
                        {
                            CevapId = 117,
                            SoruId = 49,
                            Cevaplar = "Berjer"
                        },new Cevap
                        {
                            CevapId = 118,
                            SoruId = 49,
                            Cevaplar = "İkili Koltuk"
                        },new Cevap
                        {
                            CevapId = 119,
                            SoruId = 49,
                            Cevaplar = "Üçlü Koltuk"
                        },new Cevap
                        {
                            CevapId = 120,
                            SoruId = 49,
                            Cevaplar = "L Koltuk "
                        },new Cevap
                        {
                            CevapId = 121,
                            SoruId = 49,
                            Cevaplar = "Araç içi Koltuk"
                        },new Cevap
                        {
                            CevapId = 122,
                            SoruId = 49,
                            Cevaplar = "Sandalye"
                        },new Cevap
                        {
                            CevapId = 123,
                            SoruId = 50,
                            Cevaplar = "Yaslanma yeri minderli"
                        },new Cevap
                        {
                            CevapId = 124,
                            SoruId = 50,
                            Cevaplar = "Oturma yeri minderli"
                        },new Cevap
                        {
                            CevapId = 125,
                            SoruId = 50,
                            Cevaplar = "İkisi de minderli"
                        },new Cevap
                        {
                            CevapId = 126,
                            SoruId = 50,
                            Cevaplar = "Mindersiz"
                        },new Cevap
                        {
                            CevapId = 127,
                            SoruId = 51,
                            Cevaplar = "1"
                        },new Cevap
                        {
                            CevapId = 128,
                            SoruId = 51,
                            Cevaplar = "2"
                        },new Cevap
                        {
                            CevapId = 129,
                            SoruId = 51,
                            Cevaplar = "3"
                        },new Cevap
                        {
                            CevapId = 130,
                            SoruId = 51,
                            Cevaplar = "4"
                        },new Cevap
                        {
                            CevapId = 131,
                            SoruId = 51,
                            Cevaplar = "5"
                        },new Cevap
                        {
                            CevapId = 132,
                            SoruId = 51,
                            Cevaplar = "6"
                        },new Cevap
                        {
                            CevapId = 133,
                            SoruId = 51,
                            Cevaplar = "Diğer"
                        },new Cevap
                        {
                            CevapId = 134,
                            SoruId = 52,
                            Cevaplar = "İl"
                        },new Cevap
                        {
                            CevapId = 135,
                            SoruId = 53,
                            Cevaplar = "İlçe"
                        },new Cevap
                        {
                            CevapId = 136,
                            SoruId = 54,
                            Cevaplar = "mesaj"
                        },
                        /////Cam Temizliği
                        new Cevap
                        {
                            CevapId = 137,
                            SoruId = 55,
                            Cevaplar = "1+1"
                        },new Cevap
                        {
                            CevapId = 138,
                            SoruId = 55,
                            Cevaplar = "2+1"
                        },new Cevap
                        {
                            CevapId = 139,
                            SoruId = 55,
                            Cevaplar = "3+1"
                        },new Cevap
                        {
                            CevapId = 140,
                            SoruId = 55,
                            Cevaplar = "4+1"
                        },new Cevap
                        {
                            CevapId = 141,
                            SoruId = 55,
                            Cevaplar = "Daha Büyük Ev"
                        },new Cevap
                        {
                            CevapId = 142,
                            SoruId = 55,
                            Cevaplar = "Bina Dış Cephe"
                        },new Cevap
                        {
                            CevapId = 143,
                            SoruId = 55,
                            Cevaplar = "Mağaza"
                        },new Cevap
                        {
                            CevapId = 144,
                            SoruId = 56,
                            Cevaplar = "İl"
                        },new Cevap
                        {
                            CevapId = 145,
                            SoruId = 57,
                            Cevaplar = "İlçe"
                        },new Cevap
                        {
                            CevapId = 146,
                            SoruId = 58,
                            Cevaplar = "Mesaj"
                        }
             );
        }
    }
}

