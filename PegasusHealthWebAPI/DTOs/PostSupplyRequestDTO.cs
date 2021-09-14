using System.Collections.Generic;
using PegasusHealthWebAPI.Models;

namespace PegasusHealthWebAPI.DTOs {
    public class PostSupplyRequestDTO {
        public IEnumerable<SupplyRequest> supplyRequests { get; set; }
    }
}