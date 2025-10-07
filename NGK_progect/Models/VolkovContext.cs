using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NGK_progect.Models;

public partial class VolkovContext : DbContext
{
    public VolkovContext()
    {
    }

    public VolkovContext(DbContextOptions<VolkovContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=ngknn.ru;Port=5442;Database=Volkov;Username=21P;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("C");

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.LoginId).HasName("logins_pkey");

            entity.ToTable("logins", "NGKProject");

            entity.HasIndex(e => e.Username, "logins_username_key").IsUnique();

            entity.Property(e => e.LoginId).HasColumnName("login_id");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users", "NGKProject");

            entity.HasIndex(e => e.LoginId, "users_login_id_key").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.LoginId).HasColumnName("login_id");

            entity.HasOne(d => d.Login).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.LoginId)
                .HasConstraintName("users_login_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
