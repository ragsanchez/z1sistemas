using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteCliente.Dominio;
using TesteCliente.Repositorio.FonteDeDados;

namespace TesteCliente.Services
{
    public class ClienteService : IClienteService
    {
        private readonly PersisteContext db;

        public ClienteService()
        {
            db = new PersisteContext();
        }

        public void DeleteCliente(Guid id)
        {
            db.Clientes.Remove(GetCliente(id).Result);

            db.SaveChangesAsync();
        }

        public async Task<Cliente> GetCliente(Guid id)
        {
            return await db.Clientes.FirstOrDefaultAsync(b => b.Id == id);
        }

        public void InsertCliente(Cliente cliente)
        {
            db.Clientes.Add(cliente);

            db.SaveChangesAsync(); 
        }

        public async void UpdateCliente(Cliente cliente)
        {
            db.Clientes.Attach(cliente);

            db.Entry(cliente).State = EntityState.Modified;

            await db.SaveChangesAsync();
        }
    }
}
