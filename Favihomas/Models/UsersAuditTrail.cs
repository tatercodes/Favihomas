using System;
using System.Collections.Generic;

namespace Favihomas.Models;

public partial class UsersAuditTrail
{
    public int AuditTrailId { get; set; }

    public int UserModifiedId { get; set; }

    public int AuditActionId { get; set; }

    public DateTime Date { get; set; }

    public int UserId { get; set; }

    public string Summary { get; set; } = null!;

    public string? Changes { get; set; }

    public virtual AuditAction AuditAction { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual User UserModified { get; set; } = null!;
}
