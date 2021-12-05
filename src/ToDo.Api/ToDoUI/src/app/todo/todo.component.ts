import { Component, OnInit } from '@angular/core';
import { Todoitem } from '../models/todoitem';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.scss']
})
export class TodoComponent implements OnInit {

  todoItems: Todoitem[] = [];
  newItem: string;

  constructor() { }

  ngOnInit(): void {
  }

  saveTodoItem(){
    if(this.newItem){
      let todo = new Todoitem();
      todo.title = this.newItem;
      todo.done = false;
      this.todoItems.push(todo);
      this.newItem = '';
    }else{
      alert("Porfavor ingrese una tarea");
    }
  }

  done(id: number){
    this.todoItems[id].done = !this.todoItems[id].done;
  }
}
