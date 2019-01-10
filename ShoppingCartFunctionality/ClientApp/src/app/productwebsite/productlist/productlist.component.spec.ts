/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ProductlistComponent } from './productlist.component';

let component: ProductlistComponent;
let fixture: ComponentFixture<ProductlistComponent>;

describe('productlist component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ProductlistComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ProductlistComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});