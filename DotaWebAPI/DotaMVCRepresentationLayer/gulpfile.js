var gulp = require('gulp');
var browserify = require('browserify');
var source = require('vinyl-source-stream');
var buffer = require('vinyl-buffer');
var reactify = require('reactify');
var uglify = require('gulp-uglify');
//var jshint = require('gulp-jshint');
var watchify = require('watchify');
var assign = require('lodash.assign');
var gutil = require('gulp-util');

var minifyCss = require('gulp-minify-css');
var sourcemaps = require('gulp-sourcemaps');

var gStreamify = require('gulp-streamify');


var buildOpt = {
    entries: './scripts/src/main.jsx',
    transform: [reactify],
    debug: true
};

gulp.task('build', function () {
    var bundleStream = browserify(buildOpt).bundle();

    return bundleStream
        .pipe(source('main.js'))
        .pipe( gStreamify(sourcemaps.init({loadMaps: true})) )
            .pipe(buffer())  
        .pipe(sourcemaps.write())
        .pipe(gulp.dest('./scripts/dist'));
});

gulp.task('build-release', function () {
    var bundleStream = browserify({
        entries: './scripts/src/main.jsx',
        transform: [reactify],
        debug: false
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
    .pipe(sourcemaps.write())
    .pipe(gulp.dest('./Content/Ugly'));
});
gulp.task('minify-css-release', function() {
  return gulp.src('./Content/*.css')
    .pipe(minifyCss())
    .pipe(gulp.dest('./Content/Ugly'));
});


gulp.task('watch-content-dev', function(){
  // watch other files, for example .less file
  gulp.watch('./scripts/src/**/*.jsx',
             ['build']);
  gulp.watch('./scripts/src/**/*.js',
             ['build']);
  gulp.watch('./Content/**/*.css',
             ['minify-css']);
  
});
/* 
gulp.task('lint', function() {
  return gulp.src('./Scripts/src/*.jsx')
  .pipe(jshint())
  .pipe(jshint.reporter('default'))
});*/

gulp.task('build-site-dev', ['build', 'minify-css']);
gulp.task('build-site', ['build-release', 'minify-css-release']);