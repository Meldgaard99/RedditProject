﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RedditFullStack.Model;

#nullable disable

namespace RedditProject.Migrations
{
    [DbContext(typeof(RedditContext))]
    [Migration("20230412094627_useruser")]
    partial class useruser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("RedditFullStack.Model.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Downvote")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfVotes")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Upvote")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CommentId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("RedditFullStack.Model.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Downvote")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfVotes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Upvote")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("RedditFullStack.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RedditFullStack.Model.Comment", b =>
                {
                    b.HasOne("RedditFullStack.Model.Post", null)
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.HasOne("RedditFullStack.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RedditFullStack.Model.Post", b =>
                {
                    b.HasOne("RedditFullStack.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RedditFullStack.Model.Post", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
