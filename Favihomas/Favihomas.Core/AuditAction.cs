using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Favihomas.Core
{
    public class AuditAction
    {
        [Key]
        public int AuditActionId {  get; set; }
        [Required]
        public string AuditActionName { get; set;}
    }
}
