using LineBot.DTO.Webhook;
using LineBot.Interfaces;
using LineBot.Service.MessageEventSpace;
using System.Text.RegularExpressions;

namespace LineBot.Domain.MessageEventSpace
{
    public class NorthHospital : BaseResponse, IMessageEventSpace
    {
        public NorthHospital(WebhookEventDto eventObject) : base(eventObject)
        {
        }

        public string Pattern { get; set; } = "^北榮$";

        public void Result()
        {
            List<HospitalModel> myReserve = GetMyReserve();
        }

        private List<HospitalModel> GetMyReserve()
        {
            string uri = @"https://m.vghtpe.gov.tw:8443/MobileWeb/register/find.do?id=F128383222&selMonth=12&selDay=20";
            HttpClient client = new HttpClient();
            return client.GetStringAsync(uri)
                         .Result
                         .Split('\n')
                         .Where(data => !string.IsNullOrWhiteSpace(data))
                         .Select(data => data.Trim())
                         .Where(data => !string.IsNullOrEmpty(data.Split(',').Last()))
                         .Select(data =>
                         {
                             {
                                 string[] detail = data.Split(',');
                                 HospitalModel temp = new HospitalModel
                                 {
                                     Title = detail[2],
                                     Room = detail[3],
                                     DoctorName = detail[4],
                                     MyNumber = detail[5],
                                     TitleID = detail[6],
                                     Date = detail[7],
                                     Position = detail[8],
                                 };

                                 return temp;
                             }
                         }).ToList();
        }
    }
}