import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsFriendComponent } from './details-friend.component';

describe('DetailsFriendComponent', () => {
  let component: DetailsFriendComponent;
  let fixture: ComponentFixture<DetailsFriendComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailsFriendComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsFriendComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
