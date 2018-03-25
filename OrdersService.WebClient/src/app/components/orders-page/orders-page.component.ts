import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState, getOrders, SelectPage } from '../../core';
import { OrderDto, PagedResult } from '../../domain';
import { Observable } from 'rxjs/Observable';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';

@Component({
  selector: 'app-orders-page',
  templateUrl: './orders-page.component.html',
  styleUrls: ['./orders-page.component.scss']
})
export class OrdersPageComponent implements OnInit {
  private data: Observable<PagedResult<OrderDto[]>>;

  constructor(
    private readonly store: Store<AppState>) {
  }

  ngOnInit() {
    this.data = this.store.select(getOrders);
  }

  pageChanged(page: number) {
    this.store.dispatch(new SelectPage({ page }));
  }

}
