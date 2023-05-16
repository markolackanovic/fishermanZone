import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SharedService } from './shared.service';
import { TranslatePipe } from './pipes/translate.pipe';

@NgModule({
  declarations: [TranslatePipe],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
  ],
  exports: [
    CommonModule,
    FormsModule,
    RouterModule,
    TranslatePipe
  ],
  providers: [
    SharedService
  ]
})
export class SharedModule { }
