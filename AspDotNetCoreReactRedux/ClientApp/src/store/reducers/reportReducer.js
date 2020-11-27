import * as Types from '../actions/types';

const reportReducer = (state = { result: [] }, action) => {
    switch (action.type) {
        case Types.LOAD_POSTCOMMENT: {
            return {
                result: action.payload.result
            }
        }
        default: return state;
    }
}
export default reportReducer