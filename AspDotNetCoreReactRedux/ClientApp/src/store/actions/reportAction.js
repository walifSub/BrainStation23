import Axios from 'axios';
import * as Types from './types';

export const loadPostComment = () => dispatch => {
    Axios.get('api/PostComment/GetPostComments')
        .then(response => {
            dispatch({
                type: Types.LOAD_POSTCOMMENT,
                payload: {
                    result: response.data
                }
            })
        })
        .catch(error => {
            console.log(error);
        })
}
