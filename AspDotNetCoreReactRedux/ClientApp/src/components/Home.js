import React, { Component } from 'react';
import { connect } from 'react-redux';
import DataTable from 'react-data-table-component';
import { loadPostComment } from '../store/actions/reportAction';

const columns = [
    {
        name: 'Sl. No.',
        cell: (row, index) => <div>{index + 1}</div>,
        width: "70px"
    }, {
        name: 'Post',
        selector: 'postTitle',
        sortable: true
    },
    {
        name: 'postCreateBy',
        selector: 'postCreateBy',
    },
    {
        name: 'postCreateDateTime',
        selector: 'postCreateDateTime',
    },
    {
        name: 'comment',
        selector: 'comment',
    },
    {
        name: 'commentCreateBy',
        selector: 'commentCreateBy',
    },
    {
        name: 'commentCreateDateTime',
        selector: 'commentCreateDateTime',
    },
    {
        name: 'likeVote',
        selector: 'likeVote',
    },
    {
        name: 'dislikeVote',
        selector: 'dislikeVote',
    }
];

class Home extends Component {

    componentDidMount() {
        //console.log();
        this.props.loadPostComment()
    }
    
    render() {
        const { result } = this.props.postComnt
        //console.log(this.props);
        return (
            <div>
                {
                    result &&
                    <DataTable                        
                        columns={columns}
                        data={result}
                        pagination
                    />
                }
            </div>
        )
    }
}
const mapStateToProps = state => ({
    postComnt: state.postComnt
});
export default connect(mapStateToProps, { loadPostComment })(Home)