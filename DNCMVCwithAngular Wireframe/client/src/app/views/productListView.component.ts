import { Component, OnInit } from "@angular/core";
import { Store } from "../services/store.service";

@Component({
    selector: "product-List",
    templateUrl: "productListView.component.html",
    //css files scoped just to this part of the view
    styleUrls: ["productListView.component.css"]
    
})

export default class ProductListView implements OnInit {


    constructor(public store: Store) {
    }

    ngOnInit(): void {
        this.store.loadProducts()
            .subscribe(); // this 'subscribe' actually kicks off the operation
    }

}