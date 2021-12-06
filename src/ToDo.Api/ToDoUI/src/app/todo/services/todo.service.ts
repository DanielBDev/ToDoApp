import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Todoitem } from 'src/app/models/todoitem';
import { Todolist } from 'src/app/models/todolist';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TodoService {

  tok = localStorage.getItem('token');
  headers_object = new HttpHeaders().set('Authorization', 'Bearer ' + this.tok);

  constructor(private http: HttpClient) { }

  getItems(){
    return this.http.get<Todoitem[]>(environment.apiUrl + '/TodoItems', {
      headers: this.headers_object
    }).pipe(map((resp) => {return resp;}));
  }

  // createList(list: Todolist){
  //   const entryData = {
  //     title: list.title
  //   }

  //   return this.http.post(environment.apiUrl + '/todolists', entryData, {
  //     headers: this.headers_object
  //   });
  // }

  createItem(item: Todoitem){
    const entryData = {
      listId: item.listId,
      title: item.title
    }

    return this.http.post(environment.apiUrl + '/TodoItems', entryData, {
      headers: this.headers_object
    });
  }

  updateItem(item: Todoitem){
    const entryData = {
      id: item.id,
      title: item.title,
      done: item.done
    }

    return this.http.put(environment.apiUrl + '/TodoItems/' + entryData.id, entryData, {
      headers: this.headers_object
    });
  }

  workDone(item: Todoitem ,event: any){
    const entryData = {
      id: item.id,
      title: item.title,
      done: event.target.checked
    }
    console.log();
    return this.http.put(environment.apiUrl + '/TodoItems/' + entryData.id, entryData, {
      headers: this.headers_object
    });
  }

  deleteItem(id: number){
    return this.http.delete(environment.apiUrl + '/TodoItems/' + id, {
      headers: this.headers_object
    });
  }
}

