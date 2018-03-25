import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Actions, Effect } from '@ngrx/effects';
import 'rxjs/add/observable/defer';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import { OrdersService } from '../domain';
import { OrderActionTypes, OrdersLoaded } from './';


@Injectable()
export class AppEffects {

  @Effect()
  readonly init$ =
    Observable.defer(() => {
      return this.ordersService.load()
        .map(orders => new OrdersLoaded({ orders }));
    });

  constructor(
    private ordersService: OrdersService,
    private actions$: Actions) { }
}
