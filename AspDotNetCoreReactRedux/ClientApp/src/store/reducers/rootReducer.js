import { combineReducers } from 'redux';
import ReportReducer from './reportReducer';

const rootReducers = combineReducers({
    postComnt: ReportReducer
})
export default rootReducers