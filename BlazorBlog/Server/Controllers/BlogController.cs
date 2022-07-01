using BlazorBlog.Server.Data;
using BlazorBlog.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorBlog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly DataContext _context;
        

        public BlogController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<BlogPost>> Get()
        {
            return Ok(_context.BlogPosts);
        }

        [HttpGet("{slug}")]
        public ActionResult<List<BlogPost>> Get(string slug)
        {
            var post = _context.BlogPosts.FirstOrDefault(p => p.Slug.ToLower() == slug.ToLower());
            if (post == null)
            {
                return NotFound("Post does not exist!");
            }
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<BlogPost>> Create(BlogPost request)
        {
            _context.Add(request);
            await _context.SaveChangesAsync();

            return request;
        }
    }
}
