import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OrderDto, OrderEditModel, PagedResult } from './';
import { COMMAND_PATH, ORDERS_QUERY } from './urls';

@Injectable()
export class OrdersService {
  constructor(private http: HttpClient) { }

  orders(page: number) {
    return this.http.get<PagedResult<OrderDto[]>>(`${ORDERS_QUERY}list/${page}`);
  }

  order(id: string) {
    return this.http.get<OrderDto>(`${ORDERS_QUERY}id/${id}`);
  }

  update(id: string, order: OrderEditModel) {
    return this.http.put<string>(`${COMMAND_PATH}${id}`, order);
  }
}
