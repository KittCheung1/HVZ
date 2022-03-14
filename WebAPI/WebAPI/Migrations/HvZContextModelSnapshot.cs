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
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<bool>("Is_Human_Global")
                        .HasColumnType("bit");

                    b.Property<bool>("Is_Zombie_Global")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int?>("SquadId")
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
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

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
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

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
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

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

            modelBuilder.Entity("WebAPI.Models.Domain.SquadCheckIn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("End_Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<double>("Lat")
                        .HasColumnType("float");

                    b.Property<double>("Lng")
                        .HasColumnType("float");

                    b.Property<int>("SquadId")
                        .HasColumnType("int");

                    b.Property<int>("SquadmemberId")
                        .HasColumnType("int");

                    b.Property<string>("Start_Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("SquadId");

                    b.HasIndex("SquadmemberId");

                    b.ToTable("SquadCheckIns");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            End_Time = "14:20",
                            GameId = 1,
                            Lat = 41.231299999999997,
                            Lng = 2.21312,
                            SquadId = 1,
                            SquadmemberId = 1,
                            Start_Time = "13:37"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Domain.Squadmember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<string>("Rank")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("SquadId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SquadId");

                    b.ToTable("SquadMembers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GameId = 1,
                            PlayerId = 2,
                            Rank = "Generals",
                            SquadId = 1
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
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

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
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

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
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

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
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool?>("Is_Admin")
                        .HasColumnType("bit");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            First_Name = "Martin",
                            Is_Admin = true,
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
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Game");

                    b.Navigation("Player");

                    b.Navigation("Squad");
                });

            modelBuilder.Entity("WebAPI.Models.Domain.Mission", b =>
                {
                    b.HasOne("WebAPI.Models.Game", "Game")
                        .WithMany("Missions")
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

            modelBuilder.Entity("WebAPI.Models.Domain.SquadCheckIn", b =>
                {
                    b.HasOne("WebAPI.Models.Game", "Game")
                        .WithMany("SquadCheckIns")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.Domain.Squad", "Squad")
                        .WithMany("SquadCheckIns")
                        .HasForeignKey("SquadId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.Domain.Squadmember", "Squadmember")
                        .WithMany("SquadCheckIns")
                        .HasForeignKey("SquadmemberId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Squad");

                    b.Navigation("Squadmember");
                });

            modelBuilder.Entity("WebAPI.Models.Domain.Squadmember", b =>
                {
                    b.HasOne("WebAPI.Models.Game", "Game")
                        .WithMany("Squadmembers")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.Player", "Player")
                        .WithMany("Squadmembers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.Domain.Squad", "Squad")
                        .WithMany("Squadmembers")
                        .HasForeignKey("SquadId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");

                    b.Navigation("Squad");
                });

            modelBuilder.Entity("WebAPI.Models.Kill", b =>
                {
                    b.HasOne("WebAPI.Models.Game", "Game")
                        .WithMany("Kills")
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

                    b.Navigation("SquadCheckIns");

                    b.Navigation("Squadmembers");
                });

            modelBuilder.Entity("WebAPI.Models.Domain.Squadmember", b =>
                {
                    b.Navigation("SquadCheckIns");
                });

            modelBuilder.Entity("WebAPI.Models.Game", b =>
                {
                    b.Navigation("GameChats");

                    b.Navigation("Kills");

                    b.Navigation("Missions");

                    b.Navigation("Players");

                    b.Navigation("SquadCheckIns");

                    b.Navigation("Squadmembers");

                    b.Navigation("Squads");
                });

            modelBuilder.Entity("WebAPI.Models.Player", b =>
                {
                    b.Navigation("Deaths");

                    b.Navigation("Kills");

                    b.Navigation("PlayerChats");

                    b.Navigation("Squadmembers");
                });

            modelBuilder.Entity("WebAPI.Models.User", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
