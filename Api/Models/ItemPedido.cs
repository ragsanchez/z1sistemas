using System;
using System.Collections.Generic;

#nullable disable

namespace TesteLab.Models
{
    public partial class ItemPedido
    {
        public int Id { get; set; }
        public DateTime DataEntrega { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Idpedido { get; set; }
        public string NomeProduto { get; set; }

        public virtual Pedido IdpedidoNavigation { get; set; }
    }
}
