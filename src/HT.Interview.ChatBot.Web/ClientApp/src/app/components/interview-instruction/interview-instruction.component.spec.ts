import { async, ComponentFixture, TestBed } from '@angular/core/testing';    
import { InterviewInstructionComponent } from './interview-instruction.component';

describe('InterviewInstructionComponent', () => {
  let component: InterviewInstructionComponent;
  let fixture: ComponentFixture<InterviewInstructionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [InterviewInstructionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InterviewInstructionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
