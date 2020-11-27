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
        name: 'Title',
        selector: 'title',
        sortable: true
    },
    {
        name: 'Create By',
        selector: 'createBy',
    },
    {
        name: 'Create Date',
        selector: 'createDate',
    },
    {
        name: '',
        selector: 'count',
    }
];

class Home extends Component {

    state = {
        result:[]
    }

    componentDidMount() {
        //console.log();
        this.props.loadPostComment()
    }

    UNSAFE_componentWillReceiveProps(nextProps) {
        if (nextProps.postComnt) {
            if (nextProps.postComnt.result.length != this.state.result.length) {
                this.setState({
                    result: this.GenerateResult(nextProps.postComnt.result)
                });
            }
        }
    }

    GenerateResult = (result) => {
        var data = [];
        var newRecord = [];
        //let x = result.map(item => [item.postId, item.postTitle, item.postCreateBy, item.postCreateDateTime, item.countComment]);
        //let unique = result.filter((x, i, a) => a.indexOf(x.postId) == i);
        //let unique = [...new Set(x.map(item => item))]; 
        const map = new Map();
        for (const item of result) {
            if (!map.has(item.postId)) {
                map.set(item.postId, true);    // set any value to Map
                data.push({
                    postId: item.postId,
                    postTitle: item.postTitle,
                    postCreateBy: item.postCreateBy,
                    postCreateDateTime: item.postCreateDateTime,
                    countComment: item.countComment,
                });
            }
        }
        for (const item of data) {
            newRecord.push({
                title: item.postTitle,
                createBy: item.postCreateBy,
                createDate: item.postCreateDateTime,
                count: item.countComment + ' Comments'
            });
            let comments = result.filter(c => c.postId === item.postId);
            for (const com of comments) {
                newRecord.push({
                    title: com.comment,
                    createBy: com.commentCreateBy,
                    createDate: com.commentCreateDateTime,
                    count: com.likeVote + ' || ' + com.dislikeVote
                });
            }
        }
        //console.log(data);
        return newRecord;
    }
    
    render() {
        const { result } = this.state
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