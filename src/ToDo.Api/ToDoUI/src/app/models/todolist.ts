import { Todoitem } from "./todoitem";

export class Todolist {
  id: number;
  createdBy: string;
  lastModifiedBy: string;
  title: string;
  items: Todoitem[];
}
