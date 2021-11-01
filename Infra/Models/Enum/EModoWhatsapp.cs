using System.ComponentModel;

namespace Infra.Models.Enum
{
    public enum EModoWhatsapp
    {
        [Description("https://api.whatsapp.com/")]
        Web,
        [Description("whatsapp://")]
        Desktop
    }
}
