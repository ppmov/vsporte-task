// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportEventApi.Data;

#nullable disable

namespace SportEventApi.Migrations
{
    [DbContext(typeof(GameContext))]
    partial class GameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("ClubPlayer", b =>
                {
                    b.Property<Guid>("ClubsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PlayersId")
                        .HasColumnType("TEXT");

                    b.HasKey("ClubsId", "PlayersId");

                    b.HasIndex("PlayersId");

                    b.ToTable("ClubPlayer");
                });

            modelBuilder.Entity("SportEventApi.Models.Club", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("SportEventApi.Models.GameEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClubId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("MatchTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PlayerId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("PlayerId");

                    b.ToTable("GameEvents");
                });

            modelBuilder.Entity("SportEventApi.Models.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("ClubPlayer", b =>
                {
                    b.HasOne("SportEventApi.Models.Club", null)
                        .WithMany()
                        .HasForeignKey("ClubsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportEventApi.Models.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SportEventApi.Models.GameEvent", b =>
                {
                    b.HasOne("SportEventApi.Models.Club", "Club")
                        .WithMany()
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportEventApi.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");

                    b.Navigation("Club");

                    b.Navigation("Player");
                });
#pragma warning restore 612, 618
        }
    }
}
