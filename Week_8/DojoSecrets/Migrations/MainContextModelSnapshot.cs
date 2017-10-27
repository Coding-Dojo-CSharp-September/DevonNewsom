using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DojoSecrets.Models;

namespace DojoSecrets.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.3");

            modelBuilder.Entity("DojoSecrets.Models.Like", b =>
                {
                    b.Property<int>("like_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("secret_id");

                    b.Property<int>("user_id");

                    b.HasKey("like_id");

                    b.HasIndex("secret_id");

                    b.ToTable("likes");
                });

            modelBuilder.Entity("DojoSecrets.Models.Secret", b =>
                {
                    b.Property<int>("secret_id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("created_at");

                    b.Property<string>("message");

                    b.Property<int>("user_id");

                    b.HasKey("secret_id");

                    b.ToTable("secrets");
                });

            modelBuilder.Entity("DojoSecrets.Models.User", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email");

                    b.Property<string>("first_name");

                    b.Property<string>("last_name");

                    b.Property<string>("password");

                    b.HasKey("user_id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("DojoSecrets.Models.Like", b =>
                {
                    b.HasOne("DojoSecrets.Models.Secret")
                        .WithMany("Likes")
                        .HasForeignKey("secret_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
