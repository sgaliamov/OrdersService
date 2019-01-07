import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import 'rxjs/add/operator/switchMap';
import { OrdersService, OrderDto } from '../../domain';
import { Subscription } from 'rxjs/Subscription';
import { AppState, UpdateOrder } from '../../core';
import { Store } from '@ngrx/store';

@Component({
  selector: 'app-order-edit-page',
  templateUrl: './order-edit-page.component.html',
  styleUrls: ['./order-edit-page.component.scss']
})
export class OrderEditPageComponent implements OnInit, OnDestroy {
  private subscription: Subscription;
  model: OrderDto;

  constructor(
    private readonly route: ActivatedRoute,
    private readonly router: Router,
    private readonly ordersService: OrdersService,
    private readonly store: Store<AppState>
  ) { }

  ngOnInit() {
    this.subscription = this.route.paramMap
      .switchMap(params => this.ordersService.order(params.get('id')))
      .subscribe(data => this.model = data);
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
      this.subscription = undefined;
    }
  }

  onSubmit() {
    this.store.dispatch(new UpdateOrder({
      order: this.model,
      id: this.model.id
    }));
    this.router.navigate(['/orders']);
  }

}
