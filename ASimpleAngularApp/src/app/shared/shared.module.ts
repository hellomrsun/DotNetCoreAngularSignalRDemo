import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrickComponent } from './brick/brick.component';



@NgModule({
  declarations: [BrickComponent],
  imports: [
    CommonModule
  ],
  exports: [
    BrickComponent
  ]
})
export class SharedModule { }
