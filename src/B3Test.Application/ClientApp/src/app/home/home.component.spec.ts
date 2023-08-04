import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HomeComponent } from './home.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { HttpClient } from '@angular/common/http';
import { of } from 'rxjs';

describe('HomeComponent', () => {
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;
  let httpClient: HttpClient;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [HomeComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
    httpClient = TestBed.inject(HttpClient);
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should calculate liquid value', () => {
    const response = { liquidValue: 5625 }; // Mocked response
    spyOn(httpClient, 'get').and.returnValue(of(response));

    component.initialValue = 5000;
    component.months = 12;
    component.calculate();

    expect(httpClient.get).toHaveBeenCalledOnceWith(`https://localhost:7123/api/calculatecdb/calculate?initialValue=5000&months=12`);
    expect(component.liquidValue).toBe(response.liquidValue);
  });
});
