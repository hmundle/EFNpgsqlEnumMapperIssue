﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Ppas.Dal.EfStructures;
using Ppas.Models.Entities;

#nullable disable

namespace Ppas.Dal.EfStructures.Migrations
{
    [DbContext(typeof(PpasDbContext))]
    [Migration("20221216203342_InitialWithGlobalTypeMapper")]
    partial class InitialWithGlobalTypeMapper
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "ppas", "quadrant_type", new[] { "undefined", "a", "b", "c", "d" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ppas.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<QuadrantType>("Quadrant")
                        .HasColumnType("ppas.quadrant_type")
                        .HasColumnName("quadrant")
                        .HasComment("Quadrant identifier");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_users_name");

                    b.ToTable("users", "ppas");
                });
#pragma warning restore 612, 618
        }
    }
}
