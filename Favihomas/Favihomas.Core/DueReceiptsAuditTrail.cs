using System;
using System.Collections.Generic;

namespace Favihomas.Core;

public partial class DueReceiptsAuditTrail
{
    public int AuditTrailId { get; set; }

    public int DueReceiptId { get; set; }

    public int AuditActionId { get; set; }

    public DateTime Date { get; set; }

    public int UserId { get; set; }

    public string Summary { get; set; } = null!;

    public string? Changes { get; set; }

    public virtual AuditAction AuditAction { get; set; } = null!;

    public virtual DueReceipt DueReceipt { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
