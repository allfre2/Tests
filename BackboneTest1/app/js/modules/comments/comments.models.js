let Comment = Backbone.Model.extend({
	
	urlRoot: config.endpoints.comments,
	
	idAttribute: 'id',
	
	defaults: {
		website: 'N/D',
		dates: {
			created: new Date().toISOString()
		}
	},
	
	validation: {
		name: [{
			required: true,
			msg: 'Por favor introduzca su nombre'
		}, {
			maxLength: 35,
			msg: 'El nombre no puede ser tan largo'
		}, {
			pattern: /[a-z,A-Z, ]+/,
			msg: 'El nombre no puede contener caracteres ilegales'
		}],

		email: [{
			required: true,
			msg: 'Por favor introduzca un email válido'
		}, {
			pattern: 'email',
			msg: 'Por favor introduzca un email'
		}],

		website: {
			pattern: 'url',
			msg: 'El website debe ser una url válida'
		},

		content: [{
			required: true,
			msg: 'Agregar contenido en el comentario es obligatorio'
		}, {
			maxLength: 100,
			msg: 'El contenido del comentario no puede pasar de 100 caracteres'
		}]
	},

	save: function(attrs, options) {
		options = options || {};
		if (!this.isNew()) {
			options = {
				method: 'POST',
				url: this.url() + '/update'
			};
		}
        return Backbone.Model.prototype.save.call(this, attrs, options);
	}
});

_.extend(Backbone.Model.prototype, Backbone.Validation.mixin);
