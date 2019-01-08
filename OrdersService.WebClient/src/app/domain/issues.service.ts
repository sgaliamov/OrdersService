import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IssuesCollection } from './';

@Injectable()
export class IssuesService {
  private QUERY_PATH = 'https://albelli-test-cc.atlassian.net/rest/api/3/search?jql=description~"{query}"&fields=summary&project="CC"';

  constructor(private http: HttpClient) { }

  search(id: string) {
    return this.http.get<IssuesCollection>(this.QUERY_PATH.replace('{query}', id));
  }
}
