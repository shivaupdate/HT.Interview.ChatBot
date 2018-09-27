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
  public chart3Type:string = 'line';
  public chart4Type:string = 'radar';
  public chart5Type:string = 'doughnut';

  public chartDatasets: Array<any>;
  public chartType = 'line';

  //public chartDatasets: Array<any> = [
  //  {data: [50, 40, 60, 51, 56, 55, 40], label: '#Dot Net'},
  //  {data: [28, 80, 40, 69, 36, 37, 110], label: '#Java'},
  //  {data: [38, 58, 30, 90, 45, 65, 30], label: '#PHP'}
  //];

  public chartLabels: Array<any>;/* = ['Jan', 'Feb'];*/

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
