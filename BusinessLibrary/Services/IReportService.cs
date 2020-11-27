using BusinessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Services
{
    public interface IReportService
    {
        Task<List<PostCommentModel>> GetPostComments();
    }
}
