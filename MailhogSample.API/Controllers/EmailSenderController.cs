using MailhogSample.API.Controllers.Models;
using MailhogSample.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MailhogSample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSenderController : ControllerBase
    {
        [Route("send")]
        [HttpPost]
        public async Task<IActionResult> SendEmail([FromServices] EmailService emailService, [FromBody] EmailSenderModel model)
        {
            try
            {
                await emailService.SendEmail(model.Subject, model.Body, model.From, model.To, model.Bcc, model.EmailDisplayName);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
