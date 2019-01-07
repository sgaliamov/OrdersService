import { Component, Input, EventEmitter, Output } from '@angular/core';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { OrderDto, PagedResult } from '../../domain';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.scss']
})
export class OrdersListComponent {
  @Input()
  page = 1;

  @Input()
  readonly data: PagedResult<OrderDto[]>;

  @Input()
  readonly pageSize = 5;

  @Output()
  readonly pageChanged: EventEmitter<number> = new EventEmitter<number>();

  dataStateChange(state: DataStateChangeEvent): void {
    this.page = (state.skip / this.pageSize) + 1;
    this.pageChanged.emit(this.page);
  }
}
