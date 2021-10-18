using System;

namespace Infra.SMS.Request
{
    [Serializable]
    public record RequestSendSMS
    {
        public string Key { get; init; }
        public byte Type { get; init; }
        public string Number { get; init; }
        public string Msg { get; init; }

        public static RequestSendSMS TratarNumero(RequestSendSMS request)
        {
            return request with
            {
                Number = $"55{request.Number.Replace("(", default).Replace(")", default).Replace("-", default).Replace(" ", default).Trim()}"
            };
        }
    }    
}