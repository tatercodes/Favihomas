using System;
using System.Collections.Generic;

namespace Favihomas.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Status { get; set; }

    public DateTime DateCreated { get; set; }

    public int CreatedBy { get; set; }

    public DateTime DateUpdated { get; set; }

    public int UpdatedBy { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<DueReceipt> DueReceiptCreatedByNavigations { get; set; } = new List<DueReceipt>();

    public virtual ICollection<DueReceiptDetail> DueReceiptDetailCreatedByNavigations { get; set; } = new List<DueReceiptDetail>();

    public virtual ICollection<DueReceiptDetail> DueReceiptDetailUpdatedByNavigations { get; set; } = new List<DueReceiptDetail>();

    public virtual ICollection<DueReceiptDetailsAuditTrail> DueReceiptDetailsAuditTrails { get; set; } = new List<DueReceiptDetailsAuditTrail>();

    public virtual ICollection<DueReceipt> DueReceiptUpdatedByNavigations { get; set; } = new List<DueReceipt>();

    public virtual ICollection<DueReceiptsAuditTrail> DueReceiptsAuditTrails { get; set; } = new List<DueReceiptsAuditTrail>();

    public virtual ICollection<HomeOwner> HomeOwnerCreatedByNavigations { get; set; } = new List<HomeOwner>();

    public virtual ICollection<HomeOwner> HomeOwnerUpdatedByNavigations { get; set; } = new List<HomeOwner>();

    public virtual ICollection<HomeOwnersAuditTrail> HomeOwnersAuditTrails { get; set; } = new List<HomeOwnersAuditTrail>();

    public virtual ICollection<User> InverseCreatedByNavigation { get; set; } = new List<User>();

    public virtual ICollection<User> InverseUpdatedByNavigation { get; set; } = new List<User>();

    public virtual User UpdatedByNavigation { get; set; } = null!;

    public virtual ICollection<UsersAuditTrail> UsersAuditTrailUserModifieds { get; set; } = new List<UsersAuditTrail>();

    public virtual ICollection<UsersAuditTrail> UsersAuditTrailUsers { get; set; } = new List<UsersAuditTrail>();
}
