using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTT_API.Migrations
{
    /// <inheritdoc />
    public partial class AttCampos1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Img_Foto",
                table: "Estabelecimento",
                type: "IMAGE",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "VARBINARY(MAX)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Img_Foto",
                table: "Estabelecimento",
                type: "VARBINARY(MAX)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "IMAGE");
        }
    }
}
