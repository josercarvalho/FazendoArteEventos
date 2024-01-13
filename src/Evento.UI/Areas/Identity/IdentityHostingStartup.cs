using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Evento.UI.Areas.Identity.IdentityHostingStartup))]
namespace Evento.UI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}