﻿using System;
using System.Collections.Generic;

namespace Favihomas.Models;

public partial class DueReceiptDetailsAuditTrail
{
    public int AuditTrailId { get; set; }

    public int DueReceipDetailtId { get; set; }

    public int AuditActionId { get; set; }

    public DateTime Date { get; set; }

    public int UserId { get; set; }

    public string Summary { get; set; } = null!;

    public string? Changes { get; set; }

    public virtual AuditAction AuditAction { get; set; } = null!;

    public virtual DueReceiptDetail DueReceipDetailt { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
