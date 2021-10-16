using ControleVenda.Forms;
using ControleVenda.Forms.Utility;
using Domain.Interfaces;
using Domain.Repositories;
using Infra.Data;
using Infra.Helpers;
using Infra.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
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
                CreateDefaultDirectories();

                CheckConnection();

                await CreateHostBuilder().Build().RunAsync();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogWriter.Write(e.ToString());
            }
        }
        private static void CheckConnection()
        {
            if (!CheckInternetConnection())
            {
                bool connectionRestored = false;

                while (!connectionRestored && MessageBox.Show("Conexão instável. Verifique sua rede e tente novamente", "ERRO DE CONEXÃO", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error).Equals(DialogResult.Retry))
                {
                    connectionRestored = CheckInternetConnection();
                }

                if (!connectionRestored)
                {
                    Process.GetCurrentProcess().Kill();
                }
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
                    services.AddSingleton<Settings>();

                    services.AddTransient<MainForm>();
                    services.AddTransient<VendaForm>();
                    services.AddTransient<ClienteForm>();
                    services.AddTransient<RelatorioForm>();
                    services.AddTransient<ProdutoForm>();
                    services.AddTransient<ConsultaVendaForm>();
                    services.AddTransient<MessageServiceForm>();
                    services.AddTransient<ConfiguracaoForm>();

                    services.AddScoped<IClienteRepository, ClienteRepository>();
                    services.AddScoped<IProdutoRepository, ProdutoRepository>();
                    services.AddScoped<IVendaRepository, VendaRepository>();
                    services.AddScoped<ILogRepository, LogRepository>();
                    services.AddScoped<IRelatorioRepository, RelatorioRepository>();
                    services.AddScoped<ISMSRepository, SMSRepository>();

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
        private static bool CheckInternetConnection(int timeoutMs = 10000, string url = null)
        {
            try
            {
                url ??= "http://www.gstatic.com/generate_204";

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.KeepAlive = false;
                request.Timeout = timeoutMs;

                using (var response = (HttpWebResponse)request.GetResponse())
                    return true;
            }
            catch
            {
                return false;
            }
        }
        private static void CreateDefaultDirectories()
        {
            if (!Directory.Exists("./Relatórios"))          Directory.CreateDirectory("./Relatórios");            
            if (!Directory.Exists("./Pendências Clientes")) Directory.CreateDirectory("./Pendências Clientes");            
        }
    }
}
