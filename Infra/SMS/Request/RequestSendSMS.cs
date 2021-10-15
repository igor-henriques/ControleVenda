using System;

namespace Infra.SMS.Request
{
    [Serializable]
    public record RequestSendSMS
    {
        public string Key { get; init; }
        private byte Type { get { return 9; } }
        public string Number { get; init; }
        public string Msg { get; init; }
    }
}