import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { BalancoDia } from '../_models/BalancoDia';

@Component({
  selector: 'app-relatorio-mensal',
  templateUrl: './relatorio-mensal.component.html',
  styleUrls: ['./relatorio-mensal.component.css']
})
export class RelatorioMensalComponent implements OnInit {

  baseUrl = 'https://localhost:5001/api/balancodia';
  mes: number;
  ano: number;
  balancosDias: BalancoDia[];
  relatorioForm: FormGroup;

  constructor(
      private http: HttpClient
    , private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.validation();
    this.getRelatorioMensal();
  }

  validation() {
    this.relatorioForm = this.fb.group({
      mes: ['', [Validators.required, Validators.min(1), Validators.max(12)]],
      ano: ['', [Validators.required, Validators.min(2000)]]
    });
  }

  getRelatorioMensal() {
    this.mes = this.relatorioForm.get('mes').value;
    this.ano = this.relatorioForm.get('ano').value;

    if (this.relatorioForm.valid) {
      this.http.get(`${this.baseUrl}/${this.mes}/${this.ano}`).subscribe(
        (response: BalancoDia[]) => {
          this.balancosDias = response;
          console.log(this.balancosDias);
        }, error => {
          console.log(error);
        }
      );
    }
  }
}
