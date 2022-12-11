import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Dalys } from '../models/dalys';
import { DalysService } from '../services/dalys.service';

@Component({
  selector: 'app-dalys',
  templateUrl: './dalys.component.html',
  styleUrls: ['./dalys.component.scss']
})
export class DalysComponent implements OnInit {

  records: Dalys[] = [];
  updateListSubscription: Subscription;
  constructor(private dalysService: DalysService) {
    this.updateListSubscription = this.dalysService.sendUpdateList().subscribe(() => {
      this.getAllDalys();
    });
  }

  ngOnInit(): void {
    this.getAllDalys();
  }

  getAllDalys() {
    this.dalysService.getAllDalys().subscribe((data)=>{
      this.records = data as Dalys[];
      console.log(data);
    })
  }

  onDelete(id: number){
    this.dalysService.deleteRecord(id).subscribe((data) => {
      console.log(data);
      console.log(id);
      this.getAllDalys();
    });
  }

  onUpdate(id: number){
    this.dalysService.populateForm(id);
  }


}
