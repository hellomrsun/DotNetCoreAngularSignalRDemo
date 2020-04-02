import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InfoPopupComponent } from './components/info-popup/info-popup.component';
import { NzModalModule } from 'ng-zorro-antd';

@NgModule({
  declarations: [
    InfoPopupComponent
  ],
  imports: [
    CommonModule,
    NzModalModule
  ],
  exports: [
    InfoPopupComponent
  ]
})
export class SharedModule { }
