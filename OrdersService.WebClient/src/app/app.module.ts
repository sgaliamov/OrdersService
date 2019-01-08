import { CommonModule } from '@angular/common';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { GridModule } from '@progress/kendo-angular-grid';
import { NumericTextBoxModule } from '@progress/kendo-angular-inputs';
import { TextBoxModule } from '@progress/kendo-angular-inputs';
import { MarkdownModule } from 'ngx-markdown';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { IssuesListComponent, OrderEditPageComponent, OrdersListComponent, OrdersPageComponent } from './components';
import { AboutPageComponent, AppComponent, NotFoundPageComponent } from './core';
import { AppEffects } from './core/app.effects';
import { metaReducers, reducers } from './core/app.reducers';
import { IssuesService, OrdersService } from './domain';

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
    TextBoxModule,
    MarkdownModule.forRoot({ loader: HttpClient })
  ],
  providers: [OrdersService, IssuesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
