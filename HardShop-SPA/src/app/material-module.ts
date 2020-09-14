import { NgModule } from '@angular/core';

import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatBadgeModule } from '@angular/material/badge';

@NgModule({
  imports: [MatSidenavModule, MatIconModule, MatBadgeModule],

  exports: [MatSidenavModule, MatIconModule, MatBadgeModule],
})
export class MaterialModule {}
