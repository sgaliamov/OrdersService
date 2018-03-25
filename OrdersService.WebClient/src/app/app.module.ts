import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AboutPageComponent, AppComponent, NotFoundPageComponent } from './core';
import { AppEffects } from './core/app.effects';
import { metaReducers, reducers } from './core/app.reducers';
import { OrdersService } from './domain';
import {
  OrderDetailsPageComponent,
  OrderEditPageComponent,
  OrdersListComponent,
  OrdersListItemComponent,
  OrdersPageComponent
  } from './orders';



@NgModule({
  declarations: [
    AppComponent,
    OrdersListComponent,
    OrdersListItemComponent,
    OrdersPageComponent,
    OrderDetailsPageComponent,
    OrderEditPageComponent,
    NotFoundPageComponent,
    AboutPageComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    StoreModule.forRoot(reducers, { metaReducers }),
    !environment.production ? StoreDevtoolsModule.instrument() : [],
    EffectsModule.forRoot([AppEffects])
  ],
  providers: [OrdersService],
  bootstrap: [AppComponent]
})
export class AppModule { }
