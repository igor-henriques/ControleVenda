using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace ControleVenda.Forms.Utility
{
    public class FormSelector
    {
        private readonly IServiceProvider _services;
        public FormSelector(IServiceProvider services)
        {
            this._services = services;
        }

        /// <summary>
        /// Retorna o Form relativo à tag em parâmetro
        /// </summary>
        /// <param name="formTag"></param>
        /// <returns></returns>
        public Form GetForm(string formTag)
        {
            return formTag switch
            {
                "Venda"         => _services.GetRequiredService<VendaForm>(),
                "Relatorio"     => _services.GetRequiredService<RelatorioForm>(),
                "Produto"       => _services.GetRequiredService<ProdutoForm>(),
                "Cliente"       => _services.GetRequiredService<ClienteForm>(),
                "ConsultaVenda" => _services.GetRequiredService<ConsultaVendaForm>(),
                "SMS"           => _services.GetRequiredService<MessageServiceForm>(),
                "Configuracao"  => _services.GetRequiredService<ConfiguracaoForm>(),
                _ => null
            };
        }
    }
}