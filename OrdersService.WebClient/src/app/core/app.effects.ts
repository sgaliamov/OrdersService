import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { defer } from 'rxjs/observable/defer';
import { of } from 'rxjs/observable/of';
import { catchError, map, switchMap, withLatestFrom } from 'rxjs/operators';
import { OrdersService, PagedResult, OrderDto } from '../domain';
import { Fail, OrderActionTypes, OrdersLoaded, SelectPage, UpsertOrder, AppState } from './';
import { Store } from '@ngrx/store';

const mapResult = map((result: PagedResult<OrderDto[]>) =>
  new OrdersLoaded({ orders: result.data, total: result.total }));

const handleError = (message: string) => catchError(() => of(new Fail({ message })));

@Injectable()
export class AppEffects {

  @Effect()
  readonly init$ = defer(() => this.ordersService
    .orders(1)
    .pipe(mapResult, handleError('Initialization failed.'))
  );

  @Effect()
  readonly selectPage$ = this.actions$.pipe(
    ofType<SelectPage>(OrderActionTypes.SELECT_PAGE),
    map(action => action.payload.page),
    switchMap(page => this.ordersService
      .orders(page)
      .pipe(mapResult, handleError('Can\'t change page.')))
  );

  @Effect()
  readonly updateOrder$ = this.actions$.pipe(
    ofType<UpsertOrder>(OrderActionTypes.UPSERT),
    map(action => action.payload),
    switchMap(payload => {
      const result = payload.orderId
        ? this.ordersService.update(payload.orderId, payload.order)
        : this.ordersService.create(payload.order);

      return result.pipe(withLatestFrom(this.store$), map(([_, state]) => new SelectPage({ page: state.orders.page })));
    })
  );

  constructor(
    private ordersService: OrdersService,
    private actions$: Actions,
    private store$: Store<AppState>) { }
}
