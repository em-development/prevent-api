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
    [Migration("20220329004056_sows-property-type-enum")]
    partial class sowspropertytypeenum
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

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

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

            modelBuilder.Entity("Domain.Entities.Settings.LegalEntityCore.LegalEntities.LegalEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("LegalEntity", "settings");
                });

            modelBuilder.Entity("Domain.Entities.Settings.LegalEntityCore.LegalEntityContacts.LegalEntityContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LegalEntityContactTypeId")
                        .HasColumnType("int");

                    b.Property<int>("LegalEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LegalEntityContactTypeId");

                    b.HasIndex("LegalEntityId");

                    b.ToTable("LegalEntityContact", "settings");
                });

            modelBuilder.Entity("Domain.Entities.Settings.LegalEntityCore.LegalEntityContacts.LegalEntityContactType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("LegalEntityContactType", "settings");
                });

            modelBuilder.Entity("Domain.Entities.Settings.PropertyCore.Properties.Property", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("LegalEntityId")
                        .HasColumnType("int");

                    b.Property<int>("PropertyTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LegalEntityId");

                    b.HasIndex("PropertyTypeId");

                    b.ToTable("Property", "settings");
                });

            modelBuilder.Entity("Domain.Entities.Settings.PropertyCore.Properties.PropertyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("PropertyType", "settings");
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

            modelBuilder.Entity("Domain.Entities.Settings.LegalEntityCore.LegalEntities.LegalEntity", b =>
                {
                    b.HasOne("Domain.Entities.Settings.LegalEntityCore.LegalEntities.LegalEntity", "Parent")
                        .WithMany("Childrens")
                        .HasForeignKey("ParentId");

                    b.OwnsOne("Domain.ValueObjects.Settings.Entities.Name", "Name", b1 =>
                        {
                            b1.Property<int>("LegalEntityId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("varchar(150)")
                                .HasColumnName("Name");

                            b1.HasKey("LegalEntityId");

                            b1.ToTable("LegalEntity", "settings");

                            b1.WithOwner()
                                .HasForeignKey("LegalEntityId");
                        });

                    b.OwnsOne("Domain.ValueObjects.General.CodeEntity", "CodeEntity", b1 =>
                        {
                            b1.Property<int>("LegalEntityId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)")
                                .HasColumnName("CodeEntity");

                            b1.HasKey("LegalEntityId");

                            b1.ToTable("LegalEntity", "settings");

                            b1.WithOwner()
                                .HasForeignKey("LegalEntityId");
                        });

                    b.Navigation("CodeEntity")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Domain.Entities.Settings.LegalEntityCore.LegalEntityContacts.LegalEntityContact", b =>
                {
                    b.HasOne("Domain.Entities.Settings.LegalEntityCore.LegalEntityContacts.LegalEntityContactType", "LegalEntityContactType")
                        .WithMany("LegalEntityContacts")
                        .HasForeignKey("LegalEntityContactTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Settings.LegalEntityCore.LegalEntities.LegalEntity", "LegalEntity")
                        .WithMany("LegalEntityContacts")
                        .HasForeignKey("LegalEntityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("Domain.ValueObjects.General.Email", "Email", b1 =>
                        {
                            b1.Property<int>("LegalEntityContactId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("varchar(150)")
                                .HasColumnName("Email");

                            b1.HasKey("LegalEntityContactId");

                            b1.ToTable("LegalEntityContact", "settings");

                            b1.WithOwner()
                                .HasForeignKey("LegalEntityContactId");
                        });

                    b.OwnsOne("Domain.ValueObjects.Settings.Entities.Name", "Name", b1 =>
                        {
                            b1.Property<int>("LegalEntityContactId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("varchar(150)")
                                .HasColumnName("Name");

                            b1.HasKey("LegalEntityContactId");

                            b1.ToTable("LegalEntityContact", "settings");

                            b1.WithOwner()
                                .HasForeignKey("LegalEntityContactId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("LegalEntity");

                    b.Navigation("LegalEntityContactType");

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Settings.LegalEntityCore.LegalEntityContacts.LegalEntityContactType", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.General.EnumDescription", "Description", b1 =>
                        {
                            b1.Property<int>("LegalEntityContactTypeId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Description");

                            b1.HasKey("LegalEntityContactTypeId");

                            b1.ToTable("LegalEntityContactType", "settings");

                            b1.WithOwner()
                                .HasForeignKey("LegalEntityContactTypeId");
                        });

                    b.Navigation("Description")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Settings.PropertyCore.Properties.Property", b =>
                {
                    b.HasOne("Domain.Entities.Settings.LegalEntityCore.LegalEntities.LegalEntity", "LegalEntity")
                        .WithMany("Properties")
                        .HasForeignKey("LegalEntityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Settings.PropertyCore.Properties.PropertyType", "PropertyType")
                        .WithMany("Properties")
                        .HasForeignKey("PropertyTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("Domain.ValueObjects.Settings.Properties.Code", "Code", b1 =>
                        {
                            b1.Property<int>("PropertyId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)")
                                .HasColumnName("Code");

                            b1.HasKey("PropertyId");

                            b1.ToTable("Property", "settings");

                            b1.WithOwner()
                                .HasForeignKey("PropertyId");
                        });

                    b.OwnsOne("Domain.ValueObjects.Settings.Properties.Name", "Name", b1 =>
                        {
                            b1.Property<int>("PropertyId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("varchar(150)")
                                .HasColumnName("Name");

                            b1.HasKey("PropertyId");

                            b1.ToTable("Property", "settings");

                            b1.WithOwner()
                                .HasForeignKey("PropertyId");
                        });

                    b.Navigation("Code");

                    b.Navigation("LegalEntity");

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("PropertyType");
                });

            modelBuilder.Entity("Domain.Entities.Settings.PropertyCore.Properties.PropertyType", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.General.EnumDescription", "Description", b1 =>
                        {
                            b1.Property<int>("PropertyTypeId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Description");

                            b1.HasKey("PropertyTypeId");

                            b1.ToTable("PropertyType", "settings");

                            b1.WithOwner()
                                .HasForeignKey("PropertyTypeId");
                        });

                    b.Navigation("Description")
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

            modelBuilder.Entity("Domain.Entities.Settings.LegalEntityCore.LegalEntities.LegalEntity", b =>
                {
                    b.Navigation("Childrens");

                    b.Navigation("LegalEntityContacts");

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("Domain.Entities.Settings.LegalEntityCore.LegalEntityContacts.LegalEntityContactType", b =>
                {
                    b.Navigation("LegalEntityContacts");
                });

            modelBuilder.Entity("Domain.Entities.Settings.PropertyCore.Properties.PropertyType", b =>
                {
                    b.Navigation("Properties");
                });
#pragma warning restore 612, 618
        }
    }
}
