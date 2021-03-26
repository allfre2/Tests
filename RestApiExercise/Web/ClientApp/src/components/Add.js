import React, { Component } from 'react';
import { Books } from '../api/api';

export class AddBook extends Component {
  static displayName = AddBook.name;

  constructor(props) {
    super(props);
      this.state = {
          book: {},
          loading: false,
          msg: null
      };
      this.inputChange = this.inputChange.bind(this);
      this.submitBook = this.submitBook.bind(this);
  }

    modifyProperty() {
    }

    inputChange(e) {
        let book = Object.assign({}, (this.state.book));
        if (e.target.type == 'number') {
            book[e.target.id] = parseInt(e.target.value);
        }
        else {
            book[e.target.id] = e.target.value;
        }
        this.setState({ book, loading: false, msg: null });
    }

    async submitBook(e) {
        if (Object.keys(this.state.book).length === 0) {
            this.setState({ book: this.state.book, loading: false, msg: 'Todos los campos estan vacios!' });
            return;
        }

        await this.setState({ book: this.state.book, loading: true, msg: null });
        let b = await Books.Add(this.state.book);

        await this.setState({ book: {}, loading: false, msg: 'El libro ha sido agregado exitosamente!' });
    }

    render() {
        let book = this.state.book;
        let loading = this.state.loading;
        let msg = this.state.msg;
    return (
      <div>
            <h1>Add a new Book to DataBase</h1>
            {msg ? <b>{msg}</b> : null}
            {loading ? <b>Loading...</b> :
                <div>
                    <div class="form-group">
                        <label for="title">Title</label>
                        <input value={book.title} onChange={this.inputChange} type="text" class="form-control" id="title" placeholder="Enter Title" />
                    </div>
                    <div class="form-group">
                        <label for="description">Description</label>
                        <textarea value={book.description} onChange={this.inputChange} class="form-control" id="description"></textarea>
                    </div>
                    <div class="form-group">
                        <label for="pageCount">Page Count</label>
                        <input value={book.pageCount} onChange={this.inputChange} type="number" class="form-control" id="pageCount" />
                    </div>
                    <div class="form-group">
                        <label for="excerpt">Excerpt</label>
                        <textarea value={book.excerpt} onChange={this.inputChange} class="form-control" id="excerpt"></textarea>
                    </div>
                    <div class="form-check">
                        <input value={book.publishDate} onChange={this.inputChange} type="date" class="form-check-input" id="publishDate" />
                        <label class="form-check-label" for="publishDate">Publication Date</label>
                    </div>
                    <br />
                    <hr />
                    <button onClick={this.submitBook} class="btn btn-primary">Add Book</button>
                </div>
            }
      </div>
    );
  }
}
