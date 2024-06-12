using System;
using System.Collections.Generic;

namespace Favihomas.Models;

public partial class HomeOwner
{
    public int HomeOwnerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string HouseNumber { get; set; } = null!;

    public DateTime? DateOfResidency { get; set; }

    public int HouseHoldCount { get; set; }

    public string? PhoneNumber { get; set; }

    public string? TelephoneNumber { get; set; }

    public string? EmailAddress { get; set; }

    public bool Status { get; set; }

    public DateTime DateCreated { get; set; }

    public int CreatedBy { get; set; }

    public DateTime DateUpdated { get; set; }

    public int UpdatedBy { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<DueReceipt> DueReceipts { get; set; } = new List<DueReceipt>();

    public virtual ICollection<HomeOwnersAuditTrail> HomeOwnersAuditTrails { get; set; } = new List<HomeOwnersAuditTrail>();

    public virtual User UpdatedByNavigation { get; set; } = null!;
}
