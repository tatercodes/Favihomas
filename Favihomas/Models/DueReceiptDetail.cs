using System;
using System.Collections.Generic;

namespace Favihomas.Models;

public partial class DueReceiptDetail
{
    public int DueReceipDetailtId { get; set; }

    public int DueReceiptId { get; set; }

    public DateTime DateCovered { get; set; }

    public string? Remarks { get; set; }

    public DateTime DateCreated { get; set; }

    public int CreatedBy { get; set; }

    public DateTime DateUpdated { get; set; }

    public int UpdatedBy { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual DueReceipt DueReceipt { get; set; } = null!;

    public virtual ICollection<DueReceiptDetailsAuditTrail> DueReceiptDetailsAuditTrails { get; set; } = new List<DueReceiptDetailsAuditTrail>();

    public virtual User UpdatedByNavigation { get; set; } = null!;
}
