import { Component, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TodoService, TodoItem } from '../../services/todo.service';

@Component({
  selector: 'app-todo-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './todo-list.component.html',
  styleUrl: './todo-list.component.scss'
})
export class TodoListComponent {
  private api = inject(TodoService);
  todos = signal<TodoItem[]>([]);
  title = '';

  ngOnInit() {
    this.load();
  }

  load() {
    this.api.getTodos().subscribe(d => this.todos.set(d));
  }

  create() {
    const v = this.title.trim();
    if (!v) return;
    this.api.addTodo(v).subscribe(item => {
      this.title = '';
      this.todos.update(list => [item, ...list]);
    });
  }

  toggle(t: TodoItem) {
    this.api.toggleTodo(t.id).subscribe(u => {
      this.todos.set(this.todos().map(x => x.id === u.id ? u : x));
    });
  }

  remove(t: TodoItem) {
    this.api.deleteTodo(t.id).subscribe(() => {
      this.todos.set(this.todos().filter(x => x.id !== t.id));
    });
  }
}
