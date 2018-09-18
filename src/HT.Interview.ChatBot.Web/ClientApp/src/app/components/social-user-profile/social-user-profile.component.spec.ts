import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SocialUserProfileComponent } from './social-user-profile.component';

describe('SocialUserProfileComponent', () => {
  let component: SocialUserProfileComponent;
  let fixture: ComponentFixture<SocialUserProfileComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SocialUserProfileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SocialUserProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
