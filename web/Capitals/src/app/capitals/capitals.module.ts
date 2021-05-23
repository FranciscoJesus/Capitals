import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CapitalsComponent } from './capitals.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/common/material.module';



@NgModule({
  declarations: [
    CapitalsComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {
        path: '',
        component: CapitalsComponent
      }]),
    FormsModule,   
    ReactiveFormsModule,
    MaterialModule,
  ]
})
export class CapitalsModule { }
