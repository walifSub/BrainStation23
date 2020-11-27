using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccessLibrary.EntityModels
{
    public partial class DB_CRMContext : DbContext
    {
        public DB_CRMContext()
        {
        }

        public DB_CRMContext(DbContextOptions<DB_CRMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblComment> TblComments { get; set; }
        public virtual DbSet<TblPost> TblPosts { get; set; }
        public virtual DbSet<TblVote> TblVotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Database=DB_CRM;Trusted_Connection=false;User Id=sa;Password=ss@1234;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblComment>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK__tblComme__C3B4DFCA00F35CF9");

                entity.ToTable("tblComments");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.TblComments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblComments_PostId_tblPost_PostId");
            });

            modelBuilder.Entity<TblPost>(entity =>
            {
                entity.HasKey(e => e.PostId)
                    .HasName("PK__tblPosts__AA1260187977ECA6");

                entity.ToTable("tblPosts");

                entity.Property(e => e.CreateBy).HasMaxLength(50);

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

                entity.Property(e => e.PostTitle).HasMaxLength(50);
            });

            modelBuilder.Entity<TblVote>(entity =>
            {
                entity.HasKey(e => e.VoteId)
                    .HasName("PK__tblVote__52F015C2A339C85D");

                entity.ToTable("tblVote");

                entity.Property(e => e.CreateDatetime).HasColumnType("datetime");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.TblVotes)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblVote_CommentId_tblComments_CommentId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
