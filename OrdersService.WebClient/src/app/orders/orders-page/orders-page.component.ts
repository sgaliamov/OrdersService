import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState, getOrders } from '../../core';
import { OrderDto } from '../../domain';
import { Observable } from 'rxjs/Observable';

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
}
