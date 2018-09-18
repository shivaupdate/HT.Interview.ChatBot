import { ComponentFixture, TestBed, async } from '@angular/core/testing';
import { DebugElement } from '@angular/core';
import { By } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { NO_ERRORS_SCHEMA, ChangeDetectorRef } from '@angular/core';

import { NavigationComponent } from './navigation.component';
/* import { AppDataService } from './../services/app-data.service';
import { AppDataServiceStub } from './../../test/app-data.service-stub';
import { DataService } from '../../analysis/services/data-admin.service';
import { DataServiceStub } from './../../test/data-admin.service-stub';
import { BreadcrumbService } from './../breadcrumb-component/breadcrumbService';
import { BreadcrumbServiceStub } from './../../test/breadcrumb.service-stub'; */

let comp: NavigationComponent;
let fixture: ComponentFixture<NavigationComponent>;
let de: DebugElement;
let el: HTMLElement;

describe('NavigationComponent', () => {
   /*  let appDataServiceStub = new AppDataServiceStub();
    let dataServiceStub = new DataServiceStub();
    let breadcrumbServiceStub = new BreadcrumbServiceStub();

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            providers: [
                { provide: Router, useClass: RouterTestingModule },
                { provide: AppDataService, useValue: appDataServiceStub },
                { provide: BreadcrumbService, useValue: breadcrumbServiceStub },
                { provide: DataService, useValue: dataServiceStub }
            ], 
            declarations: [NavigationComponent], // declare the test component
            schemas: [NO_ERRORS_SCHEMA]
        }); 
    }));*/

    beforeEach(() => {
        fixture = TestBed.createComponent(NavigationComponent);
        comp = fixture.componentInstance;
    });

    it('Ensures navigation component exists and if renamed or deleted should fail the test', () => {
        fixture.detectChanges();        
        expect(comp).toBeTruthy();
        expect(comp).not.toBe(undefined);
        //To Do- Need to find a way to verify the component name
    });

    it('Check if the application name is displayed correctly', () => {
        fixture.detectChanges();
        de = fixture.debugElement.query(By.css('.header-bar div:first-child'));
        el = de.nativeElement;        
        expect(el.innerText).toBe("EY Benchmark");
    });

    it('Check if LEARN and BROWSE tabs are displayed for a normal EY user', () => {
        fixture.detectChanges();
        de = fixture.debugElement.query(By.css('.navbar-nav'));
        el = de.nativeElement;        
        expect(el.childElementCount).toBe(2);        
        expect(el.innerText).toBe("LEARN BROWSE");
    });
});