using Favihomas.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Favihomas.Service.Interfaces
{
    public interface IAuditActionService
    {
        List<AuditAction> GetAllAuditActions();
    }
}
