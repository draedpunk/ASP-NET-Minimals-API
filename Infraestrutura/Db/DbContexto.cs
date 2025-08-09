using Microsoft.EntityFrameworkCore;
using MINIMAL_API.Dominio.Entidades;

namespace MINIMAL_API.Infraestrutura.Db;

public class DbContexto : DbContext
{
    public DbSet<Administrador> Administradores { get; set; } = default!;

    // Construtor que recebe as opções (configurações) do DbContext
    public DbContexto(DbContextOptions<DbContexto> options) : base(options)
    {
    }

    // Pode remover o OnConfiguring ou deixar vazio, já que a config vai vir das options
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Não precisa configurar aqui, a factory e o DI já fazem isso
    }
}
