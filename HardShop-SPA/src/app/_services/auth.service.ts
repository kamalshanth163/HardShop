import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseUrl = environment.apiUrl + 'auth/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  username: any;
  role: any;
  bsModalRef: BsModalRef;

  constructor(private http: HttpClient) {}

  customerLogin(customerForLogin) {
    return this.http
      .post(this.baseUrl + 'customer/login', customerForLogin)
      .pipe(
        map((response: any) => {
          const user = response;
          if (user) {
            localStorage.setItem('token', user.token);
            localStorage.setItem('username', user.username);
            localStorage.setItem('role', user.role);
            this.decodedToken = this.jwtHelper.decodeToken(user.token);
            this.username = user.username;
            this.role = user.role;
          }
        })
      );
  }

  customerRegister(customer) {
    return this.http.post(this.baseUrl + 'customer/register', customer);
  }

  adminLogin(model: any) {
    return this.http.post(this.baseUrl + 'admin/login', model).pipe(
      map((response: any) => {
        const admin = response;
        if (admin) {
          localStorage.setItem('token', admin.token);
          localStorage.setItem('username', admin.username);
          this.decodedToken = this.jwtHelper.decodeToken(admin.token);
          this.username = admin.username;
        }
      })
    );
  }

  adminRegister(model: any) {
    return this.http.post(this.baseUrl + 'admin/register', model);
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

}
