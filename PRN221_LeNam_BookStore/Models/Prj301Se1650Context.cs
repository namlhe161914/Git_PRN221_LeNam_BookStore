using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PRN221_LeNam_BookStore.Models;

public partial class Prj301Se1650Context : DbContext
{
    public Prj301Se1650Context()
    {
    }

    public Prj301Se1650Context(DbContextOptions<Prj301Se1650Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountDetailHe161914> AccountDetailHe161914s { get; set; }

    public virtual DbSet<AccountHe161914> AccountHe161914s { get; set; }

    public virtual DbSet<BookHe161914> BookHe161914s { get; set; }

    public virtual DbSet<CategoryHe161914> CategoryHe161914s { get; set; }

    public virtual DbSet<OrderDetailHe161914> OrderDetailHe161914s { get; set; }

    public virtual DbSet<OrderHe161914> OrderHe161914s { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<PublisherHe161914> PublisherHe161914s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server =(local); database = PRJ301_SE1650;uid=sa;pwd=admin;TrustServerCertificate=true; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountDetailHe161914>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AccountDetail_HE161914");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Aid)
                .ValueGeneratedOnAdd()
                .HasColumnName("aid");
            entity.Property(e => e.Avatar)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("avatar");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");

            entity.HasOne(d => d.AidNavigation).WithMany()
                .HasForeignKey(d => d.Aid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountDetail_HE161914_Account_HE161914");
        });

        modelBuilder.Entity<AccountHe161914>(entity =>
        {
            entity.ToTable("Account_HE161914");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Avatar).HasColumnName("avatar");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Pass)
                .HasMaxLength(50)
                .HasColumnName("pass");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<BookHe161914>(entity =>
        {
            entity.HasKey(e => e.Bid).HasName("PK__Book_HE1__3DE0C2271D91BD49");

            entity.ToTable("Book_HE161914");

            entity.Property(e => e.Bid).HasColumnName("bid");
            entity.Property(e => e.Author)
                .HasMaxLength(250)
                .HasColumnName("author");
            entity.Property(e => e.Bname)
                .HasMaxLength(250)
                .HasColumnName("bname");
            entity.Property(e => e.Cid)
                .HasMaxLength(50)
                .HasColumnName("cid");
            entity.Property(e => e.Describe).HasColumnName("describe");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Pid)
                .HasMaxLength(50)
                .HasColumnName("pid");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.CategoryHe161914).WithMany(p => p.BookHe161914s)
                .HasForeignKey(d => d.Cid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Categories_HE161914");

            entity.HasOne(d => d.PublisherHe161914).WithMany(p => p.BookHe161914s)
                .HasForeignKey(d => d.Pid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PublisherID_HE161914");
        });

        modelBuilder.Entity<CategoryHe161914>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__Category__D837D05FD9132096");

            entity.ToTable("Category_HE161914");

            entity.Property(e => e.Cid)
                .HasMaxLength(50)
                .HasColumnName("cid");
            entity.Property(e => e.Cname)
                .HasMaxLength(50)
                .HasColumnName("cname");
        });

        modelBuilder.Entity<OrderDetailHe161914>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OrderDetail_HE161914");

            entity.Property(e => e.Bid).HasColumnName("bid");
            entity.Property(e => e.Oid)
                .HasMaxLength(50)
                .HasColumnName("oid");
            entity.Property(e => e.Quanity).HasColumnName("quanity");

            entity.HasOne(d => d.BidNavigation).WithMany()
                .HasForeignKey(d => d.Bid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_HE161914_Book_HE161914");

            entity.HasOne(d => d.OidNavigation).WithMany()
                .HasForeignKey(d => d.Oid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_HE161914_Order_HE161914");
        });

        modelBuilder.Entity<OrderHe161914>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("Order_HE161914");

            entity.Property(e => e.Oid)
                .HasMaxLength(50)
                .HasColumnName("oid");
            entity.Property(e => e.Aid).HasColumnName("aid");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.AidNavigation).WithMany(p => p.OrderHe161914s)
                .HasForeignKey(d => d.Aid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_HE161914_Account_HE161914");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fullname).HasMaxLength(200);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PublisherHe161914>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PK__Publishe__DD37D91AB2600AA0");

            entity.ToTable("Publisher_HE161914");

            entity.Property(e => e.Pid)
                .HasMaxLength(50)
                .HasColumnName("pid");
            entity.Property(e => e.Pname)
                .HasMaxLength(50)
                .HasColumnName("pname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
