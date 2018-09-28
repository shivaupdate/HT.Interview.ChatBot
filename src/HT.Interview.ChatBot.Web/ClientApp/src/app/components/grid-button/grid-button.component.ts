import { Component } from "@angular/core";
import { ICellRendererAngularComp } from "ag-grid-angular";

@Component({
  selector: 'app-grid-button',
  template: `<div style="text-align:center;" (click)="invokeParentMethod()"><i class="fa fa-trophy" style="color:black; cursor: pointer;"></i></div>` 
})
export class GridButtonComponent implements

  ICellRendererAngularComp {
  public params: any;

  agInit(params: any): void {
    this.params = params;
  }

  public invokeParentMethod() {       
    this.params.context.componentParent.showEvaluateGrid(this.params.data.id);
  }

  refresh(): boolean {
    return false;
  }


  showEvaluateGrid() {
    console.log("test");
  }
}
