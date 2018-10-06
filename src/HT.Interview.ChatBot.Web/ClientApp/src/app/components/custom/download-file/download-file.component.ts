import { Component } from "@angular/core";
import { ICellRendererAngularComp } from "ag-grid-angular";

@Component({
  selector: 'app-grid-button',
  template: `<div style="text-align:center;" (click)="invokeParentMethod()"><i class="fa fa-file" style="color: darkcyan; cursor: pointer;"></i></div>` 
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
