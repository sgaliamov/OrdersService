import { Component, Input, EventEmitter, Output } from '@angular/core';
import { DataStateChangeEvent, GridDataResult } from '@progress/kendo-angular-grid';
import { State } from '@progress/kendo-data-query';
import { OrderDto } from '../../domain';


@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.scss']
})
export class OrdersListComponent {
  skip = 0;

  @Input()
  readonly orders: OrderDto[];

  @Input()
  readonly pageSize = 10;

  @Output()
  readonly pageChanged: EventEmitter<number> = new EventEmitter<number>();

  dataStateChange(state: DataStateChangeEvent): void {
    this.skip = state.skip;
    this.pageChanged.emit(state.skip / this.pageSize);
  }
}
