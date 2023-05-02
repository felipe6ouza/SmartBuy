using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCompra.API.Migrations
{
    /// <inheritdoc />
    public partial class AjustesCompraTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Compras_SolicitacaoCompraId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Produto_ProdutoId",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("12c00b0c-03ee-4a26-a39f-fe4d3602cb88"));

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "ItensCompra");

            migrationBuilder.RenameIndex(
                name: "IX_Item_SolicitacaoCompraId",
                table: "ItensCompra",
                newName: "IX_ItensCompra_SolicitacaoCompraId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_ProdutoId",
                table: "ItensCompra",
                newName: "IX_ItensCompra_ProdutoId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produto",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItensCompra",
                table: "ItensCompra",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "Preco", "Situacao" },
                values: new object[] { new Guid("897d2297-65d7-41c9-8ddb-a34645d3568a"), 1, "Descricao01", "Produto01", 100m, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_ItensCompra_Compras_SolicitacaoCompraId",
                table: "ItensCompra",
                column: "SolicitacaoCompraId",
                principalTable: "Compras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensCompra_Produto_ProdutoId",
                table: "ItensCompra",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensCompra_Compras_SolicitacaoCompraId",
                table: "ItensCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensCompra_Produto_ProdutoId",
                table: "ItensCompra");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItensCompra",
                table: "ItensCompra");

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("897d2297-65d7-41c9-8ddb-a34645d3568a"));

            migrationBuilder.RenameTable(
                name: "ItensCompra",
                newName: "Item");

            migrationBuilder.RenameIndex(
                name: "IX_ItensCompra_SolicitacaoCompraId",
                table: "Item",
                newName: "IX_Item_SolicitacaoCompraId");

            migrationBuilder.RenameIndex(
                name: "IX_ItensCompra_ProdutoId",
                table: "Item",
                newName: "IX_Item_ProdutoId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produto",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "Preco", "Situacao" },
                values: new object[] { new Guid("12c00b0c-03ee-4a26-a39f-fe4d3602cb88"), 1, "Descricao01", "Produto01", 100m, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Compras_SolicitacaoCompraId",
                table: "Item",
                column: "SolicitacaoCompraId",
                principalTable: "Compras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Produto_ProdutoId",
                table: "Item",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id");
        }
    }
}
