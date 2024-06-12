using System;
using System.Collections.Generic;

namespace Favihomas.Models;

public partial class DueReceipt
{
    public int DueReceiptId { get; set; }

    public int HomeOwnerId { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public DateTime DateIssued { get; set; }

    public decimal Amount { get; set; }

    public string? Remarks { get; set; }

    public byte[]? ReceiptImage { get; set; }

    public DateTime DateCreated { get; set; }

    public int CreatedBy { get; set; }

    public DateTime DateUpdated { get; set; }

    public int UpdatedBy { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<DueReceiptDetail> DueReceiptDetails { get; set; } = new List<DueReceiptDetail>();

    public virtual ICollection<DueReceiptsAuditTrail> DueReceiptsAuditTrails { get; set; } = new List<DueReceiptsAuditTrail>();

    public virtual HomeOwner HomeOwner { get; set; } = null!;

    public virtual User UpdatedByNavigation { get; set; } = null!;
}
