using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaRoupa.Persistency.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(maxLength: 250, nullable: false),
                    Email = table.Column<string>(maxLength: 120, nullable: false),
                    Telefone = table.Column<string>(maxLength: 11, nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    IsAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Sigla = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FormasPagamento",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormasPagamento", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StatusPedidos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusPedidos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TamanhosProduto",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TamanhosProduto", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TiposProduto",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProduto", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rua = table.Column<string>(maxLength: 200, nullable: false),
                    Numero = table.Column<string>(maxLength: 6, nullable: false),
                    Bairro = table.Column<string>(maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(maxLength: 200, nullable: false),
                    IdEstado = table.Column<int>(nullable: false),
                    CEP = table.Column<string>(maxLength: 8, nullable: false),
                    Complemento = table.Column<string>(maxLength: 200, nullable: false),
                    IdCliente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Enderecos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enderecos_Estados_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "Estados",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoID = table.Column<int>(nullable: true),
                    IdTipoProduto = table.Column<int>(nullable: false),
                    Cor = table.Column<string>(maxLength: 200, nullable: false),
                    TamanhoID = table.Column<int>(nullable: true),
                    IdTamanho = table.Column<int>(nullable: false),
                    Fabricante = table.Column<string>(maxLength: 200, nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Produtos_TamanhosProduto_TamanhoID",
                        column: x => x.TamanhoID,
                        principalTable: "TamanhosProduto",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produtos_TiposProduto_TipoID",
                        column: x => x.TipoID,
                        principalTable: "TiposProduto",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataPedido = table.Column<DateTime>(nullable: false),
                    IdCliente = table.Column<int>(nullable: false),
                    EnderecoEntregaID = table.Column<int>(nullable: true),
                    IdEnderecoEntrega = table.Column<int>(nullable: false),
                    StatusID = table.Column<int>(nullable: true),
                    IdStatusPedido = table.Column<int>(nullable: false),
                    IdFormaPagamento = table.Column<int>(nullable: false),
                    PercDesconto = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pedidos_Enderecos_EnderecoEntregaID",
                        column: x => x.EnderecoEntregaID,
                        principalTable: "Enderecos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_FormasPagamento_IdFormaPagamento",
                        column: x => x.IdFormaPagamento,
                        principalTable: "FormasPagamento",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_StatusPedidos_StatusID",
                        column: x => x.StatusID,
                        principalTable: "StatusPedidos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemPedidos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<string>(nullable: false),
                    ProdutoID = table.Column<int>(nullable: true),
                    IdProduto = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Subtotal = table.Column<decimal>(nullable: false),
                    IdPedido = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPedidos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ItemPedidos_Pedidos_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedidos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPedidos_Produtos_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "Produtos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 1, "Acre", "AC" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 27, "Tocantins", "TO" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 26, "Sergipe", "SE" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 24, "Santa Catarina", "SC" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 23, "Roraima", "RR" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 22, "Rondonia", "RO" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 21, "Rio Grande do Sul", "RS" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 20, "Rio Grande do Norte", "RN" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 19, "Rio de Janeiro", "RJ" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 18, "Piaui", "PI" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 17, "Pernanbuco", "PE" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 16, "Parana", "PR" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 15, "Paraiba", "PB" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 25, "Sao Paulo", "SP" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 13, "Minas Gerais", "MG" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 2, "Alagoas", "AL" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 3, "Amapa", "AP" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 4, "Amazonas", "AM" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 6, "Ceara", "CE" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 7, "Distrito Federal", "DF" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 5, "Bahia", "BA" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 9, "Goias", "GO" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 10, "Maranhao", "MA" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 11, "Mato Grosso", "MT" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 12, "Mato GRosso do Sul", "MS" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 8, "Espirito Santo", "ES" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "ID", "Nome", "Sigla" },
                values: new object[] { 14, "Para", "PA" });

            migrationBuilder.InsertData(
                table: "FormasPagamento",
                columns: new[] { "ID", "Nome" },
                values: new object[] { 3, "Cartao de Debito" });

            migrationBuilder.InsertData(
                table: "FormasPagamento",
                columns: new[] { "ID", "Nome" },
                values: new object[] { 1, "Boleto" });

            migrationBuilder.InsertData(
                table: "FormasPagamento",
                columns: new[] { "ID", "Nome" },
                values: new object[] { 2, "Cartao de Credito" });

            migrationBuilder.InsertData(
                table: "StatusPedidos",
                columns: new[] { "ID", "Descricao" },
                values: new object[] { 3, "PENDENTE" });

            migrationBuilder.InsertData(
                table: "StatusPedidos",
                columns: new[] { "ID", "Descricao" },
                values: new object[] { 2, "CANCELADO" });

            migrationBuilder.InsertData(
                table: "StatusPedidos",
                columns: new[] { "ID", "Descricao" },
                values: new object[] { 1, "PAGO" });

            migrationBuilder.InsertData(
                table: "TamanhosProduto",
                columns: new[] { "ID", "Nome" },
                values: new object[] { 8, "UNICO" });

            migrationBuilder.InsertData(
                table: "TamanhosProduto",
                columns: new[] { "ID", "Nome" },
                values: new object[] { 1, "PPP" });

            migrationBuilder.InsertData(
                table: "TamanhosProduto",
                columns: new[] { "ID", "Nome" },
                values: new object[] { 2, "PP" });

            migrationBuilder.InsertData(
                table: "TamanhosProduto",
                columns: new[] { "ID", "Nome" },
                values: new object[] { 3, "P" });

            migrationBuilder.InsertData(
                table: "TamanhosProduto",
                columns: new[] { "ID", "Nome" },
                values: new object[] { 4, "M" });

            migrationBuilder.InsertData(
                table: "TamanhosProduto",
                columns: new[] { "ID", "Nome" },
                values: new object[] { 5, "G" });

            migrationBuilder.InsertData(
                table: "TamanhosProduto",
                columns: new[] { "ID", "Nome" },
                values: new object[] { 6, "GG" });

            migrationBuilder.InsertData(
                table: "TamanhosProduto",
                columns: new[] { "ID", "Nome" },
                values: new object[] { 7, "GGG" });

            migrationBuilder.InsertData(
                table: "TiposProduto",
                columns: new[] { "ID", "Nome" },
                values: new object[] { 6, "Cueca" });

            migrationBuilder.InsertData(
                table: "TiposProduto",
                columns: new[] { "ID", "Nome" },
                values: new object[] { 5, "Meia" });

            migrationBuilder.InsertData(
                table: "TiposProduto",
                columns: new[] { "ID", "Nome" },
                values: new object[] { 4, "Bermuda" });

            migrationBuilder.InsertData(
                table: "TiposProduto",
                columns: new[] { "ID", "Nome" },
                values: new object[] { 7, "Jaqueta" });

            migrationBuilder.InsertData(
                table: "TiposProduto",
                columns: new[] { "ID", "Nome" },
                values: new object[] { 2, "Blusa" });

            migrationBuilder.InsertData(
                table: "TiposProduto",
                columns: new[] { "ID", "Nome" },
                values: new object[] { 1, "Calca" });

            migrationBuilder.InsertData(
                table: "TiposProduto",
                columns: new[] { "ID", "Nome" },
                values: new object[] { 3, "Camiseta" });

            migrationBuilder.InsertData(
                table: "TiposProduto",
                columns: new[] { "ID", "Nome" },
                values: new object[] { 8, "Conjunto" });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdCliente",
                table: "Enderecos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdEstado",
                table: "Enderecos",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedidos_IdPedido",
                table: "ItemPedidos",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedidos_ProdutoID",
                table: "ItemPedidos",
                column: "ProdutoID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_EnderecoEntregaID",
                table: "Pedidos",
                column: "EnderecoEntregaID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdCliente",
                table: "Pedidos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdFormaPagamento",
                table: "Pedidos",
                column: "IdFormaPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_StatusID",
                table: "Pedidos",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_TamanhoID",
                table: "Produtos",
                column: "TamanhoID");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_TipoID",
                table: "Produtos",
                column: "TipoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPedidos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "FormasPagamento");

            migrationBuilder.DropTable(
                name: "StatusPedidos");

            migrationBuilder.DropTable(
                name: "TamanhosProduto");

            migrationBuilder.DropTable(
                name: "TiposProduto");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
