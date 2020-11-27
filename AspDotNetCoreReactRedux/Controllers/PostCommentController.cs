using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetCoreReactRedux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostCommentController : ControllerBase
    {
        // GET: api/Default
        private readonly IReportService _reportService;

        public PostCommentController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        [Route("GetPostComments")]
        public async Task<IActionResult> GetPostComments()
        {
            return Ok(await _reportService.GetPostComments());
        }
    }
}
