var gulp = require('gulp');
var browserify = require('browserify');
var source = require('vinyl-source-stream');
var buffer = require('vinyl-buffer');
var reactify = require('reactify');
var uglify = require('gulp-uglify');

var minifyCss = require('gulp-minify-css');
var sourcemaps = require('gulp-sourcemaps');

gulp.task('build', function () {
    var bundleStream = browserify({
        entries: './scripts/src/main.jsx',
        transform: [reactify],
        debug: true
    }).bundle();

    bundleStream
        .pipe(source('main.js'))
        .pipe(buffer())
        //.pipe(uglify())
        .pipe(gulp.dest('./scripts/dist'));
});

gulp.task('build-release', function () {
    var bundleStream = browserify({
        entries: './scripts/src/main.jsx',
        transform: [reactify],
        debug: true
    }).bundle();

    bundleStream
        .pipe(source('main.js'))
        .pipe(buffer())
        .pipe(uglify())
        .pipe(gulp.dest('./scripts/dist'));
});

gulp.task('minify-css', function() {
  return gulp.src('./Content/*.css')
    .pipe(sourcemaps.init())
    .pipe(minifyCss())
    .pipe(sourcemaps.write())
    .pipe(gulp.dest('./Content/Ugly'));
});
