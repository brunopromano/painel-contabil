import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConciliacaoDiariaComponent } from './conciliacao-diaria/conciliacao-diaria.component';
import { LancamentosComponent } from './lancamentos/lancamentos.component';
import { RelatorioMensalComponent } from './relatorio-mensal/relatorio-mensal.component';

const routes: Routes = [
  { path: 'relatoriomensal', component: RelatorioMensalComponent},
  { path: 'conciliacaodiaria', component: ConciliacaoDiariaComponent},
  { path: '', component: LancamentosComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
