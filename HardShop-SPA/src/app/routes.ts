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
import { CustomerAuthGuard } from './_guards/customer-auth.guard';
import { NonAdminGuard } from './_guards/non-admin.guard';
import { AdminAuthGuard } from './_guards/admin-auth.guard';
import { AuthGuard } from './_guards/auth.guard';
import { AdminSidemenuComponent } from './admin-components/admin-sidemenu/admin-sidemenu.component';
import { AdminProductListComponent } from './admin-components/admin-product-list/admin-product-list.component';
import { AdminProductCreateComponent } from './admin-components/admin-product-create/admin-product-create.component';
import { AdminCategoryCreateComponent } from './admin-components/admin-category-create/admin-category-create.component';
import { AdminCategoryMainViewComponent } from './admin-components/admin-category-main-view/admin-category-main-view.component';
import { AdminCategorySubViewComponent } from './admin-components/admin-category-sub-view/admin-category-sub-view.component';

export const appRoutes: Routes = [
  {
    path: '',
    runGuardsAndResolvers: 'always',
    // canActivate: [NonAdminGuard],
    children: [
      { path: 'home', component: HomeComponent },
      { path: 'products', component: ProductListComponent },
      { path: 'cart', component: CartComponent },
    ],
  },

  {
    path: '',
    runGuardsAndResolvers: 'always',
    // canActivate: [CustomerAuthGuard],
    children: [],
  },

  {
    path: 'admin',
    component: AdminSidemenuComponent,
    runGuardsAndResolvers: 'always',
    // canActivate: [AdminAuthGuard],
    children: [
      { path: 'dashboard', component: AdminDashboardComponent },
      { path: 'sales', component: AdminSalesComponent },
      { path: 'purchase', component: AdminPurchaseComponent },
      { path: 'customers', component: AdminCustomersComponent },

      { path: 'products', component: AdminProductsComponent },
      { path: 'products/list', component: AdminProductListComponent },
      { path: 'products/create', component: AdminProductCreateComponent },

      {
        path: 'products/categories/main',
        component: AdminCategoryMainViewComponent,
      },

      {
        path: 'products/categories/sub',
        component: AdminCategorySubViewComponent,
      },

      {
        path: 'products/categories/create',
        component: AdminCategoryCreateComponent,
      },
    ],
  },

  {
    path: '',
    runGuardsAndResolvers: 'always',
    // canActivate: [AuthGuard],
    children: [
      { path: 'sign', component: SignComponent },
      { path: 'admin/sign', component: AdminSignComponent },
    ],
  },

  // {
  //   path: 'admin',
  //   runGuardsAndResolvers: 'always',
  //   canActivate: [AuthGuard],
  //   children: [{ path: 'sign', component: AdminSignComponent }],
  // },

  // { path: 'admin', component: AdminDashboardComponent },

  { path: '**', redirectTo: 'home', pathMatch: 'full' },
];
