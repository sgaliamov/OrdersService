import { Action } from '@ngrx/store';
import { OrderDto, OrderEditModel } from '../domain';

export enum OrderActionTypes {
  LOADED = '[Order] Orders Loaded',
  UPSERT = '[Order] Update Order',
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

export class UpsertOrder implements Action {
  readonly type = OrderActionTypes.UPSERT;

  constructor(public readonly payload: { orderId: string, order: OrderEditModel }) { }
}

export class Fail implements Action {
  readonly type = OrderActionTypes.FAIL;

  constructor(public readonly payload: { message: string }) { }
}

export type OrderActions
  = OrdersLoaded
  | UpsertOrder
  | SelectPage
  | Fail;
