import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState, getOrders, SelectPage } from '../../core';
import { OrderDto } from '../../domain';
import { Observable } from 'rxjs/Observable';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';

@Component({
  selector: 'app-orders-page',
  templateUrl: './orders-page.component.html',
  styleUrls: ['./orders-page.component.scss']
})
export class OrdersPageComponent implements OnInit {
  private orders: Observable<OrderDto[]>;

  constructor(
    private readonly store: Store<AppState>) {
  }

  ngOnInit() {
    this.orders = this.store.select(getOrders);
  }

  pageChanged(page: number) {
    this.store.dispatch(new SelectPage({ page }));
  }

}
