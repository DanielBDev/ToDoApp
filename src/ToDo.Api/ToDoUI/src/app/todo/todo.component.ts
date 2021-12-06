import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { AccountService } from '../login/services/account.service';
import { Todoitem } from '../models/todoitem';
import { Todolist } from '../models/todolist';
import { TodoService } from './services/todo.service';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.scss']
})
export class TodoComponent implements OnInit {

  todoItems: Todoitem[] = [];
  newItem: string;

  constructor(private todoService: TodoService, private accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
    this.loadItems();
  }

  loadItems(){
    this.todoService.getItems().subscribe((data: any) => (this.todoItems = data.data));
  }

  saveTodoItem(){
    if(this.newItem){
      let todo = new Todoitem();
      todo.listId = 1;
      todo.title = this.newItem;
      this.todoService.createItem(todo).subscribe( resp => {
        this.loadItems();
      });
      this.newItem = '';
    }else{
      alert("Porfavor ingrese una tarea");
    }
  }

  updateItem(item: Todoitem){
    Swal.fire
    ({
      title: '¿Estas seguro de modificar la tarea?',
      showDenyButton: true,
      showCancelButton: false,
      confirmButtonText: 'Guardar',
      denyButtonText: `Cancelar`,
    })
    .then((result) => {
      if(result.isConfirmed){
        this.todoService.updateItem(item).subscribe( resp => {
          Swal.fire
            ({
              icon: 'success',
              text: 'Tarea modificada con éxito',
              timer: 1500,
              showConfirmButton: false
            });
          this.loadItems();
        });
      }
      else{
        Swal.fire
            ({
              icon: 'info',
              text: 'Accion cancelada',
              timer: 1000,
              showConfirmButton: false
            });
      }
    })
  }

  deleteItem(id: number){
    Swal.fire
    ({
      title: '¿Estas seguro de eliminar la tarea?',
      showDenyButton: true,
      showCancelButton: false,
      confirmButtonText: 'Eliminar',
      denyButtonText: `Cancelar`,
    })
    .then((result) => {
      if(result.isConfirmed){
        this.todoService.deleteItem(id).subscribe( resp => {
          Swal.fire
                ({
                  icon: 'success',
                  text: 'Tarea eliminada con éxito',
                  timer: 1500,
                  showConfirmButton: false
                });
          this.loadItems();
        });
      }
      else(result.isDenied)
      {
        Swal.fire
            ({
              icon: 'info',
              text: 'Accion cancelada',
              timer: 1000,
              showConfirmButton: false
            });
      }
    })
  }

  eventCheck(item: Todoitem ,event: any){
    this.todoService.workDone(item, event).subscribe( resp => {
      this.loadItems();
    });
  }

  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('');
  }

  // isChecked(){
  //   this.todoService.getItems().subscribe((data: any) => {
  //     if(data.data.done === 1){
  //       return true;
  //     }
  //     else(data.data.done === 0)
  //     {
  //       return false;
  //     }
  //   });
  // }
}
