﻿// <auto-generated />
using BioData.DbRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BioData.Migrations
{
    [DbContext(typeof(BioDataContext))]
    partial class BioDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-rc.1.20451.13");

            modelBuilder.Entity("BioData.Data.Biodata", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Homepage")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.HasKey("Id");

                    b.ToTable("Biodata");
                });

            modelBuilder.Entity("BioData.Data.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Title")
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.HasKey("Id");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("BioData.Data.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BiodataId")
                        .HasColumnType("nvarchar(90)");

                    b.Property<string>("Note")
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<string>("Url")
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.HasKey("Id");

                    b.HasIndex("BiodataId");

                    b.ToTable("Link");
                });

            modelBuilder.Entity("BioData.Data.LinkType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Type")
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.HasKey("Id");

                    b.ToTable("LinkType");
                });

            modelBuilder.Entity("BioData.Data.OperatingSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.HasKey("Id");

                    b.ToTable("OperatingSystem");
                });

            modelBuilder.Entity("BioData.Data.ToolType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Tool")
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.HasKey("Id");

                    b.ToTable("ToolType");
                });

            modelBuilder.Entity("BiodataLanguage", b =>
                {
                    b.Property<string>("BiodataId")
                        .HasColumnType("nvarchar(90)");

                    b.Property<int>("LanguagesId")
                        .HasColumnType("int");

                    b.HasKey("BiodataId", "LanguagesId");

                    b.HasIndex("LanguagesId");

                    b.ToTable("BiodataLanguage");
                });

            modelBuilder.Entity("BiodataOperatingSystem", b =>
                {
                    b.Property<string>("BiodataId")
                        .HasColumnType("nvarchar(90)");

                    b.Property<int>("OperatingSystemsId")
                        .HasColumnType("int");

                    b.HasKey("BiodataId", "OperatingSystemsId");

                    b.HasIndex("OperatingSystemsId");

                    b.ToTable("BiodataOperatingSystem");
                });

            modelBuilder.Entity("BiodataToolType", b =>
                {
                    b.Property<string>("BiodataId")
                        .HasColumnType("nvarchar(90)");

                    b.Property<int>("ToolTypesId")
                        .HasColumnType("int");

                    b.HasKey("BiodataId", "ToolTypesId");

                    b.HasIndex("ToolTypesId");

                    b.ToTable("BiodataToolType");
                });

            modelBuilder.Entity("LinkLinkType", b =>
                {
                    b.Property<int>("LinkId")
                        .HasColumnType("int");

                    b.Property<int>("LinkTypesId")
                        .HasColumnType("int");

                    b.HasKey("LinkId", "LinkTypesId");

                    b.HasIndex("LinkTypesId");

                    b.ToTable("LinkLinkType");
                });

            modelBuilder.Entity("BioData.Data.Link", b =>
                {
                    b.HasOne("BioData.Data.Biodata", "Biodata")
                        .WithMany("Links")
                        .HasForeignKey("BiodataId");

                    b.Navigation("Biodata");
                });

            modelBuilder.Entity("BiodataLanguage", b =>
                {
                    b.HasOne("BioData.Data.Biodata", null)
                        .WithMany()
                        .HasForeignKey("BiodataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BioData.Data.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BiodataOperatingSystem", b =>
                {
                    b.HasOne("BioData.Data.Biodata", null)
                        .WithMany()
                        .HasForeignKey("BiodataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BioData.Data.OperatingSystem", null)
                        .WithMany()
                        .HasForeignKey("OperatingSystemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BiodataToolType", b =>
                {
                    b.HasOne("BioData.Data.Biodata", null)
                        .WithMany()
                        .HasForeignKey("BiodataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BioData.Data.ToolType", null)
                        .WithMany()
                        .HasForeignKey("ToolTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LinkLinkType", b =>
                {
                    b.HasOne("BioData.Data.Link", null)
                        .WithMany()
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BioData.Data.LinkType", null)
                        .WithMany()
                        .HasForeignKey("LinkTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BioData.Data.Biodata", b =>
                {
                    b.Navigation("Links");
                });
#pragma warning restore 612, 618
        }
    }
}
