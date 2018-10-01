import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from "@angular/common/http";
import { environment } from '../../../environments/environment';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})

export class DashboardComponent implements OnInit {
                   
  constructor(private http: HttpClient) { }
  private ChartwebAPIUrl = environment.application.webAPIUrl + environment.controller.dashboardController + environment.action.get;
  private chartData: any;
  ngOnInit() {
    this.test();
  
  }
  ngOnChanges() {  }

  public test(): void {
    this.http.get(this.ChartwebAPIUrl)
      .subscribe(data => {
        this.chartData = data;     
        this.chartDatasets = this.chartData;
        console.log(this.chartData);
        this.chartLabels = this.chartData[0].month
      });
   
  }
 public map: any = { lat: 51.678418, lng: 7.809007 };
  public chart1Type:string = 'bar';
  public chart2Type:string = 'pie';     

  public chartDatasets: Array<any>;
  public chartType = 'line';
                                   

  public chartLabels: Array<any>; 

  public chartColors:Array<any> = [

  ];

  public dateOptionsSelect: any[];
  public bulkOptionsSelect: any[];
  public showOnlyOptionsSelect: any[];
  public filterOptionsSelect: any[];

  public chartOptions: any = {
    responsive: true,
    legend: {
      labels: {
        fontColor: '#5b5f62',
      }
    },
    scales: {
      yAxes: [{
        ticks: {
          fontColor: '#5b5f62',
        }
      }],
      xAxes: [{
        ticks: {
          fontColor: '#5b5f62',
        }
      }]
    }
  };

  //public chartType: string = 'bar';

  //public chartDatasets: Array<any> = [
  //  { data: [65, 59, 80, 81, 56, 55, 40], label: 'My First dataset' },
  //  { data: [0, 48, 40, 19, 86, 27, 90], label: 'My Second dataset' }
  //];

  //public chartLabels: Array<any> = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul'];

  //public chartColors: Array<any> = [
  //  {
  //    backgroundColor: 'rgba(220,220,220,0.2)',
  //    borderColor: 'rgba(220,220,220,1)',
  //    borderWidth: 2,
  //    pointBackgroundColor: 'rgba(220,220,220,1)',
  //    pointBorderColor: '#fff',
  //    pointHoverBackgroundColor: '#fff',
  //    pointHoverBorderColor: 'rgba(220,220,220,1)'
  //  },
  //  {
  //    backgroundColor: 'rgba(151,187,205,0.2)',
  //    borderColor: 'rgba(151,187,205,1)',
  //    borderWidth: 2,
  //    pointBackgroundColor: 'rgba(151,187,205,1)',
  //    pointBorderColor: '#fff',
  //    pointHoverBackgroundColor: '#fff',
  //    pointHoverBorderColor: 'rgba(151,187,205,1)'
  //  }
  //];

  //public chartOptions: any = {
  //  responsive: true
  //};
  //public chartClicked(e: any): void { }
  //public chartHovered(e: any): void { }
}
