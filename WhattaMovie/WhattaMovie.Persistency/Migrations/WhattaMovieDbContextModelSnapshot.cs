﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WhattaMovie.Persistency;

namespace WhattaMovie.Persistency.Migrations
{
    [DbContext(typeof(WhattaMovieDbContext))]
    partial class WhattaMovieDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("WhattaMovie.Domain.Movie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<int>("OwnerID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OwnerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tittle")
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("OwnerID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("WhattaMovie.Domain.Rating", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<int>("MovieID")
                        .HasColumnType("INTEGER");

                    b.Property<float?>("MovieRating")
                        .HasColumnType("REAL");

                    b.Property<int>("OwnerID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("MovieID");

                    b.HasIndex("OwnerID");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("WhattaMovie.Domain.Review", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<int>("MovieID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OwnerID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OwnerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("MovieID");

                    b.HasIndex("OwnerID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("WhattaMovie.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApiKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ApiSecret")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ApiKey = "9be7824a-fd2c-4248-9c3d-a99e8a8fcdf7",
                            ApiSecret = "67a14938-1f89-45fc-a9f3-a6822fbfeb02",
                            Role = "admin",
                            Username = "Admin1"
                        },
                        new
                        {
                            ID = 2,
                            ApiKey = "79b4c44f-ca85-46a8-a8e5-249d29723901",
                            ApiSecret = "481c44c1-b7ed-42e7-ba17-31601997d138",
                            Role = "admin",
                            Username = "Admin2"
                        },
                        new
                        {
                            ID = 3,
                            ApiKey = "67776dad-a538-4206-8968-4ac619c4d487",
                            ApiSecret = "9545b98e-cc24-44c6-a9c4-6cd6507e6240",
                            Role = "user",
                            Username = "User1"
                        },
                        new
                        {
                            ID = 4,
                            ApiKey = "64263dfb-e5e9-4b42-90e4-252e5360a02c",
                            ApiSecret = "398467dc-0875-46ad-8bdf-bccbee9dda00",
                            Role = "user",
                            Username = "User2"
                        });
                });

            modelBuilder.Entity("WhattaMovie.Domain.Movie", b =>
                {
                    b.HasOne("WhattaMovie.User", "Owner")
                        .WithMany("Movies")
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WhattaMovie.Domain.Rating", b =>
                {
                    b.HasOne("WhattaMovie.Domain.Movie", "Movie")
                        .WithMany("Ratings")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WhattaMovie.User", "Owner")
                        .WithMany("Ratings")
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WhattaMovie.Domain.Review", b =>
                {
                    b.HasOne("WhattaMovie.Domain.Movie", "Movie")
                        .WithMany("Reviews")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WhattaMovie.User", "Owner")
                        .WithMany("Reviews")
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
