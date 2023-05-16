import { Component, OnInit, OnChanges, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'app-pagination',
    templateUrl: 'pagination.component.html',
    styleUrls: ['pagination.component.css'],
})
export class PaginationComponent implements OnInit, OnChanges {
    @Input() offset: number = 0;
    @Input() limit: number = 0;//broj elemenata po stranici
    @Input() size: number = 0;//broj elemenata
    @Input() range: number = 3;//broj stranica prije i posle trenutne
    @Output() pageChange: EventEmitter<number> = new EventEmitter<number>();
    @Output() limitChangeValue: EventEmitter<number> = new EventEmitter<number>();

    public pages: number[] | undefined;
    public currentPage: number = 0;
    public totalPages: number =0;

    public limitList: number[] = [5, 10, 20, 50];

    public firstPageText: string = 'Prva';
    public previousPageText: string = 'Prethodna';
    public nextPageText: string = 'Sljedeća';
    public lastPageText: string = 'Posljednja';

    constructor() { }

    ngOnInit() {
        this.getPages(this.offset, this.limit, this.size);
    }

    ngOnChanges() {
        this.getPages(this.offset, this.limit, this.size);
    }

    getPages(offset: number, limit: number, size: number) {
        this.currentPage = this.getCurrentPage(offset, limit);
        this.totalPages = this.getTotalPages(limit, size);

        this.pages = [];

        for (var i = -this.range; i <= this.range * 2 + 1; i++) {
            let page = this.currentPage + i;
            if (this.isValidPageNumber(page, this.totalPages) && page <= this.currentPage + this.range) {
                this.pages.push(page);
            }
        }
    }

    isValidPageNumber(page: number, totalPages: number): boolean {
        return page > 0 && page <= totalPages;
    }

    getCurrentPage(offset: number, limit: number): number {
        return Math.floor(offset / limit) + 1;
    }

    getTotalPages(limit: number, size: number): number {
        let totalPages = Math.ceil(Math.max(size, 1) / Math.max(limit, 1));
        return totalPages;
    }

  selectPage(page: number, $event: any) {
        if (this.isValidPageNumber(page, this.totalPages)) {
            this.pageChange.emit((page - 1) * this.limit);
        }
    }

    limitChange(value: number) {

        this.limitChangeValue.emit(value);
    }

  cancelEvent($event: any) {
        event!.preventDefault();
    }
}
