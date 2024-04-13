using LineBot;
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
    public class ExcelController : ControllerBase
    {
        /// <summary>
        /// 取用Excel Test(指定Excel)
        /// </summary>
        [HttpGet("Test1")]
        public string[][] ExcelContent()
        {
           return StaticFuntion.GetExcelData("1YWXfVyw11LxV_IkTeOzmbBMfUsMWN5EET5iPxp_bzW8", "Test1");
        }

    }

}