using System.Linq;
using PegasusHealthWebAPI.Contexts;
using PegasusHealthWebAPI.DTOs;
using PegasusHealthWebAPI.Models;

namespace PegasusHealthWebAPI.Controllers {
    public class ControllerHelper {

        private readonly DatabaseContext _context;

        public ControllerHelper(DatabaseContext context) {
            _context = context;
        }
        
        public bool SupplyRequestExists(long id) => _context.SupplyRequests.Any(e => e.Id == id);

        public SupplyRequestDTO RequestToDTO(SupplyRequest request) =>
            new() {
                RequestId = request.Id,
                Amount = request.Amount,
                MedicalSupplyId = request.MedicalSupplyId,
                VendorId = request.VendorId,
                Acknowledged = request.Acknowledged
            };
    }
}