using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoolPhone.Models;
using CoolPhone.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CoolPhone.API
{
    [Route("api/[controller]")]
    public class BlogCommentController : Controller
    {
        static ApplicationDbContext _db;
        public BlogCommentController(ApplicationDbContext db)
        {
            _db = db;
        }

        // POST api/values
        [HttpPost("{id}")]
        public IActionResult Post(int id, [FromBody]Comment comment)
        {
            var blog = _db.Blogs.Where(b => b.Id == id).Include(b => b.Comments).FirstOrDefault();
            blog.Comments.Add(comment);
            _db.SaveChanges();

            return Ok();
        }

    }
}
