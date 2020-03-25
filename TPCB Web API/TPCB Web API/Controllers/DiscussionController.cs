using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Data.Reposi;
using Repos.Abstractions;
using TPCB_Web_API;
using Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TPCB_Web_API.Controllers
{
    [Route("TPCB/[controller]")]
    [ApiController]
    public class DiscussionController : Controller
    {

        private readonly IDiscussion<Discussions> _dis;

        public DiscussionController(IDiscussion<Discussions> discussion)
        {
            _dis = discussion;
        }

        [HttpGet]
        public IEnumerable<Discussions> GetComments()
        {
            return _dis.GetDiscussion();
        }

        [HttpPost]
        public IActionResult PostComment([FromBody, Bind("CommentId, Username, Comment, ComDate")] Discussions dis)
        {
         
            _dis.AddDiscussion(dis);
            var getCom = _dis.GetDiscussion().FirstOrDefault(e => e.CommentId == dis.CommentId);
            if (getCom != null)
                return CreatedAtAction("GetCom", new { Id = getCom.CommentId }, dis);
            else
                return NotFound();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
