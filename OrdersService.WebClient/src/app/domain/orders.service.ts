import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OrderDto, PagedResult, OrderModel } from './';

@Injectable()
export class OrdersService {
  private QUERY_PATH = 'http://localhost:5000/api/ordersQuery/';
  private COMMAND_PATH = 'http://localhost:5000/api/ordersCommand/';

  constructor(private http: HttpClient) { }

  orders(page: number) {
    return this.http.get<PagedResult<OrderDto[]>>(`${this.QUERY_PATH}list/${page}`);
  }

  order(id: string) {
    return this.http.get<OrderDto>(`${this.QUERY_PATH}id/${id}`);
  }

  update(id: string, order: OrderModel) {
    return this.http.put<string>(`${this.COMMAND_PATH}${id}`, order);
  }

}


// https://albelli-test-cc.atlassian.net/rest/api/3/search?jql=description~%22SAL1005239%22&fields=summary
