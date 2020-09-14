import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service.service';

@Injectable({
  providedIn: 'root'
})
export class NonAdminGuard implements CanActivate {
  constructor(
    private authService: AuthService,
    private router: Router,
    private alertify: AlertifyService
  ) {}
  canActivate(): boolean {
    const role = localStorage.getItem('role');
    if (this.authService.loggedIn() && role === 'admin') {
      this.router.navigate(['/admin/dashboard']);
      this.alertify.error('You shall not pass !!');
      return false;
    }
    return true;
  }
  
}
