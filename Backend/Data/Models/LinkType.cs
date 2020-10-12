
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BioData.Data
{
    public class LinkType
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(90)]
        public string Name { get; set; }
        public List<Link> Link { get; set; }
    }
}