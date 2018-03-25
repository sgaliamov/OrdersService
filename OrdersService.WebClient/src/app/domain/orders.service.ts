import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OrderDto } from './';

@Injectable()
export class OrdersService {
  private API_PATH = 'http://localhost:4201/api/ordersQuery/list/';

  constructor(private http: HttpClient) { }

  load(page = 1) {
    return this.http.get<OrderDto[]>(`${this.API_PATH}${page}`);
  }

}
