import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ProductService } from 'src/app/_services/product.service';
import { AlertifyService } from 'src/app/_services/alertify.service.service';
import { Router } from '@angular/router';
import { Product } from 'src/app/_models/product';

@Component({
  selector: 'app-admin-product-create',
  templateUrl: './admin-product-create.component.html',
  styleUrls: ['./admin-product-create.component.css'],
})
export class AdminProductCreateComponent implements OnInit {
  product: any;
  products: any = [];

  mainCategory: any;
  mainCategories: any = [];

  subCategory: any;
  subCategories: any = [];

  productToCreate: any = {};
  account: any = true;
  productCreateForm: FormGroup;

  constructor(
    public productService: ProductService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.loadMainCategories();
    this.createProductCreateForm();
  }

  createProductCreateForm() {
    this.productCreateForm = this.fb.group({
      mainCategory: ['', Validators.required],
      subCategory: ['', Validators.required],
      brand: ['', Validators.required],
      name: ['', Validators.required],
      model: ['', Validators.required],
      size: ['', Validators.required],
      color: ['', Validators.required],
      currency: ['', Validators.required],
      price: ['', Validators.required],
      discount: ['', Validators.required],
      quantity: ['', Validators.required],
      status: ['available'],
      description: ['', Validators.required],
    });
  }

  onOptionSelected(value: string) {
    this.productService.getMainCategory(value).subscribe(
      (mainCategory: any) => {
        this.productService.getSubCategories(mainCategory.id).subscribe(
          (subCategories: any) => {
            this.subCategories = subCategories;
          },
          (error) => {
            this.alertify.error(error);
          }
        );
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  createProduct() {
    if (this.productCreateForm.valid) {
      console.log(this.productCreateForm.value);

      this.product = Object.assign({}, this.productCreateForm.value);

      this.productService.createProduct(this.product).subscribe(
        (next) => {
          this.alertify.success('Product successfully created!!');
        },
        (error) => {
          this.alertify.error(error);
        },
        () => {
          this.router.navigate(['/admin/products']);
        }
      );
    }
  }

  loadMainCategories() {
    this.productService.getMainCategories().subscribe(
      (mainCategories: any) => {
        this.mainCategories = mainCategories;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }
}
