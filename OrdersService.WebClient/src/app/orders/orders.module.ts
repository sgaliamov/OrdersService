import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { OrdersListComponent, OrdersListItemComponent, OrdersPageComponent, OrdersRoutingModule } from './';



@NgModule({
  imports: [
    CommonModule,
    OrdersRoutingModule
  ],
  declarations: [
    OrdersListComponent,
    OrdersListItemComponent,
    OrdersPageComponent
  ]
})
export class OrdersModule { }
