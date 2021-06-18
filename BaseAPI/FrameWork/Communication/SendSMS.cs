using FrameWork.Communication.Models.SMS;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork.Communication
{
    public static class SendSMS
    {
        public static bool SmsDotIR(SmsModel sms)
        {
            var client = new RestClient(sms.Url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("postman-token", "fcddb5f4-dc58-c7d5-4bf9-9748710f8789");
            request.AddHeader("cache-control", "no-cache");
            request.AddParameter("application/x-www-form-urlencoded", $"username={sms.UserName}&password={sms.Password}&to={sms.To}&from={sms.From}&text={sms.Body}&isflash=false", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
