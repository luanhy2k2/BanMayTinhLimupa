import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportInvoiceDetailComponent } from './import-invoice-detail.component';

describe('ImportInvoiceDetailComponent', () => {
  let component: ImportInvoiceDetailComponent;
  let fixture: ComponentFixture<ImportInvoiceDetailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ImportInvoiceDetailComponent]
    });
    fixture = TestBed.createComponent(ImportInvoiceDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
