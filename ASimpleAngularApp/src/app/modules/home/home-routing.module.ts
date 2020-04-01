import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WineRegionsComponent } from './pages/wine-regions/wine-regions.component';
import { GrapesComponent } from './pages/grapes/grapes.component';
import { AddGrapeComponent } from './pages/add-grape/add-grape.component';
import { NzFormModule } from 'ng-zorro-antd';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'wine-regions' },
  { path: 'wine-regions', component: WineRegionsComponent },
  { path: 'grapes', component: GrapesComponent },
  { path: 'add-grape', component: AddGrapeComponent }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
