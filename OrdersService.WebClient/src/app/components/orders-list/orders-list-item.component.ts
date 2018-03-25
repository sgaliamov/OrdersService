import { Component, Input } from '@angular/core';
import { OrderDto } from '../../domain';

@Component({
  selector: 'app-orders-list-item',
  templateUrl: './orders-list-item.component.html',
  styleUrls: ['./orders-list-item.component.scss']
})
export class OrdersListItemComponent {
  @Input()
  public readonly order: OrderDto;
}
