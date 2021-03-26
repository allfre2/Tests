import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { AddBook } from './components/Add';
import { Library } from './components/Library';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/library' component={Library} />
        <Route path='/add' component={AddBook} />
      </Layout>
    );
  }
}
