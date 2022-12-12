import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Aprasymas } from '../models/aprasymas';
import { AprasymasService } from '../services/aprasymas.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-aprasymas',
  templateUrl: './aprasymas.component.html',
  styleUrls: ['./aprasymas.component.scss'],
})
export class AprasymasComponent implements OnInit {
  records: Aprasymas[] = [];
  public isAdmin: boolean = false;
  public isUser: boolean = false;
  public loading: boolean = true;
  public loaded: boolean = false;
  updateListSubscription: Subscription;
  constructor(
    private aprasymasService: AprasymasService,
    private router: Router,
    private userService: UserService
  ) {
    this.updateListSubscription = this.aprasymasService
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
    this.aprasymasService.getAllAprasymai().subscribe((data) => {
      this.records = data as Aprasymas[];
      console.log(data);
    });
  }

  onDelete(id: number) {
    this.aprasymasService.deleteRecord(id).subscribe((data) => {
      console.log(data);
      console.log(id);
      this.getAllDalys();
    });
  }

  onUpdate(id: number) {
    this.aprasymasService.populateForm(id);
  }

  addNew(): void {
    this.router.navigateByUrl('/aprasymas-add');
  }
}
