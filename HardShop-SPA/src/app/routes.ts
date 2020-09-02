import { Routes } from '@angular/router';
import { HomeComponent } from './customer-components/home/home.component';
import { ProductListComponent } from './customer-components/product-list/product-list.component';
import { CartComponent } from './customer-components/cart/cart.component';
import { SignComponent } from './customer-components/sign/sign.component';
import { AdminSignComponent } from './admin-components/admin-sign/admin-sign.component';
import { AdminDashboardComponent } from './admin-components/admin-dashboard/admin-dashboard.component';
import { AdminSalesComponent } from './admin-components/admin-sales/admin-sales.component';
import { AdminPurchaseComponent } from './admin-components/admin-purchase/admin-purchase.component';
import { AdminProductsComponent } from './admin-components/admin-products/admin-products.component';
import { AdminCustomersComponent } from './admin-components/admin-customers/admin-customers.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },

  // {
  //   path: '',
  //   runGuardsAndResolvers: 'always',
  //   canActivate: [AuthGuard],
  //   children: [],
  // },

  { path: 'products', component: ProductListComponent },
  { path: 'cart', component: CartComponent },
  { path: 'sign', component: SignComponent },

  // { path: 'admin', component: AdminDashboardComponent },
  { path: 'admin/dashboard', component: AdminDashboardComponent },
  { path: 'admin/sign', component: AdminSignComponent },
  { path: 'admin/products', component: AdminProductsComponent },
  { path: 'admin/sales', component: AdminSalesComponent },
  { path: 'admin/purchase', component: AdminPurchaseComponent },
  { path: 'admin/customers', component: AdminCustomersComponent },

  { path: '**', redirectTo: 'home', pathMatch: 'full' },
];
