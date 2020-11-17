import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { IPedido } from '../app/models/IPedido';

@Injectable()
export class PedidoService {

    pedidos = [];

    constructor(
        private http: HttpClient
    ) { }

    getapi() {        
        //return "http://localhost:5000/pedido/insert"   //real
        return "http://localhost:4200/pedido/insert"    //proxy
    }

    importar(arquivo : string): Observable<any> {
        const httpOptions = {
            headers: new HttpHeaders().set('content-type', 'application/json')                                   
        };

        arquivo = this.replaceAll(arquivo, "Data Entrega","DataEntrega");
        arquivo = this.replaceAll(arquivo, "Nome do Produto","NomeProduto")        
        arquivo = this.replaceAll(arquivo, "Valor Unitário","ValorUnitario");

        const dados = this. http.post<any>(this.getapi(), arquivo, httpOptions)
            .pipe(
                map(data => data.data)
                , catchError(err => {
                    return throwError(err);
                }));

        return dados;
    }

    replaceAll(str, find, replace) {
        var escapedFind=find.replace(/([.*+?^=!:${}()|\[\]\/\\])/g, "\\$1");
        return str.replace(new RegExp(escapedFind, 'g'), replace);
    }   

    async getAll() {        
    
        const httpOptions = {
          headers: new HttpHeaders({
            'Content-Type': 'application/json',            
          }),
        };
    
        const url = "http://localhost:4200/pedido/importacoes";
    
        const pedidos = await this.http.get<IPedido[]>(url, httpOptions)
          .pipe(
            map(res => res.map((sp): IPedido => ({
                id: sp['id'],
                dtPedido: sp['dtPedido'],
                usuario: sp['usuario'],                  
                itemPedidos: sp['itemPedidos'],         
            })))
            , catchError(error => {
              return throwError(error);
            })).toPromise();
    
        return pedidos;
      }

      async get(id) {        
    
        const httpOptions = {
          headers: new HttpHeaders({
            'Content-Type': 'application/json',            
          }),
        };
    
        const url = "http://localhost:4200/pedido/importacoes/" + id;
    
        const pedidos = await this.http.get<IPedido[]>(url, httpOptions)
          .pipe(
            map(res => res.map((sp): IPedido => ({
                id: sp['id'],
                dtPedido: sp['dtPedido'],
                usuario: sp['usuario'],                  
                itemPedidos: sp['itemPedidos'],         
            })))
            , catchError(error => {
              return throwError(error);
            })).toPromise();
    
        return pedidos;
      }
    
}

