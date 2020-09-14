import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminCategorySubViewComponent } from './admin-category-sub-view.component';

describe('AdminCategorySubViewComponent', () => {
  let component: AdminCategorySubViewComponent;
  let fixture: ComponentFixture<AdminCategorySubViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminCategorySubViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminCategorySubViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
