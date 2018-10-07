import { Component } from "@angular/core";
import { ICellRendererAngularComp } from "ag-grid-angular";

@Component({
  selector: 'app-grid-button',
  template: `<div *ngIf="this.params.colDef.headerName == 'Resume' && params.data.resumeFilePath != null" style="text-align:center;" (click)="invokeParentMethod()">
              <img src="../../../assets/images/resume.png" style="cursor: pointer;height: 17px;width: 20px;"/>
            </div>
             <div *ngIf="this.params.colDef.headerName == 'Recording' && params.data.recordingFilePath != null" style="text-align:center;" (click)="invokeParentMethod()">
                <i class="fa fa-video-camera" style="color: darkcyan; cursor: pointer;"></i>
              </div>
             `
})

export class DownloadFileComponent implements

  ICellRendererAngularComp {
  public params: any;

  agInit(params: any): void {
    this.params = params;                                       
  }

  public invokeParentMethod() {       
    this.params.context.componentParent.downloadFile(this.params.colDef.headerName, this.params.data);
  }

  refresh(): boolean {
    return false;
  }                         
}
