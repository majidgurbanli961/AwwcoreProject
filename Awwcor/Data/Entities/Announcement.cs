using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Awwcor.Data.Entities
{
    [Table("Ads")]

    public class Announcement
    {
        [Column("id")]

        public int Id { get; set; }
        [Column("name")]

        public string Name { get; set; }
        [Column("description")]


        public string Description { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("public_date")]

        public DateTime PublicDate { get; set; }

        public List<Photo> Photos { get; set; }

    }
}
