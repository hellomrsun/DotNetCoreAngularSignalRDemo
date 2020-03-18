import { NgModule } from '@angular/core';

import { WelcomeRoutingModule } from './welcome-routing.module';

import { WelcomeComponent } from './welcome.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { BrickComponent } from 'src/app/shared/brick/brick.component';
import { NzCardModule } from 'ng-zorro-antd';
import { ComponentsModule } from 'src/app/components/components.module';

@NgModule({
  imports: [WelcomeRoutingModule, SharedModule, NzCardModule, ComponentsModule],
  declarations: [WelcomeComponent],
  exports: [WelcomeComponent]
})
export class WelcomeModule {}
