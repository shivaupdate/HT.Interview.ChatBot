import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';


@Component({
    moduleId: module.id.toString(),
    selector: 'navigation-component',
    templateUrl: './navigation.component.html',
    styleUrls: ["./navigation.component.css"]
})

export class NavigationComponent implements OnInit {
    applicationName = "Hexaware Interview Automation";
    @Input('activeMenuItemId') activeMenuItemId: number;
    userRoles: Array<number> = [];
    userName = "";
    currentMessage = "";
    isHovered = false;

    constructor(
        private _router: Router
       ) {}
   
    ngOnInit() {
        this.setUserName();
        this.getDataLoadStatus();
    }

    onTabHover(identifier: number): void {
        this.isHovered = true;
        
    }  

    setUserName(): void {
        this.userName = 'Admin';
        //this.userRoles = this._appDataService.userDetails.userRoles;
    }

    logoutUser(): void {
        //Logout from azure 
        /* this._adalService.logOut();
        this._adalService.clearCache(); */
    }

    getDataLoadStatus(): any {
        /* this._dataService.DataLoadStatus().subscribe(
            (data: DataLoadStatusParams) => { this.nodes = data; this._dataService.nodes = this.nodes },
            (error) => console.log(error)
        ); */
    }

    closeVisualizationContainer(): void {
        /* if (this._appDataService.showVisualizationContainer) {
            this._breadcrumbService.stripCrumbItems(2);
            this._breadcrumbService.breadCrumbData[1].isStaticElement = true;
            this._appDataService.toggleVisualizationContainer(false);
            this._appDataService.onVisualizationContainerClose.emit();
        } */
    }
}