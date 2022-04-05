using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserOperationClaimDTO
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OperationClaimName { get; set; }
    }
}
