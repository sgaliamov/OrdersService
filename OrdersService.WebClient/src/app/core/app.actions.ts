import { Action } from '@ngrx/store';
import { OrderDto, OrderModel } from '../domain';

export enum OrderActionTypes {
  LOADED = '[Order] Orders Loaded',
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

  constructor(public readonly payload: { orders: OrderDto[], total: number }) { }
}

export class UpdateOrder implements Action {
  readonly type = OrderActionTypes.UPDATE;

  constructor(public readonly payload: { id: string, order: OrderModel }) { }
}

export class Fail implements Action {
  readonly type = OrderActionTypes.FAIL;

  constructor(public readonly payload: { message: string }) { }
}

export type OrderActions
  = OrdersLoaded
  | UpdateOrder
  | SelectPage
  | Fail;
