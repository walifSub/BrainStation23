using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLibrary.EntityModels
{
    public partial class TblPost
    {
        public TblPost()
        {
            TblComments = new HashSet<TblComment>();
        }

        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDateTime { get; set; }

        public virtual ICollection<TblComment> TblComments { get; set; }
    }
}
