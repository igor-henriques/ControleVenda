using ControleVenda.Forms;
using Infra.Helpers;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleVenda
{
    public class StartService : BackgroundService
    {
        private readonly IServiceProvider _services;
        public StartService(IServiceProvider services)
        {
            this._services = services;
        }
        
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {            
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            
            Application.Run(_services.GetRequiredService<MainForm>());
            
            return Task.CompletedTask;
        }
    }
}
