using System;
using System.Collections.Generic;

namespace Favihomas.Models;

public partial class AuditAction
{
    public int AuditActionId { get; set; }

    public string AuditAction1 { get; set; } = null!;

    public virtual ICollection<DueReceiptDetailsAuditTrail> DueReceiptDetailsAuditTrails { get; set; } = new List<DueReceiptDetailsAuditTrail>();

    public virtual ICollection<DueReceiptsAuditTrail> DueReceiptsAuditTrails { get; set; } = new List<DueReceiptsAuditTrail>();

    public virtual ICollection<HomeOwnersAuditTrail> HomeOwnersAuditTrails { get; set; } = new List<HomeOwnersAuditTrail>();

    public virtual ICollection<UsersAuditTrail> UsersAuditTrails { get; set; } = new List<UsersAuditTrail>();
}
