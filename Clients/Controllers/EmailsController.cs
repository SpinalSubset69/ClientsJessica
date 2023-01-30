using Clients.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clients.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailsController : ControllerBase
    {
        private readonly BillsService _service;

        public EmailsController(BillsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> SendEmails()
        {
            try
            {
                await _service.SendNotification();
                return Ok("Se enviaron los correos");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
