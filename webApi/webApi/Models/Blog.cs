using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webApi.Models
{
    public class Blog
    {
        public Blog()
        {
            this.TagList = new HashSet<Tag>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Slug { get; set; }

        [Required]
        [StringLength(1000)]
        public string Title { get; set; }

        public string Description { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation property
        public Tag Tag { get; set; }

        public virtual ICollection<Tag> TagList { get; set; }
    }
}