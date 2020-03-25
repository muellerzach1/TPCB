import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ODBComponent } from './odb.component';

describe('ODBComponent', () => {
  let component: ODBComponent;
  let fixture: ComponentFixture<ODBComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ODBComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ODBComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
