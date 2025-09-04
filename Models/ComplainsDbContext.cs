using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UniversityComplaintSystem.Models;

public partial class ComplainsDbContext : DbContext
{
    public ComplainsDbContext()
    {
    }

    public ComplainsDbContext(DbContextOptions<ComplainsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Complaint> Complaints { get; set; }

    public virtual DbSet<ComplaintAction> ComplaintActions { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Programmer;Database= ComplainsDb;User=sa;Password=123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Complaint>(entity =>
        {
            entity.HasKey(e => e.ComplaintId).HasName("PK__Complain__740D898F7EBEE3E4");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Department).WithMany(p => p.Complaints)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Complaint__Depar__45F365D3");

            entity.HasOne(d => d.User).WithMany(p => p.Complaints)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Complaint__UserI__44FF419A");
        });

        modelBuilder.Entity<ComplaintAction>(entity =>
        {
            entity.HasKey(e => e.ActionId).HasName("PK__Complain__FFE3F4D9487F6DFC");

            entity.Property(e => e.Action).HasMaxLength(200);
            entity.Property(e => e.ActionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.ActionByUser).WithMany(p => p.ComplaintActions)
                .HasForeignKey(d => d.ActionByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Complaint__Actio__4AB81AF0");

            entity.HasOne(d => d.Complaint).WithMany(p => p.ComplaintActions)
                .HasForeignKey(d => d.ComplaintId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Complaint__Compl__49C3F6B7");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED31A118C7");

            entity.Property(e => e.HeadUserId).HasDefaultValue(1);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.HeadUser).WithMany(p => p.Departments)
                .HasForeignKey(d => d.HeadUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Departments_HeadUser");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CED18DD01");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105347C86C97B").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Role).HasMaxLength(50);

            entity.HasOne(d => d.Department).WithMany(p => p.Users)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Users__Departmen__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
