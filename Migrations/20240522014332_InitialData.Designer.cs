﻿// <auto-generated />
using System;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EntityFramework.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20240522014332_InitialData")]
    partial class InitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EntityFramework.models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Effort")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("33c4d656-65f3-420b-b25f-0657f73e6e54"),
                            Effort = 10,
                            Name = "Academy Activities"
                        },
                        new
                        {
                            CategoryId = new Guid("df89da86-0ce8-4865-85ed-cdd55b127c54"),
                            Effort = 7,
                            Name = "Job Activities"
                        });
                });

            modelBuilder.Entity("EntityFramework.models.Task", b =>
                {
                    b.Property<Guid>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateToEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TaskPriority")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("TaskId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Task", (string)null);

                    b.HasData(
                        new
                        {
                            TaskId = new Guid("ba8cbb16-7c89-4cd5-9495-c46febda8215"),
                            CategoryId = new Guid("33c4d656-65f3-420b-b25f-0657f73e6e54"),
                            Date = new DateTime(2024, 5, 22, 1, 43, 31, 763, DateTimeKind.Utc).AddTicks(4266),
                            Description = "Study English with Platzi until to be bilingual",
                            TaskPriority = 2,
                            Title = "Study English"
                        },
                        new
                        {
                            TaskId = new Guid("56ba4700-16a4-44d8-a610-feb9fec0f0b7"),
                            CategoryId = new Guid("df89da86-0ce8-4865-85ed-cdd55b127c54"),
                            Date = new DateTime(2024, 5, 22, 1, 43, 31, 763, DateTimeKind.Utc).AddTicks(4271),
                            Description = "Update all COOSALUD apps",
                            TaskPriority = 1,
                            Title = "Update COOSALUD"
                        });
                });

            modelBuilder.Entity("EntityFramework.models.Task", b =>
                {
                    b.HasOne("EntityFramework.models.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EntityFramework.models.Category", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}