import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { LoginComponent } from './login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from './shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { NgxIntlTelInputModule } from 'ngx-intl-tel-input';
import { CoreModule } from './core/core.module';
import { AssociationComponent } from './admin/association/association.component';
import { DashboardComponent } from './super-admin/dashboard/dashboard.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './public/home/home.component';
import { AssociationRegistrationComponent } from './super-admin/associations/registration/association-registration.component';
import { AssociationsListComponent } from './super-admin/associations/list/associations-list.component';
import { AssociationProfileComponent } from './admin/association/association-profile/association-profile.component';
import { AssociationMembersComponent } from './admin/association/association-members/association-members.component';
import { AssociationPostsComponent } from './admin/association/association-posts/association-posts.component';
import { AssociationProfileEditComponent } from './admin/association/association-profile/edit/association-profile-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    AssociationRegistrationComponent,
    AssociationComponent,
    DashboardComponent,
    NavbarComponent,
    AssociationsListComponent,
    AssociationProfileComponent,
    AssociationProfileEditComponent,
    AssociationMembersComponent,
    AssociationPostsComponent
  ],
  imports: [
    CoreModule,
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    SharedModule,
    NgxIntlTelInputModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports: [
  ]
})
export class AppModule { }
