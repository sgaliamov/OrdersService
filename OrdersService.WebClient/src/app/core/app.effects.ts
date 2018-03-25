import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { Observable } from 'rxjs/observable';
import { defer } from 'rxjs/observable/defer';
import { of } from 'rxjs/observable/of';
import { catchError, map, switchMap } from 'rxjs/operators';
import { OrdersService } from '../domain';
import { Fail, OrderActionTypes, OrdersLoaded, SelectPage } from './';


@Injectable()
export class AppEffects {

  @Effect({ dispatch: false })
  readonly init$ = defer(() => this.ordersService
    .load()
    .pipe(
      map(orders => new OrdersLoaded({ orders })),
      catchError(() => of(new Fail({ message: 'Initialization failed.' })))
    )
  );

  @Effect()
  readonly selectPage$ = this.actions$.pipe(
    ofType<SelectPage>(),
    map(action => action.payload.page),
    switchMap(page => this.ordersService
      .load(page)
      .pipe(
        map((orders) => new OrdersLoaded({ orders })),
        catchError(() => of(new Fail({ message: 'Can\'t change page.' })))
      )
    )
  );

  constructor(
    private ordersService: OrdersService,
    private actions$: Actions) { }
}
