import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AssociationComponent } from './admin/association/association.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './public/home/home.component';
import { AssociationRegistrationComponent } from './super-admin/associations/registration/association-registration.component';
import { AssociationsListComponent } from './super-admin/associations/list/associations-list.component';
import { DashboardComponent } from './super-admin/dashboard/dashboard.component';
import { AssociationProfileEditComponent } from './admin/association/association-profile/edit/association-profile-edit.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'home' },
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'admin/udruzenje/:id', component: AssociationComponent },
  { path: 'admin/udruzenje/:id/edit', component: AssociationProfileEditComponent },
  { path: 'super-admin/dashboard', component: DashboardComponent },
  { path: 'super-admin/udruzenja/add', component: AssociationRegistrationComponent },
  { path: 'super-admin/udruzenja/edit/:id', component: AssociationRegistrationComponent },
  { path: 'super-admin/udruzenja/list', component: AssociationsListComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
