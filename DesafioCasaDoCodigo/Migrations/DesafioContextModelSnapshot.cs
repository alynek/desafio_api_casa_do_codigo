﻿// <auto-generated />
using System;
using DesafioCasaDoCodigo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DesafioCasaDoCodigo.Migrations
{
    [DbContext(typeof(DesafioContext))]
    partial class DesafioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DesafioCasaDoCodigo.Models.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime");

                    b.Property<string>("LinkGithub")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("DesafioCasaDoCodigo.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("DesafioCasaDoCodigo.Models.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Complemento")
                        .HasColumnType("text");

                    b.Property<int?>("CupomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime");

                    b.Property<string>("Documento")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Endereco")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CupomId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("DesafioCasaDoCodigo.Models.Cupom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Desconto")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("Expiracao")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Cupons");
                });

            modelBuilder.Entity("DesafioCasaDoCodigo.Models.ItemCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CompraId")
                        .HasColumnType("int");

                    b.Property<int>("LivroId")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .HasColumnType("text");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("CompraId");

                    b.HasIndex("LivroId");

                    b.ToTable("Itens");
                });

            modelBuilder.Entity("DesafioCasaDoCodigo.Models.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.Property<string>("LinkCapaLivro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumeroPaginas")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Subtitulo")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Sumario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("Isbn")
                        .IsUnique();

                    b.HasIndex("Titulo")
                        .IsUnique();

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("DesafioCasaDoCodigo.Models.PagamentoPaypal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CompraId")
                        .HasColumnType("int");

                    b.Property<string>("IdTransacao")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompraId")
                        .IsUnique();

                    b.HasIndex("IdTransacao")
                        .IsUnique();

                    b.ToTable("PagamentosPaypal");
                });

            modelBuilder.Entity("DesafioCasaDoCodigo.Models.Compra", b =>
                {
                    b.HasOne("DesafioCasaDoCodigo.Models.Cupom", "Cupom")
                        .WithMany("Compras")
                        .HasForeignKey("CupomId");
                });

            modelBuilder.Entity("DesafioCasaDoCodigo.Models.ItemCompra", b =>
                {
                    b.HasOne("DesafioCasaDoCodigo.Models.Compra", "Compra")
                        .WithMany()
                        .HasForeignKey("CompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesafioCasaDoCodigo.Models.Livro", "Livro")
                        .WithMany("Itens")
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DesafioCasaDoCodigo.Models.Livro", b =>
                {
                    b.HasOne("DesafioCasaDoCodigo.Models.Autor", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DesafioCasaDoCodigo.Models.PagamentoPaypal", b =>
                {
                    b.HasOne("DesafioCasaDoCodigo.Models.Compra", "Compra")
                        .WithOne("PagamentoPaypal")
                        .HasForeignKey("DesafioCasaDoCodigo.Models.PagamentoPaypal", "CompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
