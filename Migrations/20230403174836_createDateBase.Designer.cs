﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaOrcamentario.Context;

namespace SistemaOrcamentario.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230403174836_createDateBase")]
    partial class createDateBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SistemaOrcamentario.Models.OrcamentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Observacoes")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("PessoaID")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasColumnType("numeric(38,2)");

                    b.Property<string>("TipoEntrega")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TipoPagamento")
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("PessoaID");

                    b.ToTable("Orcamento");
                });

            modelBuilder.Entity("SistemaOrcamentario.Models.PessoaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Cep")
                        .HasColumnType("numeric(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Cnpj")
                        .HasColumnType("numeric(14)");

                    b.Property<decimal>("Cpf")
                        .HasColumnType("numeric(11)");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<decimal>("NumberCellPhone")
                        .HasColumnType("numeric(11)");

                    b.Property<decimal>("NumberFixPhone")
                        .HasColumnType("numeric(10)");

                    b.Property<decimal>("Numero")
                        .HasColumnType("numeric(5)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("SistemaOrcamentario.Models.OrcamentoModel", b =>
                {
                    b.HasOne("SistemaOrcamentario.Models.PessoaModel", "Pessoa")
                        .WithMany("Orcamentos")
                        .HasForeignKey("PessoaID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("SistemaOrcamentario.Models.PessoaModel", b =>
                {
                    b.Navigation("Orcamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
