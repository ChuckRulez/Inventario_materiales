using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InventarioMateriales.Data;
using InventarioMateriales.Forms;
using InventarioMateriales.Services;

namespace InventarioMateriales
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Configurar la aplicación
            var services = new ServiceCollection();
            
            // Cargar configuración
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Registrar servicios
            services.AddDbContext<InventarioContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<MaterialService>();
            services.AddScoped<MainForm>();

            var serviceProvider = services.BuildServiceProvider();

            // Ejecutar aplicación
            ApplicationConfiguration.Initialize();
            
            using (var mainForm = serviceProvider.GetRequiredService<MainForm>())
            {
                Application.Run(mainForm);
            }
        }
    }
}
