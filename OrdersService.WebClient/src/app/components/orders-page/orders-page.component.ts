import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState, getOrders, SelectPage, getPage } from '../../core';
import { OrderDto, PagedResult } from '../../domain';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-orders-page',
  templateUrl: './orders-page.component.html',
  styleUrls: ['./orders-page.component.scss']
})
export class OrdersPageComponent implements OnInit {
  data: Observable<PagedResult<OrderDto[]>>;
  page: Observable<number>;

  constructor(
    private readonly store: Store<AppState>) {
  }

  ngOnInit() {
    this.data = this.store.select(getOrders);
    this.page = this.store.select(getPage);
  }

  pageChanged(page: number) {
    this.store.dispatch(new SelectPage({ page }));
  }
}
