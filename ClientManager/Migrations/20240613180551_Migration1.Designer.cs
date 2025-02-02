﻿// <auto-generated />
using System;
using ClientManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClientManager.Migrations
{
    [DbContext(typeof(ClientContext))]
    [Migration("20240613180551_Migration1")]
    partial class Migration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClientManager.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GymId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GymId");

                    b.HasIndex("UserId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("ClientManager.Models.ClientNotes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<int>("Created_By")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Created_Date")
                        .HasColumnType("date");

                    b.Property<int>("Deleted_By")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Deleted_date")
                        .HasColumnType("date");

                    b.Property<bool>("Is_Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Note_Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Updated_By")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Updated_Date")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ClientID");

                    b.ToTable("ClientNotes");
                });

            modelBuilder.Entity("ClientManager.Models.Gym", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gym");
                });

            modelBuilder.Entity("ClientManager.Models.Membership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Client_Id")
                        .HasColumnType("int");

                    b.Property<DateOnly>("End_Date")
                        .HasColumnType("date");

                    b.Property<DateOnly>("Start_Date")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("Client_Id");

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("ClientManager.Models.Membership_Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Created_By")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Created_Date")
                        .HasColumnType("date");

                    b.Property<int>("Deleted_By")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Deleted_date")
                        .HasColumnType("date");

                    b.Property<bool>("Is_Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Status_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Updated_By")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Updated_Date")
                        .HasColumnType("date");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MembershipStatus");
                });

            modelBuilder.Entity("ClientManager.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ClientManager.Models.Client", b =>
                {
                    b.HasOne("ClientManager.Models.Gym", "Gym")
                        .WithMany("Clients")
                        .HasForeignKey("GymId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClientManager.Models.User", "User")
                        .WithMany("Clients")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gym");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ClientManager.Models.ClientNotes", b =>
                {
                    b.HasOne("ClientManager.Models.Client", "Client")
                        .WithMany("Notes")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("ClientManager.Models.Membership", b =>
                {
                    b.HasOne("ClientManager.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("Client_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("ClientManager.Models.Client", b =>
                {
                    b.Navigation("Notes");
                });

            modelBuilder.Entity("ClientManager.Models.Gym", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("ClientManager.Models.User", b =>
                {
                    b.Navigation("Clients");
                });
#pragma warning restore 612, 618
        }
    }
}
