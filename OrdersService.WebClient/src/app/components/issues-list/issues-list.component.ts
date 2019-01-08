import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Issue, IssuesService } from '../../domain';

@Component({
  selector: 'app-issues-list',
  templateUrl: './issues-list.component.html',
  styleUrls: ['./issues-list.component.scss']
})
export class IssuesListComponent implements OnInit {
  @Input()
  readonly orderId: string;

  data: Observable<Issue[]>;

  constructor(private readonly issuesService: IssuesService) { }

  ngOnInit() {
    this.data = this.issuesService.search(this.orderId);
  }
}
