import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/switchMap';
import { OrdersService, OrderDto, OrderModel } from '../../domain';
import { Subscription } from 'rxjs/Subscription';

@Component({
  selector: 'app-order-edit-page',
  templateUrl: './order-edit-page.component.html',
  styleUrls: ['./order-edit-page.component.scss']
})
export class OrderEditPageComponent implements OnInit, OnDestroy {

  private subscription: Subscription;
  model: OrderModel;

  constructor(
    private readonly route: ActivatedRoute,
    private readonly ordersService: OrdersService
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
    console.log(this.model);
  }

}
