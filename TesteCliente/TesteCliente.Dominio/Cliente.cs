using System;

namespace TesteCliente.Dominio
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public Cliente()
        { }
    }
}
