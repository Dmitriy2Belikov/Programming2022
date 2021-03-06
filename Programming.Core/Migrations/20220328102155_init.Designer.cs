// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Programming.Core;

namespace Programming.Core.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220328102155_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Programming.Core.Domain.Developer.Developer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("TeamId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("Programming.Core.Domain.Project.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("TeamId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Programming.Core.Domain.Team.Team", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Programming.Core.Domain.Developer.Developer", b =>
                {
                    b.HasOne("Programming.Core.Domain.Team.Team", "Team")
                        .WithMany("Developers")
                        .HasForeignKey("TeamId");

                    b.OwnsOne("Programming.Core.Domain.Developer.ValueObjects.DeveloperName", "Name", b1 =>
                        {
                            b1.Property<long>("DeveloperId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.HasKey("DeveloperId");

                            b1.ToTable("Developers");

                            b1.WithOwner()
                                .HasForeignKey("DeveloperId");

                            b1.OwnsOne("Programming.Core.Domain.Common.ValueObjects.Name", "FirstName", b2 =>
                                {
                                    b2.Property<long>("DeveloperNameDeveloperId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("bigint")
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<string>("Value")
                                        .HasColumnType("nvarchar(max)")
                                        .HasColumnName("FirstName");

                                    b2.HasKey("DeveloperNameDeveloperId");

                                    b2.ToTable("Developers");

                                    b2.WithOwner()
                                        .HasForeignKey("DeveloperNameDeveloperId");
                                });

                            b1.OwnsOne("Programming.Core.Domain.Common.ValueObjects.Name", "LastName", b2 =>
                                {
                                    b2.Property<long>("DeveloperNameDeveloperId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("bigint")
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<string>("Value")
                                        .HasColumnType("nvarchar(max)")
                                        .HasColumnName("LastName");

                                    b2.HasKey("DeveloperNameDeveloperId");

                                    b2.ToTable("Developers");

                                    b2.WithOwner()
                                        .HasForeignKey("DeveloperNameDeveloperId");
                                });

                            b1.Navigation("FirstName");

                            b1.Navigation("LastName");
                        });

                    b.Navigation("Name");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Programming.Core.Domain.Project.Project", b =>
                {
                    b.HasOne("Programming.Core.Domain.Team.Team", "Team")
                        .WithMany("Projects")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Programming.Core.Domain.Common.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<long>("ProjectId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Name");

                            b1.HasKey("ProjectId");

                            b1.ToTable("Projects");

                            b1.WithOwner()
                                .HasForeignKey("ProjectId");
                        });

                    b.OwnsOne("Programming.Core.Domain.Project.ValueObjects.Status", "Status", b1 =>
                        {
                            b1.Property<long>("ProjectId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("ProjectStatus")
                                .HasColumnType("int")
                                .HasColumnName("Status");

                            b1.HasKey("ProjectId");

                            b1.ToTable("Projects");

                            b1.WithOwner()
                                .HasForeignKey("ProjectId");
                        });

                    b.Navigation("Name");

                    b.Navigation("Status");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Programming.Core.Domain.Team.Team", b =>
                {
                    b.OwnsOne("Programming.Core.Domain.Common.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<long>("TeamId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Name");

                            b1.HasKey("TeamId");

                            b1.ToTable("Teams");

                            b1.WithOwner()
                                .HasForeignKey("TeamId");
                        });

                    b.Navigation("Name");
                });

            modelBuilder.Entity("Programming.Core.Domain.Team.Team", b =>
                {
                    b.Navigation("Developers");

                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
