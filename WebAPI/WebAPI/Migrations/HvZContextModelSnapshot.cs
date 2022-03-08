﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Data;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(HvZContext))]
    partial class HvZContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebAPI.Models.Domain.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Chat_Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<bool>("Is_Human_Global")
                        .HasColumnType("bit");

                    b.Property<bool>("Is_Zombie_Global")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("SquadId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SquadId");

                    b.ToTable("Chats");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Chat_Time = "13:04",
                            GameId = 1,
                            Is_Human_Global = true,
                            Is_Zombie_Global = false,
                            Message = "Im the best, u scrubz",
                            PlayerId = 2,
                            SquadId = 1
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Domain.Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("End_time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<bool>("Is_Human_Visible")
                        .HasColumnType("bit");

                    b.Property<bool>("Is_Zombie_Visible")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Start_time")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Missions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Shop energy drinks at coop",
                            GameId = 1,
                            Is_Human_Visible = false,
                            Is_Zombie_Visible = true,
                            Name = "Secret Coop mission"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Domain.Squad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.Property<bool>("IsHuman")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameID");

                    b.ToTable("Squads");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GameID = 1,
                            IsHuman = true,
                            Name = "Mega-squad"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Game_state")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Nw_lat")
                        .HasColumnType("float");

                    b.Property<double?>("Nw_lng")
                        .HasColumnType("float");

                    b.Property<double?>("Se_lat")
                        .HasColumnType("float");

                    b.Property<double?>("Se_lng")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Game_state = 1,
                            Name = "Norrköpings zombie spel"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Kill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("KillerId")
                        .HasColumnType("int");

                    b.Property<double?>("Lat")
                        .HasColumnType("float");

                    b.Property<double?>("Lng")
                        .HasColumnType("float");

                    b.Property<string>("Story")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time_Of_Death")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VictimId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("KillerId");

                    b.HasIndex("VictimId");

                    b.ToTable("Kills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GameId = 1,
                            KillerId = 1,
                            Time_Of_Death = "10:33",
                            VictimId = 2
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bite_Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<bool>("Is_Human")
                        .HasColumnType("bit");

                    b.Property<bool>("Is_Patient_Zero")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bite_Code = "JagBetDig434",
                            GameId = 1,
                            Is_Human = true,
                            Is_Patient_Zero = false,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Bite_Code = "JagBetDig123",
                            GameId = 1,
                            Is_Human = false,
                            Is_Patient_Zero = true,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("WebAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            First_Name = "Martin",
                            Last_Name = "Späck"
                        },
                        new
                        {
                            Id = 2,
                            First_Name = "Gunvald",
                            Last_Name = "Larsson"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Domain.Chat", b =>
                {
                    b.HasOne("WebAPI.Models.Game", "Game")
                        .WithMany("GameChats")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.Player", "Player")
                        .WithMany("PlayerChats")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.Domain.Squad", "Squad")
                        .WithMany("SquadChats")
                        .HasForeignKey("SquadId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");

                    b.Navigation("Squad");
                });

            modelBuilder.Entity("WebAPI.Models.Domain.Mission", b =>
                {
                    b.HasOne("WebAPI.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("WebAPI.Models.Domain.Squad", b =>
                {
                    b.HasOne("WebAPI.Models.Game", "Game")
                        .WithMany("Squads")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("WebAPI.Models.Kill", b =>
                {
                    b.HasOne("WebAPI.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.Player", "Killer")
                        .WithMany("Kills")
                        .HasForeignKey("KillerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.Player", "Victim")
                        .WithMany("Deaths")
                        .HasForeignKey("VictimId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Killer");

                    b.Navigation("Victim");
                });

            modelBuilder.Entity("WebAPI.Models.Player", b =>
                {
                    b.HasOne("WebAPI.Models.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.User", "User")
                        .WithMany("Players")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebAPI.Models.Domain.Squad", b =>
                {
                    b.Navigation("SquadChats");
                });

            modelBuilder.Entity("WebAPI.Models.Game", b =>
                {
                    b.Navigation("GameChats");

                    b.Navigation("Players");

                    b.Navigation("Squads");
                });

            modelBuilder.Entity("WebAPI.Models.Player", b =>
                {
                    b.Navigation("Deaths");

                    b.Navigation("Kills");

                    b.Navigation("PlayerChats");
                });

            modelBuilder.Entity("WebAPI.Models.User", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
