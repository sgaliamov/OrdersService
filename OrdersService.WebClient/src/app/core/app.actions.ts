import { Action } from '@ngrx/store';
import { Order } from './';


export enum OrderActionTypes {
  LOAD_ORDERS = '[Order] Load Orders',
  ADD_ORDER = '[Order] Add Order',
  UPDATE_ORDER = '[Order] Update Order'
}

export class LoadOrders implements Action {
  readonly type = OrderActionTypes.LOAD_ORDERS;
}

export class AddOrder implements Action {
  readonly type = OrderActionTypes.ADD_ORDER;

  constructor(public readonly payload: { order: Order }) { }
}

export class UpdateOrder implements Action {
  readonly type = OrderActionTypes.UPDATE_ORDER;

  constructor(public readonly payload: { id: string; order: Order }) { }
}
