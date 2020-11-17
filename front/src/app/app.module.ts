import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { PedidoService } from './app.component.service';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS, HttpClient } from '@angular/common/http';
import { PedidoComponent } from './pedido/pedido.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    PedidoComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [PedidoService, HttpClient],
  bootstrap: [AppComponent]
})
export class AppModule { }
