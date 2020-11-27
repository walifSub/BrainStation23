import { createStore, compose, applyMiddleware } from 'redux';
import rootReducers from './reducers/rootReducer';
import thunk from 'redux-thunk';
const middleware = [thunk];
const composeEnhancer = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

const store = createStore(rootReducers,
    composeEnhancer(applyMiddleware(...middleware)),
)

export default store