import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminCategoryMainViewComponent } from './admin-category-main-view.component';

describe('AdminCategoryMainViewComponent', () => {
  let component: AdminCategoryMainViewComponent;
  let fixture: ComponentFixture<AdminCategoryMainViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminCategoryMainViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminCategoryMainViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
