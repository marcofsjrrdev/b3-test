import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent {
  taxCDI: number = 0.9;
  taxBank: number = 108;
  initialValue: number | null = null;
  months: number | null = null;
  liquidValue: number | null = null;

  constructor(private http: HttpClient) { }

  calculate(): void {
    const url = `https://localhost:7123/api/calculatecdb/calculate?initialValue=${this.initialValue}&months=${this.months}`;
    
    this.http.get(url).subscribe((response: any) => {
      this.liquidValue = response.liquidValue;
    });
  }
}
