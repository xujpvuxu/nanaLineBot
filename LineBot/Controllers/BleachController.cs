using LineBot;
using LineBot.Domain;
using LineBot.DTO.Webhook;
using LineBot.Enums;
using LineBot.ExcelModel;
using LineBot.Models;
using LineBot.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LineBotMessage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BleachController : ControllerBase
    {
        private string SheetId = "1VBAZM0ZiiJdxHc8NaQz3l9djOePRnrqELfM1ImYqiqw";

        [HttpGet("Change")]
        public object Change()
        {
            BleachService bleachService = new BleachService();
            StaticFuntion.GetExcel<BleachModel1>(SheetId, "多的1");
            StaticFuntion.GetExcel<BleachModel2>(SheetId, "多的2");
            List<Need> needs= bleachService.Change(BleachModel1.A1);
            needs.AddRange(bleachService.Change(BleachModel1.A2));
            needs.AddRange(bleachService.Change(BleachModel1.A3));
            needs.AddRange(bleachService.Change(BleachModel1.A4));
            needs.AddRange(bleachService.Change(BleachModel1.A5));
            needs.AddRange(bleachService.Change(BleachModel1.A5));
            needs.AddRange(bleachService.Change(BleachModel1.A6));
            needs.AddRange(bleachService.Change(BleachModel1.A7));
            needs.AddRange(bleachService.Change(BleachModel1.A8));
            needs.AddRange(bleachService.Change(BleachModel1.A9));
            needs.AddRange(bleachService.Change(BleachModel1.A10));
            needs.AddRange(bleachService.Change(BleachModel1.A11));
            needs.AddRange(bleachService.Change(BleachModel1.A12));
            needs.AddRange(bleachService.Change(BleachModel1.A13));
            needs.AddRange(bleachService.Change(BleachModel1.B1));
            needs.AddRange(bleachService.Change(BleachModel1.B2));
            needs.AddRange(bleachService.Change(BleachModel1.B3));
            needs.AddRange(bleachService.Change(BleachModel1.B4));
            needs.AddRange(bleachService.Change(BleachModel1.B5));
            needs.AddRange(bleachService.Change(BleachModel1.B5));
            needs.AddRange(bleachService.Change(BleachModel1.B6));
            needs.AddRange(bleachService.Change(BleachModel1.B7));
            needs.AddRange(bleachService.Change(BleachModel1.B8));
            needs.AddRange(bleachService.Change(BleachModel1.B9));
            needs.AddRange(bleachService.Change(BleachModel1.B10));
            needs.AddRange(bleachService.Change(BleachModel1.B11));
            needs.AddRange(bleachService.Change(BleachModel1.B12));
            needs.AddRange(bleachService.Change(BleachModel1.B13));
            needs.AddRange(bleachService.Change(BleachModel2.C1));
            needs.AddRange(bleachService.Change(BleachModel2.C2));
            needs.AddRange(bleachService.Change(BleachModel2.C3));
            needs.AddRange(bleachService.Change(BleachModel2.C4));
            needs.AddRange(bleachService.Change(BleachModel2.C5));
            needs.AddRange(bleachService.Change(BleachModel2.C5));
            needs.AddRange(bleachService.Change(BleachModel2.C6));
            needs.AddRange(bleachService.Change(BleachModel2.C7));
            needs.AddRange(bleachService.Change(BleachModel2.C8));
            needs.AddRange(bleachService.Change(BleachModel2.C9));
            needs.AddRange(bleachService.Change(BleachModel2.C10));
            needs.AddRange(bleachService.Change(BleachModel2.C11));
            needs.AddRange(bleachService.Change(BleachModel2.C12));
            needs.AddRange(bleachService.Change(BleachModel2.C13));
            needs.AddRange(bleachService.Change(BleachModel2.D1));
            needs.AddRange(bleachService.Change(BleachModel2.D2));
            needs.AddRange(bleachService.Change(BleachModel2.D3));
            needs.AddRange(bleachService.Change(BleachModel2.D4));
            needs.AddRange(bleachService.Change(BleachModel2.D5));
            needs.AddRange(bleachService.Change(BleachModel2.D5));
            needs.AddRange(bleachService.Change(BleachModel2.D6));
            needs.AddRange(bleachService.Change(BleachModel2.D7));
            needs.AddRange(bleachService.Change(BleachModel2.D8));
            needs.AddRange(bleachService.Change(BleachModel2.D9));
            needs.AddRange(bleachService.Change(BleachModel2.D10));
            needs.AddRange(bleachService.Change(BleachModel2.D11));
            needs.AddRange(bleachService.Change(BleachModel2.D12));

            StaticFuntion.GetExcel<BleachModel1>(SheetId, "缺的1");
            StaticFuntion.GetExcel<BleachModel2>(SheetId, "缺的2");
            List<Need> haves= bleachService.Change(BleachModel1.A1);
            haves.AddRange(bleachService.Change(BleachModel1.A2));
            haves.AddRange(bleachService.Change(BleachModel1.A3));
            haves.AddRange(bleachService.Change(BleachModel1.A4));
            haves.AddRange(bleachService.Change(BleachModel1.A5));
            haves.AddRange(bleachService.Change(BleachModel1.A5));
            haves.AddRange(bleachService.Change(BleachModel1.A6));
            haves.AddRange(bleachService.Change(BleachModel1.A7));
            haves.AddRange(bleachService.Change(BleachModel1.A8));
            haves.AddRange(bleachService.Change(BleachModel1.A9));
            haves.AddRange(bleachService.Change(BleachModel1.A10));
            haves.AddRange(bleachService.Change(BleachModel1.A11));
            haves.AddRange(bleachService.Change(BleachModel1.A12));
            haves.AddRange(bleachService.Change(BleachModel1.A13));
            haves.AddRange(bleachService.Change(BleachModel1.B1));
            haves.AddRange(bleachService.Change(BleachModel1.B2));
            haves.AddRange(bleachService.Change(BleachModel1.B3));
            haves.AddRange(bleachService.Change(BleachModel1.B4));
            haves.AddRange(bleachService.Change(BleachModel1.B5));
            haves.AddRange(bleachService.Change(BleachModel1.B5));
            haves.AddRange(bleachService.Change(BleachModel1.B6));
            haves.AddRange(bleachService.Change(BleachModel1.B7));
            haves.AddRange(bleachService.Change(BleachModel1.B8));
            haves.AddRange(bleachService.Change(BleachModel1.B9));
            haves.AddRange(bleachService.Change(BleachModel1.B10));
            haves.AddRange(bleachService.Change(BleachModel1.B11));
            haves.AddRange(bleachService.Change(BleachModel1.B12));
            haves.AddRange(bleachService.Change(BleachModel1.B13));
            haves.AddRange(bleachService.Change(BleachModel2.C1));
            haves.AddRange(bleachService.Change(BleachModel2.C2));
            haves.AddRange(bleachService.Change(BleachModel2.C3));
            haves.AddRange(bleachService.Change(BleachModel2.C4));
            haves.AddRange(bleachService.Change(BleachModel2.C5));
            haves.AddRange(bleachService.Change(BleachModel2.C5));
            haves.AddRange(bleachService.Change(BleachModel2.C6));
            haves.AddRange(bleachService.Change(BleachModel2.C7));
            haves.AddRange(bleachService.Change(BleachModel2.C8));
            haves.AddRange(bleachService.Change(BleachModel2.C9));
            haves.AddRange(bleachService.Change(BleachModel2.C10));
            haves.AddRange(bleachService.Change(BleachModel2.C11));
            haves.AddRange(bleachService.Change(BleachModel2.C12));
            haves.AddRange(bleachService.Change(BleachModel2.C13));
            haves.AddRange(bleachService.Change(BleachModel2.D1));
            haves.AddRange(bleachService.Change(BleachModel2.D2));
            haves.AddRange(bleachService.Change(BleachModel2.D3));
            haves.AddRange(bleachService.Change(BleachModel2.D4));
            haves.AddRange(bleachService.Change(BleachModel2.D5));
            haves.AddRange(bleachService.Change(BleachModel2.D5));
            haves.AddRange(bleachService.Change(BleachModel2.D6));
            haves.AddRange(bleachService.Change(BleachModel2.D7));
            haves.AddRange(bleachService.Change(BleachModel2.D8));
            haves.AddRange(bleachService.Change(BleachModel2.D9));
            haves.AddRange(bleachService.Change(BleachModel2.D10));
            haves.AddRange(bleachService.Change(BleachModel2.D11));
            haves.AddRange(bleachService.Change(BleachModel2.D12));

            return bleachService.Test(needs,haves);
        }


    }

    public class Need
    {
        public string Person { get; set; }
        public string Card { get; set; }
    }
}