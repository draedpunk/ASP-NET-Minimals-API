using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MINIMAL_API.Infraestrutura.Db
{
    public class DbContextoFactory : IDesignTimeDbContextFactory<DbContexto>
    {
        public DbContexto CreateDbContext(string[] args)
        {
            // Carrega as configs do appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // pega o diretório do projeto
                .AddJsonFile("appsettings.json") // carrega o arquivo
                .Build();

            // Pega a string de conexão lá do arquivo
            var connectionString = configuration.GetConnectionString("mysql");

            // Configura as opções do DbContext
            var optionsBuilder = new DbContextOptionsBuilder<DbContexto>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            // Cria e retorna o contexto configurado
            return new DbContexto(optionsBuilder.Options);
        }
    }
}
