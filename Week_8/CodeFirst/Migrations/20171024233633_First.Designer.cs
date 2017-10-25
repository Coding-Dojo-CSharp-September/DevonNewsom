using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CodeFirst.Models;

namespace CodeFirst.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20171024233633_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.3");

            modelBuilder.Entity("CodeFirst.Models.Travel", b =>
                {
                    b.Property<int>("TravelId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Destination");

                    b.Property<int>("UserId");

                    b.HasKey("TravelId");

                    b.HasIndex("UserId");

                    b.ToTable("Travels");
                });

            modelBuilder.Entity("CodeFirst.Models.TravelPlan", b =>
                {
                    b.Property<int>("TravelPlanId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("TravelId");

                    b.Property<int>("UserId");

                    b.HasKey("TravelPlanId");

                    b.HasIndex("TravelId");

                    b.HasIndex("UserId");

                    b.ToTable("TravelPlans");
                });

            modelBuilder.Entity("CodeFirst.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CodeFirst.Models.Travel", b =>
                {
                    b.HasOne("CodeFirst.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CodeFirst.Models.TravelPlan", b =>
                {
                    b.HasOne("CodeFirst.Models.Travel", "JoinedTravel")
                        .WithMany()
                        .HasForeignKey("TravelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CodeFirst.Models.User", "JoinedUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
