﻿// <auto-generated />
using System;
using LojaRoupa.Persistency;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LojaRoupa.Persistency.Migrations
{
    [DbContext(typeof(LojaDbContext))]
    partial class LojaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("LojaRoupa.Core.Cliente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(11);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(120);

                    b.Property<bool>("IsAtivo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(250);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(11);

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("LojaRoupa.Core.Endereco", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(8);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<int>("IdCliente")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdEstado")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(6);

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.HasKey("ID");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEstado");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("LojaRoupa.Core.Estado", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(2);

                    b.HasKey("ID");

                    b.ToTable("Estados");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Nome = "Acre",
                            Sigla = "AC"
                        },
                        new
                        {
                            ID = 2,
                            Nome = "Alagoas",
                            Sigla = "AL"
                        },
                        new
                        {
                            ID = 3,
                            Nome = "Amapa",
                            Sigla = "AP"
                        },
                        new
                        {
                            ID = 4,
                            Nome = "Amazonas",
                            Sigla = "AM"
                        },
                        new
                        {
                            ID = 5,
                            Nome = "Bahia",
                            Sigla = "BA"
                        },
                        new
                        {
                            ID = 6,
                            Nome = "Ceara",
                            Sigla = "CE"
                        },
                        new
                        {
                            ID = 7,
                            Nome = "Distrito Federal",
                            Sigla = "DF"
                        },
                        new
                        {
                            ID = 8,
                            Nome = "Espirito Santo",
                            Sigla = "ES"
                        },
                        new
                        {
                            ID = 9,
                            Nome = "Goias",
                            Sigla = "GO"
                        },
                        new
                        {
                            ID = 10,
                            Nome = "Maranhao",
                            Sigla = "MA"
                        },
                        new
                        {
                            ID = 11,
                            Nome = "Mato Grosso",
                            Sigla = "MT"
                        },
                        new
                        {
                            ID = 12,
                            Nome = "Mato GRosso do Sul",
                            Sigla = "MS"
                        },
                        new
                        {
                            ID = 13,
                            Nome = "Minas Gerais",
                            Sigla = "MG"
                        },
                        new
                        {
                            ID = 14,
                            Nome = "Para",
                            Sigla = "PA"
                        },
                        new
                        {
                            ID = 15,
                            Nome = "Paraiba",
                            Sigla = "PB"
                        },
                        new
                        {
                            ID = 16,
                            Nome = "Parana",
                            Sigla = "PR"
                        },
                        new
                        {
                            ID = 17,
                            Nome = "Pernanbuco",
                            Sigla = "PE"
                        },
                        new
                        {
                            ID = 18,
                            Nome = "Piaui",
                            Sigla = "PI"
                        },
                        new
                        {
                            ID = 19,
                            Nome = "Rio de Janeiro",
                            Sigla = "RJ"
                        },
                        new
                        {
                            ID = 20,
                            Nome = "Rio Grande do Norte",
                            Sigla = "RN"
                        },
                        new
                        {
                            ID = 21,
                            Nome = "Rio Grande do Sul",
                            Sigla = "RS"
                        },
                        new
                        {
                            ID = 22,
                            Nome = "Rondonia",
                            Sigla = "RO"
                        },
                        new
                        {
                            ID = 23,
                            Nome = "Roraima",
                            Sigla = "RR"
                        },
                        new
                        {
                            ID = 24,
                            Nome = "Santa Catarina",
                            Sigla = "SC"
                        },
                        new
                        {
                            ID = 25,
                            Nome = "Sao Paulo",
                            Sigla = "SP"
                        },
                        new
                        {
                            ID = 26,
                            Nome = "Sergipe",
                            Sigla = "SE"
                        },
                        new
                        {
                            ID = 27,
                            Nome = "Tocantins",
                            Sigla = "TO"
                        });
                });

            modelBuilder.Entity("LojaRoupa.Core.FormaPagamento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.HasKey("ID");

                    b.ToTable("FormasPagamento");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Nome = "Boleto"
                        },
                        new
                        {
                            ID = 2,
                            Nome = "Cartao de Credito"
                        },
                        new
                        {
                            ID = 3,
                            Nome = "Cartao de Debito"
                        });
                });

            modelBuilder.Entity("LojaRoupa.Core.ItemPedido", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdPedido")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProduto")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProdutoID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("IdPedido");

                    b.HasIndex("ProdutoID");

                    b.ToTable("ItemPedidos");
                });

            modelBuilder.Entity("LojaRoupa.Core.Pedido", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EnderecoEntregaID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdCliente")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdEnderecoEntrega")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdFormaPagamento")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdStatusPedido")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PercDesconto")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StatusID")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("EnderecoEntregaID");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdFormaPagamento");

                    b.HasIndex("StatusID");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("LojaRoupa.Core.Produto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<string>("Fabricante")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<int>("IdTamanho")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdTipoProduto")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TamanhoID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TipoID")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Valor")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("TamanhoID");

                    b.HasIndex("TipoID");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("LojaRoupa.Core.StatusPedido", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.HasKey("ID");

                    b.ToTable("StatusPedidos");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Descricao = "PAGO"
                        },
                        new
                        {
                            ID = 2,
                            Descricao = "CANCELADO"
                        },
                        new
                        {
                            ID = 3,
                            Descricao = "PENDENTE"
                        });
                });

            modelBuilder.Entity("LojaRoupa.Core.Tamanho", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.HasKey("ID");

                    b.ToTable("TamanhosProduto");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Nome = "PPP"
                        },
                        new
                        {
                            ID = 2,
                            Nome = "PP"
                        },
                        new
                        {
                            ID = 3,
                            Nome = "P"
                        },
                        new
                        {
                            ID = 4,
                            Nome = "M"
                        },
                        new
                        {
                            ID = 5,
                            Nome = "G"
                        },
                        new
                        {
                            ID = 6,
                            Nome = "GG"
                        },
                        new
                        {
                            ID = 7,
                            Nome = "GGG"
                        },
                        new
                        {
                            ID = 8,
                            Nome = "UNICO"
                        });
                });

            modelBuilder.Entity("LojaRoupa.Core.TipoProduto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.HasKey("ID");

                    b.ToTable("TiposProduto");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Nome = "Calca"
                        },
                        new
                        {
                            ID = 2,
                            Nome = "Blusa"
                        },
                        new
                        {
                            ID = 3,
                            Nome = "Camiseta"
                        },
                        new
                        {
                            ID = 4,
                            Nome = "Bermuda"
                        },
                        new
                        {
                            ID = 5,
                            Nome = "Meia"
                        },
                        new
                        {
                            ID = 6,
                            Nome = "Cueca"
                        },
                        new
                        {
                            ID = 7,
                            Nome = "Jaqueta"
                        },
                        new
                        {
                            ID = 8,
                            Nome = "Conjunto"
                        });
                });

            modelBuilder.Entity("LojaRoupa.Core.Endereco", b =>
                {
                    b.HasOne("LojaRoupa.Core.Cliente", "Cliente")
                        .WithMany("Enderecos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LojaRoupa.Core.Estado", "Estado")
                        .WithMany("Enderecos")
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LojaRoupa.Core.ItemPedido", b =>
                {
                    b.HasOne("LojaRoupa.Core.Pedido", "pedido")
                        .WithMany("Items")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LojaRoupa.Core.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoID");
                });

            modelBuilder.Entity("LojaRoupa.Core.Pedido", b =>
                {
                    b.HasOne("LojaRoupa.Core.Endereco", "EnderecoEntrega")
                        .WithMany()
                        .HasForeignKey("EnderecoEntregaID");

                    b.HasOne("LojaRoupa.Core.Cliente", "cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LojaRoupa.Core.FormaPagamento", "formaPagamento")
                        .WithMany("pedidos")
                        .HasForeignKey("IdFormaPagamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LojaRoupa.Core.StatusPedido", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID");
                });

            modelBuilder.Entity("LojaRoupa.Core.Produto", b =>
                {
                    b.HasOne("LojaRoupa.Core.Tamanho", "Tamanho")
                        .WithMany()
                        .HasForeignKey("TamanhoID");

                    b.HasOne("LojaRoupa.Core.TipoProduto", "Tipo")
                        .WithMany()
                        .HasForeignKey("TipoID");
                });
#pragma warning restore 612, 618
        }
    }
}
