﻿// <auto-generated />
using System;
using DotaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DotaAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240502084925_stringCharacteristics")]
    partial class stringCharacteristics
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DotaAPI.Models.Ability", b =>
                {
                    b.Property<int>("AbilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AbilityId"));

                    b.Property<string>("Cooldown")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsScepterUpgradeable")
                        .HasColumnType("bit");

                    b.Property<string>("ManaCost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AbilityId");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("DotaAPI.Models.AbilityDetail", b =>
                {
                    b.Property<int>("AbilityDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AbilityDetailId"));

                    b.Property<int>("AbilityId")
                        .HasColumnType("int");

                    b.Property<string>("Affects")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AttackDamageReduction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CastRange")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CastRangeReduction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Damage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DamageType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Dispellable")
                        .HasColumnType("bit");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PiercesSpellImmunity")
                        .HasColumnType("bit");

                    b.HasKey("AbilityDetailId");

                    b.HasIndex("AbilityId")
                        .IsUnique();

                    b.ToTable("AbilityDetails");
                });

            modelBuilder.Entity("DotaAPI.Models.Characteristic", b =>
                {
                    b.Property<int>("CharacteristicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacteristicId"));

                    b.Property<string>("Agility")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HeroId")
                        .HasColumnType("int");

                    b.Property<string>("Intelligence")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mana")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Strength")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CharacteristicId");

                    b.HasIndex("HeroId")
                        .IsUnique()
                        .HasFilter("[HeroId] IS NOT NULL");

                    b.ToTable("Characteristics");
                });

            modelBuilder.Entity("DotaAPI.Models.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("DotaAPI.Models.HeroAbility", b =>
                {
                    b.Property<int>("HeroId")
                        .HasColumnType("int");

                    b.Property<int>("AbilityId")
                        .HasColumnType("int");

                    b.HasKey("HeroId", "AbilityId");

                    b.HasIndex("AbilityId");

                    b.ToTable("HeroAbilities");
                });

            modelBuilder.Entity("DotaAPI.Models.Stats", b =>
                {
                    b.Property<int>("StatsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatsId"));

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("AttackRange")
                        .HasColumnType("int");

                    b.Property<double>("AttackTime")
                        .HasColumnType("float");

                    b.Property<double>("Defence")
                        .HasColumnType("float");

                    b.Property<int?>("HeroId")
                        .HasColumnType("int");

                    b.Property<string>("MagicResist")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovementSpeed")
                        .HasColumnType("int");

                    b.Property<int>("ProjectileSpeed")
                        .HasColumnType("int");

                    b.Property<double>("TurnRate")
                        .HasColumnType("float");

                    b.Property<string>("Vision")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatsId");

                    b.HasIndex("HeroId")
                        .IsUnique()
                        .HasFilter("[HeroId] IS NOT NULL");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("DotaAPI.Models.AbilityDetail", b =>
                {
                    b.HasOne("DotaAPI.Models.Ability", "Ability")
                        .WithOne("AbilityDetail")
                        .HasForeignKey("DotaAPI.Models.AbilityDetail", "AbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ability");
                });

            modelBuilder.Entity("DotaAPI.Models.Characteristic", b =>
                {
                    b.HasOne("DotaAPI.Models.Hero", "Hero")
                        .WithOne("Characteristic")
                        .HasForeignKey("DotaAPI.Models.Characteristic", "HeroId");

                    b.Navigation("Hero");
                });

            modelBuilder.Entity("DotaAPI.Models.HeroAbility", b =>
                {
                    b.HasOne("DotaAPI.Models.Ability", "Ability")
                        .WithMany("HeroAbilities")
                        .HasForeignKey("AbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotaAPI.Models.Hero", "Hero")
                        .WithMany("HeroAbilities")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ability");

                    b.Navigation("Hero");
                });

            modelBuilder.Entity("DotaAPI.Models.Stats", b =>
                {
                    b.HasOne("DotaAPI.Models.Hero", "Hero")
                        .WithOne("Stats")
                        .HasForeignKey("DotaAPI.Models.Stats", "HeroId");

                    b.Navigation("Hero");
                });

            modelBuilder.Entity("DotaAPI.Models.Ability", b =>
                {
                    b.Navigation("AbilityDetail");

                    b.Navigation("HeroAbilities");
                });

            modelBuilder.Entity("DotaAPI.Models.Hero", b =>
                {
                    b.Navigation("Characteristic");

                    b.Navigation("HeroAbilities");

                    b.Navigation("Stats");
                });
#pragma warning restore 612, 618
        }
    }
}
