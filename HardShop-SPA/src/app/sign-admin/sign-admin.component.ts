import {
  Component,
  OnInit,
  TemplateRef
} from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AlertifyService } from '../_services/alertify.service.service';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-sign-admin',
  templateUrl: './sign-admin.component.html',
  styleUrls: ['./sign-admin.component.css'],
})
export class SignAdminComponent implements OnInit {
  model: any = { username: 'admin' };
  account: any = true;
  modalRef: BsModalRef;
  name: 'kamaladmin';

  constructor(
    public authService: AuthService,
    private modalService: BsModalService,
    private alertify: AlertifyService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
  adminLoggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }
  adminLogin(model: any) {
    this.authService.adminLogin(model).subscribe(
      (next) => {
        this.alertify.success('Successfully Logged in!!');
      },
      (error) => {
        this.alertify.error(error);
      },
      () => {
        this.router.navigate(['/admin']);
      }
    );
  }
  adminRegister(model: any) {
    this.authService.adminRegister(model).subscribe(
      (next) => {
        this.alertify.success('Successfully Registered!!');
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.message('logged out');
    this.router.navigate(['/home']);
  }

  haveAccount() {
    this.account = !this.account;
  }
}
