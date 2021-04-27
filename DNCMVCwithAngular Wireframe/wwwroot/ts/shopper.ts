
class Shopper {

    //firstName = "";
    //lastName = "";
    //by adding in the private/public or whatever, it tells the typescipt that those are going to be members of the class
    //so we don't have to separately instantiate them
    constructor(private first: string, private last: string) {
    //    this.firstName = first;
    //    this.lastName = last;
    }

    showName() {
        alert('${this.firstName} ${this.lastName}');
    }


}