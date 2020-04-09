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
        public IActionResult PostComment([FromBody, Bind("Username, Comment, ComDate")] Discussions dis)
        {

            _dis.AddDiscussion(dis);
            var getCom = _dis.GetDiscussion().FirstOrDefault(e => e.CommentId == dis.CommentId);
            if (getCom != null)
                return CreatedAtAction("GetCom", new { Id = getCom.CommentId }, dis);
            else
                return NotFound();
        }

        [HttpDelete("{dis}")]
        public IActionResult DeleteComment(int dis) 
        {
            if (_dis.GetDiscussion().Any(x => x.CommentId == dis))
            //   if (_dis.GetDiscussion().FirstOrDefault(x => x.TagId == tagId))
            {
                _dis.RemoveDiscussion(dis);
                return NoContent();
            }
            // not found (404)
            return NotFound();
        }
    }
}
