let CreateView = Backbone.View.extend({
	tagName: 'div',
	className: 'container',
	model: Comment,
	template: _.template( $(config.templates.create).html() ),
	bindings: {
		'#name': 'name',
		'#website': 'website',
		'#email': 'email',
		'#content': 'content'
	},
	events: {
		['click ' + config.saveCommentButton]: 'newComment'
	},
	newComment: function(event) {
		var errors = this.model.validate();
		if (errors) {
			var msg = Object.values(errors).join('<br/>');
			M.toast({ html: msg, classes: 'red lighten-3 white-text bold'});
		} else {
			this.submit();
		}
	},
	submit: function() {
		this.model.save(null, {
			success: function(model, response) {
				M.toast({ html: 'El Comentario ha sido guardado correctamente.', classes: 'rounded'});
			},
			error: function(model, response) {
				M.toast({ html: 'No se ha podido guardar el comentario correctamente.', classes: 'red darken-2' });
			}
		});
	},
	render: function() {
		this.$el.html(this.template());
		this.stickit();
		return this;
	}
});