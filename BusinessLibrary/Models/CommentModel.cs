using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string Comment { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDateTime { get; set; }
    }
}
