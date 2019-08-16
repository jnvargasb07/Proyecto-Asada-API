﻿// <auto-generated />
using System;
using API_Asada.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API_Asada.Migrations
{
    [DbContext(typeof(AsadaContext))]
    [Migration("20190816054050_DB_Migrations")]
    partial class DB_Migrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("API_Asada.Models.Aforo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("fecha");

                    b.Property<double>("litros");

                    b.Property<DateTime>("tiempo");

                    b.HasKey("Id");

                    b.ToTable("Aforo");
                });

            modelBuilder.Entity("API_Asada.Models.Agua_No_Contabilizada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("fecha");

                    b.Property<double>("lectura_actual");

                    b.Property<double>("lectura_anterior");

                    b.Property<string>("sector")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("Agua_No_Contabilizada");
                });

            modelBuilder.Entity("API_Asada.Models.Asada_Queja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("descripcion")
                        .HasColumnType("text");

                    b.Property<DateTime>("fecha");

                    b.Property<string>("numero_casa");

                    b.HasKey("Id");

                    b.ToTable("Asada_Queja");
                });

            modelBuilder.Entity("API_Asada.Models.Averia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Id_queja");

                    b.Property<double>("costo_mano_obra");

                    b.Property<DateTime>("fecha");

                    b.Property<DateTime>("fecha_trabajo");

                    b.Property<int>("numero_averia");

                    b.Property<string>("numero_casa")
                        .HasMaxLength(10);

                    b.Property<string>("numero_medidor")
                        .HasMaxLength(150);

                    b.Property<string>("observaciones")
                        .HasColumnType("text");

                    b.Property<string>("responsable")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("Id_queja");

                    b.ToTable("Averia");
                });

            modelBuilder.Entity("API_Asada.Models.Cheque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Id_cuenta");

                    b.Property<string>("concepto")
                        .HasColumnType("text");

                    b.Property<string>("cuenta_contable")
                        .HasMaxLength(250);

                    b.Property<DateTime>("fecha");

                    b.Property<double>("monto");

                    b.Property<string>("numero_cheque")
                        .HasMaxLength(100);

                    b.Property<string>("numero_cuenta")
                        .HasMaxLength(200);

                    b.Property<string>("portador")
                        .HasMaxLength(50);

                    b.Property<bool>("tipo");

                    b.HasKey("Id");

                    b.HasIndex("Id_cuenta");

                    b.ToTable("Cheque");
                });

            modelBuilder.Entity("API_Asada.Models.Cloracion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("fecha");

                    b.Property<DateTime>("hora");

                    b.Property<double>("ppm");

                    b.Property<char>("sector");

                    b.HasKey("Id");

                    b.ToTable("Cloracion");
                });

            modelBuilder.Entity("API_Asada.Models.Compra_Inventario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Id_articulo");

                    b.Property<int>("Id_compra");

                    b.Property<int>("cantidad");

                    b.Property<DateTime>("fecha");

                    b.HasKey("Id");

                    b.HasIndex("Id_articulo");

                    b.HasIndex("Id_compra");

                    b.ToTable("Compra_Inventario");
                });

            modelBuilder.Entity("API_Asada.Models.Cuenta_Bancaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("numero_cuenta")
                        .HasMaxLength(200);

                    b.Property<string>("tipo_banco")
                        .HasMaxLength(3);

                    b.HasKey("Id");

                    b.ToTable("Cuenta_Bancaria");
                });

            modelBuilder.Entity("API_Asada.Models.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("destino");

                    b.Property<double>("monto");

                    b.Property<string>("numero_factura")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("API_Asada.Models.Factura_Cheque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Id_cheque");

                    b.Property<int>("Id_factura");

                    b.HasKey("Id");

                    b.HasIndex("Id_cheque");

                    b.HasIndex("Id_factura");

                    b.ToTable("Factura_Cheque");
                });

            modelBuilder.Entity("API_Asada.Models.Inventario_Averia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Id_articulo");

                    b.Property<int>("Id_averia");

                    b.Property<int>("cantidad");

                    b.HasKey("Id");

                    b.HasIndex("Id_articulo");

                    b.HasIndex("Id_averia");

                    b.ToTable("Inventario_Averia");
                });

            modelBuilder.Entity("API_Asada.Models.Inventario_Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("cantidad");

                    b.Property<string>("codigo_articulo")
                        .HasMaxLength(50);

                    b.Property<string>("nombre_articulo")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Inventario_Stock");
                });

            modelBuilder.Entity("API_Asada.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("material")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("API_Asada.Models.Prestamo_Inventario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Id_articulo");

                    b.Property<int>("Id_salida");

                    b.Property<bool>("estado");

                    b.Property<DateTime>("fecha_devolucion");

                    b.Property<DateTime>("fecha_prestamo");

                    b.Property<string>("responsable")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("Id_articulo");

                    b.HasIndex("Id_salida");

                    b.ToTable("Prestamo_Inventario");
                });

            modelBuilder.Entity("API_Asada.Models.Reciclaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Fk_material");

                    b.Property<int>("cantidad");

                    b.Property<DateTime>("fecha");

                    b.Property<int>("numero_boleta");

                    b.Property<double>("precio_kilo");

                    b.HasKey("Id");

                    b.HasIndex("Fk_material");

                    b.ToTable("Reciclaje");
                });

            modelBuilder.Entity("API_Asada.Models.Registro_Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("fecha");

                    b.Property<string>("numero_factura")
                        .HasMaxLength(50);

                    b.Property<string>("provedor")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Registro_Compra");
                });

            modelBuilder.Entity("API_Asada.Models.Registro_Salida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("fecha");

                    b.Property<string>("motivo")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Registro_Salida");
                });

            modelBuilder.Entity("API_Asada.Models.Salida_Inventario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Id_articulo");

                    b.Property<int>("Id_salida");

                    b.Property<int>("cantidad");

                    b.Property<DateTime>("fecha");

                    b.Property<char>("tipo");

                    b.HasKey("Id");

                    b.HasIndex("Id_articulo");

                    b.HasIndex("Id_salida");

                    b.ToTable("Salida_Inventario");
                });

            modelBuilder.Entity("API_Asada.Models.users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("first_name");

                    b.Property<string>("last_name");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("API_Asada.Models.Averia", b =>
                {
                    b.HasOne("API_Asada.Models.Asada_Queja", "Asada_Queja")
                        .WithMany()
                        .HasForeignKey("Id_queja")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API_Asada.Models.Cheque", b =>
                {
                    b.HasOne("API_Asada.Models.Cuenta_Bancaria", "Cuenta_Bancaria")
                        .WithMany()
                        .HasForeignKey("Id_cuenta")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API_Asada.Models.Compra_Inventario", b =>
                {
                    b.HasOne("API_Asada.Models.Inventario_Stock", "Inventario_Stock")
                        .WithMany()
                        .HasForeignKey("Id_articulo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API_Asada.Models.Registro_Compra", "Registro_Compra")
                        .WithMany()
                        .HasForeignKey("Id_compra")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API_Asada.Models.Factura_Cheque", b =>
                {
                    b.HasOne("API_Asada.Models.Cheque", "Cheque")
                        .WithMany()
                        .HasForeignKey("Id_cheque")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API_Asada.Models.Factura", "Factura")
                        .WithMany()
                        .HasForeignKey("Id_factura")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API_Asada.Models.Inventario_Averia", b =>
                {
                    b.HasOne("API_Asada.Models.Inventario_Stock", "Inventario_Stock")
                        .WithMany()
                        .HasForeignKey("Id_articulo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API_Asada.Models.Averia", "Averia")
                        .WithMany()
                        .HasForeignKey("Id_averia")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API_Asada.Models.Prestamo_Inventario", b =>
                {
                    b.HasOne("API_Asada.Models.Inventario_Stock", "Inventario_Stock")
                        .WithMany()
                        .HasForeignKey("Id_articulo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API_Asada.Models.Registro_Salida", "Registro_Salida")
                        .WithMany()
                        .HasForeignKey("Id_salida")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API_Asada.Models.Reciclaje", b =>
                {
                    b.HasOne("API_Asada.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("Fk_material")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API_Asada.Models.Salida_Inventario", b =>
                {
                    b.HasOne("API_Asada.Models.Inventario_Stock", "Inventario_Stock")
                        .WithMany()
                        .HasForeignKey("Id_articulo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API_Asada.Models.Registro_Salida", "Registro_Salida")
                        .WithMany()
                        .HasForeignKey("Id_salida")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
