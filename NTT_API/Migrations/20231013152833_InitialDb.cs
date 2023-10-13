using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTT_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estabelecimento",
                columns: table => new
                {
                    ID_Tarefa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Tarefa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Localidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Img_Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Nome_foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao_foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dt_Cadastro_Tarefa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefone_Tarefa = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estabelecimento", x => x.ID_Tarefa);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estabelecimento");
        }
    }
}
