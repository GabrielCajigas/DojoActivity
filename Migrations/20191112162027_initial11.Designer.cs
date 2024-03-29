﻿// <auto-generated />
using System;
using Belt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Belt.Migrations
{
    [DbContext(typeof(ElContext))]
    [Migration("20191112162027_initial11")]
    partial class initial11
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Belt.Models.FiestaAndPlanner", b =>
                {
                    b.Property<int>("FiestaAndPlannerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FiestaId");

                    b.Property<int>("UserId");

                    b.HasKey("FiestaAndPlannerId");

                    b.HasIndex("FiestaId");

                    b.HasIndex("UserId");

                    b.ToTable("FiestaAndPlanner");
                });

            modelBuilder.Entity("Belt.Models.TheFiesta", b =>
                {
                    b.Property<int>("FiestaId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("Duration");

                    b.Property<int>("PlannerId");

                    b.Property<string>("Tiempo");

                    b.Property<TimeSpan>("Time");

                    b.Property<string>("Tittle")
                        .IsRequired();

                    b.HasKey("FiestaId");

                    b.ToTable("Fiesta");
                });

            modelBuilder.Entity("Belt.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("name")
                        .IsRequired();

                    b.Property<string>("password")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Belt.Models.FiestaAndPlanner", b =>
                {
                    b.HasOne("Belt.Models.TheFiesta", "Fiesta")
                        .WithMany("JoinedUsers")
                        .HasForeignKey("FiestaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Belt.Models.User", "Planner")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
