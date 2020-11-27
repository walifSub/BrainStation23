import React, { Component, Fragment } from 'react';
import { Route, Switch } from 'react-router-dom';
import { FrontendLayout } from './layout/FrontendLayout';
import Home from "./components/Home";

class PublicRoutes extends Component {
    render() {        
        return (
            <React.Fragment>                
                <FrontendLayout>
                    <Switch>
                        <Route exact path='/' component={Home} />
                    </Switch>
                </FrontendLayout>
            </React.Fragment>
        );
    }
}
export default PublicRoutes;