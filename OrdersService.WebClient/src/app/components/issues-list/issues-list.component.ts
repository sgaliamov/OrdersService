import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState, getOrders, SelectPage, getPage } from '../../core';
import { OrderDto, PagedResult } from '../../domain';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-issues-list',
  templateUrl: './issues-list.component.html',
  styleUrls: ['./issues-list.component.scss']
})
export class IssuesListComponent implements OnInit {

  data: string;

  constructor(private readonly store: Store<AppState>) {
    this.data = new Date().toLocaleTimeString();
  }

  ngOnInit() {
  }


}
