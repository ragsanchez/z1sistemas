import { Component, OnInit } from '@angular/core';
import { PedidoService } from './../app.component.service';
import { IPedido } from '../../app/models/IPedido';
import * as XLSX from 'xlsx';
import * as FileSaver from 'file-saver';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  pedidosResponse: IPedido[];
  messagens: string[];
  loadingImportacao: boolean = false;

  fileUploaded: File;
  title = 'shell-testeAngular';
  storeData: any;
  worksheet: any;
  jsonData: any;
  retorno: any;
  pedidos: any;
  

  constructor(
    private pedidoService: PedidoService,
    private route: ActivatedRoute,
    private router: Router,
  ) {
  }

  ngOnInit(): void {
    this.getImportacoes();
  }

  async getImportacoes() {

    await this.pedidoService.getAll()
      .then(result => {
        this.pedidosResponse = result;
      },
      );

    this.loadingImportacao = true;
  }

  fileAsJson() {
    this.jsonData = XLSX.utils.sheet_to_json(this.worksheet, { raw: false });
    this.jsonData = JSON.stringify(this.jsonData);
    const data: Blob = new Blob([this.jsonData], { type: "application/json" });
    FileSaver.saveAs(data, "JsonFile" + new Date().getTime() + '.json');    
  }

  readAsJson() {
    this.jsonData = XLSX.utils.sheet_to_json(this.worksheet, { raw: false });

    this.pedidoService.importar(JSON.stringify(this.jsonData)).subscribe(res => {
      this.retorno = res;
    });

    //TODO: CAPTURAR O ÚLTIMO ID INSERIDO EM  this.retorno 
    this.router.navigate(['importacao/10']); 
  }

  uploadedFile(event) {
    this.fileUploaded = event.target.files[0];

    this.readExcel()    
  }

  readExcel() {
    let readFile = new FileReader();
    readFile.onload = (e) => {
      this.storeData = readFile.result;
      var data = new Uint8Array(this.storeData);
      var arr = new Array();
      for (var i = 0; i != data.length; ++i) arr[i] = String.fromCharCode(data[i]);
      var bstr = arr.join("");
      var workbook = XLSX.read(bstr, { type: "binary" });
      var first_sheet_name = workbook.SheetNames[0];
      this.worksheet = workbook.Sheets[first_sheet_name];
    }
    return readFile.readAsArrayBuffer(this.fileUploaded);
  }

}
