using System;
using System.Collections.Generic;

#nullable disable

namespace TesteLab.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            ItemPedidos = new HashSet<ItemPedido>();
        }

        public int Id { get; set; }
        public DateTime DtPedido { get; set; }
        public string Usuario { get; set; }

        public virtual ICollection<ItemPedido> ItemPedidos { get; set; }
    }
}
