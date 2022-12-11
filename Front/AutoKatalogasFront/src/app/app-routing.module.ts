import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AutomobiliaiComponent } from './automobiliai/automobiliai.component'
import { DalysComponent } from './dalys/dalys.component';
import { AutomobiliaiFormComponent } from './automobiliai-form/automobiliai-form.component';
import { DalysFormComponent } from './dalys-form/dalys-form.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { AprasymasComponent } from './aprasymas/aprasymas.component';
import { AprasymasFormComponent } from './aprasymas-form/aprasymas-form.component';
import { SchemaComponent } from './schema/schema.component';
import { SchemaFormComponent } from './schema-form/schema-form.component';

const routes: Routes = [
  { path: 'automobiliai', component: AutomobiliaiComponent},
  { path: 'dalys', component: DalysComponent },
  { path: 'dalys-add', component: DalysFormComponent },
  { path: 'dalys/:id', component: DalysFormComponent },
  { path: 'automobiliai/:id', component: AutomobiliaiFormComponent},
  { path: 'automobiliai-add', component: AutomobiliaiFormComponent},
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent},
  { path: 'home', component: HomeComponent},
  { path: 'aprasymas', component: AprasymasComponent},
  { path: 'aprasymas-add', component: AprasymasFormComponent},
  { path: 'aprasymas/:id', component: AprasymasFormComponent},
  { path: 'schema', component: SchemaComponent},
  { path: 'schema-add', component: SchemaFormComponent},
  { path: 'schema/:id', component: SchemaFormComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
