import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BalancoDia } from '../_models/BalancoDia';

@Component({
  selector: 'app-conciliacao-diaria',
  templateUrl: './conciliacao-diaria.component.html',
  styleUrls: ['./conciliacao-diaria.component.css']
})
export class ConciliacaoDiariaComponent implements OnInit {

  conciliacaoDiariaForm: FormGroup;
  baseUrl = 'https://localhost:5001/api/balancodiario';
  conciliacaoDiaria: BalancoDia;

  constructor(
      private http: HttpClient
    , private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.conciliacaoDiariaForm = this.fb.group({
      dataConciliacao: ['', Validators.required]
    });
  }

  getConciliacaoDiaria() {
    this.http.get<BalancoDia>(`${this.baseUrl}/${this.conciliacaoDiariaForm.get('dataConciliacao').value}`).subscribe(
      (response: BalancoDia) => {
        this.conciliacaoDiaria = response;
        console.log(this.conciliacaoDiaria);
      }, error => {
        console.log(error);
        this.conciliacaoDiaria = null;
      });
  }
}

