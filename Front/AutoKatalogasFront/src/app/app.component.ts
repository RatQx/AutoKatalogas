import { Component } from '@angular/core';
import { UserService } from './services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'AutoKatalogas';
  public isCollapsed = true;
  public isLoged: boolean = false;
  constructor(private userService: UserService) {
    this.isLoged = this.userService.isAuthenticated;
  }
  logOut() {
    this.userService.logout();
  }

}
