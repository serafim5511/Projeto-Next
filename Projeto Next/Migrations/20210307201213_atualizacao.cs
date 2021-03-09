using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Next.Migrations
{
    public partial class atualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DadosPessoais_EnderecoComercial_EnderecosComercialId",
                table: "DadosPessoais");

            migrationBuilder.DropTable(
                name: "EnderecoComercial");

            migrationBuilder.DropIndex(
                name: "IX_DadosPessoais_EnderecosComercialId",
                table: "DadosPessoais");

            migrationBuilder.DropColumn(
                name: "EnderecosComercialId",
                table: "DadosPessoais");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnderecosComercialId",
                table: "DadosPessoais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EnderecoComercial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoComercial", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DadosPessoais_EnderecosComercialId",
                table: "DadosPessoais",
                column: "EnderecosComercialId");

            migrationBuilder.AddForeignKey(
                name: "FK_DadosPessoais_EnderecoComercial_EnderecosComercialId",
                table: "DadosPessoais",
                column: "EnderecosComercialId",
                principalTable: "EnderecoComercial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
