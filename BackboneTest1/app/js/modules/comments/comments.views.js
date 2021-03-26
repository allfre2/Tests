let CommentView = Backbone.View.extend({

	tagName: 'tr',
	
	template: _.template( $(config.templates.comments.commentView).html() ),

	render: function() {
		this.$el.html(
			this.template(this.model.toJSON())
		);

		return this;
	}
});
