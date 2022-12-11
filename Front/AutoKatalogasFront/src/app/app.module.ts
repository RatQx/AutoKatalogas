import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { AutomobiliaiComponent } from './automobiliai/automobiliai.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AutomobiliaiFormComponent } from './automobiliai-form/automobiliai-form.component';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { DalysComponent } from './dalys/dalys.component';
import { DalysFormComponent } from './dalys-form/dalys-form.component';
import { RegisterComponent } from './register/register.component';
import { AprasymasComponent } from './aprasymas/aprasymas.component';
import { AprasymasFormComponent } from './aprasymas-form/aprasymas-form.component';
import { AppInitializer } from './utils/app.initializer';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { SchemaComponent } from './schema/schema.component';
import { SchemaFormComponent } from './schema-form/schema-form.component';
import { LoadingInterceptor } from './interceptors/loading';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


function initApp(initializer: AppInitializer) {
  return () => initializer.initialize();
}

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    AutomobiliaiComponent,
    AutomobiliaiFormComponent,
    DalysComponent,
    DalysFormComponent,
    RegisterComponent,
    AprasymasComponent,
    AprasymasFormComponent,
    SchemaComponent,
    SchemaFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    ReactiveFormsModule,
    CollapseModule,
    BrowserAnimationsModule
  ],
  providers: [AppInitializer,
    {
      provide: APP_INITIALIZER,
      useFactory: initApp,
      deps: [AppInitializer],
      multi: true,
    },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
