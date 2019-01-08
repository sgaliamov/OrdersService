import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SEARCH_QUERY } from './urls';
import { IssuesCollection } from './issue.models';

@Injectable()
export class IssuesService {
  constructor(private http: HttpClient) { }

  search(id: string) {
    return this.http.get<IssuesCollection>(`${SEARCH_QUERY}${id}`);
  }
}
