import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { Store } from './services/store.service';
import ProductListView from './views/productListView.component';


@NgModule({
  declarations: [
        AppComponent,
        ProductListView
    ],
    //this is where you can add other "bundles".. just like the _imports in blazor, just make sure to add the import statement above
    //as intellisense is kind of iffy on this
  imports: [
      BrowserModule,
      HttpClientModule
    ],
  //this is where you put the injectable services
    providers: [
        Store
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
