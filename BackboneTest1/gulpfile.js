const build = require('./config.build.js').build;
const gulp = require('gulp');
const del = require('del');
const concat  = require('gulp-concat');

gulp.task('clean', () => del(build.dest + '*', { force: true }));

gulp.task('copyjs', () =>
	gulp.src([
		build.include.jquery,
		build.include.underscore,
		build.include.backbone,
		build.include.stickit,
		build.include.validation,
		build.include.materialize.js
	])
	.pipe(gulp.dest(`${build.dest}js/`))
);


let modules = build.modules.reduce(
	(arr, module) => arr.concat([
		`${module.dir}/${module.name}.models.js`,
		`${module.dir}/${module.name}.collections.js`,
		`${module.dir}/${module.name}.views.js`
	]), 
	[]
);

modules.unshift(build.config.file);
modules.push(
		build.views.nav + '/**/*.js',
		build.views.routes,
		build.include.materialize.init
);

gulp.task('buildjs', () =>
	gulp.src(modules)
		.pipe(concat(build.output.js))
		.pipe(gulp.dest(`${build.dest}js/`))
);

gulp.task('buildcss', () =>
	gulp.src([
			`${build.src}**/*.css`,
			build.include.materialize.css
		])
		.pipe(concat(build.output.css))
		.pipe(gulp.dest(`${build.dest}css/`))
);


gulp.task('default', gulp.series([
	'clean',
	'copyjs',
	'buildjs',
	'buildcss'
]));
