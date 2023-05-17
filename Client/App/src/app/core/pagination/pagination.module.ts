import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule } from '@angular/forms';
import { PaginationComponent } from './pagination.component';

@NgModule({
    imports: [CommonModule, FormsModule],
    exports: [PaginationComponent],
    declarations: [PaginationComponent],

})
export class PaginationModule {
}