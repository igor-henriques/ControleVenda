using ControleVenda.Forms;
using ControleVenda.Forms.Utility;
using Domain.Interfaces;
using Domain.Repositories;
using Infra.Data;
using Infra.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleVenda
{
    public static class Program
    {
        [STAThread]
        private static async Task Main()
        {
            try
            {
                await CreateHostBuilder().Build().RunAsync();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogWriter.Write(e.ToString());                
            }            
        }
        private static IHostBuilder CreateHostBuilder()
        {
            string connectionString = ConnectionBuilder.GetConnectionString();

            return Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)),
                    ServiceLifetime.Transient,
                    ServiceLifetime.Transient);

                    services.AddHostedService<StartService>();
                    
                    services.AddSingleton<FormSelector>();
                   
                    services.AddTransient<MainForm>();
                    services.AddTransient<VendaForm>();
                    services.AddTransient<ClienteForm>();
                    services.AddTransient<RelatorioForm>();
                    services.AddTransient<ProdutoForm>();
                    services.AddTransient<ConsultaVendaForm>();

                    services.AddScoped<IClienteRepository, ClienteRepository>();
                    services.AddScoped<IProdutoRepository, ProdutoRepository>();
                    services.AddScoped<IVendaRepository, VendaRepository>();
                    services.AddScoped<ILogRepository, LogRepository>();

                    services.AddLogging(
                    builder =>
                    {
                        builder.AddFilter("Microsoft", LogLevel.Warning)
                               .AddFilter("System", LogLevel.Warning)
                               .AddFilter("NToastNotify", LogLevel.Warning)
                               .AddConsole();
                    }
                    );
                });
        }
    }
}
