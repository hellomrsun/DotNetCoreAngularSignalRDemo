import { NgModule } from "@angular/core";

import { WelcomeRoutingModule } from "./welcome-routing.module";

import { WelcomeComponent } from "./welcome.component";
import { SharedModule } from 'src/app/shared/shared.module';
import { BrickComponent } from 'src/app/shared/brick/brick.component';

@NgModule({
  imports: [WelcomeRoutingModule, SharedModule],
  declarations: [WelcomeComponent],
  exports: [WelcomeComponent]
})
export class WelcomeModule {}
