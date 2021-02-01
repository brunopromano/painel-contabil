import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';

import { Lancamento } from '../_models/Lancamento';

@Component({
  selector: 'app-lancamentos',
  templateUrl: './lancamentos.component.html',
  styleUrls: ['./lancamentos.component.css']
})
export class LancamentosComponent implements OnInit {

  lancamento: Lancamento;
  lancamentos: Lancamento[];
  baseUrl = 'https://localhost:5001/api/lancamentofinanceiro';
  fgRegistro: FormGroup;

  constructor(
      private http: HttpClient
    , private fb: FormBuilder
    , private modalService: BsModalService
  ) { }

  ngOnInit(): void {
    this._validaForm();
    this.getLancamentos();
  }

  abreNovoLancamento(template: any): any {
    this.abreModal(template);
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
    this.abreModal(template);
    this.lancamento = lancamento;
    this.fgRegistro.patchValue(lancamento);
  }

  _validaForm(): any {
    this.fgRegistro = this.fb.group({
      dataLancamento: ['', Validators.required],
      valor: ['', [Validators.required, Validators.min(1)]],
      tipo: ['', Validators.required],
      status: ['', Validators.required]
    });
  }

  salvaAlteracao(template: any): void {

  }
}
