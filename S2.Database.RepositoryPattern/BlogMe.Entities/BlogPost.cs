using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlogMe.Entities
{
    [Table("BlogPost")]
    public class BlogPost : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string PostContent { get; set; }

    }
}
