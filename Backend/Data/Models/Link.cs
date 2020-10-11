
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BioData.Data
{
    public class Link
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Url { get; set; }
        [Required]
        [MaxLength(20)]
        public string Note { get; set; }
        public List<LinkType> LinkTypes { get; set; }
    }
}