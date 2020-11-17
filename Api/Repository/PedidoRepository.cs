using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteLab.Models;

namespace TesteLab.Repository
{
    public class PedidoRepository
    {
        public void Incluir(Pedido pedido)
        {
            using (var db = new TesteLabContext())
            {
                db.Pedidos.Add(pedido);
                db.SaveChanges();
            }
        }

        public List<Pedido> Obter(int id)
        {
            using (var db = new TesteLabContext())
            {
                return db.Pedidos.Where(m => m.Id == id)
                                 .Select(m => new Pedido
                                 {
                                    Id = m.Id,                                     
                                     ItemPedidos = m.ItemPedidos.Select(p => new ItemPedido
                                    {
                                        Id = p.Id,
                                        NomeProduto = p.NomeProduto,
                                        Quantidade = p.Quantidade,
                                        ValorUnitario = p.ValorUnitario,
                                        Idpedido = p.Idpedido,
                                        DataEntrega = p.DataEntrega,
                                        //IdpedidoNavigation = p.IdpedidoNavigation,
                                    }).ToList()
                                 }).ToList();
            }
        }

        public List<Pedido> ObterTodos()
        {
            using (var db = new TesteLabContext())
            {
                //return db.Pedidos.ToList();

                return db.Pedidos
                 .Select(m => new Pedido
                 {
                     Id = m.Id,
                     ItemPedidos = m.ItemPedidos.Select(p => new ItemPedido
                     {
                         Id = p.Id,
                         NomeProduto = p.NomeProduto,
                         Quantidade = p.Quantidade,
                         ValorUnitario = p.ValorUnitario,
                         Idpedido = p.Idpedido,
                         DataEntrega = p.DataEntrega,
                         //IdpedidoNavigation = p.IdpedidoNavigation,
                                     }).ToList()
                 }).ToList();
            }
        }
    }
}
