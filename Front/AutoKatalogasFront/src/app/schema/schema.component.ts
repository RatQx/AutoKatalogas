import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { elementAt, Subscription } from 'rxjs';
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
  public loading: boolean = true;
  public loaded: boolean = false;
  public isUser: boolean = false;
  public list: Schema[] = [];
  public displayedImage: string [] = [];
  updateListSubscription: Subscription;
  constructor(
    private schemaService: SchemaService,
    private router: Router,
    private userService: UserService
  ) {
    this.updateListSubscription = this.schemaService
      .sendUpdateList()
      .subscribe(() => {
        this.getAllSchemos();
      });
    this.isAdmin = userService.isUserAdmin();
    this.isUser = userService.isUserValid();
    this.schemaService.getAllSchemos().subscribe({
      next: (data) => {
        this.list=data;
        this.list.forEach(element =>{
          this.displayedImage.push(element.img);
        })
      }
    });
  }

  async ngOnInit() {
    try {
      await new Promise(f => setTimeout(f, 1000));
      await this.getAllSchemos();
    } catch (err) {
      console.log('Error', err);
    }
    this.loaded = true;
    this.loading = false;
  }

  getAllSchemos() {
    this.schemaService.getAllSchemos().subscribe((data) => {
      this.records = data as Schema[];
      console.log(data);
    });
  }

  onDelete(id: number) {
    this.schemaService.deleteRecord(id).subscribe((data) => {
      console.log(data);
      console.log(id);
      this.getAllSchemos();
    });
  }

  onUpdate(id: number) {
    this.schemaService.populateForm(id);
  }

  addNew(): void {
    this.router.navigateByUrl('/schema-add');
  }
}
