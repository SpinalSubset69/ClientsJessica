using Clients.Dtos.BillsDtos;
using Clients.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clients.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillsController : ControllerBase
    {
        private readonly BillsService _billsService;

        public BillsController(BillsService billsService)
        {
            _billsService = billsService;
        }

        [HttpGet]
        public async Task<IEnumerable<BillsDto>> GetAllBills()
        {            
            return await _billsService.GetAllBillsAsync();
        }

        [HttpPost]
        public async Task CreateBill([FromBody] CreateBillsDto billsDto)
        {
            await _billsService.AddBill(billsDto);
        }
    }
}
