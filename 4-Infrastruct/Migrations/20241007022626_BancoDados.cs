using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RendaFixa.Infrastruct.Migrations
{
    /// <inheritdoc />
    public partial class BancoDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    data_nascimento = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "produto_renda_fixa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(200)", nullable: true),
                    indexador = table.Column<string>(type: "varchar(100)", nullable: true),
                    preco_unitario = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    taxa = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    estoque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto_renda_fixa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "conta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cliente_fk = table.Column<int>(type: "int", nullable: false),
                    codigo = table.Column<int>(type: "int", nullable: false),
                    saldo = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_conta_cliente_cliente_fk",
                        column: x => x.cliente_fk,
                        principalTable: "cliente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "aporte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    renda_fixa_fk = table.Column<int>(type: "int", nullable: false),
                    conta_fk = table.Column<int>(type: "int", nullable: false),
                    data_operacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    quantidade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aporte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_aporte_conta_conta_fk",
                        column: x => x.conta_fk,
                        principalTable: "conta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_aporte_produto_renda_fixa_renda_fixa_fk",
                        column: x => x.renda_fixa_fk,
                        principalTable: "produto_renda_fixa",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "cliente",
                columns: new[] { "Id", "cpf", "data_nascimento", "nome" },
                values: new object[] { 1, "12345678901", new DateTime(1995, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "João Silva" });

            migrationBuilder.InsertData(
                table: "produto_renda_fixa",
                columns: new[] { "Id", "estoque", "indexador", "nome", "preco_unitario", "taxa" },
                values: new object[,]
                {
                    { 1, 100, "Selic", "Tesouro Direto", 100.0000m, 5.0000m },
                    { 2, 50, "CDI", "CDBs", 55.0000m, 3.0000m },
                    { 3, 200, "IPCA", "Debêntures", 25.0000m, 4.0000m },
                    { 4, 150, "IGPM", "Fundos de Renda Fixa", 30.0000m, 6.0000m },
                    { 5, 75, "IPCA", "LCIs", 70.0000m, 5.0000m },
                    { 6, 60, "CDI", "LCAs", 45.0000m, 3.0000m },
                    { 7, 30, "IGPM", "CRIs", 60.0000m, 4.0000m },
                    { 8, 40, "Selic", "CRAs", 80.0000m, 6.0000m },
                    { 9, 20, "CDI", "Carteiras digitais remuneradas", 50.0000m, 3.0000m },
                    { 10, 10, "IPCA", "Letra de Câmbio (LC)", 90.0000m, 5.0000m }
                });

            migrationBuilder.InsertData(
                table: "conta",
                columns: new[] { "Id", "cliente_fk", "codigo", "saldo" },
                values: new object[] { 1, 1, 1001, 5000.00m });

            migrationBuilder.CreateIndex(
                name: "IX_aporte_conta_fk",
                table: "aporte",
                column: "conta_fk");

            migrationBuilder.CreateIndex(
                name: "IX_aporte_renda_fixa_fk",
                table: "aporte",
                column: "renda_fixa_fk");

            migrationBuilder.CreateIndex(
                name: "IX_conta_cliente_fk",
                table: "conta",
                column: "cliente_fk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aporte");

            migrationBuilder.DropTable(
                name: "conta");

            migrationBuilder.DropTable(
                name: "produto_renda_fixa");

            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
