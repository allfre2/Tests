let config = {
	endpoints: {
		comments: 'http://simple-api.herokuapp.com/api/v1/comments'
	},

	content: '#content',

	templates: {
		comments: {
			commentView: '#comment-template'
		},
		list: '#list-template',
		edit: '#comment-edit-template',
		create: '#comment-create-template'
	},

	nav_title: '#nav-title',

	searchBar: '#searchComments',

	editCommentButton: '.edit-comment-btn',
	saveCommentButton: '.save-comment-btn',
	
	routes: {
		list: 'list',
		filteredList: 'list/:txt',
		create: 'create',
		edit: 'edit/:id'
	}
};
