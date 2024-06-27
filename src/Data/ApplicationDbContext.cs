using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ApiCrud.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
    public DbSet<UsuarioEntidade> usuarioEntidades { get; set; }
    public DbSet<ImobiliariaEntidade> imobiliariaEntidades { get; set; }

    public DbSet<AgendamentoEntidade> agendamentoEntidades { get; set; }

    protected override void OnModelCreating(ModelBuilder optionsBuilder)
    {
        base.OnModelCreating(optionsBuilder);
    }
}
