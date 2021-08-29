import React from 'react';
import { BrowserRouter, Route, Switch, Redirect } from 'react-router-dom'
import RoutesModel from './models/Menu'
import './App.css';
import Master from './components/Master/Master';
import Menu from './components/Menu/Menu';
import Register from './components/Register/Register';
import CreditCard from './models/CreaditCard'


const onSubmitClicked = (creditCard: CreditCard): Promise<void> => {
  console.log('Submitting creditCard', creditCard) 
  return Promise.resolve()
}

const routes: RoutesModel[] = [
  {
    showMenus: true,
    path: '/Menu',
    title: 'Menu',
  },
  {
    showMenus: false,
    path: '/Register',
    title: 'Register Credit Card ',
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
              <Register onSubmitClicked={onSubmitClicked}/>
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
