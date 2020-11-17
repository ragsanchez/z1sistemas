export interface IPedido {
   id: string;
   dtPedido: string;
   usuario: string;   
   
   itemPedidos: IItemPedido[];
}

export interface IItemPedido {
   id: string;
   dataEntrega: string;
   quantidade: string;
   valorUnitario: string;
   idpedido: string;
   nomeProduto: string;
}