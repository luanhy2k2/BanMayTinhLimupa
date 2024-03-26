import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExportInvoiceComponent } from './export-invoice.component';

describe('ExportInvoiceComponent', () => {
  let component: ExportInvoiceComponent;
  let fixture: ComponentFixture<ExportInvoiceComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExportInvoiceComponent]
    });
    fixture = TestBed.createComponent(ExportInvoiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
