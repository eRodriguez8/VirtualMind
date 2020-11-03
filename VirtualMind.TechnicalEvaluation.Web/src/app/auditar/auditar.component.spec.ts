import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SeguimientoULComponent } from './seguimiento-ul.component';

describe('SeguimientoULComponent', () => {
  let component: SeguimientoULComponent;
  let fixture: ComponentFixture<SeguimientoULComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SeguimientoULComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SeguimientoULComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
