import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OrderDto, PagedResult } from './';

@Injectable()
export class OrdersService {
  private API_PATH = 'http://localhost:54765/api/ordersQuery/list/';

  constructor(private http: HttpClient) { }

  load(page: number) {
    return this.http.get<PagedResult<OrderDto[]>>(`${this.API_PATH}${page}`);
  }

}
