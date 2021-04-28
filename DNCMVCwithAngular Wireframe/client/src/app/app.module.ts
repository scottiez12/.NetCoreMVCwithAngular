import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { Store } from './services/store.service';
import ProductListView from './views/productListView.component';
import { CartView } from './views/cartView.component';
import router from './router';
import { ShopPage } from './pages/shopPage.component';
import { LoginPage } from './pages/loginPage.component';
import { AuthActivator } from './services/authActivator.service';
import { Checkout } from './pages/checkout.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
        AppComponent,
        ProductListView,
        CartView,
        ShopPage,
        Checkout,
        LoginPage
    ],
    //this is where you can add other "bundles".. just like the _imports in blazor, just make sure to add the import statement above
    //as intellisense is kind of iffy on this
  imports: [
      BrowserModule,
      //this lets you make http requests.. to apis..
      HttpClientModule,
      //access to our routing module..
      router,
      //2 way data binding for forms..
      FormsModule
    ],
  //this is where you put the injectable services
    providers: [
        Store,
        AuthActivator
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
