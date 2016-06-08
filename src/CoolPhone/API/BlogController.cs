using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoolPhone.Data;
using Microsoft.EntityFrameworkCore;
using CoolPhone.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CoolPhone.API
{
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        private ApplicationDbContext _db;
        public BlogController(ApplicationDbContext db)
        {
            this._db = db;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var blogs = _db.Blogs.ToList();
            return Ok(blogs);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var blog = _db.Blogs.Where(b => b.Id == id).Include(b => b.Comments).FirstOrDefault();
            return Ok(blog);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Blog blog)
        {
            if(blog.Id == 0)
            {
                _db.Blogs.Add(blog);
                _db.SaveChanges();
            }
            else
            {
                var blogToEdit = _db.Blogs.FirstOrDefault(b => b.Id == blog.Id);
                blogToEdit.Title = blog.Title;
                blogToEdit.Message = blog.Message;
                _db.SaveChanges();
            }

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
