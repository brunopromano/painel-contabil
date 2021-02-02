import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConciliacaoDiariaComponent } from './conciliacao-diaria.component';

describe('ConciliacaoDiariaComponent', () => {
  let component: ConciliacaoDiariaComponent;
  let fixture: ComponentFixture<ConciliacaoDiariaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConciliacaoDiariaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConciliacaoDiariaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
