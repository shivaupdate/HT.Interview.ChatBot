import { Component } from "@angular/core";
import { ICellRendererAngularComp } from "ag-grid-angular";

@Component({
  selector: 'app-grid-button',
  template: `<div style="text-align:center;" (click)="invokeParentMethod()"><img src="../../../assets/images/resume.png" style="cursor: pointer;height: 17px;width: 20px;"/></div>` 
})

export class DownloadFileComponent implements

  ICellRendererAngularComp {
  public params: any;

  agInit(params: any): void {
    this.params = params;
  }

  public invokeParentMethod() {       
    this.params.context.componentParent.downloadFile(this.params.data);
  }

  refresh(): boolean {
    return false;
  }                         
}
