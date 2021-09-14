using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PegasusHealthWebAPI.Contexts;
using PegasusHealthWebAPI.DTOs;
using PegasusHealthWebAPI.Models;
using PegasusHealthWebAPI.Strategies.RequestStrategy;

namespace PegasusHealthWebAPI.Controllers
{
    [Route("/requests")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly ControllerHelper _helper;
        private readonly IRequestStrategy _requestStrategy;

        public ClientController(
            DatabaseContext context, 
            ControllerHelper helper, 
            IRequestStrategy requestStrategy) {
            _context = context;
            _helper = helper;
            _requestStrategy = requestStrategy;
        }

        [HttpGet]
        [Route("/all")]
        public async Task<ActionResult<IEnumerable<SupplyRequestDTO>>> GetSupplyRequests() {
            return await _context.SupplyRequests
                .Select(x => _helper.RequestToDTO(x))
                .ToListAsync();
        }

        [HttpGet]
        [Route("/acknowledged")]
        public async Task<ActionResult<IEnumerable<SupplyRequestDTO>>> GetAcknowledgedSupplyRequests() {
            return await _context.SupplyRequests
                .Where(x => x.Acknowledged)
                .Select(x => _helper.RequestToDTO(x))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplyRequestDTO>> GetSupplyRequest(long id)
        {
            var supplyRequest = await _context.SupplyRequests.FindAsync(id);

            if (supplyRequest == null)
            {
                return NotFound();
            }

            return _helper.RequestToDTO(supplyRequest);
        }
        
        [HttpPost]
        [Route("/create")]
        public async Task<ActionResult<SupplyRequestDTO>> PostSupplyRequest(PostSupplyRequestDTO postSupplyRequestDTO) {
            if (postSupplyRequestDTO.supplyRequests == null) {
                return BadRequest();
            }

            await _requestStrategy.CreateRequest(postSupplyRequestDTO.supplyRequests);

            return Created(
                nameof(CreatedResult), 
                postSupplyRequestDTO);
        }
    }
}
