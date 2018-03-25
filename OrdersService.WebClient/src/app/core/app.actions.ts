import { Action } from '@ngrx/store';
import { OrderDto, OrderModel } from '../domain';


export enum OrderActionTypes {
  LOADED = '[Order] Orders Loaded',
  ADD = '[Order] Add Order',
  UPDATE = '[Order] Update Order',
  SELECT_PAGE = '[Order] Select Page',
  FAIL = '[Order] Fail'
}

export class SelectPage implements Action {
  readonly type = OrderActionTypes.SELECT_PAGE;

  constructor(public readonly payload: { page: number }) { }
}

export class OrdersLoaded implements Action {
  readonly type = OrderActionTypes.LOADED;

  constructor(public readonly payload: { orders: OrderDto[] }) { }
}

export class AddOrder implements Action {
  readonly type = OrderActionTypes.ADD;

  constructor(public readonly payload: { order: OrderModel }) { }
}

export class UpdateOrder implements Action {
  readonly type = OrderActionTypes.UPDATE;

  constructor(public readonly payload: { order: OrderDto }) { }
}

export class Fail implements Action {
  readonly type = OrderActionTypes.FAIL;

  constructor(public readonly payload: { message: string }) { }
}

export type OrderActions
  = OrdersLoaded
  | AddOrder
  | UpdateOrder
  | SelectPage
  | Fail;
