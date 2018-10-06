import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TalkToLauraComponent } from './talk-to-laura.component';

describe('ChatDialogComponent', () => {
  let component: TalkToLauraComponent;
  let fixture: ComponentFixture<TalkToLauraComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [TalkToLauraComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TalkToLauraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
