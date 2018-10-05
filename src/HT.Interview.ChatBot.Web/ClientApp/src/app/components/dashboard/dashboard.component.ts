import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from "@angular/common/http";
import { Dashboard } from '../../models/dashboard';
import { environment } from '../../../environments/environment';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})

export class DashboardComponent implements OnInit {
                   
  constructor(private http: HttpClient) { }
  private webAPIDashboardChartUrl = environment.application.webAPIUrl + environment.controller.dashboardController + environment.action.getMany;

  public barChartType: string = 'bar';    
  public barChartDataset: Array<any>;
  public barChartLabels: Array<any>;

  public pieChartType: string = 'pie';    
  public pieChartDataset: Array<any>;
  public pieChartLabels: Array<any>;
  public chartData: any;

  public chartColors: Array<any> = [    
  ];
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

  ngOnInit() {
    this.http.get<Dashboard[]>(this.webAPIDashboardChartUrl)
      .subscribe(data => {
        this.chartData = data;
       
        this.barChartLabels = this.chartData[0].chartLabel;
        this.barChartDataset = this.chartData[0].chartDataSet;

        //var pieChartData = chartData[0].chartDataSet[0].data;
        //this.pieChartLabels = this.chartData[0].chartLabel;
        //this.pieChartDataset = pieChartData;
      });  
  }

  ngOnChanges() {

  }
}
