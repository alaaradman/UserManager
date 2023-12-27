using System;
using System.Collections.Generic;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Data
{
    public partial class UserManagerDbContext : DbContext
    {
        public UserManagerDbContext()
        {
        }

        public UserManagerDbContext(DbContextOptions<UserManagerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<GroupHierarchy> GroupHierarchies { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RolePermission> RolePermissions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserGroup> UserGroups { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=UserManagerDb;Trusted_Connection=yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupHierarchy>(entity =>
            {
                entity.HasOne(d => d.ChildGroup)
                    .WithMany(p => p.GroupHierarchyChildGroups)
                    .HasForeignKey(d => d.ChildGroupId)
                    .HasConstraintName("FK__GroupHier__Child__35BCFE0A");

                entity.HasOne(d => d.ParentGroup)
                    .WithMany(p => p.GroupHierarchyParentGroups)
                    .HasForeignKey(d => d.ParentGroupId)
                    .HasConstraintName("FK__GroupHier__Paren__34C8D9D1");
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK__RolePermi__Permi__398D8EEE");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__RolePermi__RoleI__38996AB5");
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.HasOne(d => d.Group)
                    .WithMany(p => p.UserGroups)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__UserGroup__Group__31EC6D26");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserGroups)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserGroup__UserI__30F848ED");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__UserRoles__RoleI__2E1BDC42");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserRoles__UserI__2D27B809");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
