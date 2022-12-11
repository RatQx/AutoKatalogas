import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Aprasymas } from '../models/aprasymas';
import { AprasymasService } from '../services/aprasymas.service';

@Component({
  selector: 'app-aprasymas',
  templateUrl: './aprasymas.component.html',
  styleUrls: ['./aprasymas.component.scss']
})
export class AprasymasComponent implements OnInit {

  records: Aprasymas[] = [];
  updateListSubscription: Subscription;
  constructor(private aprasymasService: AprasymasService) {
    this.updateListSubscription = this.aprasymasService.sendUpdateList().subscribe(() => {
      this.getAllDalys();
    });
  }

  ngOnInit(): void {
    this.getAllDalys();
  }

  getAllDalys() {
    this.aprasymasService.getAllAprasymai().subscribe((data)=>{
      this.records = data as Aprasymas[];
      console.log(data);
    })
  }

  onDelete(id: number){
    this.aprasymasService.deleteRecord(id).subscribe((data) => {
      console.log(data);
      console.log(id);
      this.getAllDalys();
    });
  }

  onUpdate(id: number){
    this.aprasymasService.populateForm(id);
  }

}
