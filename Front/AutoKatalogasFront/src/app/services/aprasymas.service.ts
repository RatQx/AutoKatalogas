import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Aprasymas } from '../models/aprasymas';

@Injectable({
  providedIn: 'root'
})
export class AprasymasService {

  private populateFormSubject = new Subject<any>();
  private updateListSubject = new Subject<any>();
  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http:HttpClient) { }

  getAllAprasymai(){
    return this.http.get<Aprasymas[]>(this.baseApiUrl + 'api/Aprasymas');
  }

  getAprasymas(id: number){
    return this.http.get<Aprasymas>(this.baseApiUrl + 'api/Aprasymas/' + id);
  }

  addRecord(record: Aprasymas){
    return this.http.post(this.baseApiUrl + 'api/Aprasymas',record);
  }

  deleteRecord(id: number){
    return this.http.delete(this.baseApiUrl + 'api/Aprasymas/' + id,);
  }

  populateForm(id: number){
    this.populateFormSubject.next(id);
  }

  sendPopulateForm(){
    return this.populateFormSubject.asObservable();
  }

  updateAprasymas(aprasymas: Aprasymas){
    return this.http.put(this.baseApiUrl + 'api/Aprasymas/'+ aprasymas.id ,aprasymas );
  }

  updateList(){
    this.updateListSubject.next(true);
  }

  sendUpdateList(){
    return this.updateListSubject.asObservable();
  }
}
