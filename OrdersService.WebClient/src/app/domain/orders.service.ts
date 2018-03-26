import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OrderDto, PagedResult } from './';

@Injectable()
export class OrdersService {
  private API_PATH = 'http://localhost:54765/api/ordersQuery/';

  constructor(private http: HttpClient) { }

  orders(page: number) {
    return this.http.get<PagedResult<OrderDto[]>>(`${this.API_PATH}list/${page}`);
  }

  order(id: string) {
    return this.http.get<OrderDto>(`${this.API_PATH}id/${id}`);
  }

}
