﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiExercisio.Data;

#nullable disable

namespace WebApiExercisio.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240601220435_CriarBandoDeDados")]
    partial class CriarBandoDeDados
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApiExercisio.Models.AlteracaoDePesoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PesoAntigo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PesoNovo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("AlteracoesDePeso");
                });

            modelBuilder.Entity("WebApiExercisio.Models.ExercicioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("CaloriasPerdidas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Kilometragem")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("TempoDeDuracao")
                        .HasColumnType("time");

                    b.Property<int>("TipoExercicioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.HasIndex("TipoExercicioId");

                    b.ToTable("Exercicios");
                });

            modelBuilder.Entity("WebApiExercisio.Models.PessoaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PesoAtual")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("WebApiExercisio.Models.TipoExercicioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TiposDeExercicio");
                });

            modelBuilder.Entity("WebApiExercisio.Models.AlteracaoDePesoModel", b =>
                {
                    b.HasOne("WebApiExercisio.Models.PessoaModel", "Pessoa")
                        .WithMany("AlteracoesDePeso")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("WebApiExercisio.Models.ExercicioModel", b =>
                {
                    b.HasOne("WebApiExercisio.Models.PessoaModel", "Pessoa")
                        .WithMany("Exercicios")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiExercisio.Models.TipoExercicioModel", "TipoExercicio")
                        .WithMany()
                        .HasForeignKey("TipoExercicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");

                    b.Navigation("TipoExercicio");
                });

            modelBuilder.Entity("WebApiExercisio.Models.PessoaModel", b =>
                {
                    b.Navigation("AlteracoesDePeso");

                    b.Navigation("Exercicios");
                });
#pragma warning restore 612, 618
        }
    }
}
