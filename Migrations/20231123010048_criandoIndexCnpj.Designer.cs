﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaOrcamentario.Context;

#nullable disable

namespace SistemaOrcamentario.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231123010048_criandoIndexCnpj")]
    partial class criandoIndexCnpj
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemaOrcamentario.Models.OrcamentoModel", b =>
                {
                    b.Property<int>("OrcId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrcId"));

                    b.Property<DateTime?>("OrcAltEm")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OrcAltPor")
                        .HasColumnType("int");

                    b.Property<string>("OrcDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<DateTime>("OrcIncEm")
                        .HasColumnType("datetime");

                    b.Property<int>("OrcIncPor")
                        .HasColumnType("int");

                    b.Property<string>("OrcObservacao")
                        .HasColumnType("varchar(250)");

                    b.Property<decimal>("OrcPreco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("OrcTipoEntrega")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("OrcTipoPagamento")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<int>("PesId")
                        .HasColumnType("int");

                    b.HasKey("OrcId");

                    b.HasIndex("PesId");

                    b.ToTable("TBORCAMENTO", (string)null);
                });

            modelBuilder.Entity("SistemaOrcamentario.Models.PessoaModel", b =>
                {
                    b.Property<int>("PesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PesId"));

                    b.Property<DateTime?>("PesAltEm")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PesAltPor")
                        .HasColumnType("int");

                    b.Property<string>("PesBairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PesCep")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("PesCidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PesCnpj")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("PesCpf")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("PesEmail")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PesEstado")
                        .IsRequired()
                        .HasColumnType("char(2)");

                    b.Property<DateTime>("PesIncEm")
                        .HasColumnType("datetime");

                    b.Property<int>("PesIncPor")
                        .HasColumnType("int");

                    b.Property<string>("PesNome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("PesNumCelular")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("PesNumTelefone")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("PesNumero")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("PesRua")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("PesId");

                    b.HasIndex("PesCnpj")
                        .IsUnique()
                        .HasFilter("[PesCnpj] IS NOT NULL");

                    b.HasIndex("PesCpf")
                        .IsUnique()
                        .HasFilter("[PesCpf] IS NOT NULL");

                    b.ToTable("TBPESSOA", (string)null);
                });

            modelBuilder.Entity("SistemaOrcamentario.Models.UsuarioModel", b =>
                {
                    b.Property<int>("UsuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuId"));

                    b.Property<DateTime?>("UsuAltEm")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UsuAltPor")
                        .HasColumnType("int");

                    b.Property<string>("UsuEmail")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("UsuIncEm")
                        .HasColumnType("datetime2");

                    b.Property<int>("UsuIncPor")
                        .HasColumnType("int");

                    b.Property<string>("UsuLogin")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsuNome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<int>("UsuPerfil")
                        .HasColumnType("int");

                    b.Property<string>("UsuSenha")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.HasKey("UsuId");

                    b.HasIndex("UsuLogin")
                        .IsUnique();

                    b.ToTable("TBUSUARIO", (string)null);
                });

            modelBuilder.Entity("SistemaOrcamentario.Models.OrcamentoModel", b =>
                {
                    b.HasOne("SistemaOrcamentario.Models.PessoaModel", "OrcamentoPessoa")
                        .WithMany("Orcamentos")
                        .HasForeignKey("PesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrcamentoPessoa");
                });

            modelBuilder.Entity("SistemaOrcamentario.Models.PessoaModel", b =>
                {
                    b.Navigation("Orcamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
