using System.IO;

namespace Infra.SMS
{
    public record ServiceKeySMS
    {
        public string Key { get; private init; }

        public ServiceKeySMS()
        {
            this.Key = File.ReadAllText("./Configurations/MessageServiceKey.txt");
        }
    }
}