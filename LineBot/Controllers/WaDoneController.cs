using LineBot.Domain;
using LineBot.DTO.Webhook;
using LineBot.Enums;
using LineBot.Models;
using LineBot.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LineBotMessage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WaDoneController : ControllerBase
    {
        [HttpPost("")]
        public object Test([FromBody] WaDoneRequest request)
        {
            WaDoneService waDoneService = new WaDoneService(request);
            waDoneService.GetWaDone(25);

            return new
            {
                Trans = waDoneService.ResultTransPath,
                Index = waDoneService.ResultPath,
                Result = waDoneService.ResultProperity
            };
        }

        [HttpPost("Cute")]
        public object Test1([FromBody] WaDoneRequest request)
        {
            WaDoneService waDoneService = new WaDoneService(request);
            waDoneService.GetWaDone(18);

            return new
            {
                Trans = waDoneService.ResultTransPath,
                Index = waDoneService.ResultPath,
                Result = waDoneService.ResultProperity
            };
        }
        [HttpGet("")]
        public void WakeUp()
        { 
        
        }

    }

    public class T
    {
        public ProperityStatus Start { get; set; }
        public EProperity Task_Properity { get; set; }
    }
}