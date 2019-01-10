import { Component,OnInit } from '@angular/core';
import{ ItemDetailsService} from '../services/itemservice';
import { Item } from '../itemmodel';
@Component({
    selector: 'app-productlist',
    templateUrl: './productlist.component.html',
    styleUrls: ['./productlist.component.css']
})
/** productlist component*/
export class ProductListComponent implements OnInit {
    /** productlist ctor */
    constructor(private itemService:ItemDetailsService) {

    }
    items:Item[];
    ngOnInit()
    {
        this.itemService.getItemsFromApi().subscribe(items=> this.items=items);

    }

}
