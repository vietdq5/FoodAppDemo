﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WavesOfFoodDemo.Server.DataContext;

#nullable disable

namespace WavesOfFoodDemo.Server.Migrations
{
    [DbContext(typeof(FoodDbContext))]
    [Migration("20240515153336_Add_Table_Cart_Detail")]
    partial class Add_Table_Cart_Detail
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WavesOfFoodDemo.Server.Entities.CartDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreateBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("FoodId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("numeric");

                    b.Property<Guid?>("UpdateBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("FoodId");

                    b.ToTable("CartDetails");
                });

            modelBuilder.Entity("WavesOfFoodDemo.Server.Entities.CartInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreateBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateOrder")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<Guid?>("UpdateBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CartInfos", (string)null);
                });

            modelBuilder.Entity("WavesOfFoodDemo.Server.Entities.FoodInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreateBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImageDetail")
                        .HasColumnType("text");

                    b.Property<string>("ImageMenu")
                        .HasColumnType("text");

                    b.Property<string>("Ingredient")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<Guid?>("UpdateBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("FoodInfo", (string)null);
                });

            modelBuilder.Entity("WavesOfFoodDemo.Server.Entities.UserInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreateBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdateBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserAddress")
                        .HasColumnType("text");

                    b.Property<string>("UserFullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<string>("UserPassword")
                        .HasColumnType("text");

                    b.Property<string>("UserPhone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserInfo", (string)null);
                });

            modelBuilder.Entity("WavesOfFoodDemo.Server.Entities.CartDetails", b =>
                {
                    b.HasOne("WavesOfFoodDemo.Server.Entities.CartInfo", "CartInfos")
                        .WithMany("CartDetails")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WavesOfFoodDemo.Server.Entities.FoodInfo", "FoodInfos")
                        .WithMany("CartDetails")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CartInfos");

                    b.Navigation("FoodInfos");
                });

            modelBuilder.Entity("WavesOfFoodDemo.Server.Entities.CartInfo", b =>
                {
                    b.HasOne("WavesOfFoodDemo.Server.Entities.UserInfo", "UserInfos")
                        .WithMany("CartInfos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserInfos");
                });

            modelBuilder.Entity("WavesOfFoodDemo.Server.Entities.CartInfo", b =>
                {
                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("WavesOfFoodDemo.Server.Entities.FoodInfo", b =>
                {
                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("WavesOfFoodDemo.Server.Entities.UserInfo", b =>
                {
                    b.Navigation("CartInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
