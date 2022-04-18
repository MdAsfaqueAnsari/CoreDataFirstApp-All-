﻿// <auto-generated />
using System;
using CoreDataFirstApp.DB_context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreDataFirstApp.Migrations
{
    [DbContext(typeof(Db_Class))]
    [Migration("20220415173820_myfirstmigration")]
    partial class myfirstmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CoreDataFirstApp.Models.EmpModel", b =>
                {
                    b.Property<int>("Sid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Smail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Smob")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Sname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Sid");

                    b.ToTable("EmpModels");
                });
#pragma warning restore 612, 618
        }
    }
}
