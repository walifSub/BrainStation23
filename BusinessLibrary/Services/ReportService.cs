using BusinessLibrary.Models;
using DataAccessLibrary.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Services
{
    public class ReportService :IReportService
    {
        public Task<List<PostCommentModel>> GetPostComments()
        {
            using (DB_CRMContext db = new DB_CRMContext())
            {
                var postComments = (from a in db.TblPosts.AsEnumerable()
                                    join b in db.TblComments on a.PostId equals b.PostId
                             select new PostCommentModel
                             {
                                 PostTitle = a.PostTitle,
                                 PostId = a.PostId,
                                 PostCreateBy = a.CreateBy,
                                 CountComment = CountComment(a.PostId),
                                 PostCreateDateTime = a.CreateDateTime.ToString("dd/MM/yyyy"),
                                 CommentId = b.CommentId,
                                 Comment = b.Comment,
                                 CommentCreateBy = b.CreateBy,
                                 DislikeVote = CountVote(b.CommentId,false),
                                 LikeVote = CountVote(b.CommentId, true),
                                 CommentCreateDateTime = b.CreateDateTime.ToString("dd/MM/yyyy")
                             }).ToList();
                return Task.FromResult(postComments);
            }            
        }

        private int CountComment(int postId)
        {
            using (DB_CRMContext db = new DB_CRMContext())
            {
                var comments = (from a in db.TblComments
                                where a.PostId == postId
                                select a).Count();
                return comments;
            }
        }

        private int CountVote(int commentId,bool status)
        {
            using (DB_CRMContext db = new DB_CRMContext())
            {
                var votes = (from a in db.TblVotes
                                where a.CommentId == commentId && a.Vote == status
                                select a).Count();
                return votes;
            }
        }
    }
}
