using LineBot.Domain;
using LineBot.DTO.Webhook;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LineBotMessage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LineBotController : ControllerBase
    {
        private readonly LineBotService LineBotService;

        public LineBotController()
        {
            LineBotService = new LineBotService();
        }

        // 使用 Post 方法的原因是因為這支 API 會接收 Line 傳送的 webhook event，
        [HttpPost("Webhook")]
        public IActionResult Webhook(WebhookRequestBodyDto body)
        {
            LineBotService.ReceiveWebhook(body);
            return Ok();
        }

        [HttpGet("")]
        public int Test()
        {
            return 1;
        }
    }
}