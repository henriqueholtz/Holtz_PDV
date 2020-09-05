﻿// <auto-generated />
using System;
using Holtz_PDV.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Holtz_PDV.Migrations
{
    [DbContext(typeof(Holtz_PDVContext))]
    partial class Holtz_PDVContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Holtz_PDV.Models.Cidade", b =>
                {
                    b.Property<int>("CidCod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasMaxLength(8);

                    b.Property<int?>("CidIBGE")
                        .HasColumnType("int")
                        .HasMaxLength(8);

                    b.Property<string>("CidNom")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("EstCod")
                        .HasColumnType("int")
                        .HasMaxLength(8);

                    b.Property<int?>("EstadoEstCod")
                        .HasColumnType("int");

                    b.HasKey("CidCod");

                    b.HasIndex("EstadoEstCod");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("Holtz_PDV.Models.Cliente", b =>
                {
                    b.Property<int>("CliCod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasMaxLength(8);

                    b.Property<int?>("CidCod")
                        .HasColumnType("int")
                        .HasMaxLength(8);

                    b.Property<int?>("CidadeCidCod")
                        .HasColumnType("int");

                    b.Property<string>("CliBai")
                        .HasColumnType("VARCHAR(130)");

                    b.Property<string>("CliCpfCnpj")
                        .HasColumnType("VARCHAR(18)");

                    b.Property<string>("CliNomFan")
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("CliRaz")
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("CliRua")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<sbyte?>("CliSts")
                        .HasColumnType("TINYINT");

                    b.HasKey("CliCod");

                    b.HasIndex("CidadeCidCod");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Holtz_PDV.Models.Estado", b =>
                {
                    b.Property<int>("EstCod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasMaxLength(8);

                    b.Property<string>("EstNom")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("EstUf")
                        .IsRequired()
                        .HasColumnType("VARCHAR(2)");

                    b.HasKey("EstCod");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("Holtz_PDV.Models.Produto", b =>
                {
                    b.Property<int>("ProCod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasMaxLength(8);

                    b.Property<string>("ProNom")
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("ProObs")
                        .HasColumnType("VARCHAR(1000)");

                    b.Property<sbyte?>("ProSts")
                        .HasColumnType("TINYINT");

                    b.Property<decimal>("ProVlrCus")
                        .HasColumnType("DECIMAL(17,2)");

                    b.Property<decimal>("ProVlrVen")
                        .HasColumnType("DECIMAL(17,2)");

                    b.HasKey("ProCod");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Holtz_PDV.Models.Cidade", b =>
                {
                    b.HasOne("Holtz_PDV.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoEstCod");
                });

            modelBuilder.Entity("Holtz_PDV.Models.Cliente", b =>
                {
                    b.HasOne("Holtz_PDV.Models.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeCidCod");
                });
#pragma warning restore 612, 618
        }
    }
}
