
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BioData.Data
{
    public class Link
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(90)]
        public string Url { get; set; }
        [MaxLength(90)]
        public string Note { get; set; }
        public List<LinkType> LinkTypes { get; set; }
        public string BiodataId { get; set; }
        public Biodata Biodata { get; set; }
    }
}