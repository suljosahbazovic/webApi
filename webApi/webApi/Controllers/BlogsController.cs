using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.Web.Http.Description;
using webApi.Data;
using webApi.Models;

namespace webApi.Controllers
{
    public class BlogsController : ApiController
    {
        private MyContext ctx = new MyContext();
        
        //Filter blog posts by tag Name
        [HttpGet]
        [Route("api/Blogs/SearchBlogs/{type=}")]
        //Example
        //===========================================================
        //http://localhost:63938/api/Blogs/SearchBlogs?type=Android
        //===========================================================
        public IHttpActionResult SearchBlogs(string type)
        {
            var query = ctx.Blogs.Where(b => b.Tag.Name.ToString().StartsWith(type));
            return Ok(query);
        }

        [HttpGet]
        public IHttpActionResult GetBlog()
        {
            var query = ctx.Blogs.Include("TagList");
            return Ok(query);
        }

        [HttpGet]
        public IHttpActionResult GetBlog(int id)
        {
            var blog = ctx.Blogs.Include("TagList").FirstOrDefault(x => x.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        // POST: api/Blogs
        [ResponseType(typeof(Blog))]
        public IHttpActionResult Post([FromBody]Blog value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ctx.Blogs.Add(value);
            ctx.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = value.Id }, value);
        }
        
        // PUT: api/Blogs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Put(int id, Blog b)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != b.Id)
            {
                return BadRequest();
            }

            ctx.Entry(b).State = EntityState.Modified;

            try
            {
                //var entity = ctx.Blogs.FirstOrDefault(x => x.Id == id);
                //if (entity == null)
                //{
                //    return BadRequest("No record found againts this id");
                //}
                await ctx.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok("Record updated successfully");
            //return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Blogs/5
        [ResponseType(typeof(Blog))]
        public async Task<IHttpActionResult> Delete(int id)
        {
            Blog b = await ctx.Blogs.FindAsync(id);
            if (b == null)
            {
                return NotFound();
            }
            ctx.Blogs.Remove(b);
            await ctx.SaveChangesAsync();
            return Ok(b);            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BlogExists(int id)
        {
            return ctx.Blogs.Count(e => e.Id == id) > 0;
        }

        //Filter blog posts by tag Name
        //[HttpGet]
        //[Route("api/Blogs/SearchBlogs/{type=}")]
        ////Example
        ////===========================================================
        ////http://localhost:63938/api/Blogs/SearchBlogs?type=Android
        ////===========================================================
        //public IHttpActionResult SearchBlogs(string type)
        //{
        //    var query = ctx.Blogs.Where(b => b.Tag.Name.ToString().StartsWith(type));
        //    return Ok(query);
        //}

        //Sorting by CreatedAt Date
        //[HttpGet]
        //public IHttpActionResult LoadBlog(string sort)
        //{
        //    IQueryable<Blog> blogs;
        //    switch (sort)
        //    {
        //        case "desc":
        //            blogs = ctx.Blogs.OrderByDescending(q => q.CreatedAt);
        //            break;
        //        case "asc":
        //            blogs = ctx.Blogs.OrderBy(q => q.CreatedAt);
        //            break;
        //        default:
        //            blogs = ctx.Blogs;
        //            break;
        //    }
        //    return Ok(blogs);
        //}
    }
}
