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

namespace DataAccessLayer
{
    public class DatabaseContext:DbContext
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




        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)

{

            var connectionString = "Server=203-BAHADIR;Database=Armut;Integrated Security=True";
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            dbContextOptionsBuilder.UseSqlServer(connectionString);


        //    var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
        //dbContextOptionsBuilder.UseMySql"server=203-BAHADIR;database=MakaleWeb2023;Integrated Security=True" providerName = "System.Data.SqlClient"); //MySQL için...
    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hesap>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email);
                entity.Property(e => e.Sifre);
                entity.Property(e => e.Gorunurluk);
            });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.KullaniciAdi);
            entity.Property(e => e.Ad);
            entity.Property(e => e.Soyad);
            entity.Property(e => e.DogumTarihi);
            entity.Property(e => e.TelefonNumarası);
            entity.Property(e => e.ProfilImagefileName);
            entity.HasOne(e=>e.Hesap).WithOne().HasForeignKey("Kullanici","HesapId");
        entity.HasOne(e=>e.Cinsiyet).WithMany(e=>e.Kullanicilar).HasForeignKey(e=>e.CinsiyetId);
        //entity.HasMany(e=>e.Roles).WithMany(e=>e.Users).UsingEntity(j=>j.ToTable("User_Role")); 
        entity.HasMany(e=>e.HizmetIstekleri).WithMany(e=>e.TumKatilimciSayisi).UsingEntity(j=>j.ToTable("Kullanici_Etkinlik_Kayitlari"));
        });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name);
            });

            modelBuilder.Entity<KullaniciRol>().HasKey(x => new { x.KullaniciId, x.RolId });
            modelBuilder.Entity<KullaniciRol>().HasOne<Kullanici>(x => x.Kullanici).WithMany(x => x.KullaniciRolleri)
            .HasForeignKey(x => x.KullaniciId);
            modelBuilder.Entity<KullaniciRol>().HasOne<Rol>(x => x.Rol).WithMany(x => x.KullaniciRolleri)
            .HasForeignKey(x => x.RolId);


            modelBuilder.Entity<Cinsiyet>(entity =>
            {
                entity.HasKey(e => e.Id);
                
            });

            modelBuilder.Entity<Aktivite>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Ad);
                entity.Property(e => e.Baslik);
                entity.Property(e => e.Resim);
                entity.Property(e => e.Gorunurluk);
                entity.Property(e => e.OlusturmaTarih);
                entity.Property(e => e.Fiyat);
                entity.HasOne(e => e.AltKategori).WithMany(e => e.Aktiviteler).HasForeignKey(e => e.AltKategoriId);
                entity.HasOne(e => e.Adres).WithMany(e => e.Aktiviteler).HasForeignKey(e => e.AdresId);
                entity.HasOne(e => e.TeklifIsteyen).WithMany(e => e.CreatedActivities).HasForeignKey(e => e.TeklifIsteyen);
            });


            modelBuilder.Entity<HizmetZamanTablosu>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.BaslangicTarihi);
                entity.Property(e => e.BitisTarihi);
                entity.Property(e => e.Kota);
                entity.Property(e => e.KatilimciSayisi);
                entity.Property(e => e.Gorunurluk);
                /*
                entity.HasMany(e => e.KatilimciKullanicilar).WithMany(e => e.Activities).UsingEntity<HizmetZamanTablosu>(
                       x => x.HasOne(x => x.Kullanici).WithMany().HasForeignKey(x => x.KullaniciId),
                       x => x.HasOne(x => x.HizmetZamanTablosu).WithMany().HasForeignKey(x => x.HizmetZamanTablosuId)
                );
                */
                entity.HasOne(e => e.Activite).WithMany(e => e.ZamanTablosu).HasForeignKey(e => e.AktiviteId);
            });

            modelBuilder.Entity<KullaniciHizmetZamanTablosu>().HasKey(x => new { x.KullaniciId, x.HizmetZamanTablosuId });

            modelBuilder.Entity<KullaniciHizmetZamanTablosu>().HasOne<User>(x => x.User).WithMany(x => x.KullaniciHizmetZamanTablolari)
        .HasForeignKey(x => x.KullaniciId);

            modelBuilder.Entity<KullaniciHizmetZamanTablosu>().HasOne<HizmetZamanTablosu>(x => x.HizmetZamanTablosu).WithMany(x => x.AttendantUsers)
        .HasForeignKey(x => x.ActivityTimeTableId);

            modelBuilder.Entity<HizmetIstekleri>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Kullanici).WithMany(e => e.HizmetIstekleriAll).HasForeignKey(e => e.KullaniciId);
                entity.HasOne(e => e.Aktivite).WithMany(e => e.IstekKullanicilari).HasForeignKey(e => e.AktiviteId);
            });

            modelBuilder.Entity<Kategori>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.KategoriAdi);
                entity.Property(e => e.Gorunurluk);
            });


            modelBuilder.Entity<AltKategori>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Ad);
                entity.Property(e => e.Gorunurluk);
                entity.HasOne(e => e.Kategori).WithMany(e => e.AltKategoriler).HasForeignKey(e => e.KategoriId);
            });

            modelBuilder.Entity<Yorum>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Tanım);
                entity.Property(e => e.Baslik);
                entity.Property(e => e.Gorunurluk);
                entity.Property(e => e.GirisTarihi);
                entity.Property(e => e.KullaniciId);
                entity.Property(e => e.AktiviteId);
                entity.HasOne(e => e.Kullanici).WithMany(e => e.Yorumlar).HasForeignKey(e => e.KullaniciId);
                entity.HasOne(e => e.Aktivite).WithMany(e => e.Yorumlar).HasForeignKey(e => e.AktiviteId);
            });

            modelBuilder.Entity<Adres>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Ad);
                entity.Property(e => e.Adres1);
                entity.Property(e => e.Adres2);
                entity.Property(e => e.Gorunurluk);
                entity.HasOne(e => e.Ulke).WithMany(e => e.Adresler).HasForeignKey(e => e.UlkeId);
                entity.HasOne(e => e.Sehir).WithMany(e => e.Adresler).HasForeignKey(e => e.SehirId);
                entity.HasOne(e => e.Ilce).WithMany(e => e.Adresler).HasForeignKey(e => e.IlceId);
                entity.HasOne(e => e.Mahalle).WithMany(e => e.Adresler).HasForeignKey(e => e.MahalleId);
                //entity.HasOne(e => e.Semt).WithMany(e => e.Adresler).HasForeignKey(e => e.SemtId);
            });

            modelBuilder.Entity<Ulke>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name);
                //entity.Property(e => e.EyaletVarmi);
                entity.Property(e => e.Gorunurluk);
            });

       


            modelBuilder.Entity<Il>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Ad);
                entity.Property(e => e.Gorunurluk);
                entity.HasOne(e => e!.Ulke).WithMany(e => e!.Iller).HasForeignKey(e => e.UlkeId);
                entity.HasOne(e => e.Ulke).WithMany(e => e.Iller).HasForeignKey(e => e.UlkeId);
            });

            modelBuilder.Entity<Ilce>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Ad);
                entity.Property(e => e.Gorunurluk);
                entity.HasOne(e => e.Il).WithMany(e => e.Ilceler).HasForeignKey(e => e.IlId);
            });

            modelBuilder.Entity<Mahalle>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Ad);
                entity.Property(e => e.Gorunurluk);
                entity.HasOne(e => e.Ilce).WithMany(e => e.Mahalle).HasForeignKey(e => e.Ilce);
            });

            AddDataToHesap(modelBuilder);
            AddDataToKullanici(modelBuilder);
            AddDataToCinsiyet(modelBuilder);
            AddDataToRol(modelBuilder);
            AddDataToKullaniciRolleri(modelBuilder);
            AddDataToAktivite(modelBuilder);
            AddDataToHizmetZamanTablosu(modelBuilder);
            AddDataToKategori(modelBuilder);
            AddDataToAltKategori(modelBuilder);
            AddDataToAdres(modelBuilder);
        }

        void AddDataToHesap(ModelBuilder modelBuilder)

        {

            modelBuilder.Entity<Hesap>().HasData(
                     new Hesap
                     {
                         Id = 1,
                         Email = "deneme1@gmail.com",
                         Sifre = "1234567",
                         Gorunurluk = true
                     },
                     new Hesap
                     {
                         Id = 2,
                         Email = "deneme2@gmail.com",
                         Sifre = "1235467",
                         Gorunurluk = true
                     }
                 );
        }

        void AddDataToKullanici(ModelBuilder modelBuilder)
        {

        }

        void AddDataToCinsiyet(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinsiyet>().HasData(
                    new Cinsiyet
                    {
                        Id = 1,
                        Tip = "Female"
                    },
                    new Cinsiyet
                    {
                        Id = 2,
                        Tip = "Male"
                    },
                    new Cinsiyet
                    {
                        Id = 3,
                        Tip = "Undefined"
                    }
                );

            
            }
        void AddDataToRol(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Rol>().HasData(
                    new Rol
                    {
                        Id = 1,
                        Ad = "User"
                    },
                    new Rol
                    {
                        Id = 2,
                        Ad = "Admin"
                    }
            );
        }

        void AddDataToKullaniciRolleri(ModelBuilder modelBuilder)
        {

        }

        void AddDataToAktivite(ModelBuilder modelBuilder)
        {

        }
        void AddDataToHizmetZamanTablosu(ModelBuilder modelBuilder)
        {

        }
        void AddDataToKategori(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategori>().HasData(
                   new Kategori
                   {
                       Id = 1,
                       KategoriAdi = "Spor",
                       Gorunurluk = true
                   },
                   new Kategori
                   {
                       Id = 2,
                       KategoriAdi = "Dans",
                       Gorunurluk = true
                   }
           );
        }
        void AddDataToAltKategori(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AltKategori>().HasData(
                   new AltKategori
                   {
                       Id = 1,
                       Ad = "Kick Box",
                       KategoriId = 1,
                       Gorunurluk = true
                   },
                   new AltKategori
                   {
                       Id = 2,
                       Ad = "Masa tenisi",
                       KategoriId = 1,
                       Gorunurluk = true
                   },
                   new AltKategori
                   {
                       Id = 3,
                       Ad = "Zumba dansı",
                       KategoriId = 2,
                       Gorunurluk = true
                   },
                   new AltKategori
                   {
                       Id = 4,
                       Ad = "Cha Cha dansı",
                       KategoriId = 2,
                       Gorunurluk = true
                   }
           );

        }
        void AddDataToAdres(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ulke>().HasData(
                    new Ulke
                    {
                        Id = 1,
                        UlkeAd = "Turkey",
                        Gorunurluk = true,
                    },
                    new Ulke
                    {
                        Id = 2,
                        UlkeAd = "USA",
                        Gorunurluk = true, 
                    }
            );
            
            modelBuilder.Entity<Il>().HasData(
                   new Il
                   {
                       Id = 1,
                       Ad = "Istanbul",
                       Gorunurluk = true,
                       UlkeId = 1
                   },
                   new Il
                   {
                       Id = 2,
                       Ad = "Ankara",
                       Gorunurluk = true,
                       UlkeId = 1
                   },
                   new Il
                   {
                       Id = 3,
                       Ad = "New Orleans",
                       Gorunurluk = true,
                       UlkeId = 2,
                       
                   }
           );
            modelBuilder.Entity<Ilce>().HasData(
                    new District
                    {
                        Id = 1,
                        Ad = "Umraniye",
                        Gorunurluk = true,
                        IlId = 1
                    },
                    new Ilce
                    {
                        Id = 2,
                        Ad = "Kartal",
                        Gorunurluk = true,
                        IlId = 1
                    },
                    new Ilce
                    {
                        Id = 3,
                        Ad = "Ulus",
                        Gorunurluk = true,
                        IlId = 2
                    },
                    new Ilce
                    {
                        Id = 4,
                        Ad = "Eagle",
                        Gorunurluk = true,
                        IlId = 3
                    }
            );
            modelBuilder.Entity<Mahalle>().HasData(
                   new Mahalle
                   {
                       Id = 1,
                       Name = "Atakent",
                       Gorunurluk = true,
                       IlceId = 1
                   },
                   new Mahalle
                   {
                       Id = 2,
                       Name = "KartalinMahallesi1",
                       IlceId = 2,
                       Gorunurluk = true,
                   },
                   new Mahalle
                   {
                       Id = 3,
                       Name = "UlusunMahallesi1",
                       Gorunurluk = true,
                       IlceId = 3
                   },
                   new Mahalle
                   {
                       Id = 4,
                       Name = "EagleinMahallesi1",
                       Gorunurluk = true,
                       IlceId = 4
                   }
           );
            modelBuilder.Entity<Adres>().HasData(
                    new Adres
                    {
                        Id = 1,
                        AdresAd = "Evim",
                        IlceId = 1,
                        MahalleId = 1,
                        UlkeId = 1,
                        IlId = 1,
                        Gorunurluk = true,
                        Adres1 = "emrah sk. no:64"
                    },
                    new Adres
                    {
                        Id = 2,
                        AdresAd = "Isyerim",
                        IlceId = 2,
                        UlkeId = 1,
                        IlId = 1,
                        MahalleId = 2,
                        Gorunurluk = true,
                        Adres1 = "cicek sk. no:14"
                    },
                    new Adres
                    {
                        Id = 3,
                        AdresAd = "Adresim",
                        IlceId = 3,
                        UlkeId = 1,
                        IlId = 2,
                        MahalleId = 3,
                        Adres1 = "yıldıran sk. no:6 , kat : 3, daire : 5",
                        Gorunurluk = true,
                        Adres2 = "okulun arkasi marketin önü"
                    },
                    new Adres
                    {
                        Id = 4,
                        AdresAd = "My Adres",
                        IlceId = 4,
                        UlkeId = 2,
                        IlId = 3,
                        MahalleId = 4,
                        Gorunurluk = true,
                        Adres1 = "even street no:4 "
                    }
            );
        }
    }
