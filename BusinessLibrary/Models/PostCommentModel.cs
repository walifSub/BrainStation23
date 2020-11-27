using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary.Models
{
    public class PostCommentModel
    {        
        public string PostTitle { get; set; }
        public int PostId { get; set; }
        public string Comment { get; set; }
        public int CommentId { get; set; }
        public string PostCreateBy { get; set; }
        public string CommentCreateBy { get; set; }
        public int DislikeVote { get; set; }
        public int LikeVote { get; set; }
        public int CountComment { get; set; }
        public string PostCreateDateTime { get; set; }
        public string CommentCreateDateTime { get; set; }
    }
}
