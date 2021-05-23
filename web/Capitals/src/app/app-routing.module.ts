import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CapitalsComponent } from './capitals/capitals.component';

const routes: Routes = [
  {path: '',   loadChildren: () =>
  import('./capitals/capitals.module').then(m => m.CapitalsModule)}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
