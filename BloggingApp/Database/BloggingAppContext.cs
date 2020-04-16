using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BloggingApp.Database
{
    public partial class BloggingAppContext : DbContext
    {
        public BloggingAppContext()
        {
        }

        public BloggingAppContext(DbContextOptions<BloggingAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlogPost> BlogPost { get; set; }
        public virtual DbSet<BlogsTags> BlogsTags { get; set; }
        public virtual DbSet<TagList> TagList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.; Database=BloggingApp; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>(entity =>
            {
                entity.Property(e => e.BlogPostId).HasColumnName("BlogPostID");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            });

            modelBuilder.Entity<BlogsTags>(entity =>
            {
                entity.Property(e => e.BlogsTagsId).HasColumnName("BlogsTagsID");

                entity.Property(e => e.BlogPostId).HasColumnName("BlogPostID");

                entity.Property(e => e.TagListId).HasColumnName("TagListID");

                entity.HasOne(d => d.BlogPost)
                    .WithMany(p => p.BlogsTags)
                    .HasForeignKey(d => d.BlogPostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlogsTags_BlogPost");

                entity.HasOne(d => d.TagList)
                    .WithMany(p => p.BlogsTags)
                    .HasForeignKey(d => d.TagListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlogsTags_TagList");

            });

            modelBuilder.Entity<TagList>(entity =>
            {
                entity.Property(e => e.TagListId).HasColumnName("TagListID");

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(50);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
