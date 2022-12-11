import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Automobiliai } from '../models/automobiliai';
import { AutomobiliaiService } from '../services/automobiliai.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-automobiliai',
  templateUrl: './automobiliai.component.html',
  styleUrls: ['./automobiliai.component.scss'],
})
export class AutomobiliaiComponent implements OnInit {
  loading = true;
  loaded = false;
  public isAdmin: boolean = false;
  public isUser: boolean = false;
  records: Automobiliai[] = [];
  updateListSubscription: Subscription;
  deleteId = 0;
  constructor(
    private autoService: AutomobiliaiService,
    private router: Router,
    private userService: UserService
  ) {
    this.updateListSubscription = this.autoService
      .sendUpdateList()
      .subscribe(() => {
        this.getAllAutos();
      });
    this.isAdmin = userService.isUserAdmin();
    this.isUser = userService.isUserValid();
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
    this.autoService.deleteRecord(id).subscribe((data) => {
      console.log(data);
      console.log(id);
      this.getAllAutos();
    });
  }

  onUpdate(id: number) {
    this.autoService.populateForm(id);
  }

  addNew(): void {
    this.router.navigateByUrl('/automobiliai-add');
  }
}
