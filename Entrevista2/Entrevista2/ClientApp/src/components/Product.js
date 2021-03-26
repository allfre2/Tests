import React, { Component } from 'react';

export class Product extends Component {
    static displayName = Product.name;

    constructor(props) {
        super(props);
        this.state = { product: props.product };
    }

    render() {
        return <div className="card" key={this.state.product.id}>
            <div className ="card-body">
                <h5 className="card-title">{this.state.product.productCode}</h5>
                <p className="card-text">{this.state.product.description}</p>
                <a href="#" className ="card-link">Card link</a>
                <a href="#" className ="card-link">Another link</a>
            </div>
        </div>;
    }
}
