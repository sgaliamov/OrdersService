export interface FieldsCollection {
  summary: string;
}

export interface Issue {
  id: string;
  fields: FieldsCollection;
}

export interface IssuesCollection {
  issues: Issue[];
  total: number;
}
