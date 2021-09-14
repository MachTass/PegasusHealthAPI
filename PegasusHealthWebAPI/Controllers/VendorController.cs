using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PegasusHealthWebAPI.Contexts;
using PegasusHealthWebAPI.DTOs;

namespace PegasusHealthWebAPI.Controllers {
    [ApiController]
    [Route("/vendor")]
    public class VendorController : ControllerBase {
        private readonly DatabaseContext _context;
        private readonly ControllerHelper _helper;

        public VendorController(
            DatabaseContext context,
            ControllerHelper helper) {
            _context = context;
            _helper = helper;
        }

        [HttpGet]
        [Route("/retrieve")]
        public async Task<ActionResult<IEnumerable<SupplyRequestDTO>>> GetSupplyRequestsForVendor([FromQuery] long vendorId) {
            return await _context.SupplyRequests
                .Where(sr => sr.VendorId == vendorId)
                .Where(sr => !sr.Acknowledged)
                .Select(sr => _helper.RequestToDTO(sr))
                .ToListAsync();
        }
        
        [HttpPut("/acknowledge")]
        public async Task<IActionResult> AcknowledgeSupplyRequest([FromQuery] long requestId)
        {
            var todoItem = await _context.SupplyRequests.FindAsync(requestId);
            if (todoItem == null)
            {
                return NotFound();
            }

            todoItem.Acknowledged = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!_helper.SupplyRequestExists(requestId))
            {
                return NotFound();
            }

            return Ok();
        }
    }
}