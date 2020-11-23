using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteCliente.Repositorio.FonteDeDados
{
    public class FabricaPersisteContext : IDbContextFactory<PersisteContext>
    {
        private const string CONNECTIONSTRING = @"Data Source=LAPTOP-PB484ON1\SQLEXPRESS;Initial Catalog=TesteCliente;Integrated Security=True";
        
        public PersisteContext CreateDbContext()
        {
            var construtor = new DbContextOptionsBuilder<PersisteContext>();
            construtor.UseSqlServer(CONNECTIONSTRING);
            return new PersisteContext(construtor.Options);
        }
    }
}
