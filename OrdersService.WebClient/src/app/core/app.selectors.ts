import { OrdersState } from './';
import { createSelector, createFeatureSelector } from '@ngrx/store';
import { OrderDto, PagedResult } from '../domain';

const ordersState = createFeatureSelector<OrdersState>('orders');

export const getOrders = createSelector(ordersState, (state: OrdersState): PagedResult<OrderDto[]> => {
  return {
    data: Object.keys(state.entities)
      .map(id => state.entities[id])
      .sort((a, b) => a.orderId.localeCompare(b.orderId)),
    total: state.total || 0
  };
});

export const getPage = createSelector(ordersState, state => state.page);
