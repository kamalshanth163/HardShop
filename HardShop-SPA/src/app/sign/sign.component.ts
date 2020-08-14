import {
  Component,
  OnInit,
  TemplateRef
} from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { AlertifyService } from '../_services/alertify.service.service';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-sign',
  templateUrl: './sign.component.html',
  styleUrls: ['./sign.component.css'],
})
export class SignComponent implements OnInit {
  model: any = {};
  account: any = true;
  modalRef: BsModalRef;

  constructor(
    public authService: AuthService,
    private modalService: BsModalService,
    private alertify: AlertifyService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  haveAccount() {
    this.account = !this.account;
  }
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  login(model: any) {
    this.authService.login(model).subscribe(
      (next) => {
        this.alertify.success('Successfully Logged in!!');
      },
      (error) => {
        this.alertify.error(error);
      },
      () => {
        this.router.navigate(['/products']);
      }
    );
  }

  register(model: any) {
    this.authService.register(model).subscribe(
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
}
