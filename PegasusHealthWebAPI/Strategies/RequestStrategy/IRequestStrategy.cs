using System.Collections.Generic;
using System.Threading.Tasks;
using PegasusHealthWebAPI.Models;

namespace PegasusHealthWebAPI.Strategies.RequestStrategy {
    public interface IRequestStrategy {
        public Task CreateRequest(IEnumerable<SupplyRequest> postSupplyRequests);
    }
}