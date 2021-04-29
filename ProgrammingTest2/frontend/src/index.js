import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import M from 'materialize-css';

document.addEventListener('DOMContentLoaded', function() {
  M.AutoInit();
    var elems = document.querySelectorAll('.collapsible');
    M.Collapsible.init(elems, {});
});

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById('root')
);
