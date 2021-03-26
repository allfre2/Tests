import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Hello World!!</h1>
        <p>Bienvenidos a mi solucion al ejercicio de API's REST</p>
        <ul>
                <li>Utilice <a href='https://fakerestapi.azurewebsites.net/swagger/ui/index#/Books' target="_blank">esta</a> API </li>
          <li><a href='https://facebook.github.io/react/'>React</a> for client-side code</li>
        </ul>
      </div>
    );
  }
}
