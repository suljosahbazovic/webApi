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
    public class TagsController : ApiController
    {
        private MyContext ctx = new MyContext();

        // GET: api/Tags
        public IEnumerable<Tag> Get()
        {
            return ctx.Tags.ToList();
        }

        //Search
        [HttpGet]
        [Route("api/Tags/SearchTag/{type=}")]
        public IHttpActionResult SearchTag(string type)
        {
            var tags = ctx.Tags.Where(q => q.Name.StartsWith(type));
            return Ok(tags);
        }

        // GET: api/Quotes/5
        [HttpGet]
        public IHttpActionResult LoadTag(int id)
        {
            var tag = ctx.Tags.Find(id);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(tag);
        }        

        ////// GET: api/Tags/5
        //public Tag Get(int id)
        //{
        //    var tag = ctx.Tags.Find(id);
        //    return tag;
        //}

        // POST: api/Tags
        public IHttpActionResult Post([FromBody]Tag tag)       
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ctx.Tags.Add(tag);
            ctx.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }

        // PUT: api/Tags/5
        public IHttpActionResult Put(int id, [FromBody]Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = ctx.Tags.FirstOrDefault(q => q.TagId == id);
            if (entity == null)
            {
                return BadRequest("No record found id");
            }
            entity.Name = tag.Name;
            ctx.SaveChanges();
            return Ok("Record updated successfully");
        }

        // DELETE: api/Tags/5
        public IHttpActionResult Delete(int id)
        {
            var tag = ctx.Tags.Find(id);
            if (tag == null)
            {
                return BadRequest("No record found id");
            }
            ctx.Tags.Remove(tag);
            ctx.SaveChanges();
            return Ok("Tag deleted");
        }        
    }
}
