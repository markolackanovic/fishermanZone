import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SpinnerModule } from './spinner/spinner.module';
import { GlobalEventsManagerService } from './global-events-manager.service';
import { ExceptionService } from './exception.service';
import { OrderByPipe } from './../shared/pipes/order-by.pipe';
import { PaginationModule } from './pagination/pagination.module';
import { ToastModule } from './toast/toast.module';

import { SharedModule } from '../shared/shared.module';





@NgModule({
  imports: [
    SharedModule,
    CommonModule,
    FormsModule,
    RouterModule,
    //BsModalModule,
    SpinnerModule,
    ToastModule,
    PaginationModule,
    ReactiveFormsModule,
    //BreadcrumbModule,

    //SimpleImageUploadModule,
  ],
  exports: [
    CommonModule,
    //BsModalModule,
    FormsModule,
    RouterModule,
    SpinnerModule,
    ToastModule,
    //NullDefaultValueDirective,
    PaginationModule,
    //BreadcrumbModule,
    OrderByPipe,
    ReactiveFormsModule,
    //HasClaimDirective,
    //HasAccessRightDirective,
    //SimpleImageUploadModule,
    //TabComponent,
    //TabsComponent

  ],
  declarations: [ OrderByPipe, /*, TabComponent, TabsComponent, NullDefaultValueDirective, HasClaimDirective, HasAccessRightDirective*/],
  providers: [
    GlobalEventsManagerService, ExceptionService
  ]
})
export class CoreModule { }
