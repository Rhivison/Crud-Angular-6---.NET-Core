import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListPhoneNumberComponent } from './list-phone-number.component';

describe('ListPhoneNumberComponent', () => {
  let component: ListPhoneNumberComponent;
  let fixture: ComponentFixture<ListPhoneNumberComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListPhoneNumberComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListPhoneNumberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
