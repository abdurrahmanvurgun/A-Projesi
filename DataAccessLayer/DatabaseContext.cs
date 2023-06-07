using Armut.Model;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DbSet<Aktivite> Aktiviteler { get; set; }
        public DbSet<Cinsiyet> Cinsiyetler { get; set; }
        public DbSet<Hesap> Hesaplar { get; set; }
        public DbSet<HizmetIstekleri> HizmetIstekleris { get; set; }
        public DbSet<HizmetZamanTablosu> HizmetZamanTabloları { get; set; }
        public DbSet<KullaniciRol> KullaniciRoller { get; set; }
        public DbSet<Rol> Roller { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Aktivite>().HasOne(e => e.TeklifVeren).WithMany(e => e.TeklifVern).HasForeignKey(e => e.TeklifVerenId).OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Aktivite>().HasOne(e => e.TeklifIsteyen).WithMany(e => e.TeklifAln).HasForeignKey(e => e.TeklifAlanId).OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
