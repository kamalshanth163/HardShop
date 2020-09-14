import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { NgxIntlTelInputModule } from 'ngx-intl-tel-input';
import { SidebarModule } from 'ng-sidebar';

import { AppComponent } from './app.component';
import { NavComponent } from './customer-components/nav/nav.component';
import { HomeComponent } from './customer-components/home/home.component';
import { AuthService } from './_services/auth.service';
import { SignComponent } from './customer-components/sign/sign.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { ProductListComponent } from './customer-components/product-list/product-list.component';
import { CartComponent } from './customer-components/cart/cart.component';
import { AdminNavComponent } from './admin-components/admin-nav/admin-nav.component';
import { AdminSalesComponent } from './admin-components/admin-sales/admin-sales.component';
import { AdminPurchaseComponent } from './admin-components/admin-purchase/admin-purchase.component';
import { AdminSignComponent } from './admin-components/admin-sign/admin-sign.component';
import { AdminDashboardComponent } from './admin-components/admin-dashboard/admin-dashboard.component';
import { AdminProductsComponent } from './admin-components/admin-products/admin-products.component';
import { AdminCustomersComponent } from './admin-components/admin-customers/admin-customers.component';
import { AdminProductCreateComponent } from './admin-components/admin-product-create/admin-product-create.component';
import { AdminProductListComponent } from './admin-components/admin-product-list/admin-product-list.component';
import { AdminAuthGuard } from './_guards/admin-auth.guard';
import { CustomerAuthGuard } from './_guards/customer-auth.guard';
import { NonAdminGuard } from './_guards/non-admin.guard';
import { AdminSidemenuComponent } from './admin-components/admin-sidemenu/admin-sidemenu.component';
import { MaterialModule } from './material-module';
import { AdminCategoryCreateComponent } from './admin-components/admin-category-create/admin-category-create.component';
import { AdminCategoryMainViewComponent } from './admin-components/admin-category-main-view/admin-category-main-view.component';
import { AdminCategorySubViewComponent } from './admin-components/admin-category-sub-view/admin-category-sub-view.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    SignComponent,
    ProductListComponent,
    CartComponent,
    AdminNavComponent,
    AdminSignComponent,
    AdminSalesComponent,
    AdminPurchaseComponent,
    AdminDashboardComponent,
    AdminProductsComponent,
    AdminProductListComponent,
    AdminProductCreateComponent,
    AdminCustomersComponent,
    AdminSidemenuComponent,
    AdminCategoryCreateComponent,
    AdminCategoryMainViewComponent,
    AdminCategorySubViewComponent,
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    BsDatepickerModule.forRoot(),
    NgxIntlTelInputModule,
    TabsModule.forRoot(),
    ModalModule.forRoot(),
    SidebarModule.forRoot(),
    MaterialModule,
  ],
  providers: [
    AuthService,
    ErrorInterceptorProvider,
    CustomerAuthGuard,
    AdminAuthGuard,
    NonAdminGuard,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
