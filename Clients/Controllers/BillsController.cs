using AutoMapper;
using Clients.Core.Entities;
using Clients.Core.Interfaces;
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
        private readonly IConfiguration _configuration;

        public BillsController(BillsService billsService, IConfiguration configuration)
        {
            _billsService = billsService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> CreateBill([FromBody] CreateBillsDto billsDto)
        {
            try
            {
                await _billsService.AddBill(billsDto);
                return Ok(true);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonalDataByRFC([FromQuery] string RFC)
        {
            try
            {
                var personalData = await _billsService.GetPersonalDataByRFCAsync(RFC);
                return Ok(personalData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllBills()
        {
            try
            {                
                return Ok(await _billsService.GetAllBillsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("validateaccess")]
        public IActionResult VerifyAccess([FromQuery] string password)
        {
            var pass = _configuration["passwords:bills"]?.ToString();
            return Ok(_billsService.ValidateAccess(pass, password));
        }
    }
}
