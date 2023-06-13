using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanıcı",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Sifre2 = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cinsiyet = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    TelefonNumarası = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanıcı", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ülke",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ülke", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alt Kategori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AltKategoriAdi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alt Kategori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alt Kategori_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kullanıcı Rol",
                columns: table => new
                {
                    KullaniciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanıcı Rol", x => x.KullaniciId);
                    table.ForeignKey(
                        name: "FK_Kullanıcı Rol_Kullanıcı_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanıcı",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kullanıcı Rol_Roller_RolId",
                        column: x => x.RolId,
                        principalTable: "Roller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "İl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UlkeId = table.Column<int>(type: "int", nullable: false),
                    IlceId = table.Column<int>(type: "int", nullable: true),
                    AdresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_İl_Ülke_UlkeId",
                        column: x => x.UlkeId,
                        principalTable: "Ülke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sorular",
                columns: table => new
                {
                    SoruId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AltKategoriId = table.Column<int>(type: "int", nullable: false),
                    Sorular = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sorular", x => x.SoruId);
                    table.ForeignKey(
                        name: "FK_Sorular_Alt Kategori_AltKategoriId",
                        column: x => x.AltKategoriId,
                        principalTable: "Alt Kategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "İlçe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IlId = table.Column<int>(type: "int", nullable: false),
                    AdresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İlçe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_İlçe_İl_IlId",
                        column: x => x.IlId,
                        principalTable: "İl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cevaplar",
                columns: table => new
                {
                    CevapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoruId = table.Column<int>(type: "int", nullable: false),
                    Cevaplar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cevaplar", x => x.CevapId);
                    table.ForeignKey(
                        name: "FK_Cevaplar_Sorular_SoruId",
                        column: x => x.SoruId,
                        principalTable: "Sorular",
                        principalColumn: "SoruId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mahalleler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresId = table.Column<int>(type: "int", nullable: false),
                    IlceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mahalleler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mahalleler_İlçe_IlceId",
                        column: x => x.IlceId,
                        principalTable: "İlçe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategori",
                columns: new[] { "Id", "KategoriAdi" },
                values: new object[,]
                {
                    { 1, "Temizlik" },
                    { 2, "Tadilat" },
                    { 3, "Nakliyat" },
                    { 4, "Tamir" },
                    { 5, "Özel Ders" },
                    { 6, "Sağlık" },
                    { 7, "Organizasyon" },
                    { 8, "Fotoğraf Ve Video" },
                    { 9, "Dijital ve Kurumsal" },
                    { 10, "Evcil Hayvanlar" },
                    { 11, "Oto Ve Araç" },
                    { 12, "Diğer" }
                });

            migrationBuilder.InsertData(
                table: "Kullanıcı",
                columns: new[] { "Id", "Ad", "Adres", "Adres2", "Aktif", "Cinsiyet", "Email", "KayitTarihi", "KullaniciAdi", "Sifre", "Sifre2", "Soyad", "TelefonNumarası" },
                values: new object[] { new Guid("de437142-7d58-4ac1-81a2-91d48aa8be7b"), "Network", "İstanbul", null, true, "Kadın", "Network@gmail.com", new DateTime(2023, 6, 13, 11, 8, 6, 922, DateTimeKind.Local).AddTicks(5705), "networkakademi", "123", "123", "Network", "123456" });

            migrationBuilder.InsertData(
                table: "Roller",
                columns: new[] { "Id", "Ad" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Hizmet Alan" },
                    { 3, "Hizmet Veren" }
                });

            migrationBuilder.InsertData(
                table: "Alt Kategori",
                columns: new[] { "Id", "Aktif", "AltKategoriAdi", "KategoriId" },
                values: new object[,]
                {
                    { 1, true, "Ev Temizliği", 1 },
                    { 2, true, "Apartman Temizliği", 1 },
                    { 3, true, "Ofis Temizliği", 1 },
                    { 4, true, "İnşaat Sonrası Ev Temizliği", 1 },
                    { 5, true, "Dükkan/Mağaza Temizliği", 1 },
                    { 6, true, "Haşere İlaçlama", 1 },
                    { 7, true, "Halı Yıkama", 1 },
                    { 8, true, "Kuru Temizleme", 1 },
                    { 9, true, "Mobilya Temizleme", 1 },
                    { 10, true, "Cam Temziliği", 1 },
                    { 11, true, "Boya Badana", 2 },
                    { 12, true, "Kapı Tadilat", 2 },
                    { 13, true, "Pencere Tadilat", 2 },
                    { 14, true, "Banyo Tadilat", 2 },
                    { 15, true, "Duvar Örme", 2 },
                    { 16, true, "Cam Balkon", 2 },
                    { 17, true, "Zemin Döşeme", 2 },
                    { 18, true, "Havuz Yapımı", 2 },
                    { 19, true, "Gardrop Yapımı", 2 },
                    { 20, true, "iç Mimar", 2 },
                    { 21, true, "Prefabrik Ev Yapımı", 2 },
                    { 22, true, "Koltuk Döşeme", 2 },
                    { 23, true, "Çatı Tadilatı", 2 },
                    { 24, true, "Doğalgaz Tesisat", 2 },
                    { 25, true, "Gömme Dolap Yapımı", 2 },
                    { 26, true, "Güneş Enerjisi", 2 },
                    { 27, true, "Sineklik", 2 },
                    { 28, true, "Mezar Yapımı", 2 },
                    { 29, true, "Vestiyer ve Portmanto", 2 },
                    { 30, true, "Sandalye Döşeme", 2 },
                    { 31, true, "Ses Yalıtımı", 2 },
                    { 32, true, "Sıva", 2 },
                    { 33, true, "Kaynak", 2 },
                    { 34, true, "Alçı", 2 },
                    { 35, true, "Deprem Testi", 2 },
                    { 36, true, "Stor Perde", 2 },
                    { 37, true, "Panjur", 2 },
                    { 38, true, "Hazır Rulo Çim", 2 },
                    { 39, true, "Özel Mobilya Yapımı", 2 },
                    { 40, true, "Mermer", 2 },
                    { 41, true, "Panel Çit", 2 },
                    { 42, true, "Tente Branda", 2 }
                });

            migrationBuilder.InsertData(
                table: "Alt Kategori",
                columns: new[] { "Id", "Aktif", "AltKategoriAdi", "KategoriId" },
                values: new object[,]
                {
                    { 43, true, "Bina Güçlendirme", 2 },
                    { 44, true, "Teras Kapatma", 2 },
                    { 45, true, "Mutfak", 2 },
                    { 46, true, "Ambar Kargo", 3 },
                    { 47, true, "Araç Taşıma", 3 },
                    { 48, true, "Asansörlü Nakliyat", 3 },
                    { 49, true, "BUlaşık Makinesi Taşıma", 3 },
                    { 50, true, "Buzdolabı Taşıma", 3 },
                    { 51, true, "Çamaşır Makinesi Taşıma", 3 },
                    { 52, true, "Depo Kiralama", 3 },
                    { 53, true, "Doblo Nakliye", 3 },
                    { 54, true, "Eşya Depolama", 3 },
                    { 55, true, "Eşya Taşıma", 3 },
                    { 56, true, "Ev İçi Eşya Taşıma", 3 },
                    { 57, true, "Evden Eve Nakliyat", 3 },
                    { 58, true, "Günlük Şöför", 3 },
                    { 59, true, "Havaalanı Transfer", 3 },
                    { 60, true, "Kamyonet Kiralama", 3 },
                    { 61, true, "Kamyonet Nakliye", 3 },
                    { 62, true, "Kedi Taşıma", 3 },
                    { 63, true, "Koltuk Taşıma", 3 },
                    { 64, true, "Köpe Taşıma", 3 },
                    { 65, true, "Minibüs Kiralama", 3 },
                    { 66, true, "Minivan Nakliye", 3 },
                    { 67, true, "Moto Kurye", 3 },
                    { 68, true, "Motosiklet Taşıma", 3 },
                    { 69, true, "Ofis Taşıma", 3 },
                    { 70, true, "Oto Çekici", 3 },
                    { 71, true, "Köpe Taşıma", 3 },
                    { 72, true, "Minibüs Kiralama", 3 },
                    { 73, true, "Minivan Nakliye", 3 },
                    { 74, true, "Moto Kurye", 3 },
                    { 75, true, "Motosiklet Taşıma", 3 },
                    { 76, true, "Ofis Taşıma", 3 },
                    { 77, true, "Oto Çekici", 3 },
                    { 78, true, "Oto Kurtarma", 3 },
                    { 79, true, "Otobüs Kiralama", 3 },
                    { 80, true, "Özel Şöför", 3 },
                    { 81, true, "Paletli Yük Taşıma", 3 },
                    { 82, true, "Panelvan Nakliye", 3 },
                    { 83, true, "Personel Servisi", 3 },
                    { 84, true, "Şehir İçi Nakliye", 3 }
                });

            migrationBuilder.InsertData(
                table: "Alt Kategori",
                columns: new[] { "Id", "Aktif", "AltKategoriAdi", "KategoriId" },
                values: new object[,]
                {
                    { 85, true, "Şehirler Arası Araç Taşıma", 3 },
                    { 86, true, "Şehirler Arası Eşya Taşıma", 3 },
                    { 87, true, "Şehirler Arası Motosiklet Taşıma", 3 },
                    { 88, true, "Şehirler Arası Nakliye", 3 },
                    { 89, true, "Şehirler Arası Yük Taşıma", 3 },
                    { 90, true, "Şöförlü Araç Kiralama", 3 },
                    { 91, true, "Taksi", 3 },
                    { 92, true, "Transfer", 3 },
                    { 93, true, "Uluslararası Evden Eve Nakliyat", 3 },
                    { 94, true, "Uluslararası Nakliyat", 3 },
                    { 95, true, "Yük Taşıma", 3 },
                    { 96, true, "Yurtdışı Kargo", 3 },
                    { 97, true, "Ahşap Kapı Tamiri", 4 },
                    { 98, true, "Amerikan Panel Kapı Montajı", 4 },
                    { 99, true, "Amerikan Panel Kapı Tamiri", 4 },
                    { 100, true, "Asansör Bakım", 4 },
                    { 101, true, "Avize Montaj", 4 },
                    { 102, true, "Baza Tamiri", 4 },
                    { 103, true, "Beyaz Eşya Tamiri", 4 },
                    { 104, true, "Bilgisayar Format Atma", 4 },
                    { 105, true, "Bilgisayar Tamiri", 4 },
                    { 106, true, "Bilgisayar ve Laptop Parça Değişimi", 4 },
                    { 107, true, "Bulaşık Makinesi Tamiri", 4 },
                    { 108, true, "Buzdolabı Tamiri", 4 },
                    { 109, true, "Cam Kestirme", 4 },
                    { 110, true, "Cama Menfez Açma", 4 },
                    { 111, true, "Çamaşır Makinesi Tamiri", 4 },
                    { 112, true, "Çanak Anten Ayarlama", 4 },
                    { 113, true, "Çanak Anten Kurulumu", 4 },
                    { 114, true, "Çelik Kapı Kilit Değiştirme", 4 },
                    { 115, true, "Çelik Kapı Montajı", 4 },
                    { 116, true, "Çelik Kapı Tamiri", 4 },
                    { 117, true, "Çilingir Kapı Açma", 4 },
                    { 118, true, "Dolap Tamiri", 4 },
                    { 119, true, "Duşakabin Montajı", 4 },
                    { 120, true, "Duşakabin Tamiri", 4 },
                    { 121, true, "Duvara Raf Montajı", 4 },
                    { 122, true, "Elektrik Hattı Çekme", 4 },
                    { 123, true, "Elektrik Montaj", 4 },
                    { 124, true, "Elektrik Proje Çizimi", 4 },
                    { 125, true, "Elektrik Tamiri", 4 },
                    { 126, true, "Elektrik Tesisatı", 4 }
                });

            migrationBuilder.InsertData(
                table: "Alt Kategori",
                columns: new[] { "Id", "Aktif", "AltKategoriAdi", "KategoriId" },
                values: new object[,]
                {
                    { 127, true, "Elektrikçi", 4 },
                    { 128, true, "Elektrikli Süpürge Tamiri", 4 },
                    { 129, true, "Fan Temizliği ve Termal Macun Değişimi", 4 },
                    { 130, true, "Fiber Kablo Çekimi", 4 },
                    { 131, true, "Gider Açma", 4 },
                    { 132, true, "Gömme Rezervuar Tamiri", 4 },
                    { 133, true, "İnternet Kablosu Çekme", 4 },
                    { 134, true, "iPhone Batarya Değişimi", 4 },
                    { 135, true, "iPhone Tamiri", 4 },
                    { 136, true, "Kablo ve Hat Çekme", 4 },
                    { 137, true, "Kamera Güvenlik Sistemleri", 4 },
                    { 138, true, "Kamera Sistemleri", 4 },
                    { 139, true, "Kapı Kilidi Değiştirme", 4 },
                    { 140, true, "Kırmadan Su Kaçağı Tespiti", 4 },
                    { 141, true, "Klima Bakım", 4 },
                    { 142, true, "Klima Gaz Dolumu", 4 },
                    { 143, true, "Klima Montaj", 4 },
                    { 144, true, "Klima Sökme", 4 },
                    { 145, true, "Klima Tamiri", 4 },
                    { 146, true, "Klozet Montajı", 4 },
                    { 147, true, "Klozet Tamiri", 4 },
                    { 148, true, "Koltuk Yanık Tamiri", 4 },
                    { 149, true, "Kombi Bakım", 4 },
                    { 150, true, "Kombi Montaj", 4 },
                    { 151, true, "Kombi Petek Temizleme", 4 },
                    { 152, true, "Kombi Tamiri", 4 },
                    { 153, true, "Korniş Montaj", 4 },
                    { 154, true, "Laptop Tamir", 4 },
                    { 155, true, "Masa Camı Kestirme", 4 },
                    { 156, true, "Mobilya Montaj", 4 },
                    { 157, true, "Mobilya Sabitleme", 4 },
                    { 158, true, "Mobilya Sökme Taşıma ve Montaj", 4 },
                    { 159, true, "Mobilya Tamiri", 4 },
                    { 160, true, "Musluk Tamiri", 4 },
                    { 161, true, "Mutfak Dolabı Montajı", 4 },
                    { 162, true, "Mutfak Dolabı Tamiri", 4 },
                    { 163, true, "Mutfak Dolap Kapağı Değiştirme", 4 },
                    { 164, true, "Mutfak Gider Açma", 4 },
                    { 165, true, "Mutfak Tezgahı Tamiri", 4 },
                    { 166, true, "Panjur Tamiri", 4 },
                    { 167, true, "Pencere Camı Değişimi", 4 },
                    { 168, true, "Pencere Kapı Ve Pimapen Tamiri", 4 }
                });

            migrationBuilder.InsertData(
                table: "Alt Kategori",
                columns: new[] { "Id", "Aktif", "AltKategoriAdi", "KategoriId" },
                values: new object[,]
                {
                    { 169, true, "Pencere Tamiri", 4 },
                    { 170, true, "Perde Korniş Takma", 4 },
                    { 171, true, "Petek Montajı", 4 },
                    { 172, true, "Petek Tamiri", 4 },
                    { 173, true, "Petek Temizliği", 4 },
                    { 174, true, "Pimapen Kapı Tamiri", 4 },
                    { 175, true, "Pimapen Pencere Tamiri", 4 },
                    { 176, true, "PVC Pencere Tamiri", 4 },
                    { 177, true, "Samsung Telefon Tamiri", 4 },
                    { 178, true, "Sifon Tamiri", 4 },
                    { 179, true, "Sıhhi Tesisat", 4 },
                    { 180, true, "Su Arıtma Filtre Değişimi", 4 },
                    { 181, true, "Su Arıtma Montaj", 4 },
                    { 182, true, "Su Kaçağı Tamiri", 4 },
                    { 183, true, "Su Kaçağı Tespiti", 4 },
                    { 184, true, "Su Tesisatçısı", 4 },
                    { 185, true, "Su Tesisatı Döşeme", 4 },
                    { 186, true, "Su Tesisatı Montaj", 4 },
                    { 187, true, "Sürgülü Dolap Tamiri", 4 },
                    { 188, true, "Taharet Musluğu Tamiri", 4 },
                    { 189, true, "Tıkanıklık Açma", 4 },
                    { 190, true, "TV Ekran Tamiri", 4 },
                    { 191, true, "TV LED Değişimi", 4 },
                    { 192, true, "TV Montajı", 4 },
                    { 193, true, "TV Panel Tamiri", 4 },
                    { 194, true, "TV Tamiri", 4 },
                    { 195, true, "Uydu Ayarlama", 4 },
                    { 196, true, "Xiaomi Telefon Tamiri", 4 },
                    { 197, true, "Almanca Özel Ders", 5 },
                    { 198, true, "Arapça Özel Ders", 5 },
                    { 199, true, "Bağlama Dersi", 5 },
                    { 200, true, "Basketbol Özel Ders", 5 },
                    { 201, true, "Bateri Dersi", 5 },
                    { 202, true, "Boks Dersi", 5 },
                    { 203, true, "Çello Dersi", 5 },
                    { 204, true, "DGS Matematik Özel Ders", 5 },
                    { 205, true, "Diferansiyel Denklemler Özel Ders", 5 },
                    { 206, true, "Dikiş Dersi", 5 },
                    { 207, true, "Diksiyon Dersi", 5 },
                    { 208, true, "Direksiyon Dersi", 5 },
                    { 209, true, "Eğitim Koçu", 5 },
                    { 210, true, "Excel Dersi", 5 }
                });

            migrationBuilder.InsertData(
                table: "Alt Kategori",
                columns: new[] { "Id", "Aktif", "AltKategoriAdi", "KategoriId" },
                values: new object[,]
                {
                    { 211, true, "Fen Bilimleri Özel Ders", 5 },
                    { 212, true, "Fitness Özel Ders", 5 },
                    { 213, true, "Fizik Özel Ders", 5 },
                    { 214, true, "Fransızca Özel Ders", 5 },
                    { 215, true, "Gitar Dersi", 5 },
                    { 216, true, "Gitar Kursu", 5 },
                    { 217, true, "Gölge Öğretmen", 5 },
                    { 218, true, "Grup Pilates Dersi", 5 },
                    { 219, true, "Hızlı Okuma Dersi", 5 },
                    { 220, true, "Hukuk Özel Ders", 5 },
                    { 221, true, "IELTS Özel Ders", 5 },
                    { 222, true, "İktisat Özel Ders", 5 },
                    { 223, true, "İlkokul Matematik Özel Ders", 5 },
                    { 224, true, "İlkokul Özel Ders", 5 },
                    { 225, true, "İngilizce Konuşma Dersi", 5 },
                    { 226, true, "İngilizce Özel Ders", 5 },
                    { 227, true, "İspanyolca Özel Ders", 5 },
                    { 228, true, "İstatistik Özel Ders", 5 },
                    { 229, true, "İtalyanca Özel Ders", 5 },
                    { 230, true, "Keman Dersi", 5 },
                    { 231, true, "Kick Boks Dersi", 5 },
                    { 232, true, "Kimya Özel Ders", 5 },
                    { 233, true, "Klarnet Dersi", 5 },
                    { 234, true, "KPSS Matematik Özel Ders", 5 },
                    { 235, true, "Kuran Özel Ders", 5 },
                    { 236, true, "LGS Matematik Özel Ders", 5 },
                    { 237, true, "Lise Matematik Özel Ders", 5 },
                    { 238, true, "Matematik Özel Ders", 5 },
                    { 239, true, "Motosiklet Eğitimi", 5 },
                    { 240, true, "Ödev Ablası", 5 },
                    { 241, true, "Öğrenci Koçu", 5 },
                    { 242, true, "Okuma Yazma Özel Ders", 5 },
                    { 243, true, "Online Almanca Özel Ders", 5 },
                    { 244, true, "Online Arapça Özel Ders", 5 },
                    { 245, true, "Online Calculus Özel Ders", 5 },
                    { 246, true, "Online Diksiyon Dersi", 5 },
                    { 247, true, "Online Eğitim Koçu", 5 },
                    { 248, true, "Online Fizik Özel Ders", 5 },
                    { 249, true, "Online Fransızca Özel Ders", 5 },
                    { 250, true, "Online Gitar Dersi", 5 },
                    { 251, true, "Online IELTS Özel Ders", 5 },
                    { 252, true, "Online İlkokul Özel Ders", 5 }
                });

            migrationBuilder.InsertData(
                table: "Alt Kategori",
                columns: new[] { "Id", "Aktif", "AltKategoriAdi", "KategoriId" },
                values: new object[,]
                {
                    { 253, true, "Online İngilizce Özel Ders", 5 },
                    { 254, true, "Online İspanyolca Özel Ders", 5 },
                    { 255, true, "Online İtalyanca Özel Ders", 5 },
                    { 256, true, "Online LGS Matematik Özel Ders", 5 },
                    { 257, true, "Online Lise Matematik Özel Ders", 5 },
                    { 258, true, "Online Muhasebe Dersi", 5 },
                    { 259, true, "Online Öğrenci Koçu", 5 },
                    { 260, true, "Online Ortaokul Matematik Özel Ders", 5 },
                    { 261, true, "Online Personal Trainer", 5 },
                    { 262, true, "Online Pilates Dersi", 5 },
                    { 263, true, "Online Resim Dersi", 5 },
                    { 264, true, "Online Rusça Özel Ders", 5 },
                    { 265, true, "Online Şan Dersi", 5 },
                    { 266, true, "Online Türkçe Özel Ders", 5 },
                    { 267, true, "Online TYT AYT Matematik Özel Ders", 5 },
                    { 268, true, "Online Yabancılar İçin Türkçe Dersi", 5 },
                    { 269, true, "Online Yoga Dersi", 5 },
                    { 270, true, "Ortaokul Matematik Özel Ders", 5 },
                    { 271, true, "Otizm Özel Ders", 5 },
                    { 272, true, "Özel Ders", 5 },
                    { 273, true, "Personal Trainer", 5 },
                    { 274, true, "Pilates Dersi", 5 },
                    { 275, true, "Piyano Dersi", 5 },
                    { 276, true, "Reformer Pilates Dersi", 5 },
                    { 277, true, "Resim Kursu", 5 },
                    { 278, true, "Resim Özel Ders", 5 },
                    { 279, true, "Rusça Özel Ders", 5 },
                    { 280, true, "Şan Dersi", 5 },
                    { 281, true, "Satranç Özel Ders", 5 },
                    { 282, true, "Sınıf Öğretmeni", 5 },
                    { 283, true, "Spor Koçu", 5 },
                    { 284, true, "Tenis Dersi", 5 },
                    { 285, true, "Türkçe Özel Ders", 5 },
                    { 286, true, "TYT AYT Matematik Özel Ders", 5 },
                    { 287, true, "Üniversite Fizik Özel Ders", 5 },
                    { 288, true, "Üniversite Kimya Özel Ders", 5 },
                    { 289, true, "Üniversite Matematik Özel Ders", 5 },
                    { 290, true, "Yabancılar İçin Türkçe Dersi", 5 },
                    { 291, true, "Yan Flüt Dersi", 5 },
                    { 292, true, "Yazılım Özel Ders", 5 },
                    { 293, true, "Yoga Dersi", 5 },
                    { 294, true, "Yüzme Dersi", 5 }
                });

            migrationBuilder.InsertData(
                table: "Alt Kategori",
                columns: new[] { "Id", "Aktif", "AltKategoriAdi", "KategoriId" },
                values: new object[,]
                {
                    { 295, true, "Zeybek Dersi", 5 },
                    { 296, true, "Aile Danışmanı", 6 },
                    { 297, true, "Aile Terapisi", 6 },
                    { 298, true, "Astroloji Danışmanlığı", 6 },
                    { 299, true, "Bioenerji Uzmanı", 6 },
                    { 300, true, "Çift Terapisi", 6 },
                    { 301, true, "ACilt Bakımı", 6 },
                    { 302, true, "Cinsel Terapi", 6 },
                    { 303, true, "Çocuk Bakımı", 6 },
                    { 304, true, "Çocuk Bakımı Ve Ev", 6 },
                    { 305, true, "Yardımcısı", 6 },
                    { 306, true, "Çocuk Psikoloğu", 6 },
                    { 307, true, "Dil Ve Konuşma Terapisi", 6 },
                    { 308, true, "Diyetisyen", 6 },
                    { 309, true, "Doğum Haritası Çıkarma", 6 },
                    { 310, true, "Dövme Tattoo", 6 },
                    { 311, true, "EMDR Terapisi", 6 },
                    { 312, true, "Emzirme Danışmanı", 6 },
                    { 313, true, "Epilasyon", 6 },
                    { 314, true, "Erkek Epilasyon", 6 },
                    { 315, true, "Ev Yardımcısı", 6 },
                    { 316, true, "Evde Bakım Hizmetleri", 6 },
                    { 317, true, "Evde Fizik Tedavi", 6 },
                    { 318, true, "Evde Hasta Bakımı", 6 },
                    { 319, true, "Evde Hemşire", 6 },
                    { 320, true, "Evde Yaşlı Bakımı", 6 },
                    { 321, true, "Evlilik Terapisi", 6 },
                    { 322, true, "Fal Bakma", 6 },
                    { 323, true, "Fizyoterapist", 6 },
                    { 324, true, "Gelin Makyajı", 6 },
                    { 325, true, "Gelin Saçı", 6 },
                    { 326, true, "Hasta Bakımı", 6 },
                    { 327, true, "Hastane Refakatçisi", 6 },
                    { 328, true, "Hemşire", 6 },
                    { 329, true, "Hipnoterapi", 6 },
                    { 330, true, "İngilizce Oyun Ablası", 6 },
                    { 331, true, "İpek Kirpik", 6 },
                    { 332, true, "Kalıcı Oje Yapımı", 6 },
                    { 333, true, "Kaş Kontürü", 6 },
                    { 334, true, "Kayropraktik", 6 },
                    { 335, true, "Klinik Psikolog", 6 },
                    { 336, true, "Kuaför", 6 }
                });

            migrationBuilder.InsertData(
                table: "Alt Kategori",
                columns: new[] { "Id", "Aktif", "AltKategoriAdi", "KategoriId" },
                values: new object[,]
                {
                    { 337, true, "Makyaj", 6 },
                    { 338, true, "Manuel Terapi", 6 },
                    { 339, true, "Masaj (Erkek İçin)", 6 },
                    { 340, true, "Masaj (Kadın İçin)", 6 },
                    { 341, true, "Medyum", 6 },
                    { 342, true, "Microblading", 6 },
                    { 343, true, "Nefes Terapisi", 6 },
                    { 344, true, "Nişan Makyajı", 6 },
                    { 345, true, "Ombre", 6 },
                    { 346, true, "Online Çift Terapisi", 6 },
                    { 347, true, "Online Cinsel Terapisi", 6 },
                    { 348, true, "Online Çocuk Psikoloğo", 6 },
                    { 349, true, "Online Dil Ve Konuşma", 6 },
                    { 350, true, "Terapisi", 6 },
                    { 351, true, "Online Diyetisyen", 6 },
                    { 352, true, "Online Evlilik Terapisi", 6 },
                    { 353, true, "Online Pedagog", 6 },
                    { 354, true, "Online Psikolog", 6 },
                    { 355, true, "Online Psikolojik", 6 },
                    { 356, true, "Danışman", 6 },
                    { 357, true, "Online Psikoterapi", 6 },
                    { 358, true, "Online Stil Danışmanı", 6 },
                    { 359, true, "Online Terapi", 6 },
                    { 360, true, "Online Yaşam Koçu", 6 },
                    { 361, true, "Oyun Ablası", 6 },
                    { 362, true, "Oyun Terapisi", 6 },
                    { 363, true, "Özel Ambulans", 6 },
                    { 364, true, "Özel Eğitim", 6 },
                    { 365, true, "Pedagog", 6 },
                    { 366, true, "Personel Trainer", 6 },
                    { 367, true, "Pilates Dersi", 6 },
                    { 368, true, "Protez Tırnak Yapımı", 6 },
                    { 369, true, "APsikolog", 6 },
                    { 370, true, "Psikolojik Danışmanı", 6 },
                    { 371, true, "Psikoterapi", 6 },
                    { 372, true, "Saatlik Çocuk Bakımı", 6 },
                    { 373, true, "Saç Boyama", 6 },
                    { 374, true, "Saç Kaynağı", 6 },
                    { 375, true, "Stil Danışmanı", 6 },
                    { 376, true, "AUzman Psikolog", 6 },
                    { 377, true, "Yaşam Koçu", 6 },
                    { 378, true, "Yaşlı Bakımı", 6 }
                });

            migrationBuilder.InsertData(
                table: "Alt Kategori",
                columns: new[] { "Id", "Aktif", "AltKategoriAdi", "KategoriId" },
                values: new object[,]
                {
                    { 379, true, "Yetişkin Psikolog", 6 },
                    { 380, true, "Açılış Organizasyonu", 7 },
                    { 381, true, "Animatör", 7 },
                    { 382, true, "Bando Takımı", 7 },
                    { 383, true, "Butik Pasta", 7 },
                    { 384, true, "Canlı Müzik", 7 },
                    { 385, true, "Catering", 7 },
                    { 386, true, "Davet Catering", 7 },
                    { 387, true, "Davul Zurnacı Kiralama", 7 },
                    { 388, true, "DJ", 7 },
                    { 389, true, "Doğum Günü Catering", 7 },
                    { 390, true, "Doğum Günü Mekanları", 7 },
                    { 391, true, "Doğum Günü Organizasyonu", 7 },
                    { 392, true, "Doğum Günü Pastası", 7 },
                    { 393, true, "Düğün Bandosu", 7 },
                    { 394, true, "Düğün Catering", 7 },
                    { 395, true, "Düğün Organizasyon", 7 },
                    { 396, true, "Düğün Orkestrası", 7 },
                    { 397, true, "Düğün Yemeği", 7 },
                    { 398, true, "Evlilik Teklifi Organizasyon", 7 },
                    { 399, true, "Garson Kiralama", 7 },
                    { 400, true, "Gelin Alma Bandosu", 7 },
                    { 401, true, "Gelin Arabası Kiralama", 7 },
                    { 402, true, "Gelinlik Dikimi", 7 },
                    { 403, true, "Hastane Odası Süsleme", 7 },
                    { 404, true, "İftar Yemeği Catering", 7 },
                    { 405, true, "Kına Organizasyon", 7 },
                    { 406, true, "Klasik Araba Kiralama", 7 },
                    { 407, true, "Kokteyl Catering", 7 },
                    { 408, true, "Masa Sandalye Kiralama", 7 },
                    { 409, true, "Mevlüt Yemeği", 7 },
                    { 410, true, "Mevlüt Yemeği Catering", 7 },
                    { 411, true, "Müzisyen", 7 },
                    { 412, true, "Nişan İkramlıkları Catering", 7 },
                    { 413, true, "Nişan Menüsü Catering", 7 },
                    { 414, true, "Nişan Organizasyon", 7 },
                    { 415, true, "Nişan Pastası", 7 },
                    { 416, true, "Palyaço", 7 },
                    { 417, true, "Sihirbaz", 7 },
                    { 418, true, "Söz Organizyon", 7 },
                    { 419, true, "Sünnet Organizasyon", 7 },
                    { 420, true, "Tabldot Yemek", 7 }
                });

            migrationBuilder.InsertData(
                table: "Alt Kategori",
                columns: new[] { "Id", "Aktif", "AltKategoriAdi", "KategoriId" },
                values: new object[,]
                {
                    { 421, true, "Temsili Nikah Memuru", 7 },
                    { 422, true, "Yaş Pasta", 7 },
                    { 423, true, "Yat Kiralama", 7 },
                    { 424, true, "Yatta Evlilik Teklifi", 7 },
                    { 425, true, "Bebek Fotoğrafçısı", 8 },
                    { 426, true, "Dış Çekim Fotoğraf", 8 },
                    { 427, true, "Doğum Günü Fotoğrafçısı", 8 },
                    { 428, true, "Drone Çekimi", 8 },
                    { 429, true, "Drone Fotoğraf Ve Video", 8 },
                    { 430, true, "Düğün Fotoğrafçısı", 8 },
                    { 431, true, "Düğün Video Çekimi", 8 },
                    { 432, true, "Fotoğrafçı", 8 },
                    { 433, true, "Hamile Fotoğraf Çekimi", 8 },
                    { 434, true, "İnstagram İçin Fotoğraf Çekimi", 8 },
                    { 435, true, "Mekan Fotoğraf Çekimi", 8 },
                    { 436, true, "Nişan Fotoğrafçısı", 8 },
                    { 437, true, "Sosyal Medya İçin Fotoğraf Çekimi", 8 },
                    { 438, true, "Sosyal Medya Video Çekimi", 8 },
                    { 439, true, "Stüdyo Fotoğraf Çekimi", 8 },
                    { 440, true, "Tanıtım Filmi Çekimi", 8 },
                    { 441, true, "Ürün Fotoğraf Çekimi", 8 },
                    { 442, true, "Video Çekimi", 8 },
                    { 443, true, "Video Editörü", 8 },
                    { 444, true, "3D Animasyon Yapımı", 9 },
                    { 445, true, "3D Baskı", 9 },
                    { 446, true, "Abiye Dikimi", 9 },
                    { 447, true, "Afiş Tasarım", 9 },
                    { 448, true, "Almanca Çeviri", 9 },
                    { 449, true, "Almanca Yeminli Tercüme", 9 },
                    { 450, true, "Ambalaj Tasarım", 9 },
                    { 451, true, "Android Uygulama", 9 },
                    { 452, true, "Geliştirme", 9 },
                    { 453, true, "Animasyon Yapımı", 9 },
                    { 454, true, "Arapça Çeviri", 9 },
                    { 455, true, "AutoCAD Çizim", 9 },
                    { 456, true, "Banner Tasarımı", 9 },
                    { 457, true, "Broşür Baskı", 9 },
                    { 458, true, "Broşür Dağıtım", 9 },
                    { 459, true, "Broşür Tasarım", 9 },
                    { 460, true, "CV Hazırlama Danışmanlığı", 9 },
                    { 461, true, "Davetiye Baskı", 9 },
                    { 462, true, "Dijital Baskı", 9 }
                });

            migrationBuilder.InsertData(
                table: "Alt Kategori",
                columns: new[] { "Id", "Aktif", "AltKategoriAdi", "KategoriId" },
                values: new object[,]
                {
                    { 463, true, "Dijital Pazarlama ve Reklam", 9 },
                    { 464, true, "Dış Ticaret Danışmanlık", 9 },
                    { 465, true, "Duvara Resim Yapma", 9 },
                    { 466, true, "E Ticaret Danışmanı", 9 },
                    { 467, true, "E Ticaret Sitesi Yapımı", 9 },
                    { 468, true, "Elbise Dikimi", 9 },
                    { 469, true, "Elbise İmalatı", 9 },
                    { 470, true, "Elektronik Devre Tasarımı", 9 },
                    { 471, true, "Freelance Yazılımcı", 9 },
                    { 472, true, "Fuar Hostesi", 9 },
                    { 473, true, "Google Reklam Yönetimi", 9 },
                    { 474, true, "Graffiti", 9 },
                    { 475, true, "Grafik Tasarım", 9 },
                    { 476, true, "Gümrük Müşaviri", 9 },
                    { 477, true, "3D Animasyon Yapımı", 9 },
                    { 478, true, "İllüstrasyon Çizim", 9 },
                    { 479, true, "İngilizce Çeviri", 9 },
                    { 480, true, "İngilizce Makale Yazımı", 9 },
                    { 481, true, "İngilizce Yeminli Tercüme", 9 },
                    { 482, true, "İş Sağlığı ve Güvenliği", 9 },
                    { 483, true, "Kadın Manken", 9 },
                    { 484, true, "Karakalem Çizim", 9 },
                    { 485, true, "Karikatür Çizim", 9 },
                    { 486, true, "Kartvizit Baskı", 9 },
                    { 487, true, "Kartvizit Tasarımı", 9 },
                    { 488, true, "Katalog Tasarımı", 9 },
                    { 489, true, "Kitap Baskı", 9 },
                    { 490, true, "Kitap Editörü", 9 },
                    { 491, true, "Kitap Kapağı Tasarımı", 9 },
                    { 492, true, "KOSGEB Danışmanlık", 9 },
                    { 493, true, "Kutu Harf Tabela", 9 },
                    { 494, true, "Limited Şirket Kurma", 9 },
                    { 495, true, "Logo Tasarım", 9 },
                    { 496, true, "Marka Tescil", 9 },
                    { 497, true, "Metin Yazarı", 9 },
                    { 498, true, "Metin Yazma", 9 },
                    { 499, true, "Mevcut Web Sitesi Düzenleme", 9 },
                    { 500, true, "Mobil Uygulama Geliştirme", 9 },
                    { 501, true, "Moda Tasarım", 9 },
                    { 502, true, "Modelist", 9 },
                    { 503, true, "Müzik Prodüksiyon", 9 },
                    { 504, true, "Osmanlıca Çeviri", 9 }
                });

            migrationBuilder.InsertData(
                table: "Alt Kategori",
                columns: new[] { "Id", "Aktif", "AltKategoriAdi", "KategoriId" },
                values: new object[,]
                {
                    { 505, true, "Oyun Programlama", 9 },
                    { 506, true, "Özel Güvenlik", 9 },
                    { 507, true, "Özel Koruma", 9 },
                    { 508, true, "Photoshop Uzmanı", 9 },
                    { 509, true, "Pleksi Tabela", 9 },
                    { 510, true, "Python Programlama", 9 },
                    { 511, true, "Reklam Tasarımı", 9 },
                    { 512, true, "Ressam", 9 },
                    { 513, true, "Rusça Çeviri", 9 },
                    { 514, true, "Şahıs Şirketi Kurma", 9 },
                    { 515, true, "Senaryo Yazarı", 9 },
                    { 516, true, "Logo Tasarım", 9 },
                    { 517, true, "SEO Hizmeti", 9 },
                    { 518, true, "SEO Uyumlu Makale Yazımı", 9 },
                    { 519, true, "Seslendirme", 9 },
                    { 520, true, "SGK Danışmanlık", 9 },
                    { 521, true, "Simultane Çeviri", 9 },
                    { 522, true, "Site Bina ve Apartman Yönetimi", 9 },
                    { 523, true, "Sosyal Medya Danışmanlığı", 9 },
                    { 524, true, "Sosyal Medya Tasarım", 9 },
                    { 525, true, "Sosyal Medya Uzmanı", 9 },
                    { 526, true, "Sosyal Medya Yönetimi ve Danışmanlığı", 9 },
                    { 527, true, "SPSS Analizi", 9 },
                    { 528, true, "Sunum Hazırlama", 9 },
                    { 529, true, "Sweatshirt İmalatı", 9 },
                    { 530, true, "Tabela", 9 },
                    { 531, true, "Tekstil Fason Dikim ve İmalat", 9 },
                    { 532, true, "Tişört Baskı", 9 },
                    { 533, true, "Tişört İmalatı", 9 },
                    { 534, true, "Vize Danışmanı", 9 },
                    { 535, true, "Web Site Yapımı", 9 },
                    { 536, true, "Web Tasarım", 9 },
                    { 537, true, "Web Tasarım Programlama", 9 },
                    { 538, true, "Web Yazılım", 9 },
                    { 539, true, "Yazılım Geliştirme", 9 },
                    { 540, true, "Yeminli Mütercim Tercüman", 9 },
                    { 541, true, "Evde Kedi Bakımı", 10 },
                    { 542, true, "Kedi Bakımı", 10 },
                    { 543, true, "Kedi Oteli", 10 },
                    { 544, true, "Kedi Teli", 10 },
                    { 545, true, "Kedi Traşı", 10 },
                    { 546, true, "Köpek Eğitimi", 10 }
                });

            migrationBuilder.InsertData(
                table: "Alt Kategori",
                columns: new[] { "Id", "Aktif", "AltKategoriAdi", "KategoriId" },
                values: new object[,]
                {
                    { 547, true, "Köpek Gezdirme", 10 },
                    { 548, true, "Köpek Kuaförü", 10 },
                    { 549, true, "Köpek Oteli", 10 },
                    { 550, true, "Köpek Pansiyonu", 10 },
                    { 551, true, "Köpek Traşı", 10 },
                    { 552, true, "Pet Kuaförü", 10 },
                    { 553, true, "Araç Bakım", 11 },
                    { 554, true, "Araç Folyo Kaplama", 11 },
                    { 555, true, "Araç Koltuk Temizleme", 11 },
                    { 556, true, "Araç Seramik Kaplama", 11 },
                    { 557, true, "Balata Değişimi", 11 },
                    { 558, true, "Baskı Balata Değişimi", 11 },
                    { 559, true, "Boyasız Göçük Düzeltme", 11 },
                    { 560, true, "Motor Yağ Değişimi", 11 },
                    { 561, true, "Oto Bakım", 11 },
                    { 562, true, "Oto Boya", 11 },
                    { 563, true, "AOto Cam Filmi", 11 },
                    { 564, true, "Oto Ekspertiz", 11 },
                    { 565, true, "Oto Kuaför", 11 },
                    { 566, true, "Pasta Cila", 11 },
                    { 567, true, "Triger Seti Değişimi", 11 },
                    { 568, true, "Emlak Satış Danışmanı", 12 },
                    { 569, true, "Gayrimenkul Değerleme", 12 },
                    { 570, true, "Özel Dedektif", 12 },
                    { 571, true, "Trafik Sigortası", 12 }
                });

            migrationBuilder.InsertData(
                table: "Kullanıcı Rol",
                columns: new[] { "KullaniciId", "RolId" },
                values: new object[] { new Guid("de437142-7d58-4ac1-81a2-91d48aa8be7b"), 1 });

            migrationBuilder.InsertData(
                table: "Sorular",
                columns: new[] { "SoruId", "AltKategoriId", "Sorular" },
                values: new object[,]
                {
                    { 1, 1, "Evin Büyüklüğü" },
                    { 2, 1, "Banyo Sayısı" },
                    { 3, 1, "Kaç Saat" },
                    { 4, 1, "Hangi Sıklık" },
                    { 5, 1, "Ek Hizmet" },
                    { 6, 1, "il" },
                    { 7, 1, "ilçe" },
                    { 8, 1, "Detay" },
                    { 9, 2, "Daire Sayısı" },
                    { 10, 2, "Çöp Toplansın mı" },
                    { 11, 2, "Hangi Sıklık" },
                    { 12, 2, "il" },
                    { 13, 2, "ilçe" },
                    { 14, 2, "Detay" },
                    { 15, 3, "Hangi Sıklık" },
                    { 16, 3, "Kaç Metrekare" },
                    { 17, 3, "il" },
                    { 18, 3, "ilçe" },
                    { 19, 3, "Detay" },
                    { 20, 4, "Evin Büyüklüğü" },
                    { 21, 4, "Banyo Sayısı" },
                    { 22, 4, "Kaç Metrekare" },
                    { 23, 4, "İl" },
                    { 24, 4, "İlçe" },
                    { 25, 4, "Detay" },
                    { 26, 5, "Dükkan Büyüklüğü" },
                    { 27, 5, "Hangi Sıklık" },
                    { 28, 5, "İl" },
                    { 29, 5, "İlçe" },
                    { 30, 5, "Detay" },
                    { 31, 6, "Haşere Tipi" },
                    { 32, 6, "Alan Büyüklüğü" },
                    { 33, 6, "Mekan Tipi" },
                    { 34, 6, "İl" },
                    { 35, 6, "İlçe" },
                    { 36, 6, "Detay" },
                    { 37, 7, "Halı Nerede Yıkansın" },
                    { 38, 7, "Metrekaresi" },
                    { 39, 7, "Leke Var mı" },
                    { 40, 7, "İl" },
                    { 41, 7, "İlçe" },
                    { 42, 7, "Detay" }
                });

            migrationBuilder.InsertData(
                table: "Sorular",
                columns: new[] { "SoruId", "AltKategoriId", "Sorular" },
                values: new object[,]
                {
                    { 43, 8, "Ürün" },
                    { 44, 8, "Ütü Yapılsın mı" },
                    { 45, 8, "Adet" },
                    { 46, 8, "İl" },
                    { 47, 8, "İlçe" },
                    { 48, 8, "Detay" },
                    { 49, 9, "Mobilya" },
                    { 50, 9, "Koltuk Minderli mi" },
                    { 51, 9, "Adet" },
                    { 52, 9, "İl" },
                    { 53, 9, "İlçe" },
                    { 54, 9, "Detay" },
                    { 55, 10, "Mekan" },
                    { 56, 10, "İl" },
                    { 57, 10, "İlçe" },
                    { 58, 10, "Detay" },
                    { 59, 11, "Alan Büyüklüğü" },
                    { 60, 11, "Kaç Oda" },
                    { 61, 11, "Malzeme Dahil mi?" },
                    { 62, 11, "İl" },
                    { 63, 11, "İlçe" },
                    { 64, 11, "Detay" },
                    { 65, 12, "Yapılacak İş" },
                    { 66, 12, "Kaç Adet?" },
                    { 67, 12, "İl" },
                    { 68, 12, "İlçe" },
                    { 69, 12, "Detay" },
                    { 70, 13, "Tamir Tipi" },
                    { 71, 13, "Kaç Adet" },
                    { 72, 13, "İl" },
                    { 73, 13, "İlçe" },
                    { 74, 13, "Detay" },
                    { 75, 14, "Tamir Tipi" },
                    { 76, 14, "İl" },
                    { 77, 14, "İlçe" },
                    { 78, 14, "Detay" },
                    { 79, 15, "Duvar malzemesi" },
                    { 80, 15, "Duvar Uzunluğu(metre):" },
                    { 81, 15, "Duvar Yüksekliği" },
                    { 82, 15, "Malzeme Dahil Olsun mu?" },
                    { 83, 15, "İl" },
                    { 84, 15, "İlçe" }
                });

            migrationBuilder.InsertData(
                table: "Sorular",
                columns: new[] { "SoruId", "AltKategoriId", "Sorular" },
                values: new object[,]
                {
                    { 85, 15, "Detay" },
                    { 86, 16, "Balkon Sistemi" },
                    { 87, 16, "Cam Çevresi" },
                    { 88, 16, "Cam Yüksekliği" },
                    { 89, 16, "Balkon Şekli" },
                    { 90, 16, "İl" },
                    { 91, 16, "İlçe" },
                    { 92, 16, "Detay" },
                    { 93, 17, "Döşeme Tipi" },
                    { 94, 17, "Döşeme Alanı" },
                    { 95, 17, "Fiyata Malzeme Dahil olsun mu?" },
                    { 96, 17, "İl" },
                    { 97, 17, "İlçe" },
                    { 98, 17, "Detay" },
                    { 99, 18, "Havuz Türü" },
                    { 100, 18, "Havuz Boyu" },
                    { 101, 18, "Havuz Eni" },
                    { 102, 18, "Havuz Derinliği" },
                    { 103, 18, "İl" },
                    { 104, 18, "İlçe" },
                    { 105, 18, "Detay" },
                    { 106, 19, "En" },
                    { 107, 19, "Boy" },
                    { 108, 19, "Derinlik" },
                    { 109, 19, "Kapı Tipi" },
                    { 110, 19, "İl" },
                    { 111, 19, "İlçe" },
                    { 112, 19, "Detay" },
                    { 113, 20, "Mekan" },
                    { 114, 20, "Yapılacak iş" },
                    { 115, 20, "Proje Alanı" },
                    { 116, 20, "İl" },
                    { 117, 20, "İlçe" },
                    { 118, 20, "Detay" },
                    { 119, 21, "Alan" },
                    { 120, 21, "Kaç Katlı" },
                    { 121, 21, "İl" },
                    { 122, 21, "İlçe" },
                    { 123, 21, "Detay" },
                    { 124, 22, "Koltuk Tipi" },
                    { 125, 22, "Adet" },
                    { 126, 22, "İl" }
                });

            migrationBuilder.InsertData(
                table: "Sorular",
                columns: new[] { "SoruId", "AltKategoriId", "Sorular" },
                values: new object[,]
                {
                    { 127, 22, "İlçe" },
                    { 128, 22, "Detay" },
                    { 129, 23, "Çatı kaplama malzemesi nedir?" },
                    { 130, 23, "Çatıda yapılması gereken işler neler?" },
                    { 131, 23, "Tadilat yapılacak çatı alanı yaklaşık kaç m2?" },
                    { 132, 23, "Fiyata malzeme dahil olsun mu?" },
                    { 133, 23, "Fiyata malzeme dahil olsun mu?" },
                    { 134, 23, "Çatı Eğimi Ne kadar" },
                    { 135, 23, "İl" },
                    { 136, 23, "İlçe" },
                    { 137, 23, "Detay" },
                    { 138, 24, "Yapılacak İş" },
                    { 139, 24, "Kaç dairede çalışma yapılacak?" },
                    { 140, 24, "Proje çizimi ve gaz açma yapılacak mı?" },
                    { 141, 24, "Çalışma yapılacak alan kaç m2?" },
                    { 142, 24, "Hangi tesisat(lar) döşenecek?" },
                    { 143, 24, "İl" },
                    { 144, 24, "İlçe" },
                    { 145, 24, "Detay" },
                    { 146, 25, "Detay" },
                    { 147, 25, "İl" },
                    { 148, 25, "İlçe" },
                    { 149, 26, "Ne yaptırmak istiyorsun?" },
                    { 150, 26, "Güneş enerjisi sisteminin kullanım amacı nedir?" },
                    { 151, 26, "İl" },
                    { 152, 26, "İlçe" },
                    { 153, 26, "Detay" },
                    { 154, 27, "Sineklik nereye yapılacak?" },
                    { 155, 27, "Ne tür sineklik istiyorsun?" },
                    { 156, 27, "Kaç adet kapı sinekliği gerekiyor?" },
                    { 157, 27, "Kapı eni ne kadar?" },
                    { 158, 27, "Kapı boyu ne kadar?" },
                    { 159, 27, "Kaç adet pencere sinekliği gerekiyor?" },
                    { 160, 27, "Pencere eni ne kadar?" },
                    { 161, 27, "Pencere boyu ne kadar?" },
                    { 162, 27, "İl" },
                    { 163, 27, "İlçe" },
                    { 164, 27, "Detay" },
                    { 165, 28, "Kaç Kişilik" },
                    { 166, 28, "Ne kadarı Yapılacak?" },
                    { 167, 28, "Malzeme tercihi" },
                    { 168, 28, "İl" }
                });

            migrationBuilder.InsertData(
                table: "Sorular",
                columns: new[] { "SoruId", "AltKategoriId", "Sorular" },
                values: new object[,]
                {
                    { 169, 28, "İlçe" },
                    { 170, 28, "Detay" },
                    { 171, 29, "Detay" },
                    { 172, 29, "İl" },
                    { 173, 29, "İlçe" },
                    { 174, 30, "Kaç adet sandalye döşenecek?" },
                    { 175, 30, "Sandalye tipi nedir?" },
                    { 176, 30, "Nasıl bir döşeme istiyorsunuz?" },
                    { 177, 30, "İl" },
                    { 178, 30, "İlçe" },
                    { 179, 30, "Detay" },
                    { 180, 31, "Nereye ses yalıtımı yapılacak?" },
                    { 181, 31, "Ses yalıtımı yapılacak tavan alanı kaç metrekare?" },
                    { 182, 31, "İl" },
                    { 183, 31, "İlçe" },
                    { 184, 31, "Detay" },
                    { 185, 32, "Sıva hangilerine yapılacak?" },
                    { 186, 32, "Toplam kaç metrekare alan sıva yapılacak?" },
                    { 187, 32, "İl" },
                    { 188, 32, "İlçe" },
                    { 189, 32, "Detay" },
                    { 190, 33, "Kaynak yapılacak olan nedir?" },
                    { 191, 33, "İl" },
                    { 192, 33, "İlçe" },
                    { 193, 33, "Detay" },
                    { 194, 34, "Kaç metrekare oda/ev alçı yapılacak?" },
                    { 195, 34, "Fiyata malzeme dahil olsun mu?" },
                    { 196, 34, "İl" },
                    { 197, 34, "İlçe" },
                    { 198, 34, "Detay" },
                    { 199, 35, "Kaç adet bina / blok için deprem testi yapılacak?" },
                    { 200, 35, "Bina(lar) kaç katlı? (Zemin altı katlar dahil)" },
                    { 201, 35, "Bina zemin oturum alanı kaç metrekare?" },
                    { 202, 35, "İl" },
                    { 203, 35, "İlçe" },
                    { 204, 35, "Detay" },
                    { 205, 36, "Hangisine ihtiyacın var?" },
                    { 206, 36, "Hangi tip stor perde yapılacak?" },
                    { 207, 36, "İl" },
                    { 208, 36, "İlçe" },
                    { 209, 36, "Detay" },
                    { 210, 37, "Ne yapılması gerekiyor?" }
                });

            migrationBuilder.InsertData(
                table: "Sorular",
                columns: new[] { "SoruId", "AltKategoriId", "Sorular" },
                values: new object[,]
                {
                    { 211, 37, "Ne tür bir panjur?" },
                    { 212, 37, "Nereye yapılacak?" },
                    { 213, 37, "Kaç adet panjur?" },
                    { 214, 37, "İl" },
                    { 215, 37, "İlçe" },
                    { 216, 37, "Detay" },
                    { 217, 38, "Kaç metrekare hazır rulo çim yapılacak?" },
                    { 218, 38, "Fiyata sulama sistemi kurulması da dahil olsun mu?" },
                    { 219, 38, "Uygulama öncesi ne gibi toprak hazırlıklarına ihtiyacın var?" },
                    { 220, 38, "İl" },
                    { 221, 38, "İlçe" },
                    { 222, 38, "Detay" },
                    { 223, 39, "Ne yaptırmak İstiyorsunuz?" },
                    { 224, 39, "İl" },
                    { 225, 39, "İlçe" },
                    { 226, 39, "Detay" },
                    { 227, 40, "Neye ihtiyacın var?" },
                    { 228, 40, "Hangi tip mermer " },
                    { 229, 40, "İl" },
                    { 230, 40, "İlçe" },
                    { 231, 40, "Detay" },
                    { 232, 41, "Ne tip çit istiyorsun?" },
                    { 233, 41, "Hangi zemine yapılacak?" },
                    { 234, 41, "Çit uzunluğu kaç metre olacak?" },
                    { 235, 41, "Yüksekliği kaç santimetre olacak?:" },
                    { 236, 41, "Kaç kapı olacak?" },
                    { 237, 41, "İl" },
                    { 238, 41, "İlçe" },
                    { 239, 41, "Detay" },
                    { 240, 42, "Ne yaptırmak istiyorsun?" },
                    { 241, 42, "İl" },
                    { 242, 42, "İlçe" },
                    { 243, 42, "Detay" },
                    { 244, 43, "Kaç adet bina / blok için bina güçlendirme yapılacak?" },
                    { 245, 43, "Bina(lar) kaç katlı? (Zemin altı katlar dahil)" },
                    { 246, 43, "Bina zemin oturum alanı kaç metrekare?" },
                    { 247, 43, "İl" },
                    { 248, 43, "İlçe" },
                    { 249, 43, "Detay" },
                    { 250, 44, "Hangi tip tavan ile teras kapatılacak?" },
                    { 251, 44, "Kapatılacak teras alanı kaç metrekare?" },
                    { 252, 44, "İl" }
                });

            migrationBuilder.InsertData(
                table: "Sorular",
                columns: new[] { "SoruId", "AltKategoriId", "Sorular" },
                values: new object[,]
                {
                    { 253, 44, "İlçe" },
                    { 254, 44, "Detay" },
                    { 255, 45, "Yapılacak iş" },
                    { 256, 45, "Alan" },
                    { 257, 45, "Malzeme dahil mi?" },
                    { 258, 45, "İl" },
                    { 259, 45, "İlçe" },
                    { 260, 45, "Detay" }
                });

            migrationBuilder.InsertData(
                table: "Cevaplar",
                columns: new[] { "CevapId", "Cevaplar", "SoruId" },
                values: new object[,]
                {
                    { 1, "1+0", 1 },
                    { 2, "1+1", 1 },
                    { 3, "2+1", 1 },
                    { 4, "3+1", 1 },
                    { 5, "Diğer", 1 },
                    { 6, "1", 2 },
                    { 7, "2", 2 },
                    { 8, "diğer", 2 },
                    { 9, "3", 3 },
                    { 10, "4", 3 },
                    { 11, "5", 3 },
                    { 12, "6", 3 },
                    { 13, "Diğer", 3 },
                    { 14, "Haftada Bir", 4 },
                    { 15, "Haftada iki", 4 },
                    { 16, "Tek Seferlik", 4 },
                    { 17, "Diğer", 4 },
                    { 18, "Yemek", 5 },
                    { 19, "Çamaşır Yıkama", 5 },
                    { 20, "Ütü", 5 },
                    { 21, "il", 6 },
                    { 22, "ilçe", 7 },
                    { 23, "Mesaj", 8 },
                    { 24, "1-5", 9 },
                    { 25, "6-12", 9 },
                    { 26, "13-20", 9 },
                    { 27, "Diğer", 9 },
                    { 28, "Evet", 10 },
                    { 29, "Hayır", 10 },
                    { 30, "Haftada bir", 11 },
                    { 31, "Haftada iki", 11 },
                    { 32, "Tek Seferlik", 11 },
                    { 33, "Diğer", 11 },
                    { 34, "İl", 12 },
                    { 35, "İlçe", 13 },
                    { 36, "Mesaj", 14 },
                    { 37, "Haftada Bir", 15 },
                    { 38, "Haftada iki", 15 },
                    { 39, "Tek Seferlik", 15 },
                    { 40, "Diğer", 15 },
                    { 41, "30-80", 16 },
                    { 42, "80-120", 16 }
                });

            migrationBuilder.InsertData(
                table: "Cevaplar",
                columns: new[] { "CevapId", "Cevaplar", "SoruId" },
                values: new object[,]
                {
                    { 43, "120-200", 16 },
                    { 44, "İl", 17 },
                    { 45, "İlçe", 18 },
                    { 46, "Mesaj", 19 },
                    { 47, "1+0", 20 },
                    { 48, "1+1", 20 },
                    { 49, "2+1", 20 },
                    { 50, "3+1", 20 },
                    { 51, "Diğer", 20 },
                    { 52, "1", 21 },
                    { 53, "2", 21 },
                    { 54, "Diğer", 21 },
                    { 55, "30-80", 22 },
                    { 56, "80-120", 22 },
                    { 57, "120-200", 22 },
                    { 58, "İl", 23 },
                    { 59, "İlçe", 24 },
                    { 60, "Mesaj", 25 },
                    { 61, "30-80", 26 },
                    { 62, "80-120", 26 },
                    { 63, "120-200", 26 },
                    { 64, "Haftada Bir", 27 },
                    { 65, "Haftada İki", 27 },
                    { 66, "Tek seferlik", 27 },
                    { 67, "Diğer", 27 },
                    { 68, "İl", 28 },
                    { 69, "İlçe", 29 },
                    { 70, "Mesaj", 30 },
                    { 71, "Hamam Böceği", 31 },
                    { 72, "Bit/Pire", 31 },
                    { 73, "Fare", 31 },
                    { 74, "Diğer", 31 },
                    { 75, "30-80", 32 },
                    { 76, "80-120", 32 },
                    { 77, "120-200", 32 },
                    { 78, "Ev", 33 },
                    { 79, "Bahçe", 33 },
                    { 80, "Bina", 33 },
                    { 81, "Diğer", 33 },
                    { 82, "İl", 34 },
                    { 83, "İlçe", 35 },
                    { 84, "Mesaj", 36 }
                });

            migrationBuilder.InsertData(
                table: "Cevaplar",
                columns: new[] { "CevapId", "Cevaplar", "SoruId" },
                values: new object[,]
                {
                    { 85, "Adresten alınıp teslim edilsin", 37 },
                    { 86, "Evde halı temizliği", 37 },
                    { 87, "Ofiste halı temizliği", 37 },
                    { 88, "5-15", 38 },
                    { 89, "15-30", 38 },
                    { 90, "30-50", 38 },
                    { 91, "60-80", 38 },
                    { 92, "diğer", 38 },
                    { 93, "Evet", 39 },
                    { 94, "Hayır", 39 },
                    { 95, "İl", 40 },
                    { 96, "İlçe", 41 },
                    { 97, "Mesaj", 42 },
                    { 98, "Yorgan", 43 },
                    { 99, "Battaniye", 43 },
                    { 100, "Perde", 43 },
                    { 101, "Ceket", 43 },
                    { 102, "Pantolon", 43 },
                    { 103, "Gömlek", 43 },
                    { 104, "Mont/Kaban/Palto", 43 },
                    { 105, "Gelinlik", 43 },
                    { 106, "Diğer", 43 },
                    { 107, "Evet", 44 },
                    { 108, "Hayır", 44 },
                    { 109, "1-3", 45 },
                    { 110, "3-5", 45 },
                    { 111, "5-7", 45 },
                    { 112, "diğer", 45 },
                    { 113, "İl", 46 },
                    { 114, "İlçe", 47 },
                    { 115, "Mesaj", 48 },
                    { 116, "Yatak", 49 },
                    { 117, "Berjer", 49 },
                    { 118, "İkili Koltuk", 49 },
                    { 119, "Üçlü Koltuk", 49 },
                    { 120, "L Koltuk ", 49 },
                    { 121, "Araç içi Koltuk", 49 },
                    { 122, "Sandalye", 49 },
                    { 123, "Yaslanma yeri minderli", 50 },
                    { 124, "Oturma yeri minderli", 50 },
                    { 125, "İkisi de minderli", 50 },
                    { 126, "Mindersiz", 50 }
                });

            migrationBuilder.InsertData(
                table: "Cevaplar",
                columns: new[] { "CevapId", "Cevaplar", "SoruId" },
                values: new object[,]
                {
                    { 127, "1", 51 },
                    { 128, "2", 51 },
                    { 129, "3", 51 },
                    { 130, "4", 51 },
                    { 131, "5", 51 },
                    { 132, "6", 51 },
                    { 133, "Diğer", 51 },
                    { 134, "İl", 52 },
                    { 135, "İlçe", 53 },
                    { 136, "mesaj", 54 },
                    { 137, "1+1", 55 },
                    { 138, "2+1", 55 },
                    { 139, "3+1", 55 },
                    { 140, "4+1", 55 },
                    { 141, "Daha Büyük Ev", 55 },
                    { 142, "Bina Dış Cephe", 55 },
                    { 143, "Mağaza", 55 },
                    { 144, "İl", 56 },
                    { 145, "İlçe", 57 },
                    { 146, "Mesaj", 58 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alt Kategori_KategoriId",
                table: "Alt Kategori",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Cevaplar_SoruId",
                table: "Cevaplar",
                column: "SoruId");

            migrationBuilder.CreateIndex(
                name: "IX_İl_UlkeId",
                table: "İl",
                column: "UlkeId");

            migrationBuilder.CreateIndex(
                name: "IX_İlçe_IlId",
                table: "İlçe",
                column: "IlId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanıcı Rol_RolId",
                table: "Kullanıcı Rol",
                column: "RolId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mahalleler_IlceId",
                table: "Mahalleler",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_Sorular_AltKategoriId",
                table: "Sorular",
                column: "AltKategoriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cevaplar");

            migrationBuilder.DropTable(
                name: "Kullanıcı Rol");

            migrationBuilder.DropTable(
                name: "Mahalleler");

            migrationBuilder.DropTable(
                name: "Sorular");

            migrationBuilder.DropTable(
                name: "Kullanıcı");

            migrationBuilder.DropTable(
                name: "Roller");

            migrationBuilder.DropTable(
                name: "İlçe");

            migrationBuilder.DropTable(
                name: "Alt Kategori");

            migrationBuilder.DropTable(
                name: "İl");

            migrationBuilder.DropTable(
                name: "Kategori");

            migrationBuilder.DropTable(
                name: "Ülke");
        }
    }
}
