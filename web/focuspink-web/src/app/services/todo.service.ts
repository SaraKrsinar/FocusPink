import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface TodoItem {
  id: number;
  title: string;
  isDone: boolean;
  createdAt: string;
}

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  private base = '/api/todos';

  constructor(private http: HttpClient) {}

  getTodos(): Observable<TodoItem[]> {
    return this.http.get<TodoItem[]>(this.base);
  }

  addTodo(title: string): Observable<TodoItem> {
    return this.http.post<TodoItem>(this.base, { title });
  }

  toggleTodo(id: number): Observable<TodoItem> {
    return this.http.put<TodoItem>(`${this.base}/${id}/toggle`, {});
  }

  deleteTodo(id: number): Observable<void> {
    return this.http.delete<void>(`${this.base}/${id}`);
  }
}
