import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ComprarMonedaComponent } from './comprar-moneda.component';

describe('ComprarMonedaComponent', () => {
  let component: ComprarMonedaComponent;
  let fixture: ComponentFixture<ComprarMonedaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ComprarMonedaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ComprarMonedaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
