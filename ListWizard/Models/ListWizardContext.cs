using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ListWizard.Models
{
    public partial class ListWizardContext : DbContext
    {
        public ListWizardContext()
        {
        }

        public ListWizardContext(DbContextOptions<ListWizardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<CsvContent> CsvContents { get; set; } = null!;
        public virtual DbSet<WizardList> WizardLists { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source= YSALOKHE-LAP-05\\MSSQLSERVER01 ;Initial Catalog=ListWizard;Integrated Security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<CsvContent>(entity =>
            {
                entity.HasKey(e => e.CsvId)
                    .HasName("PK__CsvConte__AA1473CDC8EF4DB6");

                entity.ToTable("CsvContent");

                entity.Property(e => e.CsvId).HasColumnName("csvId");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("companyName");

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.ListId).HasColumnName("listId");

                entity.Property(e => e.Title)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.List)
                    .WithMany(p => p.CsvContents)
                    .HasForeignKey(d => d.ListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CsvConten__listI__5CD6CB2B");
            });

            modelBuilder.Entity<WizardList>(entity =>
            {
                entity.HasKey(e => e.ListId)
                    .HasName("PK__WizardLi__7D4CA77B610BCFAC");

                entity.ToTable("WizardList");

                entity.Property(e => e.ListId).HasColumnName("listId");

                entity.Property(e => e.AssignedTo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("assignedTo");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("createdDate");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ListName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("listName");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("date")
                    .HasColumnName("modifiedDate");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
