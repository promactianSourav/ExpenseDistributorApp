import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NonGroupTransactionComponent } from './non-group-transaction.component';

describe('NonGroupTransactionComponent', () => {
  let component: NonGroupTransactionComponent;
  let fixture: ComponentFixture<NonGroupTransactionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NonGroupTransactionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NonGroupTransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
