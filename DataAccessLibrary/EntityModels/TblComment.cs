using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLibrary.EntityModels
{
    public partial class TblComment
    {
        public TblComment()
        {
            TblVotes = new HashSet<TblVote>();
        }

        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string Comment { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDateTime { get; set; }

        public virtual TblPost Post { get; set; }
        public virtual ICollection<TblVote> TblVotes { get; set; }
    }
}
