using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class genderchangedinkKullanici : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cinsiyet",
                table: "Kullanıcı",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Cinsiyet",
                table: "Kullanıcı",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);
        }
    }
}
