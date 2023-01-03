﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Configuration.Context;

#nullable disable

namespace Repository.Configuration.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211212230030_issues-mappings")]
    partial class issuesmappings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Compacts.Settings.Users.CompactUser", b =>
                {
                    b.Property<int?>("AttachmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("AttachmentId");

                    b.ToView("vw_Users", "settings");
                });

            modelBuilder.Entity("Domain.Entities.BaseLogs.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("char(50)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reference")
                        .HasMaxLength(100)
                        .HasColumnType("char(100)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("char(150)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Logs", "log");
                });

            modelBuilder.Entity("Domain.Entities.BaseLogs.LogContent", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contents", "log");
                });

            modelBuilder.Entity("Domain.Entities.Files.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Attachments", "files");
                });

            modelBuilder.Entity("Domain.Entities.Settings.Checklist.RecommendationsCore.Issues.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Issues", "settings");
                });

            modelBuilder.Entity("Domain.Entities.Settings.Checklist.RecommendationsCore.Issues.IssueTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IssueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IssueId");

                    b.ToTable("IssueTags", "settings");
                });

            modelBuilder.Entity("Domain.Entities.Settings.Countries.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Countries", "settings");
                });

            modelBuilder.Entity("Domain.Entities.Settings.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Users", "settings");
                });

            modelBuilder.Entity("Domain.Compacts.Settings.Users.CompactUser", b =>
                {
                    b.HasOne("Domain.Entities.Files.Attachment", "Avatar")
                        .WithMany()
                        .HasForeignKey("AttachmentId");

                    b.Navigation("Avatar");
                });

            modelBuilder.Entity("Domain.Entities.BaseLogs.Log", b =>
                {
                    b.HasOne("Domain.Entities.Settings.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.BaseLogs.LogContent", b =>
                {
                    b.HasOne("Domain.Entities.BaseLogs.Log", "Log")
                        .WithOne("LogContent")
                        .HasForeignKey("Domain.Entities.BaseLogs.LogContent", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Log");
                });

            modelBuilder.Entity("Domain.Entities.Files.Attachment", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.Files.Bucket", "Bucket", b1 =>
                        {
                            b1.Property<int>("AttachmentId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("char(100)")
                                .HasColumnName("Bucket");

                            b1.HasKey("AttachmentId");

                            b1.ToTable("Attachments", "files");

                            b1.WithOwner()
                                .HasForeignKey("AttachmentId");
                        });

                    b.OwnsOne("Domain.ValueObjects.Files.ContentType", "ContentType", b1 =>
                        {
                            b1.Property<int>("AttachmentId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("char(150)")
                                .HasColumnName("ContentType");

                            b1.HasKey("AttachmentId");

                            b1.ToTable("Attachments", "files");

                            b1.WithOwner()
                                .HasForeignKey("AttachmentId");
                        });

                    b.OwnsOne("Domain.ValueObjects.Files.FileName", "FileName", b1 =>
                        {
                            b1.Property<int>("AttachmentId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(250)
                                .HasColumnType("char(250)")
                                .HasColumnName("FileName");

                            b1.HasKey("AttachmentId");

                            b1.ToTable("Attachments", "files");

                            b1.WithOwner()
                                .HasForeignKey("AttachmentId");
                        });

                    b.OwnsOne("Domain.ValueObjects.General.GuId", "Guid", b1 =>
                        {
                            b1.Property<int>("AttachmentId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(36)
                                .HasColumnType("char(36)")
                                .HasColumnName("GuId");

                            b1.HasKey("AttachmentId");

                            b1.ToTable("Attachments", "files");

                            b1.WithOwner()
                                .HasForeignKey("AttachmentId");
                        });

                    b.Navigation("Bucket")
                        .IsRequired();

                    b.Navigation("ContentType")
                        .IsRequired();

                    b.Navigation("FileName")
                        .IsRequired();

                    b.Navigation("Guid")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Settings.Checklist.RecommendationsCore.Issues.Issue", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.General.Description", "Description", b1 =>
                        {
                            b1.Property<int>("IssueId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("char(255)")
                                .HasColumnName("Description");

                            b1.HasKey("IssueId");

                            b1.ToTable("Issues", "settings");

                            b1.WithOwner()
                                .HasForeignKey("IssueId");
                        });

                    b.Navigation("Description")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Settings.Checklist.RecommendationsCore.Issues.IssueTag", b =>
                {
                    b.HasOne("Domain.Entities.Settings.Checklist.RecommendationsCore.Issues.Issue", "Issue")
                        .WithMany("Tags")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("Domain.ValueObjects.Settings.Checklist.RecommendationsCore.Issues.Tag", "Tag", b1 =>
                        {
                            b1.Property<int>("IssueTagId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("char(100)")
                                .HasColumnName("Tag");

                            b1.HasKey("IssueTagId");

                            b1.ToTable("IssueTags", "settings");

                            b1.WithOwner()
                                .HasForeignKey("IssueTagId");
                        });

                    b.Navigation("Issue");

                    b.Navigation("Tag")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Settings.Countries.Country", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.General.Description", "Description", b1 =>
                        {
                            b1.Property<int>("CountryId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("char(255)")
                                .HasColumnName("Description");

                            b1.HasKey("CountryId");

                            b1.ToTable("Countries", "settings");

                            b1.WithOwner()
                                .HasForeignKey("CountryId");
                        });

                    b.OwnsOne("Domain.ValueObjects.Settings.Countries.Lang", "Lang", b1 =>
                        {
                            b1.Property<int>("CountryId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(5)
                                .HasColumnType("char(5)")
                                .HasColumnName("Lang");

                            b1.HasKey("CountryId");

                            b1.ToTable("Countries", "settings");

                            b1.WithOwner()
                                .HasForeignKey("CountryId");
                        });

                    b.Navigation("Description")
                        .IsRequired();

                    b.Navigation("Lang")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Settings.Users.User", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.General.Email", "Email", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("char(150)")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.ToTable("Users", "settings");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Domain.ValueObjects.Settings.Users.Name", "Name", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("char(100)")
                                .HasColumnName("Name");

                            b1.HasKey("UserId");

                            b1.ToTable("Users", "settings");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Domain.ValueObjects.Settings.Users.UId", "UId", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("char(64)")
                                .HasColumnName("UId");

                            b1.HasKey("UserId");

                            b1.ToTable("Users", "settings");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email");

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("UId");
                });

            modelBuilder.Entity("Domain.Entities.BaseLogs.Log", b =>
                {
                    b.Navigation("LogContent");
                });

            modelBuilder.Entity("Domain.Entities.Settings.Checklist.RecommendationsCore.Issues.Issue", b =>
                {
                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
