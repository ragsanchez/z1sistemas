import { Component, OnInit } from '@angular/core';
import * as XLSX from 'xlsx';
import * as FileSaver from 'file-saver';
import { PedidoService } from './app.component.service';
import { IPedido } from '../app/models/IPedido';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent  {
  
  title = 'Teste Angular';  

  constructor(    
  ) {
  }

  ngOnInit() {
  
  }

}




