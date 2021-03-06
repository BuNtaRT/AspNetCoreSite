﻿// <auto-generated />
using System;
using LPFO_one.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LPFO_one.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("LPFO_one.Domain.Note", b =>
                {
                    b.Property<int>("ID_note")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SpecID_spec")
                        .HasColumnType("int");

                    b.Property<int?>("UsersID_user")
                        .HasColumnType("int");

                    b.HasKey("ID_note");

                    b.HasIndex("SpecID_spec");

                    b.HasIndex("UsersID_user");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("LPFO_one.Domain.ServicesU", b =>
                {
                    b.Property<int>("ID_service")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_service");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("LPFO_one.Domain.Spec", b =>
                {
                    b.Property<int>("ID_spec")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Worked")
                        .HasColumnType("bit");

                    b.HasKey("ID_spec");

                    b.ToTable("Specs");
                });

            modelBuilder.Entity("LPFO_one.Domain.Unit", b =>
                {
                    b.Property<int>("ID_unit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_unit");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("LPFO_one.Domain.Users", b =>
                {
                    b.Property<int>("ID_user")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_num")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Post")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UnitID_unit")
                        .HasColumnType("int");

                    b.HasKey("ID_user");

                    b.HasIndex("UnitID_unit");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NoteServicesU", b =>
                {
                    b.Property<int>("NotesID_note")
                        .HasColumnType("int");

                    b.Property<int>("ServicesID_service")
                        .HasColumnType("int");

                    b.HasKey("NotesID_note", "ServicesID_service");

                    b.HasIndex("ServicesID_service");

                    b.ToTable("NoteServicesU");
                });

            modelBuilder.Entity("LPFO_one.Domain.Note", b =>
                {
                    b.HasOne("LPFO_one.Domain.Spec", "Spec")
                        .WithMany()
                        .HasForeignKey("SpecID_spec");

                    b.HasOne("LPFO_one.Domain.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersID_user");

                    b.Navigation("Spec");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("LPFO_one.Domain.Users", b =>
                {
                    b.HasOne("LPFO_one.Domain.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitID_unit");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("NoteServicesU", b =>
                {
                    b.HasOne("LPFO_one.Domain.Note", null)
                        .WithMany()
                        .HasForeignKey("NotesID_note")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LPFO_one.Domain.ServicesU", null)
                        .WithMany()
                        .HasForeignKey("ServicesID_service")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
