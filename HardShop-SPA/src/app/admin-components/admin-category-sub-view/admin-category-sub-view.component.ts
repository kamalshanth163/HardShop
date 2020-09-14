import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/_services/product.service';
import { AlertifyService } from 'src/app/_services/alertify.service.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-admin-category-sub-view',
  templateUrl: './admin-category-sub-view.component.html',
  styleUrls: ['./admin-category-sub-view.component.css'],
})
export class AdminCategorySubViewComponent implements OnInit {
  subCategory: any;
  subCategories: any = [];
  subCategoryUpdateForm: FormGroup;

  constructor(
    public productService: ProductService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.loadMainCategories();
    this.createsubCategoryUpdateForm();
  }

  loadMainCategories() {
    this.productService.getMainCategories().subscribe(
      (subCategories: any) => {
        this.subCategories = subCategories;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  createsubCategoryUpdateForm() {
    this.subCategoryUpdateForm = this.fb.group({
      name: ['', Validators.required],
    });
  }
  updateSubCategory() {
    if (this.subCategoryUpdateForm.valid) {
      this.subCategory = Object.assign({}, this.subCategoryUpdateForm.value);

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
