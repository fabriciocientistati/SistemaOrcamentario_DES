﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaOrcamentario.Context;

#nullable disable

namespace SistemaOrcamentario.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("OrcDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<DateTime>("OrcIncEm")
                        .HasColumnType("datetime");

                    b.Property<string>("OrcObservacao")
                        .HasColumnType("varchar(250)");

                    b.Property<decimal>("OrcPreco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("OrcTipoEntrega")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("OrcTipoPagamento")
                        .HasColumnType("varchar(80)");

                    b.Property<int?>("OrcamentoPessoaPesId")
                        .HasColumnType("int");

                    b.Property<int>("PesId")
                        .HasColumnType("int");

                    b.HasKey("OrcId");

                    b.HasIndex("OrcamentoPessoaPesId");

                    b.ToTable("TBORCAMENTO", (string)null);
                });

            modelBuilder.Entity("SistemaOrcamentario.Models.PessoaModel", b =>
                {
                    b.Property<int>("PesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PesId"));

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
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("PesEmail")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PesEstado")
                        .IsRequired()
                        .HasColumnType("char(2)");

                    b.Property<DateTime>("PesIncEm")
                        .HasColumnType("datetime");

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

                    b.Property<string>("UsuEmail")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("UsuIncEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("UsuLogin")
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
                        .IsUnique()
                        .HasFilter("[UsuLogin] IS NOT NULL");

                    b.ToTable("TBUSUARIO", (string)null);
                });

            modelBuilder.Entity("SistemaOrcamentario.Models.OrcamentoModel", b =>
                {
                    b.HasOne("SistemaOrcamentario.Models.PessoaModel", "OrcamentoPessoa")
                        .WithMany("Orcamentos")
                        .HasForeignKey("OrcamentoPessoaPesId");

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
