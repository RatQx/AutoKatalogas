import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Dalys } from '../models/dalys';
import { DalysService } from '../services/dalys.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-dalys',
  templateUrl: './dalys.component.html',
  styleUrls: ['./dalys.component.scss'],
})
export class DalysComponent implements OnInit {
  records: Dalys[] = [];
  public isAdmin: boolean = false;
  public isUser: boolean = false;
  public loading: boolean = true;
  public loaded: boolean = false;
  updateListSubscription: Subscription;
  constructor(
    private dalysService: DalysService,
    private router: Router,
    private userService: UserService
  ) {
    this.updateListSubscription = this.dalysService
      .sendUpdateList()
      .subscribe(() => {
        this.getAllDalys();
      });
    this.isAdmin = userService.isUserAdmin();
    this.isUser = userService.isUserValid();
  }

  async ngOnInit() {
    try {
      await new Promise(f => setTimeout(f, 1000));
      await this.getAllDalys();
    } catch (err) {
      console.log('Error', err);
    }
    this.loaded = true;
    this.loading = false;
  }

  getAllDalys() {
    this.dalysService.getAllDalys().subscribe((data) => {
      this.records = data as Dalys[];
      console.log(data);
    });
  }

  onDelete(id: number) {
    this.dalysService.deleteRecord(id).subscribe((data) => {
      console.log(data);
      console.log(id);
      this.getAllDalys();
    });
  }

  onUpdate(id: number) {
    this.dalysService.populateForm(id);
  }

  addNew(): void {
    this.router.navigateByUrl('/dalys-add');
  }
}
