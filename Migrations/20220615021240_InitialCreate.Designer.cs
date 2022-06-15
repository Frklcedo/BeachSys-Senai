﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeachSys.Migrations
{
    [DbContext(typeof(BeachSysContext))]
    [Migration("20220615021240_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BeachSys.Models.Armario", b =>
                {
                    b.Property<int>("ArmarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("X")
                        .HasColumnType("double");

                    b.Property<double>("Y")
                        .HasColumnType("double");

                    b.HasKey("ArmarioId");

                    b.ToTable("Armario");
                });

            modelBuilder.Entity("BeachSys.Models.Compartimento", b =>
                {
                    b.Property<int>("CompartimentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Altura")
                        .HasColumnType("double");

                    b.Property<int>("ArmarioId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDisponivel")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("Largura")
                        .HasColumnType("double");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("numero")
                        .HasColumnType("int");

                    b.HasKey("CompartimentoId");

                    b.HasIndex("ArmarioId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Compartimento");
                });

            modelBuilder.Entity("BeachSys.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsRoot")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("BeachSys.Models.Compartimento", b =>
                {
                    b.HasOne("BeachSys.Models.Armario", "Armario")
                        .WithMany("Compartimentos")
                        .HasForeignKey("ArmarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeachSys.Models.Usuario", "Usuario")
                        .WithOne("Compartimento")
                        .HasForeignKey("BeachSys.Models.Compartimento", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}