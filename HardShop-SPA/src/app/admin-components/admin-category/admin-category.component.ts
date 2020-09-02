import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ProductService } from 'src/app/_services/product.service';
import { AlertifyService } from 'src/app/_services/alertify.service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-category',
  templateUrl: './admin-category.component.html',
  styleUrls: ['./admin-category.component.css'],
})
export class AdminCategoryComponent implements OnInit {
  subCategory: any;
  mainCategory: any;
  subCategories: any = [];
  mainCategories: any = [];
  account: any = true;
  mainCategoryCreateForm: FormGroup;
  subCategoryCreateForm: FormGroup;

  constructor(
    public productService: ProductService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.loadMainCategories();
    this.createMainCategoryCreateForm();
    this.createSubCategoryCreateForm();
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

  createMainCategoryCreateForm() {
    this.mainCategoryCreateForm = this.fb.group({
      name: ['', Validators.required]
    });
  }

  createSubCategoryCreateForm() {
    this.subCategoryCreateForm = this.fb.group({
      mainCategory: ['', Validators.required],
      name: ['', Validators.required]
    });
  }

  createMainCategory() {
    if (this.mainCategoryCreateForm.valid) {
      this.mainCategory = Object.assign({}, this.mainCategoryCreateForm.value);

      this.productService.createMainCategory(this.mainCategory).subscribe(
        (next) => {
          this.alertify.success('Category successfully created!!');
          this.loadMainCategories();
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

  createSubCategory() {
    if (this.subCategoryCreateForm.valid) {
      this.subCategory = Object.assign({}, this.subCategoryCreateForm.value);

      this.productService.createSubCategory(this.subCategory).subscribe(
        (next) => {
          this.alertify.success('Category successfully created!!');
          this.loadMainCategories();
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

}
