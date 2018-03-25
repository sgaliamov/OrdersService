import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrdersPageComponent, OrderEditPageComponent } from './components';
import { AboutPageComponent, NotFoundPageComponent } from './core';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'orders',
    pathMatch: 'full'
  },
  {
    path: 'orders',
    component: OrdersPageComponent
  },
  {
    path: 'orders/:id',
    component: OrderEditPageComponent
  },
  {
    path: 'create',
    component: OrderEditPageComponent
  },
  {
    path: 'about',
    component: AboutPageComponent
  },
  {
    path: '404',
    component: NotFoundPageComponent
  },
  {
    path: '**',
    pathMatch: 'full',
    component: NotFoundPageComponent
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
