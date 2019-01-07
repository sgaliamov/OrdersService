import { EntityState, EntityAdapter, createEntityAdapter } from '@ngrx/entity';
import { OrderDto } from '../domain';

export interface AppState {
  orders: OrdersState;
}

export interface OrdersState extends EntityState<OrderDto> {
  page: number;
  total?: number;
  selectedOrderId?: string;
}

function sortByName(a: OrderDto, b: OrderDto): number {
  return a.orderId.localeCompare(b.orderId);
}

export const ordersAdapter: EntityAdapter<OrderDto> = createEntityAdapter<OrderDto>({
  selectId: (order: OrderDto) => order.orderId,
  sortComparer: sortByName,
});
