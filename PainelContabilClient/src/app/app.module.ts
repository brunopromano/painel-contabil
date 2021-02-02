import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';
import { NgxCurrencyModule } from 'ngx-currency';
import {LOCALE_ID, DEFAULT_CURRENCY_CODE} from '@angular/core';
import localePt from '@angular/common/locales/pt';
import {registerLocaleData} from '@angular/common';
registerLocaleData(localePt, 'pt-BR');

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { LancamentosComponent } from './lancamentos/lancamentos.component';
import { RelatorioMensalComponent } from './relatorio-mensal/relatorio-mensal.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    LancamentosComponent,
    RelatorioMensalComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
    ModalModule.forRoot(),
    ButtonsModule.forRoot(),
    HttpClientModule,
    NgxCurrencyModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [{
    provide: LOCALE_ID,
    useValue: 'pt-BR'
  },
  {
    provide:  DEFAULT_CURRENCY_CODE,
    useValue: 'BRL'
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
