import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { VehileFormComponent } from './vehile-form/vehile-form.component';

import { VehileService } from './services/vehile.service';

@NgModule({
  declarations: [
    AppComponent,
    VehileFormComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {path: 'vehiles/new', component: VehileFormComponent}
    ])
  ],
  providers: [
    VehileService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
