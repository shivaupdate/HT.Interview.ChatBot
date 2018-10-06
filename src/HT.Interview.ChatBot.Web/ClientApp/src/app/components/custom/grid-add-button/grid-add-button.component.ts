import { Component } from "@angular/core";
import { ICellRendererAngularComp } from "ag-grid-angular";

@Component({
  selector: 'app-grid-add-button',
  template: `<div style="text-align:center;" (click)="invokeParentMethod()"><i class="fa fa-trophy" style="color: darkslateblue; cursor: pointer;"></i></div>` 
})

export class GridAddButtonComponent implements

  ICellRendererAngularComp {
  public params: any;

  agInit(params: any): void {
    this.params = params;
  }

  public invokeParentMethod() {       
    this.params.context.componentParent.gridAddButtonClick(this.params.data);
  }

  refresh(): boolean {
    return false;
  }          
}
