import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WineRegionsComponent } from './wine-regions/wine-regions.component';
import { NzCardModule } from 'ng-zorro-antd';

@NgModule({
  declarations: [WineRegionsComponent],
  imports: [
    CommonModule,
    NzCardModule
  ],
  exports: [
    WineRegionsComponent
  ]
})
export class ComponentsModule { }
