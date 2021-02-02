import { HttpClient } from '@angular/common/http';
import { Component, ChangeDetectionStrategy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
// import { BsModalService } from 'ngx-bootstrap/modal';

import { Lancamento } from '../_models/Lancamento';

@Component({
  selector: 'app-lancamentos',
  templateUrl: './lancamentos.component.html',
  styleUrls: ['./lancamentos.component.css']
})
export class LancamentosComponent implements OnInit {

  radioModel = 'Middle';

  baseUrl = 'https://localhost:5001/api/lancamentofinanceiro';
  bodyDeletarLancamento = '';
  fgRegistro: FormGroup;
  lancamento: Lancamento;
  lancamentos: Lancamento[];
  modoSalvar = 'post';

  constructor(
      private http: HttpClient
    , private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this._validaForm();
    this.getLancamentos();
  }

  abreNovoLancamento(template: any): any {
    this.modoSalvar = 'post';
    this.abreModal(template);
    this.fgRegistro.controls.dataLancamento.enable();
  }

  abreModal(template: any): void {
    this.fgRegistro.reset();
    template.show();
  }

  fechaModal(template: any): void {
    template.hide();
  }

  getLancamentos(): any {
    this.http.get<Lancamento[]>(this.baseUrl)
      .subscribe(response => {
        this.lancamentos = response;
        console.log(this.lancamentos);
      }, error => {
        console.log(error);
      });
  }

  editarLancamento(lancamento: Lancamento, template: any) {
    this.modoSalvar = 'put';
    this.abreModal(template);
    this.lancamento = lancamento;
    this.fgRegistro.patchValue(lancamento);
    this.fgRegistro.controls.dataLancamento.disable();
  }

  excluirLancamento(lancamento: Lancamento, template: any) {
    this.abreModal(template);
    this.lancamento = lancamento;
    this.bodyDeletarLancamento = `Tem certeza que deseja excluir o lançamento #${ lancamento.id }, no valor de R$${ lancamento.valor }?`;
  }

  confirmaExclusaoLancamento(template: any) {
    this.http.delete<Lancamento>(`${this.baseUrl}/${this.lancamento.id}`).subscribe(
      () => {
        console.log(template);
        template.hide();
        this.getLancamentos();
      }, error => {
        console.log(error);
      });
  }

  _validaForm(): any {
    this.fgRegistro = this.fb.group({
      dataLancamento: ['', Validators.required],
      valor: ['', [Validators.required, Validators.min(1)]],
      tipo: ['', Validators.required],
      status: ['', Validators.required]
    });
  }

  salvaAlteracao(lancamento: Lancamento, template: any): void {
    if (this.fgRegistro.valid) {
      if (this.modoSalvar === 'post') {
        this.lancamento = Object.assign({}, this.fgRegistro.value);
        this.lancamento.dataLancamento = new Date();
        this.http.post(this.baseUrl, this.lancamento).subscribe(
          (response) => {
            console.log(response);
            template.hide();
            this.getLancamentos();
          }, error => {
            console.log(error);
          });
      } else {
        this.lancamento = Object.assign({id: this.lancamento.id}, this.fgRegistro.value);
        console.log(this.lancamento);
        this.lancamento.dataLancamento = new Date();
        this.http.put(`${this.baseUrl}/${this.lancamento.id}`, this.lancamento).subscribe(
          (response) => {
            console.log(response);
            template.hide();
            this.getLancamentos();
          }, error => {
            console.log(error);
          }
        );
      }
    }
  }
}
