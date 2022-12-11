import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Schema } from '../models/schema';
import { SchemaService } from '../services/schema.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-schema',
  templateUrl: './schema.component.html',
  styleUrls: ['./schema.component.scss'],
})
export class SchemaComponent implements OnInit {
  records: Schema[] = [];
  public isAdmin: boolean = false;
  public isUser: boolean = false;
  updateListSubscription: Subscription;
  constructor(
    private schemaService: SchemaService,
    private router: Router,
    private userService: UserService
  ) {
    this.updateListSubscription = this.schemaService
      .sendUpdateList()
      .subscribe(() => {
        this.getAllDalys();
      });
    this.isAdmin = userService.isUserAdmin();
    this.isUser = userService.isUserValid();
  }

  ngOnInit(): void {
    this.getAllDalys();
  }

  getAllDalys() {
    this.schemaService.getAllSchemos().subscribe((data) => {
      this.records = data as Schema[];
      console.log(data);
    });
  }

  onDelete(id: number) {
    this.schemaService.deleteRecord(id).subscribe((data) => {
      console.log(data);
      console.log(id);
      this.getAllDalys();
    });
  }

  onUpdate(id: number) {
    this.schemaService.populateForm(id);
  }

  addNew(): void {
    this.router.navigateByUrl('/schema-add');
  }
}
