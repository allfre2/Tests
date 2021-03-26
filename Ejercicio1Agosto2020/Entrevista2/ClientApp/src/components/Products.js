import React, { Component } from 'react';
import { ProductsEndpoint } from '../api/Products';
import { Product } from './Product';

export class Products extends Component {
  static displayName = Products.name;

  constructor(props) {
    super(props);
      this.state = { products: [], loading: false };
      this.load = this.load.bind(this);
      this.load();
  }

    async load() {
        this.setState({ products: [], loading: true });
        console.log(this.state);
        this.setState({ products: await ProductsEndpoint.GetAll(), loading: false });
        console.log(this.state);
    }

    renderProducts(products) {
        console.log(products);
        return products && (<div> {
            products.map(product => {
                console.log(product);
                return <Product product={product} />
            })

        } </div>);
    }

    render() {
        let content = this.state.loading ? <b>loading ... </b> : this.renderProducts(this.state.products);
    return (
      <div>
            <h1>Products</h1>
            {content}
      </div>
    );
  }
}
