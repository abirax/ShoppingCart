import {Injectable} from "@angular/core";
//import { HttpClient } from "@angular/http";
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { Item } from "../itemmodel";
@Injectable()
export class ItemDetailsService{
    /**
     *
     */
    itemList:Item[];
    constructor(private http:HttpClient) {
        
        
    }
    getItemsFromApi():Observable<Item[]>
    {
        return this.http.get<Item[]>("api/itemapi/details");
        
    }
}