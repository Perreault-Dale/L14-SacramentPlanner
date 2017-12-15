﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SacramentPlanner.Data;
using SacramentPlanner.Models;
using System;

namespace SacramentPlanner.Migrations
{
    [DbContext(typeof(SacramentContext))]
    partial class SacramentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SacramentPlanner.Models.Hymn", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MeetingProgramID");

                    b.Property<int?>("hymnNumber")
                        .IsRequired();

                    b.Property<int>("location");

                    b.Property<string>("name")
                        .IsRequired();

                    b.HasKey("id");

                    b.HasIndex("MeetingProgramID");

                    b.ToTable("Hymn");
                });

            modelBuilder.Entity("SacramentPlanner.Models.MeetingProgram", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Conduct")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Preside")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("Sacrament");

                    b.Property<DateTime>("programDate");

                    b.HasKey("id");

                    b.ToTable("MeetingProgram");
                });

            modelBuilder.Entity("SacramentPlanner.Models.Prayer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MeetingProgramID");

                    b.Property<int>("location");

                    b.Property<string>("speaker")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("id");

                    b.HasIndex("MeetingProgramID");

                    b.ToTable("Prayer");
                });

            modelBuilder.Entity("SacramentPlanner.Models.Talk", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MeetingProgramID");

                    b.Property<string>("Reading");

                    b.Property<int>("order");

                    b.Property<string>("speaker")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("topic")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("id");

                    b.HasIndex("MeetingProgramID");

                    b.ToTable("Talk");
                });

            modelBuilder.Entity("SacramentPlanner.Models.Hymn", b =>
                {
                    b.HasOne("SacramentPlanner.Models.MeetingProgram")
                        .WithMany("Hymns")
                        .HasForeignKey("MeetingProgramID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SacramentPlanner.Models.Prayer", b =>
                {
                    b.HasOne("SacramentPlanner.Models.MeetingProgram")
                        .WithMany("Prayers")
                        .HasForeignKey("MeetingProgramID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SacramentPlanner.Models.Talk", b =>
                {
                    b.HasOne("SacramentPlanner.Models.MeetingProgram")
                        .WithMany("Talks")
                        .HasForeignKey("MeetingProgramID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
