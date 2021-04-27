var Shopper = /** @class */ (function () {
    //firstName = "";
    //lastName = "";
    //by adding in the private/public or whatever, it tells the typescipt that those are going to be members of the class
    //so we don't have to separately instantiate them
    function Shopper(first, last) {
        this.first = first;
        this.last = last;
        //    this.firstName = first;
        //    this.lastName = last;
    }
    Shopper.prototype.showName = function () {
        alert('${this.firstName} ${this.lastName}');
    };
    return Shopper;
}());
//# sourceMappingURL=shopper.js.map