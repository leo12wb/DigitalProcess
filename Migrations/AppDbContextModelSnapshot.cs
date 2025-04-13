﻿// <auto-generated />
using System;
using DigitalProcess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DigitalProcess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DigitalProcess.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<string>("FilePath")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ProcessId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProcessId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("DigitalProcess.Models.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("DigitalProcess.Models.Process", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("CurrentOrganizationId")
                        .HasColumnType("int");

                    b.Property<int?>("CurrentSectorId")
                        .HasColumnType("int");

                    b.Property<int?>("OriginOrganizationId")
                        .HasColumnType("int");

                    b.Property<int?>("OriginSectorId")
                        .HasColumnType("int");

                    b.Property<string>("ProtocolNumber")
                        .HasColumnType("longtext");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrentOrganizationId");

                    b.HasIndex("CurrentSectorId");

                    b.HasIndex("OriginOrganizationId");

                    b.HasIndex("OriginSectorId");

                    b.HasIndex("TypeId");

                    b.ToTable("Processes");
                });

            modelBuilder.Entity("DigitalProcess.Models.ProcessMovement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("FromSectorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("MovedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ProcessId")
                        .HasColumnType("int");

                    b.Property<int?>("ToSectorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromSectorId");

                    b.HasIndex("ProcessId");

                    b.HasIndex("ToSectorId");

                    b.ToTable("ProcessMovements");
                });

            modelBuilder.Entity("DigitalProcess.Models.ProcessType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("TemplateDocumentId")
                        .HasColumnType("int");

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.ToTable("ProcessTypes");
                });

            modelBuilder.Entity("DigitalProcess.Models.Sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<int?>("ParentSectorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("ParentSectorId");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("DigitalProcess.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DigitalProcess.Models.UserSector", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("SectorId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "SectorId");

                    b.HasIndex("SectorId");

                    b.ToTable("UserSector");
                });

            modelBuilder.Entity("DigitalProcess.Models.Document", b =>
                {
                    b.HasOne("DigitalProcess.Models.Process", null)
                        .WithMany("Documents")
                        .HasForeignKey("ProcessId");
                });

            modelBuilder.Entity("DigitalProcess.Models.Process", b =>
                {
                    b.HasOne("DigitalProcess.Models.Organization", "CurrentOrganization")
                        .WithMany()
                        .HasForeignKey("CurrentOrganizationId");

                    b.HasOne("DigitalProcess.Models.Sector", "CurrentSector")
                        .WithMany()
                        .HasForeignKey("CurrentSectorId");

                    b.HasOne("DigitalProcess.Models.Organization", "OriginOrganization")
                        .WithMany()
                        .HasForeignKey("OriginOrganizationId");

                    b.HasOne("DigitalProcess.Models.Sector", "OriginSector")
                        .WithMany()
                        .HasForeignKey("OriginSectorId");

                    b.HasOne("DigitalProcess.Models.ProcessType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentOrganization");

                    b.Navigation("CurrentSector");

                    b.Navigation("OriginOrganization");

                    b.Navigation("OriginSector");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("DigitalProcess.Models.ProcessMovement", b =>
                {
                    b.HasOne("DigitalProcess.Models.Sector", "FromSector")
                        .WithMany()
                        .HasForeignKey("FromSectorId");

                    b.HasOne("DigitalProcess.Models.Process", "Process")
                        .WithMany("Movements")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalProcess.Models.Sector", "ToSector")
                        .WithMany()
                        .HasForeignKey("ToSectorId");

                    b.Navigation("FromSector");

                    b.Navigation("Process");

                    b.Navigation("ToSector");
                });

            modelBuilder.Entity("DigitalProcess.Models.ProcessType", b =>
                {
                    b.HasOne("DigitalProcess.Models.Document", "Template")
                        .WithMany()
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Template");
                });

            modelBuilder.Entity("DigitalProcess.Models.Sector", b =>
                {
                    b.HasOne("DigitalProcess.Models.Organization", "Organization")
                        .WithMany("Sectors")
                        .HasForeignKey("OrganizationId");

                    b.HasOne("DigitalProcess.Models.Sector", "ParentSector")
                        .WithMany("Children")
                        .HasForeignKey("ParentSectorId");

                    b.Navigation("Organization");

                    b.Navigation("ParentSector");
                });

            modelBuilder.Entity("DigitalProcess.Models.User", b =>
                {
                    b.HasOne("DigitalProcess.Models.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("DigitalProcess.Models.UserSector", b =>
                {
                    b.HasOne("DigitalProcess.Models.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalProcess.Models.User", "User")
                        .WithMany("UserSectors")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sector");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DigitalProcess.Models.Organization", b =>
                {
                    b.Navigation("Sectors");
                });

            modelBuilder.Entity("DigitalProcess.Models.Process", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("Movements");
                });

            modelBuilder.Entity("DigitalProcess.Models.Sector", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("DigitalProcess.Models.User", b =>
                {
                    b.Navigation("UserSectors");
                });
#pragma warning restore 612, 618
        }
    }
}
