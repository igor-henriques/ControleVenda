using System.IO;

namespace Infra.Models
{
    public record Definitions
    {
        public string NomeNegocio { get; private init; }
        public string PIX { get; private init; }
        public string PicPay { get; private init; }

        public Definitions()
        {
            //this.NomeNegocio = File.ReadAllText("./Configurations/Negócio.txt");
            this.NomeNegocio = "Bendita Delivery";
            this.PIX = "061.627.477-78";
            this.PicPay = "@ironside_h";
        }
    }
}
