import { Component, OnInit, Input } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  // @Input authService: AuthService;
  modalRef: BsModalRef;
  opened = false;

  constructor(
    public authService: AuthService,
    private alertify: AlertifyService,
    private router: Router
  ) {}

  ngOnInit() {}

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }
  adminLoggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  toggleSidebar() {
    this.opened = !this.opened;
  }
}
