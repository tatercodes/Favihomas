using Favihomas.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Favihomas.MVC.Controllers
{
    public class AuditActionController : Controller
    {
        private readonly IAuditActionService _auditActionService;

        public AuditActionController(IAuditActionService auditActionService) {

            _auditActionService = auditActionService;
        }
        public IActionResult Index()
        {
            var auditActions = _auditActionService.GetAllAuditActions();
            return View(auditActions);
        }
    }
}
