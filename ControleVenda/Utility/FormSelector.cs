using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ControleVenda.Forms.Utility
{
    public class FormSelector
    {
        private readonly IServiceProvider _services;
        private Dictionary<string, Form> Menu;
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
            this.Menu = new Dictionary<string, Form>
            {
                { "Venda",      _services.GetRequiredService<VendaForm>()      },
                { "Relatorio",  _services.GetRequiredService<RelatorioForm>()  },
                { "Produto",    _services.GetRequiredService<ProdutoForm>()    },
                { "Cliente",    _services.GetRequiredService<ClienteForm>()    },
            };

            return Menu.Where(item => item.Key.Equals(formTag)).Select(item => item.Value).FirstOrDefault();
        }
    }
}
