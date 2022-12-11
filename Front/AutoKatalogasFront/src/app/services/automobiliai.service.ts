import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Automobiliai } from '../models/automobiliai';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AutomobiliaiService {

  private populateFormSubject = new Subject<any>();
  private updateListSubject = new Subject<any>();
  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http:HttpClient) { }

  getAllAutos(){
    return this.http.get<Automobiliai[]>(this.baseApiUrl + 'api/Automobiliais');
  }

  getAuto(id: number){
    return this.http.get<Automobiliai>(this.baseApiUrl + 'api/Automobiliais/' + id);
  }

  addRecord(record: Automobiliai){
    return this.http.post(this.baseApiUrl + 'api/Automobiliais',record);
  }

  deleteRecord(id: number){
    return this.http.delete(this.baseApiUrl + 'api/Automobilais/' + id,);
  }

  populateForm(id: number){
    this.populateFormSubject.next(id);
  }

  sendPopulateForm(){
    return this.populateFormSubject.asObservable();
  }

  updateAuto(auto: Automobiliai){
    return this.http.put(this.baseApiUrl + 'api/Automobiliais/'+auto.id ,auto );
  }

  updateList(){
    this.updateListSubject.next(true);
  }

  sendUpdateList(){
    return this.updateListSubject.asObservable();
  }
}
