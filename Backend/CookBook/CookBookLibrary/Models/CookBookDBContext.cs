using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CookBookLibrary.Models
{
    public partial class CookBookDBContext : DbContext
    {
        public CookBookDBContext()
        {
        }

        public CookBookDBContext(DbContextOptions<CookBookDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ingredient> Ingredients { get; set; } = null!;
        public virtual DbSet<Recipe> Recipes { get; set; } = null!;
        public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=jnsqlserver.caebm1qbtjvd.us-east-1.rds.amazonaws.com,1433;database=CookBookDB;User ID=admin; Password=123456789;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("Ingredient");

                entity.Property(e => e.IngredientId).HasColumnName("ingredientId");

                entity.Property(e => e.IngredientName)
                    .HasMaxLength(100)
                    .HasColumnName("ingredientName");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("Recipe");

                entity.Property(e => e.RecipeId).HasColumnName("recipeId");

                entity.Property(e => e.Complexity)
                    .HasMaxLength(30)
                    .HasColumnName("complexity");

                entity.Property(e => e.Cuisine)
                    .HasMaxLength(500)
                    .HasColumnName("cuisine");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Instruction)
                    .HasMaxLength(1000)
                    .HasColumnName("instruction");

                entity.Property(e => e.PrepTime)
                    .HasMaxLength(50)
                    .HasColumnName("prepTime");

                entity.Property(e => e.PrepVideoUrl)
                    .HasMaxLength(50)
                    .HasColumnName("prepVideoUrl");

                entity.Property(e => e.Rating)
                    .HasMaxLength(50)
                    .HasColumnName("rating");

                entity.Property(e => e.RecipeName)
                    .HasMaxLength(500)
                    .HasColumnName("recipeName");
            });

            modelBuilder.Entity<RecipeIngredient>(entity =>
            {
                entity.HasKey(e => new { e.RecipeId, e.IngredientId })
                    .HasName("PK__Recipe_I__A361D4D1EE7E14DE");

                entity.ToTable("Recipe_Ingredient");

                entity.Property(e => e.RecipeId).HasColumnName("recipeId");

                entity.Property(e => e.IngredientId).HasColumnName("ingredientId");

                entity.Property(e => e.Measurement)
                    .HasMaxLength(50)
                    .HasColumnName("measurement");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ingredientId");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_recipeId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
