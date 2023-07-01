using LibraryApp.Data;
using LibraryApp.Entities;
using LibraryApp.Repositories;
using LibraryApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApp
{
    public class Startup
    {
        public ServiceProvider BuildServiceProvider()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<DbContext, LibraryAppDbContext>(options => options.UseInMemoryDatabase("StorageAppDb"))
                .AddScoped<SqlRepository<Reader>>()
                .AddScoped<SqlRepository<Book>>()
                .AddTransient<DbSeeder>()
                .AddTransient<TerminalService>()//.AddTransient<ITerminalService, TerminalService>()
                .AddTransient<Terminal>()
                .BuildServiceProvider();

            var seeder = serviceProvider.GetService<DbSeeder>();
            Seed(seeder);

            return serviceProvider;
        }

        private void Seed(DbSeeder? seeder)
        {
            if (seeder is not null)
            {
                seeder.Seed();
                return;
            }

            Console.WriteLine("Problem z przygotowaniem bazy");
        }
        internal void CreateDir()
        {
            string folderPath = "SavedInFile";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Console.WriteLine("Folder został utworzony.");
            }
        }
    }
}
