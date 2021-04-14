

//everything in a JS file has a "global scope".. so this causes collisions in naming conventions.
//so the "common way to deal with this.. is to wrap your ENTIRE js file in an anonymous function
//because by putting it in an anon function, we can keep everything inside the function visible to each other, without worrying about the global scope
//this also lets us basically say, by wrapping that overall wrapper function with parenthesis, and putting (); at the end, its saying to
//load the function, and execute it when it's done loading

//(function () {

//    var x = 0;
//    var s = "";

//    //alert("Hello Js refresh!");

//    console.log("Hello js refresher... forgot there was intellisense in js files");


//    //so this uses jquery to automatically "query" the document... and uses the same system as CSS
//    var theForm = $("#theForm");
//    //the query always returns a collection...
//    //keeping that in mind, we know if we're using the #name syntax, we're only going to have a single object, if any
//    //so
//    //theForm.hidden = true;
//    //becomes
//    theForm.hide();

//    //vanilla JS
//    //var button = document.getElementById("buyButton");
//    //button.addEventListener("click", function () {
//    //    console.log("Buying Item");
//    //})

//    //jquery syntax
//    var button = $("#buyButton");
//    button.on("click", function () {
//        console.log("Buying Item");
//    })

//    //vanilla JS
//    //var productInfo = document.getElementsByClassName("productInfo");
//    //var listItems = productInfo.item[0].children;

//    //jquery syntax
//    //keep in mind that just like css, anything on the page that is an li child of parent with class of .productInfo is going to get this applied to it
//    var productInfo = $(".productInfo li");
//    productInfo.on("click", function () {
//        console.log("You Clicked on " + $(this).text())
//    })


//})();

//-------------------------------------------------------------------------------------------------------------------------------------------------

//the way around this with JQeury...
//this guarantees that the browser has loaded EVERYTHING IN THE DOM, then says ok load this..
$(document).ready(function () {
    var x = 0;
    var s = "";

    //alert("Hello Js refresh!");

    console.log("Hello js refresher... forgot there was intellisense in js files");


    //so this uses jquery to automatically "query" the document... and uses the same system as CSS
    var theForm = $("#theForm");
    //the query always returns a collection...
    //keeping that in mind, we know if we're using the #name syntax, we're only going to have a single object, if any...
    //so.
    //theForm.hidden = true;
    //becomes
    theForm.hide();

    //vanilla JS
    //var button = document.getElementById("buyButton");
    //button.addEventListener("click", function () {
    //    console.log("Buying Item");
    //})

    //jquery syntax
    var button = $("#buyButton");
    button.on("click", function () {
        console.log("Buying Item");
    })

    //vanilla JS
    //var productInfo = document.getElementsByClassName("productInfo");
    //var listItems = productInfo.item[0].children;

    //jquery syntax
    //keep in mind that just like css, anything on the page that is an li child of parent with class of .productInfo is going to get this applied to it
    var productInfo = $(".productInfo li");
    productInfo.on("click", function () {
        console.log("You Clicked on " + $(this).text())
    });


    //get objects we need first
    //use $sign in name so you know its a jquery object
    var $loginToggle = $("#loginToggle");
    var $popupForm = $(".popup-form");

    $loginToggle.on("click", function () {
        $popupForm.fadeToggle(500);
    });



});//end of jquery wrapper

