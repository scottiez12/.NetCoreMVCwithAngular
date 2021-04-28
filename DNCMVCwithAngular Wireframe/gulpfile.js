
var gulp = require("gulp");
var uglify = require("gulp-uglify")
var concat = require("gulp-concat")

//minify js
function minify() {
    return gulp.src(["wwwroot/js/**/*.js"])
        .pipe(uglify())
        .pipe(concat("project.min.js"))
        .pipe(gulp.dest("wwwroot/dist/"))
        ;
}


//minify css
function styles() {
    return gulp.src(["wwwroot/css/**/*.css"])
        .pipe(uglify())
        .pipe(concat("project.min.css"))
        .pipe(gulp.dest("wwwroot/dist"));
}


exports.minify = minify;
exports.styles = style;

//can use series or parallel, depending on available threads..
exports.default = gulp.parallel(minify, styles);