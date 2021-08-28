import React from 'react';
import logo from './logo.svg';
import { BrowserRouter, Route, Switch, Redirect } from 'react-router-dom'
import RoutesModel from './models/Menu'
import './App.css';
import Master from './components/Master/Master';
import Menu from './components/Menu/Menu';


const routes: RoutesModel[] = [
  {
    showMenus: true,
    path: '/Menu',
    title: 'Menu',
  },
  {
    showMenus: false,
    path: '/RegisterForm',
    title: 'Register card form',
  },
]

function App() {
  return (
    <BrowserRouter>
      <div>
        <Master routes={routes}>
          <Switch>
            <Route exact path="/">
              <Redirect to="/Register" />
            </Route>
            <Route path="/Register">
              {/* <Register onSubmitClicked={onSubmitClicked}/> */}
            </Route>
            <Route path="/Menu">
              <Menu />
            </Route>
          </Switch>
        </Master>
      </div>
    </BrowserRouter>

  );
}

export default App;
