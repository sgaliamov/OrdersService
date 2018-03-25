import { createEntityAdapter, EntityAdapter, EntityState } from '@ngrx/entity';
import {
  ActionReducer,
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
  MetaReducer
  } from '@ngrx/store';
import { storeFreeze } from 'ngrx-store-freeze';
import { environment } from '../../environments/environment';
import { OrderDto } from '../domain';
import {
  AppState,
  OrderActions,
  OrderActionTypes,
  ordersAdapter,
  OrdersState
  } from './';



const initialState: OrdersState = ordersAdapter.getInitialState({
  page: 1
});

export function ordersReducer(state: OrdersState = initialState, action: OrderActions): OrdersState {
  switch (action.type) {
    case OrderActionTypes.LOADED:
      return ordersAdapter.addAll(action.payload.orders, state);

    case OrderActionTypes.UPDATE:
      return ordersAdapter.upsertOne({
        id: action.payload.order.id,
        changes: action.payload.order
      }, {
          ...state,
          selectedOrderId: action.payload.order.id
        });

    case OrderActionTypes.SELECT_PAGE:
      return { ...state, page: action.payload.page };

    default:
      return state;
  }
}

export const reducers: ActionReducerMap<AppState> = {
  orders: ordersReducer
};

export function logger(reducer: ActionReducer<AppState>): ActionReducer<AppState> {
  return function (state: AppState, action: any): AppState {
    if (!action.type.startsWith('@ngrx/')) {
      console.log(action, state);
    }

    return reducer(state, action);
  };
}


export const metaReducers: MetaReducer<AppState>[] = !environment.production
  ? [logger, storeFreeze]
  : [];
