import { Component, Input } from '@angular/core';
import { OrderDto } from '../../domain';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.scss']
})
export class OrdersListComponent {
  @Input()
  public readonly orders: OrderDto[];
}
