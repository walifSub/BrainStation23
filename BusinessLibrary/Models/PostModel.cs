using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary.Models
{
    public class PostModel
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
