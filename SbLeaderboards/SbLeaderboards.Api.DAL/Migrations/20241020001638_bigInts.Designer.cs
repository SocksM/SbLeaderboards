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
    [Migration("20241020001638_bigInts")]
    partial class bigInts
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

                    b.Property<DateTime>("LastNameCheck")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastStatUpdate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("McUuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("SbLeaderboards.Resources.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CuteName")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("SbLeaderboards.Resources.Models.Stats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("AlchemyExp")
                        .HasColumnType("bigint");

                    b.Property<long>("ArcherExp")
                        .HasColumnType("bigint");

                    b.Property<long>("BerserkerExp")
                        .HasColumnType("bigint");

                    b.Property<long>("CarpentryExp")
                        .HasColumnType("bigint");

                    b.Property<long>("CatacombsExp")
                        .HasColumnType("bigint");

                    b.Property<long>("CombatExp")
                        .HasColumnType("bigint");

                    b.Property<long>("EnchantingExp")
                        .HasColumnType("bigint");

                    b.Property<long>("FarmingExp")
                        .HasColumnType("bigint");

                    b.Property<long>("FishingExp")
                        .HasColumnType("bigint");

                    b.Property<long>("ForagingExp")
                        .HasColumnType("bigint");

                    b.Property<long>("HealerExp")
                        .HasColumnType("bigint");

                    b.Property<long>("MageExp")
                        .HasColumnType("bigint");

                    b.Property<long>("MiningExp")
                        .HasColumnType("bigint");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<long>("RunecraftingExp")
                        .HasColumnType("bigint");

                    b.Property<long>("SkyblockExp")
                        .HasColumnType("bigint");

                    b.Property<long>("SocialExp")
                        .HasColumnType("bigint");

                    b.Property<long>("TamingExp")
                        .HasColumnType("bigint");

                    b.Property<long>("TankExp")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("SbLeaderboards.Resources.Models.Profile", b =>
                {
                    b.HasOne("SbLeaderboards.Resources.Models.Player", null)
                        .WithMany("Profiles")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SbLeaderboards.Resources.Models.Stats", b =>
                {
                    b.HasOne("SbLeaderboards.Resources.Models.Profile", null)
                        .WithMany("Stats")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SbLeaderboards.Resources.Models.Player", b =>
                {
                    b.Navigation("Profiles");
                });

            modelBuilder.Entity("SbLeaderboards.Resources.Models.Profile", b =>
                {
                    b.Navigation("Stats");
                });
#pragma warning restore 612, 618
        }
    }
}
