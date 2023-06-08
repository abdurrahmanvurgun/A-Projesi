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
                    KategoriAdi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
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
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Sifre2 = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Cinsiyet = table.Column<bool>(type: "bit", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    ProfilResmiDosyaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "AltKategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AltKategoriAdi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AltKategoriler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AltKategoriler_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciRoller",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false),
                    KullaniciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciRoller", x => x.RolId);
                    table.ForeignKey(
                        name: "FK_KullaniciRoller_Kullanıcı_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanıcı",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullaniciRoller_Roller_RolId",
                        column: x => x.RolId,
                        principalTable: "Roller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AltKategoriler_KategoriId",
                table: "AltKategoriler",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciRoller_KullaniciId",
                table: "KullaniciRoller",
                column: "KullaniciId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AltKategoriler");

            migrationBuilder.DropTable(
                name: "KullaniciRoller");

            migrationBuilder.DropTable(
                name: "Kategori");

            migrationBuilder.DropTable(
                name: "Kullanıcı");

            migrationBuilder.DropTable(
                name: "Roller");
        }
    }
}
