using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TesteLab.Models;
using TesteLab.Repository;

namespace TesteLab.Services
{
    public class PedidoService : IPedidoService
    {
        PedidoRepository repos;
        List<ResponseValidation> validation;

        public PedidoService()
        {
            repos = new PedidoRepository();
        }

        public Task<List<Pedido>> GetImportacao()
        {
            throw new NotImplementedException();
        }

        public Task<Pedido> GetImportacao(int id)
        {
            throw new NotImplementedException();
        }

        public List<ResponseValidation> Insert(ICollection<ItemPedidoDTO> itens, string Usuario)
        {
            validation = new List<ResponseValidation>();

            Pedido pedido = new Pedido();
            pedido.Usuario = Usuario;

            List<ItemPedido> itensPedido = new List<ItemPedido>();

            ItemPedido itemPedido;
            int count = 1;

            foreach (var dto in itens)
            {
                itemPedido = new ItemPedido();

                itemPedido.DataEntrega = ValidarDataEntrega(dto.DataEntrega, count);
                itemPedido.NomeProduto = ValidarNomeProduto(dto.NomeProduto, count);
                itemPedido.Quantidade = ValidarQuantidade(dto.Quantidade, count);
                itemPedido.ValorUnitario = ValidarValor(dto.ValorUnitario, count);

                itensPedido.Add(itemPedido);

                count++;
            }

            pedido.ItemPedidos = itensPedido;

            return validation;
        }

        private decimal ValidarValor(string valorUnitario, int linha)
        {
            try
            {
                decimal valor = Math.Round(Convert.ToDecimal(valorUnitario, new CultureInfo("en-US")), 2);

                if (valor <= 0)
                    validation.Add(new ResponseValidation { Linha = linha, Campo = valor.ToString(), Mensagem = "O campo valor deve ser maior que 0" });

                return valor;
            }
            catch
            {
                validation.Add(new ResponseValidation { Linha = linha, Campo = valorUnitario, Mensagem = "O campo valor deve ser maior que 0" });
                return 0;
            }
        }

        private string ValidarNomeProduto(string nomeProduto, int linha)
        {
            if (nomeProduto.Length > 50)
            {
                validation.Add(new ResponseValidation { Linha = linha, Campo = nomeProduto, Mensagem = "O campo nome do produto não pode ter mais que 50 caracteres" });
                
                return "";
            }
            else
                return nomeProduto;
        }

        private DateTime ValidarDataEntrega(string dataEntrega, int linha)
        {
            try
            {
                string format = "M/dd/yy";
                DateTime value = DateTime.ParseExact(dataEntrega, format,
                                                     CultureInfo.InvariantCulture,
                                                     DateTimeStyles.None);

                if (value <= DateTime.Now.Date)
                {
                    validation.Add(new ResponseValidation { Linha = linha, Campo = dataEntrega, Mensagem = "A data de entrega não pode ser menor ou igual que o dia atual" });

                    return DateTime.MinValue;
                }
                else
                    return value;
            }
            catch
            {
                validation.Add(new ResponseValidation { Linha = linha, Campo = dataEntrega, Mensagem = "O campo data esta inválido" });

                return DateTime.MinValue;
            }
        }

        private decimal ValidarQuantidade(string quantidade, int linha)
        {
            try
            {
                decimal qtd = Convert.ToDecimal(quantidade);

                if (qtd <= 0)
                    validation.Add(new ResponseValidation { Linha = linha, Campo = quantidade.ToString(), Mensagem = "O campo quantidade deve ser maior que 0" });

                return qtd;                   
            }
            catch
            {
                validation.Add(new ResponseValidation { Linha = linha, Campo = quantidade.ToString(), Mensagem = "O campo quantidade deve ser um número válido" });
                return 0;
            }
        }

    }
}
