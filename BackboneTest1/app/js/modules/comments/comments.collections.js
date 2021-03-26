let CommentCollection = Backbone.Collection.extend({

	model: Comment,
	url: config.endpoints.comments,
	initialize: function() {
		var self = this;
		this.fetch({
			success: function(collection, response, options) {
				self.trigger('success-fetch', collection, response, options);
			},
			error: function(collection, response, options) {
				self.trigger('error-fetch', collection, response, options);
			}
		});
	}
});
