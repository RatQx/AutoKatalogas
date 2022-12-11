import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Dalys } from '../models/dalys';

@Injectable({
  providedIn: 'root'
})
export class DalysService {

  private populateFormSubject = new Subject<any>();
  private updateListSubject = new Subject<any>();
  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http:HttpClient) { }

  getAllDalys(){
    return this.http.get<Dalys[]>(this.baseApiUrl + 'api/Dalys');
  }

  getDalis(id: number){
    return this.http.get<Dalys>(this.baseApiUrl + 'api/Dalys/' + id);
  }

  addRecord(record: Dalys){
    return this.http.post(this.baseApiUrl + 'api/Dalys',record);
  }

  deleteRecord(id: number){
    return this.http.delete(this.baseApiUrl + 'api/Dalys/' + id,);
  }

  populateForm(id: number){
    this.populateFormSubject.next(id);
  }

  sendPopulateForm(){
    return this.populateFormSubject.asObservable();
  }

  updateDalis(dalys: Dalys){
    return this.http.put(this.baseApiUrl + 'api/Dalys/'+ dalys.id ,dalys );
  }

  updateList(){
    this.updateListSubject.next(true);
  }

  sendUpdateList(){
    return this.updateListSubject.asObservable();
  }
}
