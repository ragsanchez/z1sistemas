using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteCliente.Dominio;

namespace TesteCliente.Services
{
    public interface IClienteService
    {
        Task<Cliente> GetCliente(Guid id);

        void DeleteCliente(Guid id);

        void UpdateCliente(Cliente cliente);

        void InsertCliente(Cliente cliente);
    }
}
