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
    [Migration("20240624105811_projekt")]
    partial class projekt
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Asqa_Web.Models.Entities.Mitarbeiter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Ma_FirmaRolle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ma_Gebjahr")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ma_Nachname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ma_Vorname")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Projekten");
                });
#pragma warning restore 612, 618
        }
    }
}
