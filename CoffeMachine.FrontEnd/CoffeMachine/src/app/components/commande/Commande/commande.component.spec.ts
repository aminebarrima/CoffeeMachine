import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Commande1Component } from './commande.component';

describe('CommandeComponent', () => {
  let component: Commande1Component;
  let fixture: ComponentFixture<Commande1Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Commande1Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Commande1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
  

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
