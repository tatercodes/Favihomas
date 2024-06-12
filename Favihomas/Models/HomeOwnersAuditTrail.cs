using System;
using System.Collections.Generic;

namespace Favihomas.Models;

public partial class HomeOwnersAuditTrail
{
    public int AuditTrailId { get; set; }

    public int HomeOwnerId { get; set; }

    public int AuditActionId { get; set; }

    public DateTime Date { get; set; }

    public int UserId { get; set; }

    public string Summary { get; set; } = null!;

    public string? Changes { get; set; }

    public virtual AuditAction AuditAction { get; set; } = null!;

    public virtual HomeOwner HomeOwner { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
