﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SbLeaderboards.Api.DAL.Context;

#nullable disable

namespace SbLeaderboards.Api.DAL.Migrations
{
    [DbContext(typeof(SbLeaderboardsContext))]
    [Migration("20240920150621_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SbLeaderboards.Resources.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("McUuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("players");
                });

            modelBuilder.Entity("SbLeaderboards.Resources.Models.Stats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlchemyExp")
                        .HasColumnType("int");

                    b.Property<int>("ArcherExp")
                        .HasColumnType("int");

                    b.Property<int>("BerserkerExp")
                        .HasColumnType("int");

                    b.Property<int>("CarpentryExp")
                        .HasColumnType("int");

                    b.Property<int>("CatacombsExp")
                        .HasColumnType("int");

                    b.Property<int>("CombatExp")
                        .HasColumnType("int");

                    b.Property<int>("EnchantingExp")
                        .HasColumnType("int");

                    b.Property<int>("FarmingExp")
                        .HasColumnType("int");

                    b.Property<int>("FishingExp")
                        .HasColumnType("int");

                    b.Property<int>("ForagingExp")
                        .HasColumnType("int");

                    b.Property<int>("HealerExp")
                        .HasColumnType("int");

                    b.Property<int>("MageExp")
                        .HasColumnType("int");

                    b.Property<int>("MiningExp")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("ProfileType")
                        .HasColumnType("int");

                    b.Property<int>("RunecraftingExp")
                        .HasColumnType("int");

                    b.Property<int>("SkyblockExp")
                        .HasColumnType("int");

                    b.Property<int>("SocialExp")
                        .HasColumnType("int");

                    b.Property<int>("TamingExp")
                        .HasColumnType("int");

                    b.Property<int>("TankExp")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("SbLeaderboards.Resources.Models.Stats", b =>
                {
                    b.HasOne("SbLeaderboards.Resources.Models.Player", null)
                        .WithMany("StatList")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SbLeaderboards.Resources.Models.Player", b =>
                {
                    b.Navigation("StatList");
                });
#pragma warning restore 612, 618
        }
    }
}
