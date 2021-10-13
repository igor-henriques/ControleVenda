using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Infra.SMS
{
    public class MobileMessage
    {
        public static async Task SendSMS(string telefone, string conteudo)
        {
            string accountSid = "AC0c6eb66f566d0da1f8d9d8c954dd3f6b";
            string authToken = "7dbfeb060c3d1dc1f9782bc05853ea16";

            TwilioClient.Init(accountSid, authToken);

            await Task.Run(() =>  MessageResource.Create(
                body: conteudo,
                from: new Twilio.Types.PhoneNumber("+12088261797"),
                to: new Twilio.Types.PhoneNumber(telefone)
            ));
        }
    }
}
