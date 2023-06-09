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
            //modelBuilder.Entity<Kategori>().HasData(

            //new Kategori()
            //{


            //    KategoriAdi = "Temizlik",
            //    AltKategoriler = new AltKategori()
            //    {
            //        AltKategoriAdi = "fwaf",
                   
            //    }

            //});
             //new Kategori()
             //{
              

             //    KategoriAdi = "Tadilat"

             //},
            //  new Kategori()
            //  {
                  

            //      KategoriAdi = "Nakliyat"

            //  },
            //   new Kategori()
            //   {
                  

            //       KategoriAdi = "Tamir"

            //   },
            //    new Kategori()
            //    {
                   

            //        KategoriAdi = "Özel Ders"

            //    },
            //     new Kategori()
            //     {
                    

            //         KategoriAdi = "Sağlık"

            //     },
            //      new Kategori()
            //      {
                     

            //          KategoriAdi = "Organizasyon"

            //      },
            //       new Kategori()
            //       {
                       

            //           KategoriAdi = "Fotoğraf Ve Video"

            //       },
            //        new Kategori()
            //        {
                        

            //            KategoriAdi = "Digital Ve Kurumsal"

            //        },
            //         new Kategori()
            //         {
                         

            //             KategoriAdi = "Evcil Hayvanlar"

            //         },
            //         new Kategori()
            //         {

            //             KategoriAdi = "Oto Ve Araç"

            //         },
            //         new Kategori()
            //         {
                         

            //             KategoriAdi = "Diğer"

            //         });

            //modelBuilder.Entity<Kategori>().HasData(
            //    new AltKategori()
            //    {
            //        Id = 1,
            //        KategoriId = 1,
            //        AltKategoriAdi = "Ev Temizliği",
            //        Aktif = true
            //    });
            //new AltKategori()
            //{
            //    Id = 1,
            //    KategoriId = 1,
            //    AltKategoriAdi = "",
            //    Aktif = true
            //},

        }



    }
    }

