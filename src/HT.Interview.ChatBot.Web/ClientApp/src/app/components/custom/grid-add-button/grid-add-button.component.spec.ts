import { async, ComponentFixture, TestBed } from '@angular/core/testing';    
import { GridAddButtonComponent } from './grid-add-button.component';

describe('GridAddButtonComponent', () => {
  let component: GridAddButtonComponent;
  let fixture: ComponentFixture<GridAddButtonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [GridAddButtonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GridAddButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
