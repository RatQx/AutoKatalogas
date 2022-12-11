import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Automobiliai } from '../models/automobiliai';
import { AutomobiliaiService } from '../services/automobiliai.service';

@Component({
  selector: 'app-automobiliai',
  templateUrl: './automobiliai.component.html',
  styleUrls: ['./automobiliai.component.scss'],
})
export class AutomobiliaiComponent implements OnInit {
  loading = true;
  loaded = false;

  records: Automobiliai[] = [];
  updateListSubscription: Subscription;
  deleteId = 0;
  constructor(private autoService: AutomobiliaiService) {
    this.updateListSubscription = this.autoService
      .sendUpdateList()
      .subscribe(() => {
        this.getAllAutos();
      });
  }

  async ngOnInit() {
    try {
      await this.getAllAutos();
    } catch (err) {
      console.log('Error', err);
    }
    this.loaded = true;
    this.loading = false;
  }
  getAllAutos() {
    this.autoService.getAllAutos().subscribe((data) => {
      this.records = data as Automobiliai[];
      console.log(data);
    });
  }

  onDelete(id: number) {
    this.autoService.deleteRecord(this.deleteId).subscribe((data) => {
      console.log(data);
      this.getAllAutos();
    });
  }

  onUpdate(id: number) {
    this.autoService.populateForm(id);
  }
}
