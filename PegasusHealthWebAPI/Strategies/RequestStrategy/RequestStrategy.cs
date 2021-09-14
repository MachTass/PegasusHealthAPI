using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PegasusHealthWebAPI.Contexts;
using PegasusHealthWebAPI.DTOs;
using PegasusHealthWebAPI.Models;

namespace PegasusHealthWebAPI.Strategies.RequestStrategy {
    public class RequestStrategy : ControllerBase, IRequestStrategy {

        private readonly DatabaseContext _databaseContext;

        public RequestStrategy(DatabaseContext databaseContext) {
            _databaseContext = databaseContext;
        }
        
        public async Task CreateRequest(IEnumerable<SupplyRequest> postSupplyRequests) {
            foreach (SupplyRequest sr in postSupplyRequests) {
                _databaseContext.SupplyRequests.Add(sr);
            }
            await _databaseContext.SaveChangesAsync();
        }
        
        private bool SupplyRequestExists(long id) => _databaseContext.SupplyRequests.Any(e => e.Id == id);

        private SupplyRequestDTO RequestToDTO(SupplyRequest request) =>
            new() {
                RequestId = request.Id,
                Amount = request.Amount,
                MedicalSupplyId = request.MedicalSupplyId,
                VendorId = request.VendorId,
                Acknowledged = request.Acknowledged
            };
    }
}