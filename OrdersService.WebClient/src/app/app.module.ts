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
import { TextBoxModule } from '@progress/kendo-angular-inputs';
import { NumericTextBoxModule } from '@progress/kendo-angular-inputs';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { OrderEditPageComponent, OrdersListComponent, OrdersPageComponent, IssuesListComponent } from './components';
import { AboutPageComponent, AppComponent, NotFoundPageComponent } from './core';
import { AppEffects } from './core/app.effects';
import { metaReducers, reducers } from './core/app.reducers';
import { OrdersService, IssuesService } from './domain';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    OrdersListComponent,
    OrdersPageComponent,
    OrderEditPageComponent,
    IssuesListComponent,
    NotFoundPageComponent,
    AboutPageComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    StoreModule.forRoot(reducers, { metaReducers }),
    !environment.production ? StoreDevtoolsModule.instrument() : [],
    EffectsModule.forRoot([AppEffects]),
    GridModule,
    ButtonsModule,
    NumericTextBoxModule,
    TextBoxModule
  ],
  providers: [OrdersService, IssuesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
