using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteLab.Models;

namespace TesteLab.Services
{
    public interface IPedidoService
    {
        Task<List<Pedido>> GetImportacao();

        Task<Pedido> GetImportacao(int id);

        List<ResponseValidation> Insert(ICollection<ItemPedidoDTO> itens, string Usuario); 
    }
}
