using System;
using System.Collections.Generic;
using Emtias.Models.Scaffolded;
using Microsoft.EntityFrameworkCore;

namespace Emtias.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartView> CartViews { get; set; }

    public virtual DbSet<Catgory> Catgories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<GlobalParamater> GlobalParamaters { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<OffersView> OffersViews { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrdersItemsView> OrdersItemsViews { get; set; }

    public virtual DbSet<Otplogin> Otplogins { get; set; }

    public virtual DbSet<Otpsm> Otpsms { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<RestaurantsComment> RestaurantsComments { get; set; }

    public virtual DbSet<RestaurantsCommentsVoting> RestaurantsCommentsVotings { get; set; }

    public virtual DbSet<UsersRestCommentsView> UsersRestCommentsViews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AS");

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FullName).HasMaxLength(1500);
            entity.Property(e => e.HasComplateData).HasColumnName("hasComplateData");
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.RefreshTokenExpiryTime).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.ToTable("Cart");

            entity.Property(e => e.CreateAt).HasColumnType("datetime");

            entity.HasOne(d => d.Offer).WithMany(p => p.Carts)
                .HasForeignKey(d => d.OfferId)
                .HasConstraintName("FK_Cart_Offers");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Cart_Products");

            entity.HasOne(d => d.Rest).WithMany(p => p.Carts)
                .HasForeignKey(d => d.RestId)
                .HasConstraintName("FK_Cart_Restaurants");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Cart_Employees");
        });

        modelBuilder.Entity<CartView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CartView");

            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.IconLink).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.State).HasMaxLength(50);
        });

        modelBuilder.Entity<Catgory>(entity =>
        {
            entity.ToTable("Catgory");

            entity.Property(e => e.EnName).HasMaxLength(500);
            entity.Property(e => e.IconLink).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(500);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.Property(e => e.EnName).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UrName).HasMaxLength(100);

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Cities_Countries");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(e => e.EnName).HasMaxLength(100);
            entity.Property(e => e.EnNationality).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Nationality).HasMaxLength(100);
            entity.Property(e => e.UrName).HasMaxLength(100);
            entity.Property(e => e.UrNationality).HasMaxLength(100);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.ContactInfo).HasMaxLength(200);
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.DeleteAt).HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.District).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IdentityNumber).HasMaxLength(50);
            entity.Property(e => e.Img)
                .HasMaxLength(200)
                .HasColumnName("img");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsInApi)
                .HasDefaultValue(true)
                .HasColumnName("IsInAPI");
            entity.Property(e => e.JobTitle).HasMaxLength(100);
            entity.Property(e => e.Lat).HasMaxLength(20);
            entity.Property(e => e.Lng).HasMaxLength(20);
            entity.Property(e => e.MobileNumber).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.Region).HasMaxLength(500);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Streat).HasMaxLength(500);
            entity.Property(e => e.UpdateAte).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasMaxLength(450);
            entity.Property(e => e.ZipCode).HasMaxLength(50);

            entity.HasOne(d => d.City).WithMany(p => p.Employees)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_Employees_Cities");

            entity.HasOne(d => d.Country).WithMany(p => p.EmployeeCountries)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Countries_Company");

            entity.HasOne(d => d.Nationality).WithMany(p => p.EmployeeNationalities)
                .HasForeignKey(d => d.NationalityId)
                .HasConstraintName("FK_Employees_Nationalities");
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.State).HasMaxLength(50);

            entity.HasOne(d => d.Product).WithMany(p => p.Offers)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Offers_Products");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.Offers)
                .HasForeignKey(d => d.RestaurantId)
                .HasConstraintName("FK_Offers_Restaurants");
        });

        modelBuilder.Entity<OffersView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OffersView");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.CatgoryName).HasMaxLength(500);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.IconLink).HasMaxLength(500);
            entity.Property(e => e.Lat).HasMaxLength(50);
            entity.Property(e => e.Lng).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.ProductName).HasMaxLength(500);
            entity.Property(e => e.RestName).HasMaxLength(500);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.State).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BCF591D938C");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CustomerNotes).HasMaxLength(500);
            entity.Property(e => e.DeleverCost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Discount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PaymentId).HasMaxLength(50);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(20)
                .HasDefaultValue("cash");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ShippingAddress)
                .HasMaxLength(500)
                .HasDefaultValue("--");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("pending");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Employees");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED068112B3355B");

            entity.Property(e => e.Quantity).HasDefaultValue(1);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Offer).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OfferId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COrderItems_Offers");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderItems_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COrderItems_Products");

            entity.HasOne(d => d.Rest).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.RestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_Restaurants");
        });

        modelBuilder.Entity<OrdersItemsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OrdersItemsView");

            entity.Property(e => e.CustomerNotes).HasMaxLength(500);
            entity.Property(e => e.DeleverCost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.IconLink).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.PaymentId).HasMaxLength(50);
            entity.Property(e => e.PaymentType).HasMaxLength(20);
            entity.Property(e => e.ShippingAddress).HasMaxLength(500);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Otplogin>(entity =>
        {
            entity.ToTable("OTPLogins");

            entity.Property(e => e.Aspid)
                .HasMaxLength(450)
                .HasColumnName("ASPId");
            entity.Property(e => e.IsCurrent).HasColumnName("isCurrent");
            entity.Property(e => e.IsPassChanged).HasColumnName("isPassChanged");
            entity.Property(e => e.IsVerify).HasColumnName("isVerify");
            entity.Property(e => e.OtpTime).HasColumnName("otpTime");
            entity.Property(e => e.Otpcode).HasColumnName("OTPCode");
            entity.Property(e => e.Otphash).HasColumnName("otphash");
            entity.Property(e => e.PhoneNo).HasMaxLength(50);
            entity.Property(e => e.Purpose)
                .HasMaxLength(50)
                .HasDefaultValue("R")
                .HasColumnName("purpose");
        });

        modelBuilder.Entity<Otpsm>(entity =>
        {
            entity.ToTable("OTPSMS");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.MsgId).HasMaxLength(50);
            entity.Property(e => e.Responce).HasColumnName("responce");
            entity.Property(e => e.SendStatus).HasColumnName("sendStatus");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.EnName).HasMaxLength(500);
            entity.Property(e => e.IconLink).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .HasDefaultValue("new");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.Products)
                .HasForeignKey(d => d.RestaurantId)
                .HasConstraintName("FK_Products_Restaurants");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.ReserveState).HasMaxLength(50);

            entity.HasOne(d => d.Rest).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RestId)
                .HasConstraintName("FK_Reservations_Restaurants");

            entity.HasOne(d => d.User).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Reservations_Employees");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Details).HasMaxLength(500);
            entity.Property(e => e.EnName).HasMaxLength(500);
            entity.Property(e => e.IconLink).HasMaxLength(500);
            entity.Property(e => e.Lat).HasMaxLength(50);
            entity.Property(e => e.Lng).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(500);

            entity.HasOne(d => d.Catgory).WithMany(p => p.Restaurants)
                .HasForeignKey(d => d.CatgoryId)
                .HasConstraintName("FK_Restaurants_Catgory");
        });

        modelBuilder.Entity<RestaurantsComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_estaurantsComments");

            entity.Property(e => e.CommentDate).HasColumnType("datetime");

            entity.HasOne(d => d.Rest).WithMany(p => p.RestaurantsComments)
                .HasForeignKey(d => d.RestId)
                .HasConstraintName("FK_RestaurantsComments_Restaurants");

            entity.HasOne(d => d.User).WithMany(p => p.RestaurantsComments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_RestaurantsComments_Employees");
        });

        modelBuilder.Entity<RestaurantsCommentsVoting>(entity =>
        {
            entity.Property(e => e.VotingDate).HasColumnType("datetime");

            entity.HasOne(d => d.RestComment).WithMany(p => p.RestaurantsCommentsVotings)
                .HasForeignKey(d => d.RestCommentId)
                .HasConstraintName("FK_RestaurantsComments_RestaurantsCommentsVotings");

            entity.HasOne(d => d.User).WithMany(p => p.RestaurantsCommentsVotings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_RestaurantsCommentsVotings_Employees");
        });

        modelBuilder.Entity<UsersRestCommentsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("UsersRestCommentsViews");

            entity.Property(e => e.CommentDate).HasColumnType("datetime");
            entity.Property(e => e.Img)
                .HasMaxLength(200)
                .HasColumnName("img");
            entity.Property(e => e.Name).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
