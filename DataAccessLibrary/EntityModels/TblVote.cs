using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLibrary.EntityModels
{
    public partial class TblVote
    {
        public int VoteId { get; set; }
        public int CommentId { get; set; }
        public bool Vote { get; set; }
        public DateTime CreateDatetime { get; set; }

        public virtual TblComment Comment { get; set; }
    }
}
