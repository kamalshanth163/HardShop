import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-sidemenu',
  templateUrl: './admin-sidemenu.component.html',
  styleUrls: ['./admin-sidemenu.component.css'],
})
export class AdminSidemenuComponent implements OnInit {
  constructor(public router: Router) {}
  isOpen = true;
  contentMargin = 240;
  isActive = 'active';
  showSubMenu = true;
  subMenuPosition = 'relative';
  subMenuMarginLeft = 0;
  subMenuMarginTop = 0;
  active = {
    dashboard: false,
    products: false,
    customers: false,
    sales: false,
    purchase: false,
  };
  display = 'none';
  displayStatus = {
    dashboard: this.display,
    products: this.display,
    customers: this.display,
    sales: this.display,
    purchase: this.display,
  };

  routerLinkDashboard = '/admin/dashboard';
  routerLinkProducts = '/admin/products/list';
  routerLinkCustomers = '/admin/customers';
  routerLinkSales = '/admin/sales';
  routerLinkPurchase = '/admin/purchase';

  ngOnInit() {
    const url = this.router.url;
    this.checkActiveUrl(url);
  }

  checkActiveUrl(url) {
    if (url.includes('dashboard')) {
      this.active.dashboard = true;
      this.routerLinkDashboard = url;
    } else if (url.includes('products')) {
      this.active.products = true;
      this.routerLinkProducts = url;
    } else if (url.includes('customers')) {
      this.active.customers = true;
      this.routerLinkCustomers = url;
    } else if (url.includes('sales')) {
      this.active.sales = true;
      this.routerLinkSales = url;
    } else if (url.includes('purchase')) {
      this.active.purchase = true;
      this.routerLinkPurchase = url;
    } else {
    }
  }

  clickedSubMenuLink(e) {
    const pathname = e.target.pathname;
    this.routerLinkProducts = pathname;
    // this.router.navigate([pathname]);
    if (this.contentMargin === 60) {
      this.displayStatus.products = 'none';
    }
  }

  clickedMenuLink(str) {
    this.clearAllActiveStyle();
    this.setActiveStyle(str);
    this.toggleSubMenu(str);
  }

  toggleChange(status) {
    this.isOpen = status;
    if (this.isOpen === false) {
      this.contentMargin = 60;
      this.subMenuPosition = 'fixed';
      this.subMenuMarginLeft = this.contentMargin;
      this.subMenuMarginTop = -this.contentMargin;
    } else {
      this.contentMargin = 240;
      this.subMenuPosition = 'relative';
      this.subMenuMarginLeft = 0;
      this.subMenuMarginTop = 0;
    }
  }

  setAllDisplayNone() {
    this.displayStatus.dashboard = this.display;
    this.displayStatus.products = this.display;
    this.displayStatus.customers = this.display;
    this.displayStatus.sales = this.display;
    this.displayStatus.purchase = this.display;
  }

  clearAllActiveStyle() {
    this.active.dashboard = false;
    this.active.products = false;
    this.active.customers = false;
    this.active.sales = false;
    this.active.purchase = false;
  }

  setActiveStyle(str) {
    this.active[str] = true;
  }

  toggleSubMenu(str) {
    if (this.displayStatus[str] === 'block') {
      this.displayStatus[str] = 'none';
    } else if (this.displayStatus[str] === 'none') {
      this.setAllDisplayNone();
      this.displayStatus[str] = 'block';
    }
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }
}
