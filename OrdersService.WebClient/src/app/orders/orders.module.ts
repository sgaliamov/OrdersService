import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import {
  OrderDetailsPageComponent,
  OrderEditPageComponent,
  OrdersListComponent,
  OrdersListItemComponent,
  OrdersPageComponent,
  OrdersRoutingModule
  } from './';


@NgModule({
  imports: [
    CommonModule,
    OrdersRoutingModule
  ],
  declarations: [
    OrdersListComponent,
    OrdersListItemComponent,
    OrdersPageComponent,
    OrderDetailsPageComponent,
    OrderEditPageComponent
  ]
})
export class OrdersModule { }
