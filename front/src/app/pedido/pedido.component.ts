import { Component, OnInit } from '@angular/core';
import { PedidoService } from './../app.component.service';
import { IPedido } from '../../app/models/IPedido';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-pedido',
  templateUrl: './pedido.component.html',
  styleUrls: ['./pedido.component.scss']
})
export class PedidoComponent implements OnInit {

  pedidosResponse: IPedido[];
  messagens: string[];
  loadingImportacao: boolean = false;
  id : string;

  constructor(
    private pedidoService: PedidoService,
    private route: ActivatedRoute,
    private router: Router,
  ) {
  }

  ngOnInit(): void {
    
    this.route.params.subscribe(params => {
      this.id = params['id'];

      this.getImportacoes();
    });    
  }

  async getImportacoes() {

    await this.pedidoService.get(this.id)
      .then(result => {
        this.pedidosResponse = result;
      },
      );

    this.loadingImportacao = true;
  }

  onBack() {
    this.router.navigate(['home']); 
  }

}
