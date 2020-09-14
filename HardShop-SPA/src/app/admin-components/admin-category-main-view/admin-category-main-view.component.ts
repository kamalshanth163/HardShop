import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/_services/product.service';
import { AlertifyService } from 'src/app/_services/alertify.service.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-admin-category-main-view',
  templateUrl: './admin-category-main-view.component.html',
  styleUrls: ['./admin-category-main-view.component.css'],
})
export class AdminCategoryMainViewComponent implements OnInit {
  mainCategory: any;
  mainCategories: any = [];
  mainCategoryUpdateForm: FormGroup;

  constructor(
    public productService: ProductService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.loadMainCategories();
    this.createMainCategoryUpdateForm();
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

  createMainCategoryUpdateForm() {
    this.mainCategoryUpdateForm = this.fb.group({
      name: ['', Validators.required],
    });
  }
  updateMainCategory() {
    if (this.mainCategoryUpdateForm.valid) {
      this.mainCategory = Object.assign({}, this.mainCategoryUpdateForm.value);

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
}
