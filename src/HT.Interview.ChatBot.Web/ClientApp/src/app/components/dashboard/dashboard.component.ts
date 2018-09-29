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
}
