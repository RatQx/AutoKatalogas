import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Schema } from '../models/schema';

@Injectable({
  providedIn: 'root'
})
export class SchemaService {

  private populateFormSubject = new Subject<any>();
  private updateListSubject = new Subject<any>();
  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http:HttpClient) { }

  getAllSchemos(){
    return this.http.get<Schema[]>(this.baseApiUrl + 'api/Schema');
  }

  getSchema(id: number){
    return this.http.get<Schema>(this.baseApiUrl + 'api/Schema/' + id);
  }

  addRecord(record: Schema){
    return this.http.post(this.baseApiUrl + 'api/Schema',record);
  }

  deleteRecord(id: number){
    return this.http.delete(this.baseApiUrl + 'api/Schema/' + id,);
  }

  populateForm(id: number){
    this.populateFormSubject.next(id);
  }

  sendPopulateForm(){
    return this.populateFormSubject.asObservable();
  }

  updateSchema(schema: Schema){
    return this.http.put(this.baseApiUrl + 'api/Schema/'+ schema.id ,schema );
  }

  updateList(){
    this.updateListSubject.next(true);
  }

  sendUpdateList(){
    return this.updateListSubject.asObservable();
  }
}
