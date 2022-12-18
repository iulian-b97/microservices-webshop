import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from 'src/app/_customer/authentication/authentication.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(public authService: AuthenticationService,
              private router: Router) { }

  active: number = 0

    ngOnInit(): void {
        this.active = + localStorage.getItem('active');
    }
        
    isHome() {
        this.active = 0
        localStorage.setItem('active', '0');
    }    

    isProduct() {
        this.active = 1
        localStorage.setItem('active', '1');
    }

    isInventory() {
        this.active = 2
        localStorage.setItem('active', '2');
    }

    isOrders() {
        this.active = 3
        localStorage.setItem('active', '3');
    }

    isDiscount() {
        this.active = 4
        localStorage.setItem('active', '4');
    }

    isAuthentication() {
        this.active = 5
        localStorage.setItem('active', '5');
    } 

    logout() {
        this.authService.logout();
        return this.router.navigate(['/home'])
    }

    isLogged(): boolean {
        return this.authService.isLogged()
    }
}
