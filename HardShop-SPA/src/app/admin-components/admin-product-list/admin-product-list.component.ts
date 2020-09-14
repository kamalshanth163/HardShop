import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/_services/auth.service';
import { AlertifyService } from 'src/app/_services/alertify.service.service';
import { Router } from '@angular/router';
import { ProductService } from 'src/app/_services/product.service';

@Component({
  selector: 'app-admin-product-list',
  templateUrl: './admin-product-list.component.html',
  styleUrls: ['./admin-product-list.component.css']
})
export class AdminProductListComponent implements OnInit {
  product: any;
  productToCreate: any = {};
  products: any = [];
  account: any = true;
  productCreateForm: FormGroup;

  constructor(
    public productService: ProductService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.loadProducts();
  }
  loadProducts() {
    this.productService.getMainCategories().subscribe(
      (products: any) => {
        this.products = products;
        // console.log(this.products);
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

}
