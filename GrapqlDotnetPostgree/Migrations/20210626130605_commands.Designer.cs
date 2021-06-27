﻿// <auto-generated />
using GrapqlDotnetPostgree.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GrapqlDotnetPostgree.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210626130605_commands")]
    partial class commands
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("GrapqlDotnetPostgree.Models.Commands", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CommandLine")
                        .HasColumnType("text");

                    b.Property<string>("HowTo")
                        .HasColumnType("text");

                    b.Property<int>("PlatformsId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlatformsId");

                    b.ToTable("Commands");
                });

            modelBuilder.Entity("GrapqlDotnetPostgree.Models.Platforms", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("LicenseKey")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("GrapqlDotnetPostgree.Models.Commands", b =>
                {
                    b.HasOne("GrapqlDotnetPostgree.Models.Platforms", "Platforms")
                        .WithMany("Commands")
                        .HasForeignKey("PlatformsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Platforms");
                });

            modelBuilder.Entity("GrapqlDotnetPostgree.Models.Platforms", b =>
                {
                    b.Navigation("Commands");
                });
#pragma warning restore 612, 618
        }
    }
}
