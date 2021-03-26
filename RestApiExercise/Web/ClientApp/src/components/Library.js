import React, { Component } from 'react';
import { Books } from '../api/api';

export class Library extends Component {
  static displayName = Library.name;

  constructor(props) {
    super(props);
    this.state = { books: [], loading: false };
      this.fetchBooks = this.fetchBooks.bind(this);
      this.onInputChange = this.onInputChange.bind(this);
  }

    async fetchBooks() {
        this.setState({ loading: true, books: [] });

        this.setState({
            books: await Books.Get(), loading: false
        });
    }

    async onInputChange(e, i, p) {
        console.log(e,i,p);
        let books = [...this.state.books];
        let book = { ...books[i] };
        book[p] = e.target.value;
        books[i] = book;
        await this.setState({books: books, loading: false});
    }

    renderBooksTable(books) {

        return <table className='table table-striped' aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>T{'\u00ed'}Tulo</th>
                    <th>Descripci{'\u00f3'}n</th>
                    <th>#Paginas</th>
                    <th>Fragmento</th>
                    <th>Fecha Publicaci{'\u00f3'}n</th>
                </tr>
            </thead>
            <tbody>
                {books.map((book,i) => {
                 return   <tr key={book.id + book.title}>
                     <td>
                         <div className="input-group mb-3">
                             <input onChange={e => this.onInputChange(e,i,'title')} value={book.title} type="text" className="form-control" placeholder="Title" aria-label="Title" aria-describedby="basic-addon1" />
                        </div>
                     </td>
                     <td>
                        <div class="input-group">
                            <textarea class="form-control" aria-label="Description">{book.description}</textarea>
                        </div>
                     </td>
                     <td>
                         <div className="input-group mb-3">
                             <input value={book.pageCount} type="number" className="form-control" placeholder="PageCount" aria-label="PageCount" aria-describedby="basic-addon1" />
                         </div>
                     </td>
                     <td>
                         <div class="input-group">
                             <textarea class="form-control" aria-label="Excerpt">{book.excerpt}</textarea>
                         </div>
                     </td>
                     <td>
                         <div className="input-group">
                             <input value={new Date(book.publishDate).toString('yyyy-MM-dd')} type="date" placeholder="PublishDate" aria-label="PublishDate" aria-describedby="basic-addon1" />
                         </div>
                     </td>

                     <td>
                         <button type="button" class="btn btn-info" onClick={e => {
                             console.log(e, e.target.value);

                         }}>Save</button>
                         <button type="button" class="btn btn-danger">Delete</button>
                     </td>

                    </tr>
                }
                )}
            </tbody>
        </table>;
    }

    render() {

        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderBooksTable(this.state.books);

    return (
      <div>
            <h1><i>Available</i> <b>books</b> :)</h1>
            <div className="row justify-content-center">
                <button className="btn btn-primary text-center" onClick={this.fetchBooks}>Look!</button>
            </div>
            <br />
            {contents}
      </div>
    );
  }
}
