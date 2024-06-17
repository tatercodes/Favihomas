using Favihomas.Core;
using Favihomas.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Favihomas.Service.Services
{
    public class AuditActionService : IAuditActionService
    {
        private readonly AppDBContext _context;

        public AuditActionService(AppDBContext context) { 
        
            _context = context;
        }
        public List<AuditAction> GetAllAuditActions() {

            var auditActions = _context.AuditActions.ToList();

            return auditActions;
        }

    }
}
