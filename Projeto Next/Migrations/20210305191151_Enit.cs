﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Next.Migrations
{
    public partial class Enit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnderecoComercial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(nullable: true),
                    Logradouro = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoComercial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoResidencial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(nullable: true),
                    Logradouro = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoResidencial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DadosPessoais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    EnderecosComercialId = table.Column<int>(nullable: false),
                    EnderecosResidencialId = table.Column<int>(nullable: false),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosPessoais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DadosPessoais_EnderecoComercial_EnderecosComercialId",
                        column: x => x.EnderecosComercialId,
                        principalTable: "EnderecoComercial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DadosPessoais_EnderecoResidencial_EnderecosResidencialId",
                        column: x => x.EnderecosResidencialId,
                        principalTable: "EnderecoResidencial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DadosPessoais_EnderecosComercialId",
                table: "DadosPessoais",
                column: "EnderecosComercialId");

            migrationBuilder.CreateIndex(
                name: "IX_DadosPessoais_EnderecosResidencialId",
                table: "DadosPessoais",
                column: "EnderecosResidencialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosPessoais");

            migrationBuilder.DropTable(
                name: "EnderecoComercial");

            migrationBuilder.DropTable(
                name: "EnderecoResidencial");
        }
    }
}
