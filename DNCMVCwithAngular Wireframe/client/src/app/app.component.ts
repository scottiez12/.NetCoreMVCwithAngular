import { Component } from '@angular/core';

@Component({
    //the selector property is the element that this component is going to try to render into..
  //selector: 'app-root',
    selector: 'the-shop',
    //renamed this to templateUrl instead of just template; will make it easier to figure out endpoints later on....
  templateUrl:"app.component.html",
  styles: []
})
export class AppComponent {
    //this is just a property that can be selected with the double handlebar {{}} syntax, just like using @ in DNC
  //title = 'client';
  title = 'DNC With Angular';
}
