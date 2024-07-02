﻿// <auto-generated />
using System;
using Asqa_Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Asqa_Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240702092555_initialcreate")]
    partial class initialcreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Asqa_Web.Models.Entities.Ausbildungen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ausb_institut")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Ausb_jahr")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Ausb_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Ausbildungen");
                });

            modelBuilder.Entity("Asqa_Web.Models.Entities.Ma_Projekt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MaNachname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("MitarbeiterId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Proj_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ProjektId")
                        .HasColumnType("int");

                    b.Property<string>("Rolle")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Taetigkeiten")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MitarbeiterId");

                    b.HasIndex("ProjektId");

                    b.ToTable("Ma_Projekte");
                });

            modelBuilder.Entity("Asqa_Web.Models.Entities.Mitarb_Projekt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("End_date")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("Ma_id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Ma_rolle")
                        .HasColumnType("longtext");

                    b.Property<int>("Proj_id")
                        .HasColumnType("int");

                    b.Property<string>("Proj_name")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Start_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Taetigkeiten")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Ma_id");

                    b.HasIndex("Proj_id");

                    b.ToTable("Mitarb_Projekte");
                });

            modelBuilder.Entity("Asqa_Web.Models.Entities.Mitarbeiter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Ma_FirmaRolle")
                        .HasColumnType("longtext");

                    b.Property<string>("Ma_Gebjahr")
                        .HasColumnType("longtext");

                    b.Property<string>("Ma_ImagePath")
                        .HasColumnType("longtext");

                    b.Property<string>("Ma_Nachname")
                        .HasColumnType("longtext");

                    b.Property<string>("Ma_Vorname")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Mitarbeiter");
                });

            modelBuilder.Entity("Asqa_Web.Models.Entities.Projekten", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Proj_Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Projekten");
                });

            modelBuilder.Entity("Asqa_Web.Models.Entities.Rolle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Rolle_name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Rollen");
                });

            modelBuilder.Entity("Asqa_Web.Models.Entities.Sprache", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Sprache_name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Sprache");
                });

            modelBuilder.Entity("Asqa_Web.Models.Entities.Taetigkeit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Taetigkeiten");
                });

            modelBuilder.Entity("Asqa_Web.Models.Entities.Technologie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Tech_name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Technologie");
                });

            modelBuilder.Entity("Asqa_Web.Models.Entities.Ma_Projekt", b =>
                {
                    b.HasOne("Asqa_Web.Models.Entities.Mitarbeiter", "Mitarbeiter")
                        .WithMany("Ma_Projekte")
                        .HasForeignKey("MitarbeiterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asqa_Web.Models.Entities.Projekten", "Projekten")
                        .WithMany("Ma_Projekte")
                        .HasForeignKey("ProjektId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mitarbeiter");

                    b.Navigation("Projekten");
                });

            modelBuilder.Entity("Asqa_Web.Models.Entities.Mitarb_Projekt", b =>
                {
                    b.HasOne("Asqa_Web.Models.Entities.Mitarbeiter", "Mitarbeiter")
                        .WithMany()
                        .HasForeignKey("Ma_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asqa_Web.Models.Entities.Projekten", "Projekten")
                        .WithMany()
                        .HasForeignKey("Proj_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mitarbeiter");

                    b.Navigation("Projekten");
                });

            modelBuilder.Entity("Asqa_Web.Models.Entities.Mitarbeiter", b =>
                {
                    b.Navigation("Ma_Projekte");
                });

            modelBuilder.Entity("Asqa_Web.Models.Entities.Projekten", b =>
                {
                    b.Navigation("Ma_Projekte");
                });
#pragma warning restore 612, 618
        }
    }
}
