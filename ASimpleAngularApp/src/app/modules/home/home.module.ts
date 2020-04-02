import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { WineRegionsComponent } from './pages/wine-regions/wine-regions.component';
import { NzCardModule, NzTableModule, NzFormModule, NzPopconfirmModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GrapesComponent } from './pages/grapes/grapes.component';
import { AddGrapeComponent } from './pages/add-grape/add-grape.component';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [WineRegionsComponent, GrapesComponent, AddGrapeComponent],
  imports: [
    CommonModule,
    HomeRoutingModule,
    NzCardModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NzPopconfirmModule,
    SharedModule
  ],
  exports: [WineRegionsComponent, GrapesComponent, AddGrapeComponent]
})
export class HomeModule { }
