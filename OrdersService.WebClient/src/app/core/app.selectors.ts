import { AppState, OrdersState } from './';
import { createSelector, createFeatureSelector } from '@ngrx/store';

const ordersState = createFeatureSelector<OrdersState>('orders');

export const getOrders = createSelector(ordersState, (state: OrdersState) => {
  return Object.keys(state.entities).map(id => state.entities[id]);
});
