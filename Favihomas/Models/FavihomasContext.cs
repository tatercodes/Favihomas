using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Favihomas.Models;

public partial class FavihomasContext : DbContext
{
    public FavihomasContext()
    {
    }

    public FavihomasContext(DbContextOptions<FavihomasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuditAction> AuditActions { get; set; }

    public virtual DbSet<DueReceipt> DueReceipts { get; set; }

    public virtual DbSet<DueReceiptDetail> DueReceiptDetails { get; set; }

    public virtual DbSet<DueReceiptDetailsAuditTrail> DueReceiptDetailsAuditTrails { get; set; }

    public virtual DbSet<DueReceiptsAuditTrail> DueReceiptsAuditTrails { get; set; }

    public virtual DbSet<HomeOwner> HomeOwners { get; set; }

    public virtual DbSet<HomeOwnersAuditTrail> HomeOwnersAuditTrails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersAuditTrail> UsersAuditTrails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=Favihomas; User Id=sa; Password=Cc987654321; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditAction>(entity =>
        {
            entity.HasKey(e => e.AuditActionId).HasName("PK__AuditAct__53A8C1C406E37BA6");

            entity.Property(e => e.AuditActionId).HasColumnName("AuditActionID");
            entity.Property(e => e.AuditAction1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AuditAction");
        });

        modelBuilder.Entity<DueReceipt>(entity =>
        {
            entity.HasKey(e => e.DueReceiptId).HasName("PK__DueRecei__B327BA17A8D0AB37");

            entity.Property(e => e.DueReceiptId).HasColumnName("DueReceiptID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateIssued).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.HomeOwnerId).HasColumnName("HomeOwnerID");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ReceiptImage)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Remarks).HasColumnType("text");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.DueReceiptCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DueReceip__Creat__4CA06362");

            entity.HasOne(d => d.HomeOwner).WithMany(p => p.DueReceipts)
                .HasForeignKey(d => d.HomeOwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DueReceip__HomeO__4BAC3F29");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.DueReceiptUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DueReceip__Updat__4D94879B");
        });

        modelBuilder.Entity<DueReceiptDetail>(entity =>
        {
            entity.HasKey(e => e.DueReceipDetailtId).HasName("PK__DueRecei__B2916AEA9AC1F41D");

            entity.Property(e => e.DueReceipDetailtId).HasColumnName("DueReceipDetailtID");
            entity.Property(e => e.DateCovered).HasColumnType("datetime");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.DueReceiptId).HasColumnName("DueReceiptID");
            entity.Property(e => e.Remarks).HasColumnType("text");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.DueReceiptDetailCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DueReceip__Creat__5629CD9C");

            entity.HasOne(d => d.DueReceipt).WithMany(p => p.DueReceiptDetails)
                .HasForeignKey(d => d.DueReceiptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DueReceip__DueRe__5535A963");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.DueReceiptDetailUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DueReceip__Updat__571DF1D5");
        });

        modelBuilder.Entity<DueReceiptDetailsAuditTrail>(entity =>
        {
            entity.HasKey(e => e.AuditTrailId).HasName("PK__DueRecei__41B2DDD32819076F");

            entity.ToTable("DueReceiptDetailsAuditTrail");

            entity.Property(e => e.AuditTrailId).HasColumnName("AuditTrailID");
            entity.Property(e => e.AuditActionId).HasColumnName("AuditActionID");
            entity.Property(e => e.Changes).HasColumnType("text");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.DueReceipDetailtId).HasColumnName("DueReceipDetailtID");
            entity.Property(e => e.Summary).HasColumnType("text");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.AuditAction).WithMany(p => p.DueReceiptDetailsAuditTrails)
                .HasForeignKey(d => d.AuditActionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DueReceip__Audit__5AEE82B9");

            entity.HasOne(d => d.DueReceipDetailt).WithMany(p => p.DueReceiptDetailsAuditTrails)
                .HasForeignKey(d => d.DueReceipDetailtId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DueReceip__DueRe__59FA5E80");

            entity.HasOne(d => d.User).WithMany(p => p.DueReceiptDetailsAuditTrails)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DueReceip__UserI__5BE2A6F2");
        });

        modelBuilder.Entity<DueReceiptsAuditTrail>(entity =>
        {
            entity.HasKey(e => e.AuditTrailId).HasName("PK__DueRecei__41B2DDD3D19BCFF4");

            entity.ToTable("DueReceiptsAuditTrail");

            entity.Property(e => e.AuditTrailId).HasColumnName("AuditTrailID");
            entity.Property(e => e.AuditActionId).HasColumnName("AuditActionID");
            entity.Property(e => e.Changes).HasColumnType("text");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.DueReceiptId).HasColumnName("DueReceiptID");
            entity.Property(e => e.Summary).HasColumnType("text");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.AuditAction).WithMany(p => p.DueReceiptsAuditTrails)
                .HasForeignKey(d => d.AuditActionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DueReceip__Audit__5165187F");

            entity.HasOne(d => d.DueReceipt).WithMany(p => p.DueReceiptsAuditTrails)
                .HasForeignKey(d => d.DueReceiptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DueReceip__DueRe__5070F446");

            entity.HasOne(d => d.User).WithMany(p => p.DueReceiptsAuditTrails)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DueReceip__UserI__52593CB8");
        });

        modelBuilder.Entity<HomeOwner>(entity =>
        {
            entity.HasKey(e => e.HomeOwnerId).HasName("PK__HomeOwne__56BFF5E80008C3F3");

            entity.Property(e => e.HomeOwnerId).HasColumnName("HomeOwnerID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateOfResidency).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.HouseNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Street)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TelephoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.HomeOwnerCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HomeOwner__Creat__4316F928");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.HomeOwnerUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HomeOwner__Updat__440B1D61");
        });

        modelBuilder.Entity<HomeOwnersAuditTrail>(entity =>
        {
            entity.HasKey(e => e.AuditTrailId).HasName("PK__HomeOwne__41B2DDD3B75D5AE2");

            entity.ToTable("HomeOwnersAuditTrail");

            entity.Property(e => e.AuditTrailId).HasColumnName("AuditTrailID");
            entity.Property(e => e.AuditActionId).HasColumnName("AuditActionID");
            entity.Property(e => e.Changes).HasColumnType("text");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.HomeOwnerId).HasColumnName("HomeOwnerID");
            entity.Property(e => e.Summary).HasColumnType("text");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.AuditAction).WithMany(p => p.HomeOwnersAuditTrails)
                .HasForeignKey(d => d.AuditActionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HomeOwner__Audit__47DBAE45");

            entity.HasOne(d => d.HomeOwner).WithMany(p => p.HomeOwnersAuditTrails)
                .HasForeignKey(d => d.HomeOwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HomeOwner__HomeO__46E78A0C");

            entity.HasOne(d => d.User).WithMany(p => p.HomeOwnersAuditTrails)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HomeOwner__UserI__48CFD27E");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC48405C06");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InverseCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__CreatedBy__398D8EEE");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.InverseUpdatedByNavigation)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__UpdatedBy__3A81B327");
        });

        modelBuilder.Entity<UsersAuditTrail>(entity =>
        {
            entity.HasKey(e => e.AuditTrailId).HasName("PK__UsersAud__41B2DDD33F38720C");

            entity.ToTable("UsersAuditTrail");

            entity.Property(e => e.AuditTrailId).HasColumnName("AuditTrailID");
            entity.Property(e => e.AuditActionId).HasColumnName("AuditActionID");
            entity.Property(e => e.Changes).HasColumnType("text");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Summary).HasColumnType("text");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserModifiedId).HasColumnName("UserModifiedID");

            entity.HasOne(d => d.AuditAction).WithMany(p => p.UsersAuditTrails)
                .HasForeignKey(d => d.AuditActionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsersAudi__Audit__3E52440B");

            entity.HasOne(d => d.User).WithMany(p => p.UsersAuditTrailUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsersAudi__UserI__3F466844");

            entity.HasOne(d => d.UserModified).WithMany(p => p.UsersAuditTrailUserModifieds)
                .HasForeignKey(d => d.UserModifiedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsersAudi__UserM__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
