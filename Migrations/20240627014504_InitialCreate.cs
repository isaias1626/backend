using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agendamentoEntidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Data = table.Column<string>(type: "text", nullable: false),
                    Hora = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agendamentoEntidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContatoCorretorEntidade",
                columns: table => new
                {
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Telefone = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatoCorretorEntidade", x => x.Nome);
                });

            migrationBuilder.CreateTable(
                name: "usuarioEntidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Idade = table.Column<int>(type: "integer", nullable: false),
                    Cidade = table.Column<string>(type: "text", nullable: false),
                    Telefone = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarioEntidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "imobiliariaEntidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Preco = table.Column<int>(type: "integer", nullable: false),
                    Localizacao = table.Column<string>(type: "text", nullable: false),
                    Link_detalhes = table.Column<string>(type: "text", nullable: false),
                    Foto = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Caracteristicas = table.Column<string>(type: "text", nullable: false),
                    contatoCorretorNome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imobiliariaEntidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_imobiliariaEntidades_ContatoCorretorEntidade_contatoCorreto~",
                        column: x => x.contatoCorretorNome,
                        principalTable: "ContatoCorretorEntidade",
                        principalColumn: "Nome",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_imobiliariaEntidades_contatoCorretorNome",
                table: "imobiliariaEntidades",
                column: "contatoCorretorNome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agendamentoEntidades");

            migrationBuilder.DropTable(
                name: "imobiliariaEntidades");

            migrationBuilder.DropTable(
                name: "usuarioEntidades");

            migrationBuilder.DropTable(
                name: "ContatoCorretorEntidade");
        }
    }
}
