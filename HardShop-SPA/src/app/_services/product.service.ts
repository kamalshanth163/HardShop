import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { Product } from '../_models/product';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  baseUrl = environment.apiUrl + 'admins/3/';

  constructor(private http: HttpClient) {}

  createProduct(product: Product) {
    return this.http.post(this.baseUrl + 'products', product).pipe(
      map((response: any) => {
        if (response) {
          console.log(response);
        }
      })
    );
  }

  createMainCategory(mainCategory) {
    return this.http.post(this.baseUrl + 'products/categories/main', mainCategory).pipe(
      map((response: any) => {
        if (response) {
          console.log(response);
        }
      })
    );
  }

  createSubCategory(subCategory) {
    return this.http.post(this.baseUrl + 'products/categories/sub', subCategory).pipe(
      map((response: any) => {
        if (response) {
          console.log(response);
        }
      })
    );
  }

  getMainCategory(mainName: string) {
    return this.http.get(
      this.baseUrl + 'products/categories/main/name/' + mainName
    );
  }

  getMainCategories() {
    return this.http.get(this.baseUrl + 'products/categories/main');
  }

  getSubCategories(mainId: number) {
    return this.http.get(
      this.baseUrl + 'products/categories/main/' + mainId + '/sub'
    );
  }

  createCategory(category: any) {
    return this.http
      .post(this.baseUrl + 'products/categories/main', category)
      .pipe(
        map((response: any) => {
          if (response) {
            console.log(response);
          }
        })
      );
  }
}
