using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlogApp.Models
{
    public partial class DemoBlogDBContext : DbContext
    {
        public DemoBlogDBContext()
        {
        }

        public DemoBlogDBContext(DbContextOptions<DemoBlogDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Post> Post { get; set; }

        /*       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
               /* 
                if (!optionsBuilder.IsConfigured)
                {
      #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                    optionsBuilder.UseSqlServer("Data Source= GANESHA\\SQLEXPRESS; Initial Catalog= DemoBlogDB; Integrated security=True");
                }

           } */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Slug)
                    .HasColumnName("slug")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnName("Created_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Post__CategoryId__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
