using System;
using System.Collections.Generic;

namespace Emtias.Models.Scaffolded;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? MobileNumber { get; set; }

    public string? IdentityNumber { get; set; }

    public DateOnly? BirthDate { get; set; }

    public int? Gender { get; set; }

    public int? NationalityId { get; set; }

    public int? CityId { get; set; }

    public string? Region { get; set; }

    public string? Streat { get; set; }

    public string? District { get; set; }

    public string? ZipCode { get; set; }

    public string? PhoneNumber { get; set; }

    public DateOnly? DateOfJoin { get; set; }

    public DateTime? CreateAt { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public string? Status { get; set; }

    public string? UserId { get; set; }

    public int? CreatorUserId { get; set; }

    public int? DeletedUserId { get; set; }

    public DateTime? DeleteAt { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? UpdateAte { get; set; }

    public int? CountryId { get; set; }

    public string? Img { get; set; }

    public bool IsInApi { get; set; }

    public string? Lat { get; set; }

    public string? Lng { get; set; }

    public string? Department { get; set; }

    public string? JobTitle { get; set; }

    public string? ContactInfo { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual City? City { get; set; }

    public virtual Country? Country { get; set; }

    public virtual Country? Nationality { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<RestaurantsComment> RestaurantsComments { get; set; } = new List<RestaurantsComment>();

    public virtual ICollection<RestaurantsCommentsVoting> RestaurantsCommentsVotings { get; set; } = new List<RestaurantsCommentsVoting>();
}
