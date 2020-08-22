import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { AlertifyService } from '../_services/alertify.service.service';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder,
} from '@angular/forms';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { Customer } from '../_models/customer';

@Component({
  selector: 'app-sign',
  templateUrl: './sign.component.html',
  styleUrls: ['./sign.component.css'],
})
export class SignComponent implements OnInit {
  model: any = {};
  customer: Customer;
  account: any = true;
  modalRef: BsModalRef;
  registerForm: FormGroup;
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

  register() {
    if (this.registerForm.valid) {
      this.registerForm.value.phone.intlNumber = this.registerForm.value.phone.internationalNumber;
      delete this.registerForm.value.phone.internationalNumber;
      this.registerForm.value.phone.natlNumber = this.registerForm.value.phone.nationalNumber;
      delete this.registerForm.value.phone.nationalNumber;

      this.customer = Object.assign({}, this.registerForm.value);
      this.authService.register(this.customer).subscribe(
        (next) => {
          this.alertify.success('Customer Registered Successfully!!');
        },
        (error) => {
          this.alertify.error(error);
        }
      );
    }
    console.log(this.registerForm.value);
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.message('logged out');
    this.router.navigate(['/home']);
  }
}
