import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EngineerDetailComponent } from './engineer-detail.component';

describe('EngineerDetailComponent', () => {
  let component: EngineerDetailComponent;
  let fixture: ComponentFixture<EngineerDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EngineerDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EngineerDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
