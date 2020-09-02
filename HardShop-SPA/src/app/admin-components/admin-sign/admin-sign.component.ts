import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { AuthService } from 'src/app/_services/auth.service';
import { AlertifyService } from 'src/app/_services/alertify.service.service';
import { Router } from '@angular/router';
import { Admin } from '../../_models/admin';

@Component({
  selector: 'app-admin-sign',
  templateUrl: './admin-sign.component.html',
  styleUrls: ['./admin-sign.component.css'],
})
export class AdminSignComponent implements OnInit {
  adminForLogin: Admin;
  admin: Admin;
  account: any = true;
  modalRef: BsModalRef;
  registerForm: FormGroup;
  loginForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;

  constructor(
    public authService: AuthService,
    private modalService: BsModalService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.bsConfig = {
      containerClass: 'theme-dark-blue',
    };
    this.createRegisterForm();
    this.createLoginForm();
  }

  createLoginForm() {
    this.loginForm = this.fb.group({
      email: [
        '',
        [
          Validators.required,
          Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}$'),
        ],
      ],
      password: [
        '',
        [Validators.required, Validators.minLength(4), Validators.maxLength(8)],
      ],
    });
  }
  createRegisterForm() {
    this.registerForm = this.fb.group(
      {
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        email: [
          '',
          [
            Validators.required,
            Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}$'),
          ],
        ],
        phone: ['', Validators.required],
        gender: ['', Validators.required],
        dateOfBirth: ['', Validators.required],
        password: [
          '',
          [
            Validators.required,
            Validators.minLength(4),
            Validators.maxLength(8),
          ],
        ],
        confirmPassword: ['', Validators.required],
      },
      { validator: this.passwordMatchValidator }
    );
  }

  passwordMatchValidator(g: FormGroup) {
    return g.get('password').value === g.get('confirmPassword').value
      ? null
      : { mismatch: true };
  }

  login() {
    if (this.loginForm.valid) {
      this.adminForLogin = Object.assign({}, this.loginForm.value);
      this.authService.adminLogin(this.adminForLogin).subscribe(
        (next) => {
          this.alertify.success('Successfully Logged in!!');
          this.router.navigate(['/admin']);
        },
        (error) => {
          this.alertify.error(error);
        },
        () => {}
      );
    }
  }

  register() {
    if (this.registerForm.valid) {
      this.registerForm.value.phone.intlNumber = this.registerForm.value.phone.internationalNumber;
      delete this.registerForm.value.phone.internationalNumber;
      this.registerForm.value.phone.natlNumber = this.registerForm.value.phone.nationalNumber;
      delete this.registerForm.value.phone.nationalNumber;

      this.admin = Object.assign({}, this.registerForm.value);
      this.authService.adminRegister(this.admin).subscribe(
        (next) => {
          this.alertify.success('Admin Registered Successfully!!');
        },
        (error) => {
          this.alertify.error(error);
        },
        () => {
          this.authService.adminLogin(this.admin).subscribe(() => {
            this.router.navigate(['/admin']);
          });
        }
      );
    }
  }

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

  logout() {
    localStorage.removeItem('token');
    this.alertify.message('logged out');
    this.router.navigate(['/admin']);
  }
}
