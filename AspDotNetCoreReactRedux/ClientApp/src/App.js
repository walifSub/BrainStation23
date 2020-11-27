import React, { Component } from 'react';
import { Route, BrowserRouter, Switch } from 'react-router-dom';
import PublicRoutes from './PublicRoutes';
class App extends Component {
    render() {
        return (
            <BrowserRouter>
                <Switch>
                    <Route path='/' component={PublicRoutes} />                    
                </Switch>
            </BrowserRouter>  
        )
    }
}
export default App

