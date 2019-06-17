﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TabletopStore.Models;

namespace TabletopStore.Migrations
{
    [DbContext(typeof(StoreDBContext))]
    [Migration("20190617213027_orders1")]
    partial class orders1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TabletopStore.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TabletopStore.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmountInStock");

                    b.Property<int>("CategoryId");

                    b.Property<string>("ImageThumbnailUrl");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsHit");

                    b.Property<string>("LongDescription");

                    b.Property<int>("MaxPlayers");

                    b.Property<int>("MinPlayers");

                    b.Property<string>("Name");

                    b.Property<int>("PrefferedAge");

                    b.Property<double>("Price");

                    b.Property<string>("ShortDescription");

                    b.Property<int>("Time");

                    b.HasKey("GameId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("TabletopStore.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress");

                    b.Property<string>("Country");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("OrderPlaced");

                    b.Property<double>("OrderTotal");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TabletopStore.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int>("GameId");

                    b.Property<int>("OrderId");

                    b.Property<double>("Price");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("GameId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("TabletopStore.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int?>("GameId");

                    b.Property<string>("ShoppingCartId");

                    b.HasKey("ShoppingCartItemId");

                    b.HasIndex("GameId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("TabletopStore.Models.Game", b =>
                {
                    b.HasOne("TabletopStore.Models.Category", "Category")
                        .WithMany("List")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TabletopStore.Models.OrderDetail", b =>
                {
                    b.HasOne("TabletopStore.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TabletopStore.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TabletopStore.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("TabletopStore.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId");
                });
#pragma warning restore 612, 618
        }
    }
}
