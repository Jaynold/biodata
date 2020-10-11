
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BioData.Data
{
    public class LinkType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Link { get; set; }
    }
}