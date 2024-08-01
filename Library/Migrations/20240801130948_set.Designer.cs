﻿// <auto-generated />
using System;
using Library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20240801130948_set")]
    partial class set
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("BookcaseId")
                        .HasColumnType("int");

                    b.Property<string>("BooksName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<bool>("IsSet")
                        .HasColumnType("bit");

                    b.Property<int?>("SetBooksId")
                        .HasColumnType("int");

                    b.Property<int?>("ShelfId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("BookcaseId");

                    b.HasIndex("SetBooksId");

                    b.HasIndex("ShelfId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.Models.Bookcase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bookcases");
                });

            modelBuilder.Entity("Library.Models.SetBooks", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("setName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("SetOfBooks");
                });

            modelBuilder.Entity("Library.Models.Shelf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookcaseId")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("Weidth")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookcaseId");

                    b.ToTable("Shelfs");
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.HasOne("Library.Models.Bookcase", "Bookcase")
                        .WithMany()
                        .HasForeignKey("BookcaseId");

                    b.HasOne("Library.Models.SetBooks", "setBooks")
                        .WithMany("bookList")
                        .HasForeignKey("SetBooksId");

                    b.HasOne("Library.Models.Shelf", "shelf")
                        .WithMany("Books")
                        .HasForeignKey("ShelfId");

                    b.Navigation("Bookcase");

                    b.Navigation("setBooks");

                    b.Navigation("shelf");
                });

            modelBuilder.Entity("Library.Models.Shelf", b =>
                {
                    b.HasOne("Library.Models.Bookcase", "Bookcase")
                        .WithMany("shelflist")
                        .HasForeignKey("BookcaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bookcase");
                });

            modelBuilder.Entity("Library.Models.Bookcase", b =>
                {
                    b.Navigation("shelflist");
                });

            modelBuilder.Entity("Library.Models.SetBooks", b =>
                {
                    b.Navigation("bookList");
                });

            modelBuilder.Entity("Library.Models.Shelf", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
