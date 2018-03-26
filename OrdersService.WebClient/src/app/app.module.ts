import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { GridModule } from '@progress/kendo-angular-grid';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { OrderEditPageComponent, OrdersListComponent, OrdersPageComponent } from './components';
import { AboutPageComponent, AppComponent, NotFoundPageComponent } from './core';
import { AppEffects } from './core/app.effects';
import { metaReducers, reducers } from './core/app.reducers';
import { OrdersService } from './domain';


@NgModule({
  declarations: [
    AppComponent,
    OrdersListComponent,
    OrdersPageComponent,
    OrderEditPageComponent,
    NotFoundPageComponent,
    AboutPageComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    StoreModule.forRoot(reducers, { metaReducers }),
    !environment.production ? StoreDevtoolsModule.instrument() : [],
    EffectsModule.forRoot([AppEffects]),
    GridModule,
    ButtonsModule
  ],
  providers: [OrdersService],
  bootstrap: [AppComponent]
})
export class AppModule { }
