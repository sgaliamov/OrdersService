import { createEntityAdapter, EntityAdapter, EntityState } from '@ngrx/entity';
import { ActionReducer, ActionReducerMap, createFeatureSelector, createSelector, MetaReducer } from '@ngrx/store';
import { environment } from '../../../environments/environment';

export interface Order {
  id: string;
  price: number;
  address: string;
  customerName: string;
}

export interface State extends EntityState<Order> {
  page: number;
}

export function sortById(a: Order, b: Order): number {
  return a.id.localeCompare(b.id);
}

export const adapter: EntityAdapter<Order> = createEntityAdapter<Order>({
  sortComparer: sortById
});




export function reducer(state: State, action: OrderActionTypes): State {
  switch (action) {
    case value:

      break;

    default:
      break;
  }
}

export const reducers: ActionReducerMap<State> = {
  page: reducer;
};


export const metaReducers: MetaReducer<State>[] = !environment.production ? [] : [];
